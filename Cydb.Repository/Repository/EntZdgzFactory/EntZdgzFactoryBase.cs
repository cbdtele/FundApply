using System;
using Cydb.Repository.Entity;
using Cydb.Repository.Repository.EntZdgzFactory.FieldType;

namespace Cydb.Repository.Repository.EntZdgzFactory {
    public abstract class EntZdgzFactoryBase {
        protected EntZdgzFieldBase EntRankFieldTypeBase;

        protected EntZdgzFactoryBase(EntZdgzRepository.EntZczbChangeDto entZczbChangeDto) {
            switch (entZczbChangeDto.EnumTargetField) {
                case EnumTargetField.Tax:
                    EntRankFieldTypeBase = new EntZdgzFieldTypeTax(entZczbChangeDto);
                    break;
                case EnumTargetField.Qjsr:
                    EntRankFieldTypeBase = new EntZdgzFieldTypeQjsr(entZczbChangeDto);
                    break;
                case EnumTargetField.Gdp:
                    EntRankFieldTypeBase = new EntZdgzFieldTypeGdp(entZczbChangeDto);
                    break;
                case EnumTargetField.Pl:
                    throw new Exception("社会消费品零售额指标暂无");
                case EnumTargetField.Gdzc:
                    throw new Exception("全社会固定资产投资指标暂无");
                case EnumTargetField.Cyry:
                    EntRankFieldTypeBase = new EntZdgzFieldTypeCyry(entZczbChangeDto);
                    break;
                case EnumTargetField.Yysr:
                    EntRankFieldTypeBase = new EntZdgzFieldTypeYysr(entZczbChangeDto);
                    break;
                case EnumTargetField.Zczj:
                    EntRankFieldTypeBase = new EntZdgzFieldTypeZczj(entZczbChangeDto);
                    break;
                case EnumTargetField.Lrze:
                    EntRankFieldTypeBase = new EntZdgzFieldTypeLrze(entZczbChangeDto);
                    break;
                case EnumTargetField.Nh:
                    EntRankFieldTypeBase = new EntZdgzFieldTypeNh(entZczbChangeDto);
                    break;
                case EnumTargetField.Sh:
                    EntRankFieldTypeBase = new EntZdgzFieldTypeSh(entZczbChangeDto);
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
