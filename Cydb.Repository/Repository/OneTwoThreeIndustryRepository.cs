using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cydb.Repository.Base;

namespace Cydb.Repository.Repository {
    public class OneTwoThreeIndustryRepository : IOneTwoThreeIndustryRepository {
        private readonly ISqlBaseOperation _sqlBaseOperation = new SqlBaseOperation();

        public List<dynamic> GetTableForSummary(string proName, OracleDynamicParameters data) {
            return _sqlBaseOperation.ExecuteProcedure(proName, data).ToList();
        }

        public List<dynamic> GetOneTwoThreeList(string[] fields, string strWhere, string searchField, string groupby, string orderby) {
            StringBuilder strSql = new StringBuilder($" select {searchField} ,count(*) numbers, ");
            Func<string, string> buildStr = field => $" sum(nvl({field}, 0)) {field}, sum(decode({field}, 0, 0, 1)) {field}entnum, ";
            foreach (var field in fields) {
                strSql.Append(buildStr(field));
            }
            var str = strSql.ToString();
            strSql = new StringBuilder(str.Remove(str.LastIndexOf(",", StringComparison.OrdinalIgnoreCase), 1));
            strSql.Append($" from t_eco_year_entlist a,dic_123c b, ndic_industry c where a.flag_3c=b.id(+) and a.INDUSTRY_ID=c.industry_type4_id(+) and a.flag_3c is not null {strWhere} group by {groupby} order by {orderby} ");
            return _sqlBaseOperation.Query(strSql.ToString()).ToList();
        }

        public List<dynamic> GetGetOneTwoThreeEntList(string where) {
            return _sqlBaseOperation.Query(@" select a.* from t_eco_year_entlist a, dic_123c b, ndic_industry c
 where a.flag_3c = b.id(+) and a.INDUSTRY_ID = c.industry_type4_id(+) and a.flag_3c is not null " + where).ToList();
        }

    }
}
