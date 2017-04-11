using System.Collections.Generic;

namespace Cydb.Repository.Repository {
    public interface IEntZczbChangeRepository {
        /// <summary>
        /// 获取企业变动状况列表（注册资产排序）
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        List<object> GetEntZczjList(EntZczbChangeRepository.EntZczbChangeDto dto);
        /// <summary>
        /// 获取企业变动状况列表总数（注册资产排序）
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        int GetEntZczjCount(EntZczbChangeRepository.EntZczbChangeDto dto);
    }
}