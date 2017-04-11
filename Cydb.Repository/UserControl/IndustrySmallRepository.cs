using System.Collections.Generic;
using System.Linq;
using Cydb.Repository.Base;
using Cydb.Repository.UserControl.Base;
using Dapper;

namespace Cydb.Repository.UserControl {
    public class IndustrySmallRepository : IUserControlBase {

        /// <summary>
        /// 获取行业细类集合
        /// </summary>
        /// <returns></returns>
        public List<dynamic> GetAllList() {
            using (var conn = new DbBase().DbConnecttion) {
                return conn.Query(@" select distinct INDUSTRY_TYPE4_ID, INDUSTRY_TYPE4_NAME from ndic_industry ").ToList();
            }
        }
    }
}
