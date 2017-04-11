using System;
using Cydb.Repository.Entity;

namespace Cydb.Repository.Repository.EntRankFactory.FieldType {
    /// <summary>
    /// 指标基类
    /// </summary>
    public abstract class EntRankFieldTypeBase {
        protected EntRankingRepository.EntRankingDto EntRankingDto;
        protected SqlBuildSubQuery SqlBuildSubQuery = new SqlBuildSubQuery();
        public abstract SqlBuildSubQuery BuildEntRankingDto();

        protected EntRankFieldTypeBase(EntRankingRepository.EntRankingDto entRankingDto) {
            EntRankingDto = entRankingDto;

            switch (EntRankingDto.Strategy) {
                case EnumStrategy.Targetsum:
                    SqlBuildSubQuery.SelectColumn = " nvl(A.TARGETFIELD,0) ";
                    break;
                case EnumStrategy.Zs:
                    SqlBuildSubQuery.SelectColumn = " DECODE(NVL(B.TARGETFIELD,0),0,0,ROUND(((NVL(A.TARGETFIELD,0)-B.TARGETFIELD)/NVL(B.TARGETFIELD,0))*100,2)) ";
                    break;
                case EnumStrategy.Zl:
                    SqlBuildSubQuery.SelectColumn = " (NVL(A.TARGETFIELD,0)-NVL(B.TARGETFIELD,0))  ";
                    break;
                default:
                    throw new Exception("企业排名未知查询策略命令");
            }
        }
    }
}
