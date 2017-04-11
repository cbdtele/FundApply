using System;
using Cydb.Repository.Entity;

namespace Cydb.Repository.Repository.EntZdgzFactory.FieldType {
    public abstract class EntZdgzFieldBase {
        /// <summary>
        /// 同比增长阀值
        /// </summary>
        protected string UpRate;
        protected EntZdgzRepository.EntZczbChangeDto EntZczbDto;
        protected SqlBuildSubQuery SqlBuildSubQuery = new SqlBuildSubQuery();
        public abstract SqlBuildSubQuery BuildEntZdgzDto();
        protected EntZdgzFieldBase(EntZdgzRepository.EntZczbChangeDto entRankingDto) {
            EntZczbDto = entRankingDto;
            //服务前端缓存中分页，
            //SqlBuildSubQuery.Paging = $" and r between {EntZczbDto.BeginPagNum} and {EntZczbDto.EndPagNum} ";

            switch (EntZczbDto.UpRate) {
                case 1:
                    //一年增长超过30%
                    UpRate = " >=30 ";
                    break;
                case 2:
                    //两年增长超过20%
                    UpRate = " >=20 ";
                    break;
                case 3:
                    //三年增长超过10%
                    UpRate = " >=10 ";
                    break;
                default:
                    throw new Exception("重点关注企业未知查询策略命令");
            }
        }
    }
}
