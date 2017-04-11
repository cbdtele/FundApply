using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cydb.Common.Helper;
using Cydb.Repository.Base;
using Cydb.Repository.Entity;
using Cydb.Repository.Repository.EntRankFactory;

namespace Cydb.Repository.Repository {
    /// <summary>
    /// 企业排名模块仓库
    /// </summary>
    public class EntRankingRepository : IEntRankingRepository {
        private static readonly ISqlBaseOperation SqlBaseOperation = new SqlBaseOperation();
        private readonly SqlBuildSubQuery _sqlBuildSubQuery;

        public EntRankingRepository(EntRankingDto entRankingDto) {
            EntRankFactoryBase entRankFactory = new EntRankFactory.EntRankFactory(entRankingDto);
            _sqlBuildSubQuery = entRankFactory.GetSqlBuildSubQuery();
        }

        /// <summary>
        /// 查询企业排名的数据传输对象
        /// </summary>
        public class EntRankingDto : EntFactoryEntity {
            public EntRankingDto(string beginTime, string endTime, int enumTargetField, int strategy, string orderBy, int page, int rows) : base(beginTime, endTime, enumTargetField, orderBy, page, rows) {
                Strategy = (EnumStrategy)strategy;
                TbBeginTime = BeginTime?.YearSubtract();
            }

            /// <summary>
            /// 查询策略
            /// </summary>
            public EnumStrategy Strategy { get; }
        }

        /// <summary>
        /// 获取查询的所有记录数
        /// </summary>
        /// <returns></returns>
        public int GetListCount() {
            var strSql = new StringBuilder($@" 
select count(*)
from
( select * from org_info2 ) x,
( select * from ndic_industry ) x1,
{_sqlBuildSubQuery.SubQuery}
where x.INDUSTRY_ID=x1.industry_type4_id(+)
{_sqlBuildSubQuery.JoinWhere}
order by {_sqlBuildSubQuery.OrderBy} ");
            return SqlBaseOperation.Query<int>(strSql.ToString()).Single();
        }

        /// <summary>
        /// 根据时间、查询指标、查询策略、排序方式来获取企业排名列表
        /// </summary>
        /// <returns></returns>
        public List<dynamic> GetListByWhere() {
            var strSql = new StringBuilder($@" 
select * from (
select row_number() over(ORDER BY {_sqlBuildSubQuery.OrderBy} ) r, x.nat_org_code,x.org_name,x1.industry_mtype_name,
{_sqlBuildSubQuery.SelectColumn} TARGETFIELD,
ORG_ADDR, ORG_ADDR2, BIZ_SCOPE, round(REG_CAPITAL,2) REG_CAPITAL, X2.CURR_NAME
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
