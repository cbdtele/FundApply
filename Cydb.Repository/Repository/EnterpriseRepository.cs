using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cydb.Repository.Base;
using Dapper;

namespace Cydb.Repository.Repository
{
    public class EnterpriseRepository<TEntity>
    {
        /// <summary>
        /// 获取企业列表集合
        /// </summary>
        /// <param name="searchTime">查询时间区间</param>
        /// <param name="tbSearchTime">查询同比时间区间</param>
        /// <param name="where">条件</param>
        /// <param name="orderBy">排序，默认税收降序</param>
        /// <returns></returns>
        //        public List<TEntity> GetAllList(int[] searchTime, int[] tbSearchTime, string where, string orderBy = "tax") {
        //            using (var conn = new DbBase().DbConnecttion) {
        //                StringBuilder strSql = new StringBuilder();
        //                strSql.AppendFormat(@" 
        //select * from
        //( select 
        //a.*,
        //round(nvl(b.tax,0)/10000,2) tax,
        //round((nvl(b.tax,0)-nvl(c.tax,0))/10000,2) taxZl,
        //decode(nvl(c.tax,0),0,0,round((nvl(b.tax,0)-nvl(c.tax,0))/nvl(c.tax,0)*100,2)) taxZs,
        //round(nvl(b.QJSR,0)/10000,2) QJSR,
        //round((nvl(b.QJSR,0)-nvl(c.QJSR,0))/10000,2) QJSRZl,
        //decode(nvl(c.QJSR,0),0,0,round((nvl(b.QJSR,0)-nvl(c.QJSR,0))/nvl(c.QJSR,0)*100,2)) QJSRZs,
        //d.industry_mtype_id,d.industry_mtype_name,d.industry_type4_id,d.industry_type4_name,
        //e.region_name
        //from 
        //(select NAT_ORG_CODE, ORG_NAME,PROJECT_ID, ORG_ADDR, ORG_ADDR2,ENT_TYPE_ID,(select ENT_BTYPE_NAME from dic_enterprise_type where ENT_BTYPE_ID=ENT_TYPE_ID) ENT_BTYPE_NAME,CURR_TYPE_ID,INDUSTRY_ID,REG_CAPITAL,REGION_ID_GSFJ from org_info2) a,
        //(select NAT_ORG_CODE, sum(TAX) TAX, sum(QJSR) QJSR from t_tax3 where REP_DATE between " + searchTime[0] + @" and " + searchTime[1] + @" group by NAT_ORG_CODE) b,
        //(select NAT_ORG_CODE, sum(TAX) TAX, sum(QJSR) QJSR from t_tax3 where REP_DATE between " + tbSearchTime[0] + @" and " + tbSearchTime[1] + @" group by NAT_ORG_CODE) c,
        //ndic_industry d,
        //ORG_GF_REGION e
        //where a.nat_org_code=b.nat_org_code(+)
        //and a.nat_org_code=c.nat_org_code(+)
        //and a.INDUSTRY_ID=d.industry_type4_id(+)
        //and a.REGION_ID_GSFJ=e.region_id(+) order by {0} desc
        //) a where 1=1 {1} ", orderBy, where);
        //                return conn.Query<TEntity>(strSql.ToString()).ToList();
        //            }
        //        //}
        //    }

        public List<TEntity> GetAllList(string where, string orderBy = "REG_CAPITAL")
        {
            using (var conn = new DbBase().DbConnecttion)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.AppendFormat(@" 
select * from
( select 
a.*,
d.industry_mtype_id,d.industry_mtype_name,d.industry_type4_id,d.industry_type4_name,
e.region_name
from 
(select NAT_ORG_CODE, ORG_NAME,PROJECT_ID, ORG_ADDR, ORG_ADDR2,ENT_TYPE_ID,
(select ENT_BTYPE_NAME from dic_enterprise_type where ENT_BTYPE_ID=ENT_TYPE_ID) ENT_BTYPE_NAME,
(select curr_name from dic_curr_type where curr_type_dm=CURR_TYPE_ID) CURR_TYPE_ID,
INDUSTRY_ID,
to_char(nvl(REG_CAPITAL,0),'999999990.00') REG_CAPITAL,
REGION_ID_GSFJ from org_info2) a,
ndic_industry d,
ORG_GF_REGION e
where a.INDUSTRY_ID=d.industry_type4_id(+)
and a.REGION_ID_GSFJ=e.region_id(+) order by nvl({0},0) desc
) a where 1=1 {1} ", orderBy, where);
                return conn.Query<TEntity>(strSql.ToString()).ToList();
            }
        }
    }
}
