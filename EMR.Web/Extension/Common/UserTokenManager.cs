using EMR.Core.Caching;
using EMR.Web.Extension.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMR.Web.Extension.Common
{
    public class UserTokenManager
    {
        private static ICacheManager _tokenRep;
        private const string TOKENNAME = "PASSPORT.TOKEN";

        static UserTokenManager()
        {
            _tokenRep = RedisCacheManager.CreateInstance();
        }
        /// <summary>
        /// 初始化缓存
        /// </summary>
        private static List<UserToken> InitCache()
        {

            var tokens = _tokenRep.Get<List<UserToken>>("tokenlist");
            // cache 的过期时间， 令牌过期时间 *2
            if (tokens == null)
                return new List<UserToken>();
            //HttpRuntime.Cache.Insert(TOKENNAME, tokens, null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromDays(7 * 2));
            return tokens;
        }


        public static string GetUId(string token)
        {
            var tokens = InitCache();
            var result = "";
            if (tokens.Count > 0)
            {
                var id = tokens.Where(c => c.Token == token).Select(c => c.UserId).FirstOrDefault();
                if (id != null)
                    result = id;
            }
            return result;
        }


        public static string GetPermission(string token)
        {
            var tokens = InitCache();
            if (tokens.Count == 0)
                return "NoAuthorize";
            else
                return tokens.Where(c => c.Token == token).Select(c => c.Permission).FirstOrDefault();
        }

        public static string GetUserOrganId(string token)
        {
            var tokens = InitCache();
            if (tokens.Count == 0)
                return "";
            else
                return tokens.Where(c => c.Token == token).Select(c => c.ORGANID).FirstOrDefault();
        }

        /// <summary>
        /// 判断令牌是否存在
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static bool IsExistToken(string token)
        {
            var tokens = InitCache();
            if (tokens.Count == 0)
            {
                return false;
            }

            var t = tokens.Where(c => c.Token == token).FirstOrDefault();
            if (t == null)
                return false;
            else if (t.Timeout < DateTime.Now)
            {
                RemoveToken(t);
                return false;
            }
            else
            {
                // 小于8小时 更新过期时间
                if ((t.Timeout - DateTime.Now).TotalMinutes < 600)
                {
                    t.Timeout = DateTime.Now.AddHours(1);
                    UpdateToken(t);
                }
                return true;
            }
        }

        public static UserToken GetUserToken(string token)
        {
            var tokens = InitCache();
            if (tokens.Count == 0) return new UserToken();
            else
            {
                var t = tokens.Where(c => c.Token == token).FirstOrDefault();
                if (t == null)
                    return new UserToken();
                else
                    return t;
            }
        }

        /// <summary>
        /// 添加令牌， 没有则添加，有则更新
        /// </summary>
        /// <param name="token"></param>
        public static void AddToken(UserToken token)
        {
            var tokens = InitCache();
            // 不存在  怎增加
            if (!IsExistToken(token.Token))
            {
                tokens.Add(token);
                // 插入数据库
                _tokenRep.Set("tokenlist", token, 600);
            }
            else  // 有则更新
            {
                UpdateToken(token);
            }
        }

        public static bool UpdateToken(UserToken token)
        {
            var tokens = InitCache();
            if (tokens.Count == 0)
            {
                return false;
            }
            var t = tokens.Where(c => c.Token == token.Token).FirstOrDefault();
            if (t == null)
                return false;
            t.Timeout = token.Timeout;
            // 更新数据库
            //var tt = _tokenRep.FindByToken(token.Token);
            var tt = _tokenRep.Get<List<UserToken>>("tokenlist").Find(f => f.Token == token.Token);
            if (tt != null)
            {
                tt = token;
                //_tokenRep.Update(tt);
            }
            return true;

        }
        /// <summary>
        /// 移除指定令牌
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static void RemoveToken(UserToken token)
        {
            var tokens = InitCache();
            if (tokens.Count == 0) return;
            tokens.Remove(token);
            //_tokenRep.Remove(token);
        }

        public static void RemoveToken(string token)
        {
            var tokens = InitCache();
            if (tokens.Count == 0) return;

            var ts = tokens.Where(c => c.Token == token).ToList();
            foreach (var t in ts)
            {
                tokens.Remove(t);
                //var tt = _tokenRep.FindByToken(t.Token);
                //if (tt != null)
                //    _tokenRep.Remove(tt);
            }
        }
    }
}