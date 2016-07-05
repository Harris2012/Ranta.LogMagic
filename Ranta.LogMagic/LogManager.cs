using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranta.LogMagic
{
    public static class LogManager
    {
        /// <summary>
        /// 获取默认Log记录器
        /// </summary>
        /// <returns></returns>
        public static ILog GetLogger()
        {
            return new Log();
        }

        /// <summary>
        /// 获取Log记录器，为该记录器指定源Class
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static ILog GetLogger(string source)
        {
            return new Log(source);
        }

        /// <summary>
        /// 获取Log记录器，为该记录器指定源Class
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static ILog GetLogger<T>()
        {
            return new Log(typeof(T).FullName);
        }

        /// <summary>
        /// 获取Log记录器，为该记录器指定源Class
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static ILog GetLogger(Type type)
        {
            return new Log(type.FullName);
        }
    }
}
