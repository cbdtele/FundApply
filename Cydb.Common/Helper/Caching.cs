using System;
using System.Collections;
using System.Web;

namespace Cydb.Common.Helper
{
    /// <summary>
    /// Caching 的摘要说明
    /// </summary>
    public class Caching
    {
        /// <summary>
        /// 弹性缓存时间 12小时
        /// </summary>
        private static readonly DateTime CachingTime = DateTime.Now.AddHours(1);
        
        /// <summary>
        /// 检查CacheKey是否已经存在 true：已存在
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <returns></returns>
        public static bool IsExist(string cacheKey)
        {
            return GetCache(cacheKey) != null;
        }

        /// <summary>
        /// 获取当前应用程序指定CacheKey的Cache值
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <returns></returns>y
        public static object GetCache(string cacheKey)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            return objCache[cacheKey];
        }

        /// <summary>
        /// 设置当前应用程序指定CacheKey的Cache值
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <param name="objObject"></param>
        public static void SetCache(string cacheKey, object objObject)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            objCache.Insert(cacheKey, objObject, null, CachingTime, TimeSpan.Zero);
        }

        /// <summary>
        /// 设置当前应用程序指定CacheKey的Cache值
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <param name="objObject"></param>
        /// <param name="absoluteExpiration"></param>
        /// <param name="slidingExpiration"></param>
        public static void SetCache(string cacheKey, object objObject, DateTime absoluteExpiration, TimeSpan slidingExpiration)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            objCache.Insert(cacheKey, objObject, null, absoluteExpiration, slidingExpiration);
        }

        /// <summary>
        /// 清除单一键缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="CacheKey"></param>
        public static void RemoveKeyCache(string CacheKey)
        {
            try
            {
                System.Web.Caching.Cache objCache = HttpRuntime.Cache;
                objCache.Remove(CacheKey);
            }
            catch { }
        }

        /// <summary>
        /// 清除所有缓存
        /// </summary>
        public static void RemoveAllCache()
        {
            System.Web.Caching.Cache cache = HttpRuntime.Cache;
            IDictionaryEnumerator cacheEnum = cache.GetEnumerator();
            if (cache.Count > 0)
            {
                ArrayList al = new ArrayList();
                while (cacheEnum.MoveNext())
                {
                    al.Add(cacheEnum.Key);
                }
                foreach (string key in al)
                {
                    cache.Remove(key);
                }
            }
        }

        /// <summary>
        /// 以列表形式返回已存在的所有缓存 
        /// </summary>
        /// <returns></returns> 
        public static ArrayList ShowAllCache()
        {
            ArrayList al = new ArrayList();
            System.Web.Caching.Cache cache = HttpRuntime.Cache;
            if (cache.Count > 0)
            {
                IDictionaryEnumerator cacheEnum = cache.GetEnumerator();
                while (cacheEnum.MoveNext())
                {
                    al.Add(cacheEnum.Key);
                }
            }
            return al;
        }
    }
}