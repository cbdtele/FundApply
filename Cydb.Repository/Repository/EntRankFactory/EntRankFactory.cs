using Cydb.Repository.Entity;

namespace Cydb.Repository.Repository.EntRankFactory {
    /// <summary>
    /// 企业排名查询指标语句构造工厂
    /// </summary>
    public class EntRankFactory : EntRankFactoryBase {
        public EntRankFactory(EntRankingRepository.EntRankingDto entRankingDto) : base(entRankingDto) {
        }

        /// <summary>
        /// 获取构造结果
        /// </summary>
        /// <returns></returns>
        public override SqlBuildSubQuery GetSqlBuildSubQuery() {
            return EntRankFieldTypeBase.BuildEntRankingDto();
        }
    }
}
