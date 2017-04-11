using System.Collections.Generic;
using System.Linq;
using Cydb.Repository.Base;

namespace Cydb.Repository.Repository {
    public class TargetFieldRepository : ITargetFieldRepository {
        private static readonly ISqlBaseOperation SqlBaseOperation = new SqlBaseOperation();
        public class TargetFieldDto {
            public string Id { set; get; }
            public string Name { set; get; }
        }
        /// <summary>
        /// 获取主要指标列表
        /// </summary>
        /// <param name="where">过滤条件</param>
        /// <returns></returns>
        public List<TargetFieldDto> GetList(string where = "") {
            return SqlBaseOperation.Query<TargetFieldDto>($" select * from dic_target where 1=1 {where} ").ToList();
        }

    }
}
