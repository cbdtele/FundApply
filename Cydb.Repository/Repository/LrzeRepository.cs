using Cydb.Common.Helper;
using Cydb.Repository.Base;
using System.Collections.Generic;
using System.Text;
namespace Cydb.Repository.Repository
{
   public class LrzeRepository:ILrzeRepository
    {
        private static readonly ISqlBaseOperation SqlBaseOperation = new SqlBaseOperation();
        /// <summary>
        /// 资产总计、同比增速
        /// </summary>
        /// <param name="beginTime"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<dynamic> LRZE(string beginTime, string type)
        {
            string beginTime_Tq = beginTime.YearSubtract();
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"select a.entnum,a.lrze,b.lrze,decode(b.lrze,0,0,round((a.lrze-b.lrze)*100/b.lrze,2)) tb from
(select count(1) entnum, round(sum(nvl(lrze,0)/10000),2) lrze from t_cw_month
where rep_date = {0} and flag_orginfo2=1 and type in (select * from table(strsplit(GetFalg_Type({2})))) and nvl(lrze,0)<>0 ) a
,
(select count(1) entnum, round(sum(nvl(lrze,0)/10000),2) lrze from t_cw_month
where rep_date = {1} and flag_orginfo2=1 and type in (select * from table(strsplit(GetFalg_Type({2})))) and nvl(lrze,0)<>0) b"
, beginTime, beginTime_Tq, type);
            return SqlBaseOperation.Query(strSql.ToString());
        }

        /// <summary>
        /// 总额
        /// </summary>
        /// <param name="beginTime"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<dynamic> Chart01(string beginTime, string type)
        {
            var beginTime_year = TimeHelper.GetYear(beginTime);
            var beginTime_month = TimeHelper.GetMonth(beginTime);
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"
select c.rep_date,a.lrze,b.lrze zczj_11 from
(select substr(rep_date, 0, 4) rep_date, round(sum(nvl(lrze, 0)) / 10000, 2) lrze, count(1) entnum from t_cw_month 
where rep_date like '%12' and flag_orginfo2=1 and type in (select * from table(strsplit(GetFalg_Type({2}))))  and nvl(lrze,0)<>0
group by substr(rep_date, 0, 4)) a,
(select substr(rep_date, 0, 4) rep_date, round(sum(nvl(lrze, 0)) / 10000, 2) lrze, count(1) entnum from t_cw_month 
where rep_date like '%{1}' and flag_orginfo2=1 and type in (select * from table(strsplit(GetFalg_Type({2}))))  and nvl(lrze,0)<>0 
group by substr(rep_date, 0, 4)) b,
(select distinct substr(sjrq, 0, 4) rep_date from ORG_INFO_TIME_TJ) c
where a.rep_date(+)=c.rep_date and b.rep_date(+)=c.rep_date and substr(c.rep_date, 0, 4) between 2010 and {0}
order by substr(c.rep_date, 0, 4)   ", beginTime_year, beginTime_month, type);
            return SqlBaseOperation.Query(strSql.ToString());
        }

        /// <summary>
        /// 增速
        /// </summary>
        /// <param name="beginTime"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<dynamic> Chart02(string beginTime, string type)
        {
            var beginTime_year = TimeHelper.GetYear(beginTime);
            var beginTime_month = TimeHelper.GetMonth(beginTime);
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"select rep_date,
sum(decode(type, '1', nvl(tbzs, 0), 0)) tbzs12,
sum(decode(type, '2', nvl(tbzs, 0), 0)) tbzs11 from 
(select rep_date ,lrze,t_zczj,type,round(decode(t_zczj,0,null,(lrze-t_zczj)/abs(t_zczj))*100,2) tbzs from
(
select  rep_date ,type,lrze,LAG(lrze, 1, 0) OVER(PARTITION BY type ORDER BY rep_date) AS t_zczj from 
(
select substr(rep_date,0,4) rep_date,'1' type, round(sum(nvl(lrze,0))/10000,2) lrze from t_cw_month where rep_date  like '%12' and flag_orginfo2=1 
and type in (select * from table(strsplit(GetFalg_Type({2})))) and nvl(lrze,0)<>0 group by substr(rep_date,0,4)
union all
select substr(rep_date,0,4) rep_date,'2' type, round(sum(nvl(lrze,0))/10000,2) lrze from t_cw_month where rep_date  like '%{1}' and flag_orginfo2=1 
and type in (select * from table(strsplit(GetFalg_Type({2})))) and nvl(lrze,0)<>0 group by substr(rep_date,0,4) 
))
where rep_date <={0})
group by rep_date
order by rep_date asc", beginTime_year, beginTime_month, type);
            return SqlBaseOperation.Query(strSql.ToString());
        }

        /// <summary>
        /// 统计口径 年份
        /// </summary>
        /// <param name="beginTime"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<dynamic> GetAllByYear(string beginTime,string type)
        {
            var beginTime_year = TimeHelper.GetYear(beginTime);
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"select b.rep_date, decode(a.lrze, null, 0, a.lrze) lrze, decode(a.entnum, null, 0, a.entnum) entnum from
(select substr(rep_date, 0, 4) rep_date, round(sum(nvl(lrze, 0))/10000,2) lrze, count(*) entnum from t_cw_month
where flag_orginfo2 = 1 and substr(rep_date, 5, 2) = 12 and type in (select * from table(strsplit(GetFalg_Type({1}))))and nvl(lrze, 0) <> 0
group by substr(rep_date, 0, 4)
order by rep_date desc)a,
(select distinct substr(sjrq, 0, 4) rep_date from org_info_time_tj where substr(sjrq, 0, 4)<={0}) b
    where a.rep_date(+) = b.rep_date
order by rep_date desc", beginTime_year, type);
            return SqlBaseOperation.Query(strSql.ToString());
        }

        /// <summary>
        /// 统计口径 月份
        /// </summary>
        /// <param name="beginTime"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<dynamic> GetMonthByYear(string year, string type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"select rep_date,round(sum(nvl(lrze,0))/10000,2) lrze,count(*) entnum from t_cw_month 
where substr(rep_date, 0, 4) = {0} and substr(rep_date,5,2) in(02,05,08,11,12) and flag_orginfo2 = 1 and type in (select * from table(strsplit(GetFalg_Type({1}))))and nvl(lrze, 0) <> 0
group by rep_date
order by rep_date desc", year, type);
            return SqlBaseOperation.Query(strSql.ToString());
        }
    }
}
