using System;
using Cydb.Repository.Entity;
using Cydb.Repository.Repository.EntRankFactory.FieldType;

namespace Cydb.Repository.Repository.EntRankFactory {
    /// <summary>
    /// 构造基类工厂
    /// </summary>
    public abstract class EntRankFactoryBase {
        protected EntRankFieldTypeBase EntRankFieldTypeBase;

        protected EntRankFactoryBase(EntRankingRepository.EntRankingDto entRankingDto) {
            switch (entRankingDto.EnumTargetField) {
                case EnumTargetField.Tax:
                    EntRankFieldTypeBase = new EntRankFieldTypeTax(entRankingDto);
                    break;
                case EnumTargetField.Qjsr:
                    EntRankFieldTypeBase = new EntRankFieldTypeQjsr(entRankingDto);
                    break;
                case EnumTargetField.Gdp:
                    EntRankFieldTypeBase = new EntRankFieldTypeGdp(entRankingDto);
                    break;
                case EnumTargetField.Pl:
                    throw new Exception("社会消费品零售额指标暂无");
                case EnumTargetField.Gdzc:
                    throw new Exception("全社会固定资产投资指标暂无");
                case EnumTargetField.Cyry:
                    EntRankFieldTypeBase = new EntRankFieldTypeCyry(entRankingDto);
                    break;
                case EnumTargetField.Yysr:
                    EntRankFieldTypeBase = new EntRankFieldTypeYysr(entRankingDto);
                    break;
                case EnumTargetField.Zczj:
                    EntRankFieldTypeBase = new EntRankFieldTypeZczj(entRankingDto);
                    break;
                case EnumTargetField.Lrze:
                    EntRankFieldTypeBase = new EntRankFieldTypeLrze(entRankingDto);
                    break;
                case EnumTargetField.Nh:
                    EntRankFieldTypeBase = new EntRankFieldTypeNh(entRankingDto);
                    break;
                case EnumTargetField.Sh:
                    EntRankFieldTypeBase = new EntRankFieldTypeSh(entRankingDto);
                    break;
                default:
                    throw new Exception("未知指标查询指令");
            }
        }

        /// <summary>
        /// 获取构造结果
        /// </summary>
        /// <returns></returns>
        public abstract SqlBuildSubQuery GetSqlBuildSubQuery();
    }
}