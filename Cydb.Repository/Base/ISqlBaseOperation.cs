using System.Collections.Generic;

namespace Cydb.Repository.Base {
    public interface ISqlBaseOperation {
        /// <summary>
        /// 查询一条记录
        /// </summary>
        /// <returns></returns>
        T Get<T>(string str, object param = null);
        dynamic Get(string str, object param = null);


        /// <summary>
        /// 执行查询操作
        /// </summary>
        /// <returns></returns>
        List<T> Query<T>(string str, object param = null);
        List<dynamic> Query(string str, object param = null);

        /// <summary>
        /// 执行Oracle存储过程
        /// </summary>
        /// <param name="procedureName">存储过程名</param>
        /// <param name="oracleDynamicParameters">参数</param>
        /// <returns></returns>
        List<T> ExecuteProcedure<T>(string procedureName, OracleDynamicParameters oracleDynamicParameters);
        List<dynamic> ExecuteProcedure(string procedureName, OracleDynamicParameters oracleDynamicParameters);
    }
}