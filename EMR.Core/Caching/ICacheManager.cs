using System;

namespace EMR.Core.Caching
{
    /// <summary>
    /// Cache manager interface
    /// </summary>
    public interface ICacheManager : IDisposable
    {
        /// <summary>
        /// 获取与指定键关联的值
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="key">键名</param>
        /// <returns>与指定键关联的值.</returns>
        T Get<T>(string key);

        /// <summary>
        /// 将指定的键和对象添加到缓存中
        /// </summary>
        /// <param name="key">键名</param>
        /// <param name="data">值对象</param>
        /// <param name="cacheTime_min">缓存时间（分钟）</param>
        void Set<T>(string key, T data, int cacheTime_min);

        /// <summary>
        /// 获取一个值，该值指示是否缓存与指定键关联的值
        /// </summary>
        /// <param name="key">键名</param>
        /// <returns></returns>
        bool IsSet(string key);

        /// <summary>
        /// 根据键名更新缓存内的键值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">键名</param>
        /// <param name="data">值对象</param>
        /// <param name="cacheTime_min">缓存时间（分钟）</param>
        void Update<T>(string key, T data, int cacheTime_min);

        /// <summary>
        /// 从缓存中删除具有指定键的值
        /// </summary>
        /// <param name="key">键名</param>
        void Remove(string key);

        /// <summary>
        /// 按匹配的公式删除项目
        /// </summary>
        /// <param name="pattern">匹配的公式</param>
        void RemoveByPattern(string pattern, string key="");

        /// <summary>
        /// 清除所有缓存数据
        /// </summary>
        void Clear();
    }
}
