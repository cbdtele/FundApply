using System.Collections.Generic;

namespace Cydb.Repository.Repository {
    public interface INhRepository {
        /// <summary>
        /// 获取统计企业总数
        /// </summary>
        /// <returns></returns>
        int GetStatisticsEntNums();

        /// <summary>
        /// 根据时间获取当季度的值和同比
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        dynamic GetValueAndTbByTime(string time);

        /// <summary>
        /// 获取税收和能耗折线图
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        List<dynamic> GetTaxAndNhListChart(string time);

        /// <summary>
        /// 获取GDP和能耗折线图
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        List<dynamic> GetGdpAndNhListChart(string time);

        /// <summary>
        /// 获取能耗行分布中的一级行业门类列表
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        List<dynamic> GetNhHyfbList(string time);

        /// <summary>
        /// 能耗行业分布 ， 时间圆饼图
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        List<dynamic> GetNhHyChar(string time);

        /// <summary>
        /// 口径说明 总体情况 年
        /// </summary>
        /// <returns></returns>
        List<dynamic> GetAllByYear(string beginTime);

        /// <summary>
        /// 口径说明 总体情况 月
        /// </summary>
        /// <returns></returns>
        List<dynamic> GetMonthByYear(string year);

        List<dynamic> Get123CList(string time, bool issearchflag = true, string pIndustryId = "0");
        List<dynamic> GetNhZdcyList(string time);
        List<dynamic> GetNhZdcyChart(string time);
        List<dynamic> GetNhXtlbList(string time);
        List<dynamic> GetNhQylxList(string time);
        List<dynamic> GetNhQylxChart(string time);
        List<dynamic> GetNhGnqListAndChart(string beginTime, string endTime);
    }
}