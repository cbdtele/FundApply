

using System.Collections.Generic;
using System.Text;
using Cydb.Common.Helper;
using Cydb.Repository.Base;
using Cydb.Repository.Entity;

namespace Cydb.Repository.Repository {
    /// <summary>
    /// 从行业角度全指标统计
    /// </summary>
    public class NdicListRepository {
        private readonly int _beginTime;
        private readonly int _endTime;
        private static readonly ISqlBaseOperation SqlBaseOperation = new SqlBaseOperation();

        public NdicListRepository(int beginTime, int endTime) {
            _beginTime = beginTime;
            _endTime = endTime;
        }

        public enum NdicType {
            /// <summary>
            /// 行业门类
            /// </summary>
            First = 1,
            /// <summary>
            /// 行业大类
            /// </summary>
            Second = 2,
            /// <summary>
            /// 行业小类
            /// </summary>
            Third = 3,
            /// <summary>
            /// 行业细类
            /// </summary>
            Fourth = 4
        }
        public List<NdicListEntity> GetList(NdicType ndicType, string typeId = null) {
            StringBuilder str;
            switch (ndicType) {
                case NdicType.First:
                    str = SearchBase(new[] { "INDUSTRY_BTYPE_ID", "INDUSTRY_BTYPE_NAME" }).Append($" and INDUSTRY_MTYPE_ID ='{typeId}' group by INDUSTRY_BTYPE_ID, INDUSTRY_BTYPE_NAME order by decode(TAX,NULL,0,TAX) desc ");
                    return SqlBaseOperation.Query<NdicListEntity>(str.ToString());
                case NdicType.Second:
                    str = SearchBase(new[] { "INDUSTRY_STYPE_ID", "INDUSTRY_STYPE_NAME" }).Append($" and INDUSTRY_BTYPE_ID ='{typeId}' group by INDUSTRY_STYPE_ID, INDUSTRY_STYPE_NAME order by decode(TAX,NULL,0,TAX) desc ");
                    return SqlBaseOperation.Query<NdicListEntity>(str.ToString());
                case NdicType.Third:
                    str = SearchBase(new[] { "INDUSTRY_TYPE4_ID", "INDUSTRY_TYPE4_NAME" }).Append($" and INDUSTRY_STYPE_ID ='{typeId}' group by INDUSTRY_TYPE4_ID, INDUSTRY_TYPE4_NAME order by decode(TAX,NULL,0,TAX) desc ");
                    return SqlBaseOperation.Query<NdicListEntity>(str.ToString());
                default:
                    str = SearchBase(new[] { "INDUSTRY_MTYPE_ID", "INDUSTRY_MTYPE_NAME" }).Append(" group by INDUSTRY_MTYPE_ID, INDUSTRY_MTYPE_NAME order by decode(TAX,NULL,0,TAX) desc ");
                    return SqlBaseOperation.Query<NdicListEntity>(str.ToString());
            }
        }

        private StringBuilder SearchBase(IList<string> columns) {
            var year = TimeHelper.GetYear(_endTime);
            return new StringBuilder($@"
select {columns[0]} ID, {columns[1]} NAME,
sum(TAX) TAX, sum(QJSR) QJSR, sum(GDP) GDP, sum(ZCZJ) ZCZJ, sum(YYSR) YYSR, sum(LRZE) LRZE, sum(CYRY) CYRY, sum(SH_SJ) SH_SJ, sum(NYXFL) NYXFL from 
(select INDUSTRY_MTYPE_ID, INDUSTRY_MTYPE_NAME, INDUSTRY_BTYPE_ID, INDUSTRY_BTYPE_NAME, INDUSTRY_STYPE_ID, INDUSTRY_STYPE_NAME, INDUSTRY_TYPE4_ID, INDUSTRY_TYPE4_NAME from ndic_industry) x,
(select round(sum(TAX)/100000000,2) TAX, round(sum(QJSR)/100000000,2) QJSR, INDUSTRY_ID from T_TAX3 where REP_DATE between {_beginTime} and {_endTime} group by INDUSTRY_ID) a,
(select round(sum(GDP)/10000,2) GDP, HY from T_GDP_YEAR_ENTLIST where REP_DATE={year} group by HY) b,
(select round(sum(ZCZJ)/10000,2) ZCZJ, round(sum(YYSR)/10000,2) YYSR, round(sum(LRZE)/10000,2) LRZE, sum(CYRY) CYRY, INDUSTRY_ID from T_CW_MONTH where FLAG_ORGINFO2=1 and REP_DATE between {_beginTime} and {_endTime} group by INDUSTRY_ID) c,
(select round(sum(SH_SJ)/10000,2) SH_SJ, INDUSTRY_ID from T_SH_YEAR_ENTLIST where FLAG_ORGINFO2=1 and REP_DATE={year} group by INDUSTRY_ID) d,
(select round(sum(NYXFL)/10000,2) NYXFL, INDUSTRY_ID from T_NH_MONTH_ENTLIST where FLAG_ORGINFO2=1 and REP_DATE={_endTime} group by INDUSTRY_ID) e

where x.INDUSTRY_TYPE4_ID=a.INDUSTRY_ID(+)
and x.INDUSTRY_TYPE4_ID=b.hy(+)
and x.INDUSTRY_TYPE4_ID=c.industry_id(+)
and x.INDUSTRY_TYPE4_ID=d.INDUSTRY_ID(+)
and x.INDUSTRY_TYPE4_ID=e.INDUSTRY_ID(+)

");
        }
    }
}
