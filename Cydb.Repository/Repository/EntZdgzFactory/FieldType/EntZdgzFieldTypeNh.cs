﻿using System;
using Cydb.Repository.Entity;

namespace Cydb.Repository.Repository.EntZdgzFactory.FieldType {
    public class EntZdgzFieldTypeNh : EntZdgzFieldBase {
        public EntZdgzFieldTypeNh(EntZdgzRepository.EntZczbChangeDto entRankingDto) : base(entRankingDto) {
        }

        public override SqlBuildSubQuery BuildEntZdgzDto() {
            SqlBuildSubQuery.SelectColumn = $@" nvl(a.targetfield,0) SUMTARGE, nvl(decode(b.targetfield,0,0,round((a.targetfield-b.targetfield)/abs(b.targetfield)*100,2)),0) ZS ";
            SqlBuildSubQuery.SubQuery = $@" ( select NAT_ORG_CODE, round(sum(NYXFL)/10000,2) targetfield from T_NH_MONTH_ENTLIST where rep_date={EntZczbDto.BeginTime} and FLAG_ORGINFO2=1 group by NAT_ORG_CODE ) a,
( select NAT_ORG_CODE, round(sum(NYXFL)/10000,2) targetfield from T_NH_MONTH_ENTLIST where rep_date={EntZczbDto.TbBeginTime} and FLAG_ORGINFO2=1 group by NAT_ORG_CODE ) b ";
            SqlBuildSubQuery.JoinWhere = $@" and x.nat_org_code=a.nat_org_code(+) and x.nat_org_code=b.nat_org_code(+) 
and nvl(decode(b.targetfield,0,0,round((a.targetfield-b.targetfield)/abs(b.targetfield)*100,2)),0) {UpRate}";
            SqlBuildSubQuery.OrderBy = $@" nvl(decode(b.targetfield,0,0,round((a.targetfield-b.targetfield)/abs(b.targetfield)*100,2)),0) {EntZczbDto.OrderBy} ";
            return SqlBuildSubQuery;
        }
    }
}
