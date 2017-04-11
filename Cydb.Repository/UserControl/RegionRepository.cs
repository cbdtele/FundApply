using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cydb.Repository.Base;
using Cydb.Repository.UserControl.Base;
using Dapper;

namespace Cydb.Repository.UserControl {
    public class RegionRepository : IUserControlBase {
        /// <summary>
        /// 获取街乡集合
        /// </summary>
        /// <returns></returns>
        public List<dynamic> GetAllList() {
            using (var conn = new DbBase().DbConnecttion) {
                return conn.Query(@" select distinct REGION_NAME, REGION_ID from ORG_GF_REGION  ").ToList();
            }
        }
    }
}
