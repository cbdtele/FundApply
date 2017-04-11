using System.Collections.Generic;

namespace Cydb.Repository.Repository {
    public interface IEntZdgzRepository {
        /// <summary>
        /// 获取重点关注企业列表总数（注册资产排序）
        /// </summary>
        /// <returns></returns>
        int GetEntZdgzCount();

        /// <summary>
        /// 获取重点关注企业列表（注册资产排序）
        /// </summary>
        /// <returns></returns>
        List<object> GetEntZdgzList();

    }
}