using System.Collections.Generic;

namespace Cydb.Repository.Repository {
    public interface IEntRankingRepository {
        /// <summary>
        /// 根据时间、查询指标、查询策略、排序方式来获取企业排名列表
        /// </summary>
        /// <returns></returns>
        List<object> GetListByWhere();

        /// <summary>
        /// 获取查询的所有记录数
        /// </summary>
        /// <returns></returns>
        int GetListCount();
    }
}