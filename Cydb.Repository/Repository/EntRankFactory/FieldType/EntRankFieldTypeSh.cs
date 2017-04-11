using Cydb.Repository.Entity;

namespace Cydb.Repository.Repository.EntRankFactory.FieldType {
    /// <summary>
    /// 企业排名 - 水耗
    /// </summary>
    public class EntRankFieldTypeSh : EntRankFieldTypeBase {
        public EntRankFieldTypeSh(EntRankingRepository.EntRankingDto entRankingDto) : base(entRankingDto) {
        }

        public override SqlBuildSubQuery BuildEntRankingDto() {
            SqlBuildSubQuery.SubQuery = $@" ( select NAT_ORG_CODE, round(sum(SH_SJ)/10000,2) targetfield from T_SH_YEAR_ENTLIST where rep_date={EntRankingDto.BeginTime} and FLAG_ORGINFO2=1 group by NAT_ORG_CODE ) a,
( select NAT_ORG_CODE, round(sum(SH_SJ)/10000,2) targetfield from T_SH_YEAR_ENTLIST where rep_date={EntRankingDto.TbBeginTime} and FLAG_ORGINFO2=1 group by NAT_ORG_CODE ) b ";
            SqlBuildSubQuery.JoinWhere = @" and x.nat_org_code=a.nat_org_code(+) and x.nat_org_code=b.nat_org_code(+) ";
            SqlBuildSubQuery.OrderBy = $@" {SqlBuildSubQuery.SelectColumn} {EntRankingDto.OrderBy} ";
            SqlBuildSubQuery.Paging = $" and r between {EntRankingDto.BeginPagNum} and {EntRankingDto.EndPagNum} ";
            return SqlBuildSubQuery;
        }
    }
}
