using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;

namespace Cydb.Repository.Base {
    public class SqlBaseOperation : ISqlBaseOperation {
        /// <summary>
        /// 查询一条记录
        /// </summary>
        /// <returns></returns>
        public T Get<T>(string str, object param = null) {
            using (var conn = new DbBase().DbConnecttion) {
                return conn.Query<T>(str, param).SingleOrDefault();
            }
        }

        /// <summary>
        /// 查询一条记录
        /// </summary>
        /// <returns></returns>
        public dynamic Get(string str, object param = null) {
            using (var conn = new DbBase().DbConnecttion) {
                return conn.Query(str, param).SingleOrDefault();
            }
        }

        /// <summary>
        /// 执行查询操作
        /// </summary>
        /// <returns></returns>
        public List<T> Query<T>(string str, object param = null) {
            using (var conn = new DbBase().DbConnecttion) {
                return conn.Query<T>(str, param).ToList();
            }
        }

        /// <summary>
        /// 执行查询操作
        /// </summary>
        /// <returns></returns>
        public List<dynamic> Query(string str, object param = null) {
            using (var conn = new DbBase().DbConnecttion) {
                return conn.Query(str, param).ToList();
            }
        }

        /// <summary>
        /// 执行Oracle存储过程
        /// </summary>
        /// <param name="procedureName">存储过程名</param>
        /// <param name="oracleDynamicParameters">参数</param>
        /// <returns></returns>
        public List<T> ExecuteProcedure<T>(string procedureName, OracleDynamicParameters oracleDynamicParameters) {
            using (var conn = new DbBase().DbConnecttion) {
                return conn.Query<T>(procedureName, oracleDynamicParameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        /// <summary>
        /// 执行Oracle存储过程
        /// </summary>
        /// <param name="procedureName">存储过程名</param>
        /// <param name="oracleDynamicParameters">参数</param>
        /// <returns></returns>
        public List<dynamic> ExecuteProcedure(string procedureName, OracleDynamicParameters oracleDynamicParameters) {
            using (var conn = new DbBase().DbConnecttion) {
                return conn.Query(procedureName, oracleDynamicParameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }

    }
}
