using System.Runtime.Remoting.Contexts;
using Newtonsoft.Json;

namespace Cydb.Common.Json {
    public class JsonHelper {
        /// <summary>
        /// 对象转换Json
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="isNullValueHandling"></param>
        /// <returns></returns>
        public static string ToJson(object obj, bool isNullValueHandling = false) {
            JsonSerializerSettings jsetting = new JsonSerializerSettings();
            if (isNullValueHandling) {
                jsetting.NullValueHandling = NullValueHandling.Ignore;
            }
            return JsonConvert.SerializeObject(obj, Formatting.Indented, jsetting);
        }

        /// <summary>
        /// json转换对象
        /// </summary>
        /// <typeparam name="T">目标对象</typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T ToObject<T>(string json) {
            return JsonConvert.DeserializeObject<T>(json);
        }

        /// <summary>
        /// 强制输出Json格式的数据
        /// </summary>
        /// <param name="obj"></param>
        public static void ToPageReturnJson(object obj) {
            System.Web.HttpContext.Current.Response.ContentType = "application/json; charset=utf-8";
            System.Web.HttpContext.Current.Response.Write(ToJson(obj));
        }

        /// <summary>
        /// 强制输出Json格式的数据（直接输出）
        /// </summary>
        /// <param name="obj"></param>
        public static void ToPageReturnJson(string obj) {
            System.Web.HttpContext.Current.Response.ContentType = "application/json; charset=utf-8";
            System.Web.HttpContext.Current.Response.Write(obj);
        }

        /// <summary>
        /// 输出EasyUi-DataTable的数据源格式
        /// </summary>
        /// <param name="total">总行数</param>
        /// <param name="rows">内容</param>
        public static void ToDataTableReturnJson(int total, object rows) {
            System.Web.HttpContext.Current.Response.ContentType = "application/json; charset=utf-8";
            System.Web.HttpContext.Current.Response.Write(ToJson(new { total, rows }));
        }
    }
}
