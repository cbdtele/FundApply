using Cydb.Repository.Entity;

namespace Cydb.Repository.Repository.EntRankFactory.FieldType {
    /// <summary>
    /// 企业排名 - GDP
    /// </summary>
    public class EntRankFieldTypeGdp : EntRankFieldTypeBase {
        public EntRankFieldTypeGdp(EntRankingRepository.EntRankingDto entRankingDto) : base(entRankingDto) {
        }

        public override SqlBuildSubQuery BuildEntRankingDto() {
            SqlBuildSubQuery.SubQuery = $@" ( select NAT_ORG_CODE, round(sum(GDP)/10,2) targetfield from t_gdp_year_entlist where rep_date={EntRankingDto.BeginTime} group by NAT_ORG_CODE ) a,
( select NAT_ORG_CODE, round(sum(GDP)/10,2) targetfield from t_gdp_year_entlist where rep_date={EntRankingDto.TbBeginTime} group by NAT_ORG_CODE ) b ";
            SqlBuildSubQuery.JoinWhere = @" and x.nat_org_code=a.nat_org_code(+) and x.nat_org_code=b.nat_org_code(+) ";
            SqlBuildSubQuery.OrderBy = $@" {SqlBuildSubQuery.SelectColumn} {EntRankingDto.OrderBy} ";
            SqlBuildSubQuery.Paging = $" and r between {EntRankingDto.BeginPagNum} and {EntRankingDto.EndPagNum} ";
            return SqlBuildSubQuery;
        }
    }
}
