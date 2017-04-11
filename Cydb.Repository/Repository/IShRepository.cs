using System.Collections.Generic;

namespace Cydb.Repository.Repository
{
    public interface IShRepository
    {
        /// <summary>
        /// 从业人员、同比增速
        /// </summary>
        /// <param name="beginTime"></param>
        /// <returns></returns>
        List<dynamic> SH(string beginTime);

        /// <summary>
        /// 水耗
        /// </summary>
        /// <param name="beginTime"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        List<dynamic> Chart01(string beginTime);


        /// <summary>
        /// 水耗的增速
        /// </summary>
        /// <param name="beginTime"></param>
        /// <returns></returns>
        List<dynamic> Chart02(string beginTime);

        /// <summary>
        /// 统计口径 年份
        /// </summary>
        /// <param name="beginTime"></param>
        /// <returns></returns>
        List<dynamic> GetAllByYear(string beginTime);

        /// <summary>
        /// 行业分布 行业名称
        /// </summary>
        /// <param name="beginTime"></param>
        /// <returns></returns>
        List<dynamic> HyfbTable01(string beginTime);

        /// <summary>
        /// 行业分布 连续高速增长
        /// </summary>
        /// <param name="beginTime"></param>
        /// <returns></returns>
        List<dynamic> HyfbTable02(string beginTime);

        /// <summary>
        /// 行业分布 连续高速减少
        /// </summary>
        /// <param name="beginTime"></param>
        /// <returns></returns>
        List<dynamic> HyfbTable03(string beginTime);

        /// <summary>
        /// 行业水耗占比分析
        /// </summary>
        /// <param name="beginTime"></param>
        /// <returns></returns>
        List<dynamic> HyfbChart01(string beginTime);

        /// <summary>
        /// 产业分布 一二三次产业
        /// </summary>
        /// <param name="beginTime"></param>
        /// <returns></returns>
        List<dynamic> CyfbTable01(string beginTime);

        /// <summary>
        /// 产业分布 主导产业
        /// </summary>
        /// <param name="beginTime"></param>
        /// <returns></returns>
        List<dynamic> CyfbTable02(string beginTime);

        /// <summary>
        /// 产业分布  一二三次产业水耗总量占比
        /// </summary>
        /// <param name="beginTime"></param>
        /// <returns></returns>
        List<dynamic> CyfbChart01(string beginTime);

        /// <summary>
        /// 产业分布 主导产业水耗总量占比
        /// </summary>
        /// <param name="beginTime"></param>
        /// <returns></returns>
        string CyfbChart02(string beginTime);

        /// <summary>
        /// 形态类别
        /// </summary>
        /// <param name="beginTime"></param>
        /// <returns></returns>
        List<dynamic> XtlbTable01(string beginTime);

        /// <summary>
        /// 企业类型 分类
        /// </summary>
        /// <param name="beginTime"></param>
        /// <returns></returns>
        List<dynamic> WzTable01(string beginTime);

        /// <summary>
        /// 企业类型 内外资水耗占比分析
        /// </summary>
        /// <param name="beginTime"></param>
        /// <returns></returns>
        List<dynamic> WzChart01(string beginTime);

        /// <summary>
        /// 功能区 分类
        /// </summary>
        /// <param name="beginTime"></param>
        /// <returns></returns>
        List<dynamic> GnqTable01(string beginTime);

        /// <summary>
        /// 功能区水耗占比分析
        /// </summary>
        /// <param name="beginTime"></param>
        /// <returns></returns>
        IEnumerable<dynamic> GnqChart01(System.Data.IDbConnection conn, string beginTime);
    }
}
