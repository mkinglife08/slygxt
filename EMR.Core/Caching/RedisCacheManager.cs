using System;
using System.Text;
using Newtonsoft.Json;
using EMR.Core.Configuration;
using ServiceStack.Redis;
using System.Text.RegularExpressions;


namespace EMR.Core.Caching
{
    /// <summary>
    /// 用于在Redis存储中缓存的管理器，适用于任何服务器及环境。
    /// </summary>
    public partial class RedisCacheManager : ICacheManager
    {
        protected static IRedisClient Redis { get; private set; }
        private static string RedisPath = System.Configuration.ConfigurationSettings.AppSettings["RedisPath"];
        private bool _disposed = false;
        private static PooledRedisClientManager _prcm;
        private static ICacheManager _perRequestCacheManager
        {
            get
            {
                //判断是否存在redis服务，未检测到redis则使用MemoryCache
                ICacheManager _temp = new RedisCacheManager();
                try { Redis.ContainsKey("aa"); }
                catch (Exception err) { _temp = new MemoryCacheManager(); }
                return _temp;
            }
        }

        /// <summary>
        /// 创建缓存实例
        /// </summary>
        /// <returns></returns>
        public static ICacheManager CreateInstance()
        {
            return _perRequestCacheManager;
        }

        public RedisCacheManager() {
            Redis = GetClient();
        }

        public static IRedisClient GetClient()
        {
            if (_prcm == null)
            {
                _prcm = CreateManager(new string[] { RedisPath }, new string[] { RedisPath });
            }
            return _prcm.GetClient();
        }

        private static PooledRedisClientManager CreateManager(string[] readWriteHosts, string[] readOnlyHosts)
        {
            //WriteServerList：可写的Redis链接地址。
            //ReadServerList：可读的Redis链接地址。
            //MaxWritePoolSize：最大写链接数。
            //MaxReadPoolSize：最大读链接数。
            //AutoStart：自动重启。
            //LocalCacheTime：本地缓存到期时间，单位:秒。
            //RecordeLog：是否记录日志,该设置仅用于排查redis运行时出现的问题,如redis工作正常,请关闭该项。
            //RedisConfigInfo类是记录redis连接信息，此信息和配置文件中的RedisConfig相呼应

            // 支持读写分离，均衡负载 
            return new PooledRedisClientManager(readWriteHosts, readOnlyHosts, new RedisClientManagerConfig
            {
                MaxWritePoolSize = 5, // “写”链接池链接数 
                MaxReadPoolSize = 5, // “读”链接池链接数 
                AutoStart = true,
            });
        }

        /// <summary>
        ///  获取与指定键关联的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">键名</param>
        /// <returns>与指定键关联的值</returns>
        public virtual T Get<T>(string key)
        {
            try
            {
                return Redis.Get<T>(key);
            }
            catch(Exception err) { throw new Exception(err.Message); }
        }

        /// <summary>
        /// 获取一个值，该值指示是否缓存与指定键关联的值
        /// </summary>
        /// <param name="key">键名</param>
        /// <returns></returns>
        public virtual bool IsSet(string key)
        {
            return Redis.ContainsKey(key);
        }

        /// <summary>
        /// 从缓存中删除具有指定键的值
        /// </summary>
        /// <param name="key">键名</param>
        public virtual void Remove(string key)
        {
            if (IsSet(key))
                Redis.Remove(key);
        }

        /// <summary>
        /// 按匹配的公式删除项目
        /// </summary>
        /// <param name="pattern">匹配的公式</param>
        /// <param name="key">键名</param>
        public virtual void RemoveByPattern(string pattern, string key)
        {
            if (key != "")
            {
                var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
                Redis.GetAllItemsFromSet(key).RemoveWhere(p => regex.IsMatch(p.ToString()));
            }
        }

        /// <summary>
        /// 将指定的键和对象添加到缓存中
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">键名</param>
        /// <param name="data">值对象</param>
        /// <param name="cacheTime_min">缓存时间（分钟）</param>
        public virtual void Set<T>(string key, T data, int cacheTime_min)
        {
            if(!IsSet(key))
                Redis.Set(key, data,DateTime.Now.AddMinutes(cacheTime_min));
        }

        /// <summary>
        /// 根据键名更新缓存内的键值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">键名</param>
        /// <param name="data">值对象</param>
        /// <param name="cacheTime_min">缓存时间（分钟）</param>
        public virtual void Update<T>(string key, T data, int cacheTime_min)
        {
            if (IsSet(key))
                Remove("key");
            Set(key, data, cacheTime_min);
        }

        /// <summary>
        /// 清除所有缓存数据
        /// </summary>
        public virtual void Clear()
        {
            foreach (string key in Redis.GetAllKeys())
            {
                Remove(key);
            }
        }

        /// <summary>
        /// 释放回收内存
        /// </summary>
        public virtual void Dispose()
        {
            if (!this._disposed)
            {
                Redis.Dispose();
                Redis = null;
                GC.SuppressFinalize(this);
            }
            this._disposed = true;
        }
    }
}
