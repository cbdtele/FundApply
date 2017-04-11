using Cydb.Common.Helper;

namespace Cydb.Common.Helper {
    /// <summary>
    ///GeneralOperation 的摘要说明
    /// </summary>
    public static class GeneralOperation {
        /// <summary>
        /// 分割时间
        /// 传入模型 2015|1,8
        /// 输出 201501，201508
        /// </summary>
        /// <param name="timeStr">时间组合字符串</param>
        public static string[] TimeCutting(this string timeStr) {
            string[] outStr = new string[2];
            var part01 = timeStr.Split('|');
            if (part01.Length == 2) {
                var part02 = part01[1].Split(',');
                if (part02.Length == 2) {
                    outStr[0] = part01[0] + (Conv.ToInt(part02[0]) < 10 ? "0" + part02[0] : part02[0]);
                    outStr[1] = part01[0] + (Conv.ToInt(part02[1]) < 10 ? "0" + part02[1] : part02[1]);
                }
            }
            return outStr;
        }

        /// <summary>
        /// 去掉null
        /// </summary>
        /// <param name="jsonStr"></param>
        /// <returns></returns>
        public static string JsonNull(this string jsonStr) {
            return jsonStr.Replace("null", "\"\"");
        }
    }
}