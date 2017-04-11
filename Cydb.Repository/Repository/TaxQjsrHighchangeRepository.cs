using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using Cydb.Repository.Base;

namespace Cydb.Repository.Repository {
    /// <summary>
    /// 税收和财政收入高速变化 仓储
    /// </summary>
    public class TaxQjsrHighchangeRepository : ITaxQjsrHighchangeRepository
    {
        private readonly ISqlBaseOperation _sqlBaseOperation = new SqlBaseOperation();
        /// <summary>
        /// 获取高速增长
        /// </summary>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <param name="targetColumn">目标值</param>
        /// <param name="upordown">up 或者 down</param>
        /// <returns></returns>
        public List<dynamic> GetTaxQjsrHighchange(string beginTime, string endTime, string targetColumn, string upordown) {
            var oracleDynamicParameters = new OracleDynamicParameters();
            oracleDynamicParameters.Add("beginTime", beginTime);
            oracleDynamicParameters.Add("endTime", endTime);
            oracleDynamicParameters.Add("targetColumn", targetColumn);
            oracleDynamicParameters.Add("upordown", upordown);
            oracleDynamicParameters.Add("vCur", OracleType.Cursor, ParameterDirection.Output);
            return _sqlBaseOperation.ExecuteProcedure("p_tax_qjsr_highchange", oracleDynamicParameters);
        }
    }
}
