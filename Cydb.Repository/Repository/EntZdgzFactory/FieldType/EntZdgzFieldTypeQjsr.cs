using Cydb.Repository.Entity;

namespace Cydb.Repository.Repository.EntZdgzFactory.FieldType {
    public class EntZdgzFieldTypeQjsr : EntZdgzFieldBase {
        public EntZdgzFieldTypeQjsr(EntZdgzRepository.EntZczbChangeDto entRankingDto) : base(entRankingDto) {
        }

        public override SqlBuildSubQuery BuildEntZdgzDto() {
            SqlBuildSubQuery.SelectColumn = $@" nvl(a.targetfield,0) SUMTARGE, nvl(decode(b.targetfield,0,0,round((a.targetfield-b.targetfield)/abs(b.targetfield)*100,2)),0) ZS ";
            SqlBuildSubQuery.SubQuery = $@" ( select nat_org_code, round(sum(qjsr)/10000,2) targetfield from t_tax3 where rep_date between {EntZczbDto.BeginTime} and {EntZczbDto.EndTime} group by nat_org_code ) a,
( select nat_org_code, round(sum(qjsr)/10000,2) targetfield from t_tax3 where rep_date between {EntZczbDto.TbBeginTime} and {EntZczbDto.TbEndTime} group by nat_org_code ) b ";
            SqlBuildSubQuery.JoinWhere = $@" and x.nat_org_code=a.nat_org_code(+) and x.nat_org_code=b.nat_org_code(+) 
and nvl(decode(b.targetfield,0,0,round((a.targetfield-b.targetfield)/abs(b.targetfield)*100,2)),0) {UpRate}";
            SqlBuildSubQuery.OrderBy = $@" nvl(decode(b.targetfield,0,0,round((a.targetfield-b.targetfield)/abs(b.targetfield)*100,2)),0) {EntZczbDto.OrderBy} ";
            return SqlBuildSubQuery;
        }
    }
}
