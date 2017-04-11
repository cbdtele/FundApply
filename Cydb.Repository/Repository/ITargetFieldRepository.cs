using System.Collections.Generic;

namespace Cydb.Repository.Repository {
    public interface ITargetFieldRepository {
        /// <summary>
        /// 获取主要指标列表
        /// </summary>
        /// <param name="where">过滤条件</param>
        /// <returns></returns>
        List<TargetFieldRepository.TargetFieldDto> GetList(string where = "");
    }
}