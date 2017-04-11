using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Cydb.Repository.Repository
{
    public interface IZczjRepository
    {
        /// <summary>
        /// 资产总计、同比增速
        /// </summary>
        /// <param name="beginTime"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        List<dynamic> ZCZJ(string beginTime, string type);

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

        List<dynamic> HyfbTable01(string beginTime, string type, string colType);
        List<dynamic> HyfbTable02(string beginTime, string type, string colType);
        List<dynamic> HyfbTable03(string beginTime, string type, string colType);
        List<dynamic> HyfbChart01(string beginTime, string type, string colType);
        List<dynamic> CyfbTable01(string beginTime, string type, string colType);
        List<dynamic> CyfbTable02(string beginTime, string type, string colType);
        List<dynamic> CyfbChart01(string beginTime, string type, string colType);
        string CyfbChart02(string beginTime, string type, string colType);
        List<dynamic> XtlbTable01(string beginTime, string type, string colType);
        List<dynamic> WzTable01(string beginTime, string type, string colType);
        List<dynamic> WzChart01(string beginTime, string type, string colType);
        List<dynamic> GnqTable01(string beginTime, string type, string colType);
        IEnumerable<dynamic> GnqChart01(IDbConnection conn, string beginTime, string type, string colType);

    }
}
