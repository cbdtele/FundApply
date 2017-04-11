using Cydb.Common.Helper;
using Cydb.Repository.Base;

namespace Cydb.Repository.Repository {
    public class CommonRepository {
        private static readonly ISqlBaseOperation SqlBaseOperation = new SqlBaseOperation();
        /// <summary>
        /// 获取最小年份
        /// </summary>
        /// <returns></returns>
        public static int GetMinYear(string tableName, string date = "REP_DATE") {
            //自动获取最初日期
            var minTime = Conv.ToInt((SqlBaseOperation
                .Get<string>($"select min({date}) minTime from {tableName} t") ?? "").Substring(0, 4));
            return minTime;
        }

        /// <summary>
        /// 获取最大年份
        /// </summary>
        /// <returns></returns>
        public static int GetMaxYear(string tableName, string date = "REP_DATE") {
            //自动获取最初日期
            var minTime = Conv.ToInt((SqlBaseOperation
                .Get<string>($"select max({date}) maxTime from {tableName} t") ?? "").Substring(0, 4));
            return minTime;
        }
    }
}
