using System;
using System.Collections.Generic;
using System.Linq;

namespace Cydb.Common.Helper {
    /// <summary>
    ///TimeHelper 的摘要说明
    /// </summary>
    public static class TimeHelper {
        /// <summary>
        /// 根据当前日期获取1月
        /// </summary>
        /// <param name="time">当前日期</param>
        /// <returns></returns>
        public static string GetStartTime(string time)
        {
            if (time != null && time.Length == 6)
            {
                return time.Substring(0, 4) + "01";
            }
            else
            {
                return time;
            }
        }
        /// <summary>
        /// 根据当前日期获取同期日期
        /// </summary>
        /// <param name="time">当前日期</param>
        /// <returns></returns>
        public static string GetTqTime(string time)
        {
            if (time != null && time.Length == 6)
            {
                return (int.Parse(time.Substring(0, 4)) - 1) + time.Substring(4, 2);
            }
            else
            {
                return time;
            }
        }

        /// <summary>
        /// 转换为两个时间的区间
        /// </summary>
        /// <param name="dtBegin"></param>
        /// <param name="dtEnd"></param>
        /// <param name="isReverse">是否反转数组</param>
        /// <returns>201001,201002,201003 ... 201012</returns>
        public static List<string> ToInterval(DateTime dtBegin, DateTime dtEnd, bool isReverse = true) {
            var list = new List<string>();
            for (var i = dtBegin.Year; i <= dtEnd.Year; i++) {
                if (i == dtBegin.Year) {
                    for (var j = dtBegin.Month; j <= 12; j++) {
                        list.Add(i + "" + ComplementZero(j));
                    }
                }
                else if (i == dtEnd.Year) {
                    for (var j = 1; j <= dtEnd.Month; j++) {
                        list.Add(i + "" + ComplementZero(j));
                    }
                }
                else {
                    for (var j = 1; j <= 12; j++) {
                        list.Add(i + "" + ComplementZero(j));
                    }
                }
            }
            if (isReverse)
                list.Reverse();
            return list;
        }

        /// <summary>
        /// 获取年度集合
        /// </summary>
        /// <param name="beginYear">开始年份</param>
        /// <param name="entYear">截至年份</param>
        /// <param name="isReverse">是否反转数组</param>
        /// <returns></returns>
        public static List<string> GetYearList(int beginYear, int entYear, bool isReverse = true) {
            var list = new List<string>();
            for (var i = beginYear; i <= entYear; i++) {
                list.Add(i.ToString());
            }
            if (isReverse)
                list.Reverse();
            return list;
        }

        /// <summary>
        /// 0占位
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static string ComplementZero(int i) {
            if (i < 10) {
                return "0" + i;
            }
            else {
                return i + "";
            }
        }

        /// <summary>
        /// 年份减去传入的年份，默认一年
        /// </summary>
        /// <param name="times"></param>
        /// <param name="num">减去的年份，默认为一年</param>
        /// <returns></returns>
        public static string YearSubtract(this string times, int num = 1) {
            if (string.IsNullOrWhiteSpace(times)) {
                throw new Exception("查询的时间错误！");
            }
            if (times.Length == 4) {
                return (Conv.ToInt(times.Substring(0, 4)) - num).ToString();
            }
            if (times.Length == 6) {
                return (Conv.ToInt(times.Substring(0, 4)) - num) + times.Substring(4, 2);
            }
            throw new Exception("查询的时间格式错误！");
        }

        /// <summary>
        /// 通过日期(int)获取年份
        /// </summary>
        /// <param name="time">日期</param>
        /// <returns></returns>
        public static int GetYear(int time) {
            if (Conv.ToString(time).Length < 4) {
                throw new Exception("通过日期获取年份时出错！");
            }
            return Conv.ToString(time).Length == 4 ? time : Conv.ToInt(Conv.ToString(time).Substring(0, 4));
        }

