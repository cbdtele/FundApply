using System.Collections.Generic;
using System.Linq;
using Cydb.Repository.Base;
using Cydb.Repository.UserControl.Base;
using Dapper;

namespace Cydb.Repository.UserControl {
    public class IndustryRepository : IUserControlBase {

        /// <summary>
        /// 获取行业集合
        /// </summary>
        /// <returns></returns>
        public List<dynamic> GetAllList() {
            using (var conn = new DbBase().DbConnecttion) {
                return conn.Query(@"select distinct INDUSTRY_MTYPE_ID, INDUSTRY_MTYPE_NAME from ndic_industry").ToList();
            }
        }
    }
}
