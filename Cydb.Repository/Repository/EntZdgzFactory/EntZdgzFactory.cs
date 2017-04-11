using Cydb.Repository.Entity;

namespace Cydb.Repository.Repository.EntZdgzFactory {
    /// <summary>
    /// 重点关注企业 构造工厂
    /// </summary>
    public class EntZdgzFactory : EntZdgzFactoryBase {
        public EntZdgzFactory(EntZdgzRepository.EntZczbChangeDto entZczbChangeDto) : base(entZczbChangeDto) {
        }

        public override SqlBuildSubQuery GetSqlBuildSubQuery() {
            return EntRankFieldTypeBase.BuildEntZdgzDto();
        }
    }
}
