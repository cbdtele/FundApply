using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cydb.Repository.Repository
{
    public interface IYysrRepository
    {
        /// <summary>
        /// 营业收入、同比增速
        /// </summary>
        /// <param name="beginTime"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        List<dynamic> YYSR(string beginTime, string type);

        /// <summary>
        /// 总额
        /// </summary>
        /// <param name="beginTime"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        List<dynamic> Chart01(string beginTime, string type);

        /// <summary>
        /// 增速
        /// </summary>
        /// <param name="beginTime"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        List<dynamic> Chart02(string beginTime, string type);

        /// <summary>
        /// 统计口径 年份
        /// </summary>
        /// <param name="beginTime"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        List<dynamic> GetAllByYear(string beginTime, string type);

        /// <summary>
        /// 统计口径 月份
        /// </summary>
        /// <param name="beginTime"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        List<dynamic> GetMonthByYear(string year, string type);

    }
}
