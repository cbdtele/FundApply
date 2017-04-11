using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using Cydb.Common.Helper;
using Cydb.Repository.Base;

namespace Cydb.Repository.Repository {
    /// <summary>
    /// GDP仓储
    /// </summary>
    public class GdpRepository : IGdpRepository {
        private static readonly ISqlBaseOperation SqlBaseOperation = new SqlBaseOperation();

        public List<dynamic> GetAllList() {
            var d = SqlBaseOperation.Query(
                 " select REP_DATE, round(GDP/10000,2) GDP,round(T_GDP/10000,2) T_GDP, TB from T_GDP_YEAR ")
                 .OrderBy(t => t.REP_DATE).ToList();
            return d;
        }

        public dynamic GetSingelByTime(string time) {
            var d =
                SqlBaseOperation.Query(
                    " select REP_DATE, round(GDP/10000,2) GDP,round(T_GDP/10000,2) T_GDP, TB from T_GDP_YEAR where REP_DATE=:REP_DATE ",
                    new { REP_DATE = time }).SingleOrDefault();
            return d;
        }

        public List<dynamic> GetDgpHyfbList(string beginTime, string pIndustryId) {
            OracleDynamicParameters oracleDynamicParameters = new OracleDynamicParameters();
            oracleDynamicParameters.Add("begintime", beginTime);
            oracleDynamicParameters.Add("p_industry_id", pIndustryId);
            oracleDynamicParameters.Add("vcur", OracleType.Cursor, ParameterDirection.Output);
            return SqlBaseOperation.ExecuteProcedure("p_gdp_hyfblist", oracleDynamicParameters);
        }

        public List<dynamic> GetGdpContinuousUp(string time, string targetColumn, string upordown) {
            var oracleDynamicParameters = new OracleDynamicParameters();
            oracleDynamicParameters.Add("beginTime", time);
            oracleDynamicParameters.Add("targetColumn", targetColumn);
            oracleDynamicParameters.Add("upordown", upordown);
            oracleDynamicParameters.Add("vCur", OracleType.Cursor, ParameterDirection.Output);
            return SqlBaseOperation.ExecuteProcedure("p_gdp_highchange", oracleDynamicParameters);
        }

