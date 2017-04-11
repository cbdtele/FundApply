using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cydb.Repository.Base;
using Cydb.Repository.Entity;

namespace Cydb.Repository.Repository {
    /// <summary>
    /// 企业注册资本变动情况
    /// </summary>
    public class EntZczbChangeRepository : IEntZczbChangeRepository {
        private static readonly ISqlBaseOperation SqlBaseOperation = new SqlBaseOperation();
        /// <summary>
        /// 企业注册资本变动情况的数据传输对象
        /// </summary>
        public class EntZczbChangeDto : BaseTablePaging<EntZczbChangeDto> {
            public EntZczbChangeDto(string orderBy = "desc", int page = 1, int rows = 10) : base(page, rows) {
                OrderBy = orderBy;
            }

            /// <summary>
            /// 排序方式 默认降序
            /// </summary>
            public string OrderBy { get; }
        }

        /// <summary>
        /// 获取企业变动状况列表总数（注册资产排序）
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public int GetEntZczjCount(EntZczbChangeDto dto) {
            return SqlBaseOperation.Query<int>($@" 
select count(*)  from
( select REG_CAPITAL, NAT_ORG_CODE, ORG_NAME, ORG_ADDR, ORG_ADDR2,INDUSTRY_ID,CURR_TYPE_ID from org_info2 ) a,
( select * from ndic_industry ) b
where a.INDUSTRY_ID=b.Industry_Type4_Id(+) ").SingleOrDefault();
        }

        /// <summary>
        /// 获取企业变动状况列表（注册资产排序）
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public List<dynamic> GetEntZczjList(EntZczbChangeDto dto) {
            StringBuilder strsql = new StringBuilder($@" 
select * from (
select row_number() over(order by nvl(a.REG_CAPITAL,0) {dto.OrderBy}) r, round(nvl(REG_CAPITAL,0),2) REG_CAPITAL, NAT_ORG_CODE, ORG_NAME, ORG_ADDR, ORG_ADDR2, INDUSTRY_ID, X.CURR_NAME, b.industry_mtype_name from
( select CURR_TYPE_DM, CURR_NAME from dic_curr_type ) x,
( select REG_CAPITAL, NAT_ORG_CODE, ORG_NAME, ORG_ADDR, ORG_ADDR2,INDUSTRY_ID,CURR_TYPE_ID from org_info2 ) a,
( select * from ndic_industry ) b
where a.INDUSTRY_ID=b.Industry_Type4_Id(+) and a.curr_type_id=x.curr_type_dm(+)  
order by nvl(a.REG_CAPITAL,0) {dto.OrderBy}
) where r between {dto.BeginPagNum} and {dto.EndPagNum} ");
            return SqlBaseOperation.Query(strsql.ToString());
        }
    }
}