        /// <summary>
        /// 通过日期(string)获取年份
        /// </summary>
        /// <param name="t">日期</param>
        /// <returns></returns>
        public static int GetYear(string t) {
            var time = Conv.ToInt(t);
            if (Conv.ToString(time).Length < 4) {
                throw new Exception("通过日期获取年份时出错！");
            }
            return Conv.ToString(time).Length == 4 ? time : Conv.ToInt(Conv.ToString(time).Substring(0, 4));
        }

        /// <summary>
        /// 通过日期(int)获取月份
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static int GetMonth(int time) {
            if (Conv.ToString(time).Length < 6) {
                throw new Exception("通过日期获取月份时出错！");
            }
            return Conv.ToInt(Conv.ToString(time).Substring(4, 2));
        }

        /// <summary>
        /// 通过日期(string)获取月份
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static string GetMonth(string time) {
            if (time.Length < 6) {
                throw new Exception("通过日期获取月份时出错！");
            }
            return Conv.ToString(time).Substring(4, 2);
        }

        #region 季度
        /// <summary>
        /// 判断月份所属季度，输出中文：第一季度...第四季度
        /// </summary>
        /// <param name="month">月份</param>
        /// <returns></returns>
        public static string GetQuarterString(int month) {
            Dictionary<string, int[]> dictionary = new Dictionary<string, int[]>
            {
                {"第一季度", new[] { 1, 3 }},
                {"第二季度", new[] { 4, 6 }},
                {"第三季度", new[] { 7, 9 }},
                {"第四季度", new[] {10, 12}}
            };
            return dictionary.SingleOrDefault(intse => month >= intse.Value[0] && month <= intse.Value[1]).Key;
        }

        /// <summary>
        /// 判断月份所属季度，输出中文：第一季度...第四季度
        /// </summary>
        /// <param name="time">时间字符串：20160101</param>
        /// <returns></returns>
        public static string GetQuarterString(string time) {
            var month = GetMonth(Conv.ToInt(time));
            Dictionary<string, int[]> dictionary = new Dictionary<string, int[]>
            {
                {"第一季度", new[] { 1, 3 }},
                {"第二季度", new[] { 4, 6 }},
                {"第三季度", new[] { 7, 9 }},
                {"第四季度", new[] {10, 12}}
            };
            return dictionary.SingleOrDefault(intse => month >= intse.Value[0] && month <= intse.Value[1]).Key;
        }

        /// <summary>
        /// 获取传入时间所属季度，并返回边界值
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static string[] GetQuarterTimeBoundary(string time) {
            var year = GetYear(Conv.ToInt(time));
            var month = GetMonth(Conv.ToInt(time));
            Dictionary<string[], int[]> dictionary = new Dictionary<string[], int[]>
            {
                {new[] {year + "01", year + "03"}, new[] {1, 3}},
                {new[] {year + "04", year + "06"}, new[] {4, 6}},
                {new[] {year + "07", year + "09"}, new[] {7, 9}},
                {new[] {year + "10", year + "12"}, new[] {10, 12}}
            };
            return dictionary.SingleOrDefault(intse => month >= intse.Value[0] && month <= intse.Value[1]).Key;
        }

        /// <summary>
        /// 判断月份所属季度月份边界，输出中文：季度时间边界，字符串 01,03
        /// </summary>
        /// <param name="month">月份</param>
        /// <returns></returns>
        public static string[] GetQuarterMonthBoundary(int month) {
            Dictionary<string[], int[]> dictionary = new Dictionary<string[], int[]>
            {
                {new[] {"01", "03"}, new[] {1, 3}},
                {new[] {"04", "06"}, new[] {4, 6}},
                {new[] {"07", "09"}, new[] {7, 9}},
                {new[] {"10", "11"}, new[] {10, 12}}
            };
            return dictionary.SingleOrDefault(intse => month >= intse.Value[0] && month <= intse.Value[1]).Key;
        }
        #endregion

    }

}
