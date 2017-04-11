using System.Collections.Generic;

namespace Cydb.Repository.Repository {
    public interface ITaxQjsrHighchangeRepository {
        /// <summary>
        /// 获取高速增长
        /// </summary>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <param name="targetColumn">目标值</param>
        /// <param name="upordown">up 或者 down</param>
        /// <returns></returns>
        List<object> GetTaxQjsrHighchange(string beginTime, string endTime, string targetColumn, string upordown);
    }
}