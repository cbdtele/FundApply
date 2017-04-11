using System.Collections.Generic;

namespace Cydb.Repository.Repository
{
    public interface ICyryRepository
    {
        /// <summary>
        /// 总体情况  从业人员、同比增速
        /// </summary>
        /// <param name="beginTime"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        List<dynamic> CYRY(string beginTime, string type);

        /// <summary>
        /// 历年1-n月税收与从业人员
        /// </summary>
        /// <param name="beginTime"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        List<dynamic> Chart01(string beginTime, string type);


        /// <summary>
        /// 历年全年1-n月税收与从业人员
        /// </summary>
        /// <param name="beginTime"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        List<dynamic> Chart02(string beginTime, string type);

        /// <summary>
        /// 人均税收、从业人员 TOP10
        /// </summary>
        /// <param name="beginTime"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        List<dynamic> ShuiShou_CYRY_List_Sql(string beginTime, string type);


        /// <summary>
        /// 口径说明 年份
        /// </summary>
        /// <param name="beginTime"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        List<dynamic> GetAllByYear(string beginTime, string type);

        /// <summary>
        /// 口径说明 月份
        /// </summary>
        /// <param name="beginTime"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        List<dynamic> GetMonthByYear(string year, string type);


        List<dynamic> HyfbTable01(string beginTime, string type);
        List<dynamic> HyfbChart01(string beginTime, string type);

        List<dynamic> CyfbTable01(string beginTime, string type);

        List<dynamic> WzTable01(string beginTime, string type);


    }
}
