using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cydb.Common.Helper;
using Cydb.Repository.Base;
using Cydb.Repository.Entity;
using Cydb.Repository.Repository.EntZdgzFactory;

namespace Cydb.Repository.Repository {

    /// <summary>
    /// 企业状况 - 重点关注企业SQL仓库
    /// </summary>
    public class EntZdgzRepository : IEntZdgzRepository {
        private static readonly ISqlBaseOperation SqlBaseOperation = new SqlBaseOperation();
        private readonly SqlBuildSubQuery _sqlBuildSubQuery;

        public EntZdgzRepository(EntZczbChangeDto entZczbChangeDto) {
            EntZdgzFactoryBase entZdgzFactory = new EntZdgzFactory.EntZdgzFactory(entZczbChangeDto);
            _sqlBuildSubQuery = entZdgzFactory.GetSqlBuildSubQuery();
        }
        /// <summary>
        /// 重点关注企业的数据传输对象
        /// </summary>
        public class EntZczbChangeDto : EntFactoryEntity {
            public EntZczbChangeDto(string beginTime, string endTime, int enumTargetField, int upRate, string orderBy, int page, int rows) : base(beginTime, endTime, enumTargetField, orderBy, page, rows) {
                UpRate = upRate;
                TbBeginTime = BeginTime?.YearSubtract();
            }

            /// <summary>
            /// 查询策略
            /// </summary>
            public int UpRate { get; }
        }

        /// <summary>
        /// 获取重点关注企业列表总数
        /// </summary>
        /// <returns></returns>
        public int GetEntZdgzCount() {
            //            return SqlBaseOperation.Query<int>($@" 
            //select count(*) from 
            //( select * from org_info2 ) x,
            //( select nat_org_code, round(sum(tax)/10000,2) tax from t_tax3 where rep_date between {dto.BeginTime} and {dto.EndTime} group by nat_org_code ) a,
            //( select nat_org_code, round(sum(tax)/10000,2) tax from t_tax3 where rep_date between {dto.TbBeginTime} and {dto.TbEndTime} group by nat_org_code ) b
            //where x.nat_org_code=a.nat_org_code(+)
            //and x.nat_org_code=b.nat_org_code(+)
            //and decode(b.tax,0,0,round((a.tax-b.tax)/b.tax*100,2))>{dto.SelectType}
            //order by decode(b.tax,0,0,round((a.tax-b.tax)/b.tax*100,2)) desc ").SingleOrDefault();

            var strSql = new StringBuilder($@" 
select count(*)
from
( select * from org_info2 ) x,
( select * from ndic_industry ) x1,
{_sqlBuildSubQuery.SubQuery}
where x.INDUSTRY_ID=x1.industry_type4_id(+)
{_sqlBuildSubQuery.JoinWhere}
order by {_sqlBuildSubQuery.OrderBy} ");
            return SqlBaseOperation.Query<int>(strSql.ToString()).SingleOrDefault();
        }

        /// <summary>
        /// 获取重点关注企业列表
        /// </summary>
        /// <returns></returns>
        public List<dynamic> GetEntZdgzList() {
            //            var strSql = new StringBuilder($@" 
            //select * from (
            //select row_number() over(order by (nvl(decode(b.tax,0,0,round((a.tax-b.tax)/b.tax*100,2)),0)) {dto.OrderBy}) r, x.NAT_ORG_CODE, x.ORG_NAME, ORG_ADDR, ORG_ADDR2, INDUSTRY_ID, CURR_TYPE_ID, x1.industry_mtype_name,
            //nvl(a.tax,0) SUMTARGE,
            //nvl(decode(b.tax,0,0,round((a.tax-b.tax)/b.tax*100,2)),0) ZS from 
            //( select * from org_info2 ) x,
            //( select * from ndic_industry ) x1,
            //( select nat_org_code, round(sum(tax)/10000,2) tax from t_tax3 where rep_date between {dto.BeginTime} and {dto.EndTime} group by nat_org_code ) a,
            //( select nat_org_code, round(sum(tax)/10000,2) tax from t_tax3 where rep_date between {dto.TbBeginTime} and {dto.TbEndTime} group by nat_org_code ) b
            //where x.nat_org_code=a.nat_org_code(+)
            //and x.INDUSTRY_ID=x1.Industry_Type4_Id(+)
            //and x.nat_org_code=b.nat_org_code(+)
            //and decode(b.tax,0,0,round((a.tax-b.tax)/b.tax*100,2))>
            //order by decode(b.tax,0,0,round((a.tax-b.tax)/b.tax*100,2)) {dto.OrderBy}) ");

            var strSql = new StringBuilder($@" 
select * from (
select row_number() over(ORDER BY {_sqlBuildSubQuery.OrderBy} ) r, x.nat_org_code,x.org_name,x1.industry_mtype_name,
{_sqlBuildSubQuery.SelectColumn} ,
ORG_ADDR, ORG_ADDR2, BIZ_SCOPE, REG_CAPITAL, X2.CURR_NAME
from
( select * from org_info2 ) x,
( select * from ndic_industry ) x1,
( select CURR_TYPE_DM, CURR_NAME from dic_curr_type ) x2,
{_sqlBuildSubQuery.SubQuery}
where x.INDUSTRY_ID=x1.industry_type4_id(+) and x.curr_type_id=x2.curr_type_dm(+)  
{_sqlBuildSubQuery.JoinWhere} order by {_sqlBuildSubQuery.OrderBy} ) where 1=1 {_sqlBuildSubQuery.Paging} ");
            return SqlBaseOperation.Query(strSql.ToString());
        }
    }
}
