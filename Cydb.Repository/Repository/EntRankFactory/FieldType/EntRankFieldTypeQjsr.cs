using Cydb.Repository.Entity;

namespace Cydb.Repository.Repository.EntRankFactory.FieldType {
    /// <summary>
    /// 企业排名 - 财政收入
    /// </summary>
    public class EntRankFieldTypeQjsr : EntRankFieldTypeBase {
        public EntRankFieldTypeQjsr(EntRankingRepository.EntRankingDto entRankingDto) : base(entRankingDto) {
        }

        public override SqlBuildSubQuery BuildEntRankingDto() {
            SqlBuildSubQuery.SubQuery = $@" ( select NAT_ORG_CODE,round(sum(nvl(qjsr,0))/10000,2) targetfield from t_tax3 where rep_date between {EntRankingDto.BeginTime} and {EntRankingDto.EndTime} group by NAT_ORG_CODE ) a,
( select NAT_ORG_CODE,round(sum(nvl(qjsr,0))/10000,2) targetfield from t_tax3 where rep_date between {EntRankingDto.TbBeginTime} and {EntRankingDto.TbEndTime} group by NAT_ORG_CODE ) b ";
            SqlBuildSubQuery.JoinWhere = @" and x.nat_org_code=a.nat_org_code(+) and x.nat_org_code=b.nat_org_code(+) ";
            SqlBuildSubQuery.OrderBy = $@" {SqlBuildSubQuery.SelectColumn} {EntRankingDto.OrderBy} ";
            SqlBuildSubQuery.Paging = $" and r between {EntRankingDto.BeginPagNum} and {EntRankingDto.EndPagNum} ";
            return SqlBuildSubQuery;
        }
    }
}
