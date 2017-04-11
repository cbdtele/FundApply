using System.Collections.Generic;
using Cydb.Repository.Base;

namespace Cydb.Repository.Repository
{
    public interface IOneTwoThreeIndustryRepository
    {
        List<dynamic> GetTableForSummary(string proName, OracleDynamicParameters data);
        List<dynamic> GetOneTwoThreeList(string[] fields, string strWhere, string searchField, string groupby,
            string orderby);
        List<dynamic> GetGetOneTwoThreeEntList(string where);
    }
}