        public List<dynamic> GetGdpHyChar(string time) {
            var year = Conv.ToInt(time.Substring(0, 4));
            var strSql = new StringBuilder();
            //自动获取最初日期
            var minTime = SqlBaseOperation.Get<int>(" select min(REP_DATE) REP_DATE from T_GDP_YEAR_ENTLIST ");
            for (var i = year; i >= minTime; i--) {
                strSql.AppendFormat(@" 
select {0} rep_date,INDUSTRY_MTYPE_ID industryId, INDUSTRY_MTYPE_NAME PIENAME
,round(sum(nvl(a.gdp,0))/100000,2) PIEVALUE
from
(select sum(GDP) GDP, HY,count(*) numbers from T_GDP_YEAR_ENTLIST where REP_DATE={0} group by HY) a
,ndic_industry c
where c.INDUSTRY_TYPE4_ID=a.HY(+)
group by INDUSTRY_MTYPE_ID, INDUSTRY_MTYPE_NAME ", i);
                if (i > minTime)
                    strSql.Append(" union all ");
            }
            return SqlBaseOperation.Query(strSql.ToString()).OrderBy(t => t.REP_DATE).ToList();
        }

        public List<dynamic> Get123CList(string time) {
//            var year = TimeHelper.GetYear(Conv.ToInt(time));
//            var strSql = new StringBuilder();
//            strSql.AppendFormat(@" 
//select case 
//when flag_3c=1 then '第一产业'
//when flag_3c=2 then '第二产业'
//when flag_3c=3 then '第三产业' 
//else null end INDUSTRYNAME,FLAG_3C INDUSTRYID,gdp SUMTOTAL,ZS,decode(t.gdp,0,0,round(t.gdp*100/sum(t.gdp) over(partition by null),2))BZ,QYSL NUMBERS  
//from
//(select FLAG_3C ,round(sum(nvl(a.gdp,0))/10000,2) gdp,
//round(decode(sum(nvl(a1.gdp,0)),0,0,（sum(nvl(a.gdp,0))-sum(nvl(a1.gdp,0))）/sum(nvl(a1.gdp,0)))*100,2) ZS,
//count(a.nat_org_code) qysl from
//(select * from t_gdp_year_entlist where rep_date={0}) a,
//(select * from t_gdp_year_entlist where rep_date={1}) a1,
//org_info2 b
//where b.nat_org_code= a.nat_org_code(+)
//and b.nat_org_code = a1.nat_org_code(+)
//and b.flag_3c <>0
//group by FLAG_3C) t
//order by t.flag_3c asc", year, year - 1);
//            var data = SqlBaseOperation.Query(strSql.ToString()).ToList();

            OracleDynamicParameters oracleDynamicParameters = new OracleDynamicParameters();
            oracleDynamicParameters.Add("beginTime", time);
            oracleDynamicParameters.Add("isSearchFlag", "true");
            oracleDynamicParameters.Add("p_industry_id", 0);
            oracleDynamicParameters.Add("vcur", OracleType.Cursor, ParameterDirection.Output);
            var data = SqlBaseOperation.ExecuteProcedure("p_gdp_123c", oracleDynamicParameters).ToList();
            return data;
        }

        public List<dynamic> GetGdpDzcyList(string time) {
            OracleDynamicParameters oracleDynamicParameters = new OracleDynamicParameters();
            oracleDynamicParameters.Add("beginTime", time);
            oracleDynamicParameters.Add("p_industry_id", 0);
            oracleDynamicParameters.Add("isSearchJH", "true");
            oracleDynamicParameters.Add("jhId", 0);
            oracleDynamicParameters.Add("vcur", OracleType.Cursor, ParameterDirection.Output);
            var data = SqlBaseOperation.ExecuteProcedure("p_gdp_zdcylist", oracleDynamicParameters).ToList();
            return data;
        }

        public List<dynamic> GetGdpXtlbList(string time) {
            OracleDynamicParameters oracleDynamicParameters = new OracleDynamicParameters();
            oracleDynamicParameters.Add("beginTime", time);
            oracleDynamicParameters.Add("vcur", OracleType.Cursor, ParameterDirection.Output);
            var data = SqlBaseOperation.ExecuteProcedure("p_gdp_ent_category", oracleDynamicParameters).ToList();
            return data;
        }

        public List<dynamic> GetGdpQylxList(string time) {
            var year = TimeHelper.GetYear(Conv.ToInt(time));
            var strSql = new StringBuilder();
            strSql.AppendFormat(@" 
select 
ENT_MTYPE_ID, ENT_MTYPE_NAME
,decode(sum(a.numbers),null,0,sum(a.numbers)) numbers
,decode(sum(a.GDP),null,0,sum(a.GDP)) sumtotal
,sum(nvl(a.GDP,0)-(nvl(b.GDP,0))) ZL
,decode(sum(nvl(b.GDP,0)),0,0,round(sum(nvl(a.GDP,0)-(nvl(b.GDP,0)))/abs(sum(nvl(b.GDP,0)))*100,2)) ZS
,decode(sum(nvl(a.GDP,0)),0,0,round(ratio_to_report(sum(nvl(a.GDP,0))) over(),4)*100) BZ
 from 
(select ENT_MTYPE_ID, ENT_MTYPE_NAME, ENT_BTYPE_ID from DIC_ENTERPRISE_TYPE) x,
(select NAT_ORG_CODE,ENT_TYPE_ID from org_info2) xx,
(select NAT_ORG_CODE,round(sum(GDP)/100000,2) GDP,decode(count(*),0,0,1) numbers from T_GDP_YEAR_ENTLIST where REP_DATE={0} group by nat_org_code) a,
(select NAT_ORG_CODE,round(sum(GDP)/100000,2) GDP,decode(count(*),0,0,1) numbers from T_GDP_YEAR_ENTLIST where REP_DATE={1} group by nat_org_code) b
where xx.NAT_ORG_CODE=a.NAT_ORG_CODE(+)
and xx.NAT_ORG_CODE=b.NAT_ORG_CODE(+)
and x.ENT_BTYPE_ID=xx.ent_type_id(+)
group by ENT_MTYPE_ID, ENT_MTYPE_NAME ", year, year - 1);
            var data = SqlBaseOperation.Query(strSql.ToString()).ToList();
            return data;
        }

        public List<dynamic> GetGdpQylxChart(string time) {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"
select ENT_MTYPE_ID, ENT_MTYPE_NAME
,decode(sum(nvl(a.GDP,0)),0,0,round(ratio_to_report(sum(nvl(a.GDP,0))) over(),4)*100) BZ
from 
(select ENT_MTYPE_ID, ENT_MTYPE_NAME, ENT_BTYPE_ID from DIC_ENTERPRISE_TYPE) x,
(select NAT_ORG_CODE,ENT_TYPE_ID from org_info2) xx,
(select NAT_ORG_CODE,round(sum(GDP)/100000,2) GDP,decode(count(*),0,0,1) numbers from T_GDP_YEAR_ENTLIST where REP_DATE={0} group by nat_org_code) a
where xx.NAT_ORG_CODE=a.NAT_ORG_CODE(+)
and x.ENT_BTYPE_ID=xx.ent_type_id(+)
group by ENT_MTYPE_ID, ENT_MTYPE_NAME ", time);
            return SqlBaseOperation.Query(strSql.ToString()).ToList();
        }

        public List<dynamic> GetGdpGnqList(string time) {
            OracleDynamicParameters oracleDynamicParameters = new OracleDynamicParameters();
            oracleDynamicParameters.Add("beginTime", time);
            oracleDynamicParameters.Add("vcur", OracleType.Cursor, ParameterDirection.Output);
            var data = SqlBaseOperation.ExecuteProcedure("p_gdp_ggq", oracleDynamicParameters).ToList();
            return data;
        }
    }
}
