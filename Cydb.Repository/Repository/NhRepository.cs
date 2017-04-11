using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using Cydb.Common.Helper;
using Cydb.Repository.Base;

namespace Cydb.Repository.Repository
{
    /// <summary>
    /// 能耗SQL仓库
    /// </summary>
    public class NhRepository : INhRepository
    {
        private static readonly ISqlBaseOperation SqlBaseOperation = new SqlBaseOperation();

        /// <summary>
        /// 获取统计企业总数
        /// </summary>
        /// <returns></returns>
        public int GetStatisticsEntNums()
        {
            return SqlBaseOperation.Query<int>(" select count(*) from t_nh_month_entlist ").SingleOrDefault();
        }

        /// <summary>
        /// 根据时间获取当季度的值和同比
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public dynamic GetValueAndTbByTime(string time)
        {
            var timeBoundary = TimeHelper.GetQuarterTimeBoundary(time);
            var tBtimeBoundary = TimeHelper.GetQuarterTimeBoundary(time.YearSubtract());
            StringBuilder strSql = new StringBuilder($@" 
select a.rep_date, a.NH_LJ NYXFL, decode(b.NH_LJ,0,0,round(((a.NH_LJ-b.NH_LJ)/b.NH_LJ)*100,2)) TB  from 
( select '{TimeHelper.GetQuarterString(time)}' rep_date,NH_LJ from t_nh_quarter where rep_date={timeBoundary[1]} ) a,
( select '{TimeHelper.GetQuarterString(time)}' rep_date,NH_LJ from t_nh_quarter where rep_date={tBtimeBoundary[1]} ) b
where a.rep_date=b.rep_date ");
            return SqlBaseOperation.Query(strSql.ToString()).SingleOrDefault();
        }

        /// <summary>
        /// 获取全区税收和能耗折线图
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public List<dynamic> GetTaxAndNhListChart(string time)
        {
            StringBuilder strSql = new StringBuilder(@" 
select x.rep_date, a.NH_LJ Nh, b.tax from 
( select distinct substr(sjrq,0,4) rep_date from ORG_INFO_TIME_TJ ) x,
( select substr(rep_date,0,4) rep_date, sum(NH_LJ) NH_LJ from t_nh_quarter where substr(rep_date,5,2)=12 group by substr(rep_date,0,4)) a,
( select substr(REP_DATE,0,4) rep_date, round(sum(QQ_TAX)/100000000,2) tax from t_tax3_month group by substr(rep_date,0,4) ) b
where x.rep_date=a.rep_date(+)
and x.rep_date=b.rep_date(+)
and x.rep_date<=:rep_date
order by REP_DATE ");
            return SqlBaseOperation.Query(strSql.ToString(), new { rep_date = TimeHelper.GetYear(time) });
        }

        /// <summary>
        /// 获取全区GDP和能耗折线图
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public List<dynamic> GetGdpAndNhListChart(string time)
        {
            StringBuilder strSql = new StringBuilder(@"
select x.rep_date, a.NH_LJ Nh, b.GDP from 
( select distinct substr(sjrq,0,4) rep_date from ORG_INFO_TIME_TJ ) x,
( select substr(rep_date,0,4) rep_date, sum(NH_LJ) NH_LJ from t_nh_quarter where substr(rep_date,5,2)=12 group by substr(rep_date,0,4)) a,
( select rep_date, round(sum(GDP)/10000,2) GDP from T_GDP_YEAR group by REP_DATE ) b
where x.rep_date=a.rep_date(+)
and x.rep_date=b.rep_date(+)
and x.rep_date<=:rep_date
order by REP_DATE ");
            return SqlBaseOperation.Query(strSql.ToString(), new { rep_date = TimeHelper.GetYear(time) });
        }

        /// <summary>
        /// 口径说明 总体情况 年
        /// </summary>
        /// <returns></returns>
        public List<dynamic> GetAllByYear(string beginTime)
        {
            var beginTime_year = TimeHelper.GetYear(beginTime);
            StringBuilder strSql = new StringBuilder();
            if (TimeHelper.GetMonth(beginTime)=="12")
            {
                strSql.AppendFormat(@"
select substr(rep_date,0,4) rep_date ,sum(nh_lj) nh_lj from t_nh_quarter
where substr(rep_date,5,2)=12 and substr(rep_date,0,4) <={0}
group by substr(rep_date,0,4)
order by substr(rep_date,0,4) desc", beginTime_year);
            }
            else
            {
                strSql.AppendFormat(@"
select substr(rep_date,0,4) rep_date ,sum(nh_lj) nh_lj from t_nh_quarter
where substr(rep_date,5,2)=12 and substr(rep_date,0,4) <={0}
group by substr(rep_date,0,4)
union 
select substr(rep_date,0,4) rep_date ,sum(nh_lj) nh_lj from t_nh_quarter
where substr(rep_date,5,2)={1} and substr(rep_date,0,4) ={0}
group by substr(rep_date,0,4)
order by rep_date desc", beginTime_year,TimeHelper.GetMonth(beginTime));
            }

            return SqlBaseOperation.Query(strSql.ToString());
        }

        /// <summary>
        /// 口径说明 总体情况 月
        /// </summary>
        /// <returns></returns>
        public List<dynamic> GetMonthByYear(string year)
        {
            StringBuilder strSql = new StringBuilder(string.Format(@"
select rep_name,nh from t_nh_quarter 
where substr(rep_date,0,4) =:rep_date
order by rep_date desc", year));
            return SqlBaseOperation.Query(strSql.ToString(), new { rep_date = year });
        }

        /// <summary>
        /// 获取能耗重点产业图数据
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public List<dynamic> GetNhZdcyChart(string time)
        {
            OracleDynamicParameters oracleDynamicParameters = new OracleDynamicParameters();
            //oracleDynamicParameters.Add("beginTime", time + "01");
            oracleDynamicParameters.Add("endTime", time + "12");
            oracleDynamicParameters.Add("p_industry_id", 0);
            oracleDynamicParameters.Add("isSearchJH", "true");
            oracleDynamicParameters.Add("jhId", 0);
            oracleDynamicParameters.Add("vCur", OracleType.Cursor, ParameterDirection.Output);
            var data = SqlBaseOperation.ExecuteProcedure("p_nh_zdcylist", oracleDynamicParameters);
            return data;
        }

        /// <summary>
        /// 获取能耗重点产业数据表
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public List<dynamic> GetNhZdcyList(
            string time)
        {
            //var tBtimeBoundary = TimeHelper.GetQuarterTimeBoundary(time);
            OracleDynamicParameters oracleDynamicParameters = new OracleDynamicParameters();
            //oracleDynamicParameters.Add("beginTime", tBtimeBoundary[0]);
            //oracleDynamicParameters.Add("endTime", tBtimeBoundary[1]);
            oracleDynamicParameters.Add("endTime", time);
            oracleDynamicParameters.Add("p_industry_id", 0);
            oracleDynamicParameters.Add("isSearchJH", "true");
            oracleDynamicParameters.Add("jhId", 0);
            oracleDynamicParameters.Add("vCur", OracleType.Cursor, ParameterDirection.Output);
            var data = SqlBaseOperation.ExecuteProcedure("p_nh_zdcylist", oracleDynamicParameters);
            return data;
        }

        /// <summary>
        /// 获取能耗形态类别数据表
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public List<dynamic> GetNhXtlbList(string time)
        {
            //var tBtimeBoundary = TimeHelper.GetQuarterTimeBoundary(time);
            OracleDynamicParameters oracleDynamicParameters = new OracleDynamicParameters();
            //oracleDynamicParameters.Add("beginTime", tBtimeBoundary[0]);
            //oracleDynamicParameters.Add("endTime", tBtimeBoundary[1]);
            oracleDynamicParameters.Add("endTime", time);
            oracleDynamicParameters.Add("vcur", OracleType.Cursor, ParameterDirection.Output);
            var data = SqlBaseOperation.ExecuteProcedure("p_nh_ent_category", oracleDynamicParameters).ToList();
            return data;
        }

        /// <summary>
        /// 企业类型数据表表
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public List<dynamic> GetNhQylxList(string time)
        {
            //var timeBoundary = TimeHelper.GetQuarterTimeBoundary(time);
            //var tBtimeBoundary = TimeHelper.GetQuarterTimeBoundary(time.YearSubtract());
            var strSql = new StringBuilder();
            strSql.AppendFormat(@" 
select 
ENT_MTYPE_ID, ENT_MTYPE_NAME
,decode(sum(a.numbers),null,0,sum(a.numbers)) numbers
,decode(sum(a.NYXFL),null,0,sum(a.NYXFL)) sumtotal
,sum(nvl(a.NYXFL,0)-(nvl(b.NYXFL,0))) ZL
,decode(sum(nvl(b.NYXFL,0)),0,0,round(sum(nvl(a.NYXFL,0)-(nvl(b.NYXFL,0)))/abs(sum(nvl(b.NYXFL,0)))*100,2)) ZS
,decode(sum(nvl(a.NYXFL,0)),0,0,round(ratio_to_report(sum(nvl(a.NYXFL,0))) over(),4)*100) BZ
 from 
(select ENT_MTYPE_ID, ENT_MTYPE_NAME, ENT_BTYPE_ID from DIC_ENTERPRISE_TYPE) x,
(select NAT_ORG_CODE,ENT_TYPE_ID from org_info2) xx,
(select NAT_ORG_CODE,round(sum(NYXFL)/10000,2) NYXFL,decode(count(*),0,0,1) numbers from T_NH_MONTH_ENTLIST where REP_DATE ={0} group by nat_org_code) a,
(select NAT_ORG_CODE,round(sum(NYXFL)/10000,2) NYXFL,decode(count(*),0,0,1) numbers from T_NH_MONTH_ENTLIST where REP_DATE ={0} group by nat_org_code) b
where xx.NAT_ORG_CODE=a.NAT_ORG_CODE(+)
and xx.NAT_ORG_CODE=b.NAT_ORG_CODE(+)
and x.ENT_BTYPE_ID=xx.ent_type_id(+)
group by ENT_MTYPE_ID, ENT_MTYPE_NAME ",time);
            var data = SqlBaseOperation.Query(strSql.ToString()).ToList();
            return data;
        }

        /// <summary>
        /// 企业类型数据饼图
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public List<dynamic> GetNhQylxChart(string time)
        {
            var timeBoundary = TimeHelper.GetQuarterTimeBoundary(time);
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat($@"
select ENT_MTYPE_ID, ENT_MTYPE_NAME
,decode(sum(nvl(a.NYXFL,0)),0,0,round(ratio_to_report(sum(nvl(a.NYXFL,0))) over(),4)*100) BZ
from 
(select ENT_MTYPE_ID, ENT_MTYPE_NAME, ENT_BTYPE_ID from DIC_ENTERPRISE_TYPE) x,
(select NAT_ORG_CODE,ENT_TYPE_ID from org_info2) xx,
(select NAT_ORG_CODE,round(sum(NYXFL)/10000,2) NYXFL,decode(count(*),0,0,1) numbers from T_NH_MONTH_ENTLIST where REP_DATE between {timeBoundary[0]} and {timeBoundary[1]} group by nat_org_code) a
where xx.NAT_ORG_CODE=a.NAT_ORG_CODE(+)
and x.ENT_BTYPE_ID=xx.ent_type_id(+)
group by ENT_MTYPE_ID, ENT_MTYPE_NAME ");
            return SqlBaseOperation.Query(strSql.ToString()).ToList();
        }

        /// <summary>
        /// 获取能耗功能区数据表列和饼图数据
        /// </summary>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public List<dynamic> GetNhGnqListAndChart(string beginTime, string endTime)
        {
            OracleDynamicParameters oracleDynamicParameters = new OracleDynamicParameters();
            oracleDynamicParameters.Add("beginTime", beginTime);
            oracleDynamicParameters.Add("endTime", endTime);
            oracleDynamicParameters.Add("vcur", OracleType.Cursor, ParameterDirection.Output);
            var data = SqlBaseOperation.ExecuteProcedure("p_nh_ggq", oracleDynamicParameters).ToList();
            return data;
        }

        /// <summary>
        /// 能耗123产 表格
        /// </summary>
        /// <param name="time"></param>
        /// <param name="issearchflag"></param>
        /// <param name="pIndustryId"></param>
        /// <returns></returns>
        public List<dynamic> Get123CList(string time, bool issearchflag = true, string pIndustryId = "0")
        {
            //var tBtimeBoundary = TimeHelper.GetQuarterTimeBoundary(time.YearSubtract());
            OracleDynamicParameters oracleDynamicParameters = new OracleDynamicParameters();
            //oracleDynamicParameters.Add("begintime", tBtimeBoundary[0]);
            //oracleDynamicParameters.Add("endtime", tBtimeBoundary[1]);
            oracleDynamicParameters.Add("endtime", time);
            oracleDynamicParameters.Add("issearchflag", issearchflag);
            oracleDynamicParameters.Add("p_industry_id", pIndustryId);
            oracleDynamicParameters.Add("vcur", OracleType.Cursor, ParameterDirection.Output);
            var data = SqlBaseOperation.ExecuteProcedure("p_nh_123c", oracleDynamicParameters);
            return data;
        }

        /// <summary>
        /// 获取能耗行分布中的一级行业门类列表
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public List<dynamic> GetNhHyfbList(string time)
        {
            var tBtimeBoundary = TimeHelper.GetQuarterTimeBoundary(time.YearSubtract());
            OracleDynamicParameters oracleDynamicParameters = new OracleDynamicParameters();
            //oracleDynamicParameters.Add("beginTime", tBtimeBoundary[0]);
            //oracleDynamicParameters.Add("endTime", tBtimeBoundary[1]);
            oracleDynamicParameters.Add("beginTime", time);
            oracleDynamicParameters.Add("endTime", time);
            oracleDynamicParameters.Add("vCur", OracleType.Cursor, ParameterDirection.Output);
            var data = SqlBaseOperation.ExecuteProcedure("p_nh_hyfb", oracleDynamicParameters);
            return data;
        }

        /// <summary>
        /// 获取能耗行分布中的一级行业门类 饼图
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public List<dynamic> GetNhHyChar(string time)
        {
            var timeBoundary = TimeHelper.GetYear(time);
            var minTime = CommonRepository.GetMinYear("t_nh_month_entlist");
            //操作行为
            Func<string, string, List<dynamic>> doProcedure = (beginTime, endTime) =>
            {
                OracleDynamicParameters oracleDynamicParameters = new OracleDynamicParameters();
                oracleDynamicParameters.Add("beginTime", beginTime);
                oracleDynamicParameters.Add("endTime", endTime);
                oracleDynamicParameters.Add("vCur", OracleType.Cursor, ParameterDirection.Output);
                var data = SqlBaseOperation.ExecuteProcedure("p_nh_hyfb", oracleDynamicParameters);
                return data;
            };
            var dataList = new List<dynamic>();
            for (int i = minTime; i <= timeBoundary; i++)
            {
                dataList.AddRange(doProcedure(i + "01", i + "12"));
            }
            return dataList;
        }

    }
}
