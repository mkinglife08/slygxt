using System;
using System.Linq;
using System.Runtime.Caching;

namespace EMR.Core.Caching
{
    /// <summary>
    /// 用于在HTTP请求之间进行缓存的管理器
    /// </summary>
    public partial class MemoryCacheManager : ICacheManager
    {
        /// <summary>
        /// Cache object
        /// </summary>
        protected ObjectCache Cache
        {
            get
            {
                return MemoryCache.Default;
            }
        }

        /// <summary>
        ///  获取与指定键关联的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">键名</param>
        /// <returns>与指定键关联的值</returns>
        public virtual T Get<T>(string key)
        {
            return (T)Cache[key];
        }

        /// <summary>
        /// 将指定的键和对象添加到缓存中
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">键名</param>
        /// <param name="data">值对象</param>
        /// <param name="cacheTime_min">缓存时间（分钟）</param>
        public virtual void Set<T>(string key, T data, int cacheTime)
        {
            if (data == null)
                return;

            var policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(cacheTime);
            policy.Priority = CacheItemPriority.NotRemovable;
            Cache.Add(new CacheItem(key, data), policy);
            //if (Command != null)
            //{
            //    System.Data.SqlClient.SqlDependency mSqlDependency = new System.Data.SqlClient.SqlDependency(Command);
            //    policy.ChangeMonitors.Add(new SqlChangeMonitor(mSqlDependency));
            //}
            
        }

        /// <summary>
        /// 获取一个值，该值指示是否缓存与指定键关联的值
        /// </summary>
        /// <param name="key">键名</param>
        /// <returns></returns>
        public virtual bool IsSet(string key)
        {
            return (Cache.Contains(key));
        }

        /// <summary>
        /// 从缓存中删除具有指定键的值
        /// </summary>
        /// <param name="key">键名</param>
        public virtual void Remove(string key)
        {
            Cache.Remove(key);
        }

        /// <summary>
        /// 按匹配的公式删除项目
        /// </summary>
        /// <param name="pattern">匹配的公式</param>
        /// <param name="key">键名</param>
        public virtual void RemoveByPattern(string pattern,string key)
        {
            this.RemoveByPattern(pattern, Cache.Select(p => p.Key));
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
            foreach (var item in Cache)
                Remove(item.Key);
        }

        /// <summary>
        /// 释放回收内存
        /// </summary>
        public virtual void Dispose()
        {
        }
    }
}