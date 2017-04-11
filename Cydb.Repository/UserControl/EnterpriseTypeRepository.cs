using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cydb.Repository.Base;
using Cydb.Repository.UserControl.Base;
using Dapper;

namespace Cydb.Repository.UserControl {
    public class EnterpriseTypeRepository : IUserControlBase {

        /// <summary>
        /// 获取企业类型集合
        /// </summary>
        /// <returns></returns>
        public List<dynamic> GetAllList() {
            using (var conn = new DbBase().DbConnecttion) {
                return conn.Query(@" select distinct ENT_BTYPE_ID, ENT_BTYPE_NAME from DIC_ENTERPRISE_TYPE ").ToList();
            }
        }
    }
}
