using Cydb.Repository.Entity;

namespace Cydb.Repository.Repository.EntZdgzFactory.FieldType {
    public class EntZdgzFieldTypeGdp : EntZdgzFieldBase {
        public EntZdgzFieldTypeGdp(EntZdgzRepository.EntZczbChangeDto entRankingDto) : base(entRankingDto) {
        }

        public override SqlBuildSubQuery BuildEntZdgzDto() {
            SqlBuildSubQuery.SelectColumn = $@" nvl(a.targetfield,0) SUMTARGE, nvl(decode(b.targetfield,0,0,round((a.targetfield-b.targetfield)/abs(b.targetfield)*100,2)),0) ZS ";
            SqlBuildSubQuery.SubQuery = $@" ( select nat_org_code, round(sum(GDP)/10,2) targetfield from t_gdp_year_entlist where rep_date={EntZczbDto.BeginTime} group by nat_org_code ) a,
( select nat_org_code, round(sum(GDP)/10,2) targetfield from t_gdp_year_entlist where rep_date={EntZczbDto.TbBeginTime} group by nat_org_code ) b ";
            SqlBuildSubQuery.JoinWhere = $@" and x.nat_org_code=a.nat_org_code(+) and x.nat_org_code=b.nat_org_code(+) 
and nvl(decode(b.targetfield,0,0,round((a.targetfield-b.targetfield)/abs(b.targetfield)*100,2)),0) {UpRate}";
            SqlBuildSubQuery.OrderBy = $@" nvl(decode(b.targetfield,0,0,round((a.targetfield-b.targetfield)/abs(b.targetfield)*100,2)),0) {EntZczbDto.OrderBy} ";
            return SqlBuildSubQuery;
        }
    }
}
