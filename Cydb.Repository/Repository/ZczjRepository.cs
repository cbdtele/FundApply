using Cydb.Common.Helper;
using Cydb.Repository.Base;
using System.Collections.Generic;
using System.Text;
using System;
using System.Data;
using Dapper;

namespace Cydb.Repository.Repository
{
    public class ZczjRepository : IZczjRepository
    {
        private static readonly ISqlBaseOperation SqlBaseOperation = new SqlBaseOperation();
        /// <summary>
        /// 资产总计、同比增速
        /// </summary>
        /// <param name="beginTime"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<dynamic> ZCZJ(string beginTime, string type)
        {
            string beginTime_Tq = beginTime.YearSubtract();
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"select a.entnum,a.zczj,b.zczj,decode(b.zczj,0,0,round((a.zczj-b.zczj)*100/b.zczj,2)) tb from
(select count(1) entnum, round(sum(nvl(zczj,0)/10000),2) zczj from t_cw_month
where rep_date = {0} and flag_orginfo2=1 and type in (select * from table(strsplit(GetFalg_Type({2})))) and nvl(zczj,0)<>0 ) a
,
(select count(1) entnum, round(sum(nvl(zczj,0)/10000),2) zczj from t_cw_month
where rep_date = {1} and flag_orginfo2=1 and type in (select * from table(strsplit(GetFalg_Type({2})))) and nvl(zczj,0)<>0) b"
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
select c.rep_date,a.zczj,b.zczj zczj_11 from
(select substr(rep_date, 0, 4) rep_date, round(sum(nvl(zczj, 0)) / 10000, 2) zczj, count(1) entnum from t_cw_month 
where rep_date like '%12' and flag_orginfo2=1 and type in (select * from table(strsplit(GetFalg_Type({2}))))  and nvl(zczj,0)<>0
group by substr(rep_date, 0, 4)) a,
(select substr(rep_date, 0, 4) rep_date, round(sum(nvl(zczj, 0)) / 10000, 2) zczj, count(1) entnum from t_cw_month 
where rep_date like '%{1}' and flag_orginfo2=1 and type in (select * from table(strsplit(GetFalg_Type({2}))))  and nvl(zczj,0)<>0 
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
(select rep_date ,zczj,t_zczj,type,round(decode(t_zczj,0,null,(zczj-t_zczj)/abs(t_zczj))*100,2) tbzs from
(
select  rep_date ,type,zczj,LAG(zczj, 1, 0) OVER(PARTITION BY type ORDER BY rep_date) AS t_zczj from 
(
select substr(rep_date,0,4) rep_date,'1' type, round(sum(nvl(zczj,0))/10000,2) zczj from t_cw_month where rep_date  like '%12' and flag_orginfo2=1 
and type in (select * from table(strsplit(GetFalg_Type({2})))) and nvl(zczj,0)<>0 group by substr(rep_date,0,4)
union all
select substr(rep_date,0,4) rep_date,'2' type, round(sum(nvl(zczj,0))/10000,2) zczj from t_cw_month where rep_date  like '%{1}' and flag_orginfo2=1 
and type in (select * from table(strsplit(GetFalg_Type({2})))) and nvl(zczj,0)<>0 group by substr(rep_date,0,4) 
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
        public List<dynamic> GetAllByYear(string beginTime, string type)
        {
            var beginTime_year = TimeHelper.GetYear(beginTime);
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"select b.rep_date, decode(a.zczj, null, 0, a.zczj) zczj, decode(a.entnum, null, 0, a.entnum) entnum from
(select substr(rep_date, 0, 4) rep_date, round(sum(nvl(zczj, 0))/10000,2) zczj, count(*) entnum from t_cw_month
where flag_orginfo2 = 1 and substr(rep_date, 5, 2) = 12 and type in (select * from table(strsplit(GetFalg_Type({1}))))and nvl(zczj, 0) <> 0
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
            strSql.AppendFormat(@"select rep_date,round(sum(nvl(zczj,0))/10000,2) zczj,count(*) entnum from t_cw_month 
where substr(rep_date, 0, 4) = {0} and substr(rep_date,5,2) in(02,05,08,11,12) and flag_orginfo2 = 1 and type in (select * from table(strsplit(GetFalg_Type({1}))))and nvl(zczj, 0) <> 0
group by rep_date
order by rep_date desc", year, type);
            return SqlBaseOperation.Query(strSql.ToString());
        }

        /// <summary>
        /// 行业分布 行业名称
        /// </summary>
        /// <param name="year"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<dynamic> HyfbTable01(string beginTime, string type, string colType)
        {
            var beginTime_Tq = beginTime.YearSubtract();
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"select cc.industry_mtype_name,cc.INDUSTRY_MTYPE_ID,decode(aa.{3},null,0,aa.{3}) {3},bb.t_{3},decode(bb.t_{3},0,0, round((aa.{3}-bb.t_{3})/bb.t_{3}*100,2)) tbzz ,aa.zb,decode(aa.entnum,null,0,aa.entnum) entnum from
(select b.industry_mtype_name,round(sum(nvl({3},0))/10000,2) {3},round((ratio_to_report(sum(nvl({3},0))) over())*100,2) zb,count(1) entnum 
from t_cw_month a,ndic_industry b
where a.industry_id(+)=b.industry_type4_id and rep_date={0} and flag_orginfo2=1 and type in (select * from table(strsplit(GetFalg_Type({2})))) and nvl({3},0)<>0 
group by industry_mtype_name) aa
,
(select  b.industry_mtype_name,round(sum(nvl({3},0))/10000,2) t_{3} from t_cw_month a,
ndic_industry b
where a.industry_id(+)=b.industry_type4_id and rep_date={1} and flag_orginfo2=1 and type in (select * from table(strsplit(GetFalg_Type({2})))) and nvl({3},0)<>0 
group by industry_mtype_name) bb ,
(select distinct industry_mtype_id, industry_mtype_name from ndic_industry)  cc
where  cc.industry_mtype_name=aa.industry_mtype_name(+)  and cc.industry_mtype_name=bb.industry_mtype_name(+)
order by decode(aa.{3},null,0,aa.{3}) desc", beginTime, beginTime_Tq, type, colType);
            return SqlBaseOperation.Query(strSql.ToString());
        }

        /// <summary>
        /// 行业分布 连续高速增长
        /// </summary>
        /// <param name="year"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<dynamic> HyfbTable02(string beginTime, string type, string colType)
        {
            var beginTime_Tq = beginTime.YearSubtract();
            var beginTime_Tq_1 = beginTime.YearSubtract(2);
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"
select a.INDUSTRY_MTYPE_ID, a.INDUSTRY_MTYPE_NAME
,a1.ZS ZS_first, a2.ZS ZS_second
 from 
( select distinct INDUSTRY_MTYPE_ID, INDUSTRY_MTYPE_NAME from ndic_industry ) a,

(select c.industry_mtype_id,c.industry_mtype_name
,decode(sum(nvl(b.targetfield,0)),0,0,round(sum(nvl(a.targetfield,0)-(nvl(b.targetfield,0)))/abs(sum(nvl(b.targetfield,0)))*100,2)) ZS
from
(select industry_id,sum(nvl({4},0)) targetfield from t_cw_month where rep_date ={0} and flag_orginfo2=1 and type in (select * from table(strsplit(GetFalg_Type({3})))) and nvl({4},0)<>0 group by industry_id) a,
(select industry_id,sum(nvl({4},0)) targetfield from t_cw_month where rep_date ={1} and flag_orginfo2=1 and type in (select * from table(strsplit(GetFalg_Type({3})))) and nvl({4},0)<>0 group by industry_id) b,
ndic_industry c                                                                                                                                                  
where c.industry_type4_id=a.industry_id(+) and c.industry_type4_id=b.industry_id(+)                                                                              
group by c.industry_mtype_id,c.industry_mtype_name) a1,                                                                                                          
                                                                                                                                                                 
(select c.industry_mtype_id,c.industry_mtype_name                                                                                                                
,decode(sum(nvl(b.targetfield,0)),0,0,round(sum(nvl(a.targetfield,0)-(nvl(b.targetfield,0)))/abs(sum(nvl(b.targetfield,0)))*100,2)) ZS                                
from                                                                                                                                                             
(select industry_id,sum(nvl({4},0)) targetfield from t_cw_month where rep_date ={1} and flag_orginfo2=1 and type in (select * from table(strsplit(GetFalg_Type({3})))) and nvl({4},0)<>0 group by industry_id) a,
(select industry_id,sum(nvl({4},0)) targetfield from t_cw_month where rep_date ={0} and flag_orginfo2=1 and type in (select * from table(strsplit(GetFalg_Type({3})))) and nvl({4},0)<>0 group by industry_id) b,
ndic_industry c
where c.industry_type4_id=a.industry_id(+) and c.industry_type4_id=b.industry_id(+)
group by c.industry_mtype_id,c.industry_mtype_name) a2
where a.INDUSTRY_MTYPE_ID=a1.INDUSTRY_MTYPE_ID(+)
and a.INDUSTRY_MTYPE_ID=a2.INDUSTRY_MTYPE_ID(+)
and a1.ZS>=30 and a2.ZS>=30 order by a1.ZS desc", beginTime, beginTime_Tq, beginTime_Tq_1, type, colType);
            return SqlBaseOperation.Query(strSql.ToString());
        }

        /// <summary>
        /// 行业分布 连续高速减少
        /// </summary>
        /// <param name="year"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<dynamic> HyfbTable03(string beginTime, string type, string colType)
        {
            var beginTime_Tq = beginTime.YearSubtract();
            var beginTime_Tq_1 = beginTime.YearSubtract(2);
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"
select a.INDUSTRY_MTYPE_ID, a.INDUSTRY_MTYPE_NAME
,a1.ZS ZS_first, a2.ZS ZS_second
 from 
( select distinct INDUSTRY_MTYPE_ID, INDUSTRY_MTYPE_NAME from ndic_industry ) a,

(select c.industry_mtype_id,c.industry_mtype_name
,decode(sum(nvl(b.targetfield,0)),0,0,round(sum(nvl(a.targetfield,0)-(nvl(b.targetfield,0)))/abs(sum(nvl(b.targetfield,0)))*100,2)) ZS
from
(select industry_id,sum(nvl({4},0)) targetfield from t_cw_month where rep_date ={0} and flag_orginfo2=1 and type in (select * from table(strsplit(GetFalg_Type({3})))) and nvl({4},0)<>0 group by industry_id) a,
(select industry_id,sum(nvl({4},0)) targetfield from t_cw_month where rep_date ={1} and flag_orginfo2=1 and type in (select * from table(strsplit(GetFalg_Type({3})))) and nvl({4},0)<>0 group by industry_id) b,
ndic_industry c                                                                                                                                                  
where c.industry_type4_id=a.industry_id(+) and c.industry_type4_id=b.industry_id(+)                                                                              
group by c.industry_mtype_id,c.industry_mtype_name) a1,                                                                                                          
                                                                                                                                                                 
(select c.industry_mtype_id,c.industry_mtype_name                                                                                                                
,decode(sum(nvl(b.targetfield,0)),0,0,round(sum(nvl(a.targetfield,0)-(nvl(b.targetfield,0)))/abs(sum(nvl(b.targetfield,0)))*100,2)) ZS                                
from                                                                                                                                                             
(select industry_id,sum(nvl({4},0)) targetfield from t_cw_month where rep_date ={1} and flag_orginfo2=1 and type in (select * from table(strsplit(GetFalg_Type({3})))) and nvl({4},0)<>0 group by industry_id) a,
(select industry_id,sum(nvl({4},0)) targetfield from t_cw_month where rep_date ={0} and flag_orginfo2=1 and type in (select * from table(strsplit(GetFalg_Type({3})))) and nvl({4},0)<>0 group by industry_id) b,
ndic_industry c
where c.industry_type4_id=a.industry_id(+) and c.industry_type4_id=b.industry_id(+)
group by c.industry_mtype_id,c.industry_mtype_name) a2
where a.INDUSTRY_MTYPE_ID=a1.INDUSTRY_MTYPE_ID(+)
and a.INDUSTRY_MTYPE_ID=a2.INDUSTRY_MTYPE_ID(+)
and a1.ZS<=-30 and a2.ZS<=-30 order by a1.ZS asc", beginTime, beginTime_Tq, beginTime_Tq_1, type, colType);
            return SqlBaseOperation.Query(strSql.ToString());
        }

        /// <summary>
        /// 行业分布 行业资产总计占比分析
        /// </summary>
        /// <param name="year"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<dynamic> HyfbChart01(string beginTime, string type, string colType)
        {
            var year = Conv.ToInt(beginTime.Substring(0, 4));
            var strSql = new StringBuilder();
            var minTime = 2010;
            for (var i = year; i >= minTime; i--)
            {
                strSql.AppendFormat(@"
select {0} rep_date, b.industry_mtype_name PIENAME, round(sum(nvl({2},0))/10000,2) PIEVALUE,round((ratio_to_report(sum(nvl(a.{2},0))) over())*100,2) zb 
from t_cw_month a,ndic_industry b
where a.industry_id(+)=b.industry_type4_id and rep_date={0}12 and flag_orginfo2=1 and type in (select * from table(strsplit(GetFalg_Type({1})))) and nvl({2},0)<>0 
group by  b.industry_mtype_name
", i, type, colType);
                if (i > minTime)
                    strSql.Append(" union all ");
            }
            return SqlBaseOperation.Query(strSql.ToString());
        }

        /// <summary>
        /// 产业分布 一二三次产业
        /// </summary>
        /// <param name="year"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<dynamic> CyfbTable01(string beginTime, string type, string colType)
        {
            var beginTime_Tq = beginTime.YearSubtract();
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"
select aa.flag_3c,
case
when aa.flag_3c=1 then '第一产业'
when aa.flag_3c=2 then '第二产业'
when aa.flag_3c=3 then '第三产业' 
else null end FLAG_3C_NAME,
decode(aa.{3},null,0,aa.{3}) {3},
decode(aa.{3},0,0,round((aa.{3}-bb.t_{3})/abs(abs(bb.t_{3})*100,2)) tbzs,
decode(aa.{3},0,0,round(aa.{3}*100/sum(aa.{3}) over(partition by null),2)) zb,
decode(aa.entnum,null,0,aa.entnum) entnum
from 
(select bb.flag_3c,aa.entnum,aa.{3} from
(select b.flag_3c,count(1) entnum, round(sum(nvl({3},0))/10000,2) {3} from t_cw_month a,org_info2 b 
where a.nat_org_code(+)=b.nat_org_code and rep_date ={0} and type in (select * from table(strsplit(GetFalg_Type({2})))) and nvl({3},0)<>0 and b.flag_3c<>0
group by b.flag_3c)aa,
(select distinct flag_3c from org_info2 where  flag_3c <>0) bb
where aa.flag_3c(+)=bb.flag_3c) aa
,
(select bb.flag_3c,aa.entnum,aa.t_{3} from
(select b.flag_3c,count(1) entnum, round(sum(nvl({3},0))/10000,2) t_{3} from t_cw_month a,org_info2 b 
where a.nat_org_code(+)=b.nat_org_code and rep_date ={1} and type in (select * from table(strsplit(GetFalg_Type({2})))) and nvl({3},0)<>0 and b.flag_3c<>0
group by b.flag_3c)aa,
(select distinct flag_3c from org_info2 where  flag_3c <>0) bb
where aa.flag_3c(+)=bb.flag_3c) bb
where aa.flag_3c=bb.flag_3c
order by FLAG_3C", beginTime, beginTime_Tq, type, colType);
            return SqlBaseOperation.Query(strSql.ToString());
        }

        /// <summary>
        /// 产业分布 主导产业
        /// </summary>
        /// <param name="year"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<dynamic> CyfbTable02(string beginTime, string type, string colType)
        {
            var beginTime_Tq = beginTime.YearSubtract();
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"
select bbb.DY_INDUSTRY_MTYPE_ID, bbb.DY_INDUSTRY_MTYPE_NAME,decode(aaa.{3},null,0,aaa.{3}) {3},aaa.tbzs,aaa.zb,decode(aaa.entnum,null,0,aaa.entnum) entnum from
(
select aa.DY_INDUSTRY_MTYPE_ID,aa.DY_INDUSTRY_MTYPE_NAME,aa.{3},BB.{3} t_{3},
decode(aa.{3},0,0,round((aa.{3}-bb.{3})/abs(bb.{3})*100,2)) tbzs,
decode(aa.{3},0,0,round(aa.{3}*100/sum(aa.{3}) over(partition by null),2)) zb,aa.ENTNUM
from
(select DY_INDUSTRY_MTYPE_ID,b.dy_industry_mtype_name,round(sum(nvl({3},0))/10000,2) {3},count(1) entnum from t_cw_month a,
dic_dy_industry b 
where 
a.industry_id=b.dy_industry_type4_id
and DY_INDUSTRY_MTYPE_ID in('X','W','J')
and rep_date ={0} 
and flag_orginfo2=1
and type in (select * from table(strsplit(GetFalg_Type({2}))))
and nvl({3},0)<>0
group by  DY_INDUSTRY_MTYPE_ID, b.dy_industry_mtype_name
union
select DY_INDUSTRY_MTYPE_ID,b.dy_industry_mtype_name,round(sum(nvl({3},0))/10000,2) {3},count(1) entnum from t_cw_month a,
dic_dy_industry_new b
where 
a.industry_id(+)=b.industry_id
and DY_INDUSTRY_MTYPE_ID in('GX')
and rep_date ={0}
and flag_orginfo2=1
and type in (select * from table(strsplit(GetFalg_Type({2}))))
and nvl({3},0)<>0
group by  DY_INDUSTRY_MTYPE_ID, b.dy_industry_mtype_name) aa
,
(select DY_INDUSTRY_MTYPE_ID,b.dy_industry_mtype_name,round(sum(nvl({3},0))/10000,2) {3},count(1) entnum from t_cw_month a,
dic_dy_industry b 
where 
a.industry_id=b.dy_industry_type4_id
and DY_INDUSTRY_MTYPE_ID in('X','W','J')
and rep_date ={1} 
and flag_orginfo2=1
and type in (select * from table(strsplit(GetFalg_Type({2}))))
and nvl({3},0)<>0
group by  DY_INDUSTRY_MTYPE_ID, b.dy_industry_mtype_name
union
select DY_INDUSTRY_MTYPE_ID,b.dy_industry_mtype_name,round(sum(nvl({3},0))/10000,2) {3},count(1) entnum from t_cw_month a,
dic_dy_industry_new b
where 
a.industry_id(+)=b.industry_id
and DY_INDUSTRY_MTYPE_ID in('GX')
and rep_date ={1}
and flag_orginfo2=1
and type in (select * from table(strsplit(GetFalg_Type({2}))))
and nvl({3},0)<>0
group by  DY_INDUSTRY_MTYPE_ID, b.dy_industry_mtype_name) bb
where aa.DY_INDUSTRY_MTYPE_ID=bb.DY_INDUSTRY_MTYPE_ID
order by DY_INDUSTRY_MTYPE_NAME desc) aaa
,
(select distinct DY_INDUSTRY_MTYPE_ID, DY_INDUSTRY_MTYPE_NAME from dic_dy_industry where DY_INDUSTRY_MTYPE_ID in('X','W','J')
union
select distinct DY_INDUSTRY_MTYPE_ID, DY_INDUSTRY_MTYPE_NAME from dic_dy_industry_new where DY_INDUSTRY_MTYPE_ID in('GX')) bbb
where aaa.DY_INDUSTRY_MTYPE_NAME(+)=bbb.DY_INDUSTRY_MTYPE_NAME", beginTime, beginTime_Tq, type, colType);
            return SqlBaseOperation.Query(strSql.ToString());
        }

        /// <summary>
        /// 产业分布 一二三次产业资产总计占比
        /// </summary>
        /// <param name="year"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<dynamic> CyfbChart01(string beginTime, string type, string colType)
        {
            var beginTime_Tq = beginTime.YearSubtract();
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"select case
when aa.flag_3c=1 then '第一产业'
when aa.flag_3c=2 then '第二产业'
when aa.flag_3c=3 then '第三产业' 
else null end FLAG_3C,
decode(aa.{3},null,0,round(aa.{3}*100/sum(aa.{3}) over(partition by null),2)) zb
from 
((select bb.flag_3c,aa.entnum,aa.{3} from
(select b.flag_3c,count(1) entnum, round(sum(nvl({3},0))/10000,2) {3} from t_cw_month a,org_info2 b 
where a.nat_org_code(+)=b.nat_org_code and rep_date ={0} and type in (select * from table(strsplit(GetFalg_Type({2})))) and nvl({3},0)<>0 and b.flag_3c<>0
group by b.flag_3c)aa,
(select distinct flag_3c from org_info2 where  flag_3c <>0) bb
where aa.flag_3c(+)=bb.flag_3c)
order by flag_3c) aa
,
((select bb.flag_3c,aa.entnum,aa.{3} from
(select b.flag_3c,count(1) entnum, round(sum(nvl({3},0))/10000,2) {3} from t_cw_month a,org_info2 b 
where a.nat_org_code(+)=b.nat_org_code and rep_date ={1} and type in (select * from table(strsplit(GetFalg_Type({2})))) and nvl({3},0)<>0 and b.flag_3c<>0
group by b.flag_3c)aa,
(select distinct flag_3c from org_info2 where  flag_3c <>0) bb
where aa.flag_3c(+)=bb.flag_3c)) bb
where aa.flag_3c=bb.flag_3c", beginTime, beginTime_Tq, type, colType);
            return SqlBaseOperation.Query(strSql.ToString());
        }

        /// <summary>
        /// 产业分布 主导产业资产总计占比
        /// </summary>
        /// <param name="year"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public string CyfbChart02(string beginTime, string type, string colType)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"select {0} DY_INDUSTRY_MTYPE_ID,DY_INDUSTRY_MTYPE_NAME,{2},decode(t.{2},0,0,round(t.{2}*100/sum(t.{2}) over(partition by null),2))zb from(
select DY_INDUSTRY_MTYPE_ID,  b.dy_industry_mtype_name,round(sum(nvl(a.{2},0))/10000,2) {2}
from
(select * from t_cw_month where rep_date={0}12 and flag_orginfo2=1 and type in (select * from table(strsplit(GetFalg_Type({1})))) and nvl({2},0)<>0) a,
dic_dy_industry b
where a.industry_id=b.dy_industry_type4_id
and DY_INDUSTRY_MTYPE_ID in('X','W','J')
group by DY_INDUSTRY_MTYPE_ID, b.dy_industry_mtype_name
union  
select DY_INDUSTRY_MTYPE_ID,  b.dy_industry_mtype_name,round(sum(nvl(a.{2},0))/10000,2) {2}
from
(select * from t_cw_month where rep_date={0}12 and flag_orginfo2=1 and type in (select * from table(strsplit(GetFalg_Type({1})))) and nvl({2},0)<>0) a,
dic_dy_industry_new b
where a.industry_id=b.industry_id
and DY_INDUSTRY_MTYPE_ID in('GX')
group by DY_INDUSTRY_MTYPE_ID,  b.dy_industry_mtype_name) t
order by t.dy_industry_mtype_name desc", beginTime, type, colType);
            return strSql.ToString();
        }

        /// <summary>
        /// 形态类别
        /// </summary>
        /// <param name="year"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<dynamic> XtlbTable01(string beginTime, string type, string colType)
        {
            var beginTime_Tq = beginTime.YearSubtract();
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"
select aa.names,decode(aa.{3},null,0,aa.{3}) {3},bb.{3} t_{3},decode(aa.{3},0,0,round((aa.{3}-bb.{3})/bb.{3}*100,2)) tbzz,aa.entnum
from 
(select '总部企业' names ,round(sum(nvl({3},0))/10000,2) {3},count(1) entnum from t_cw_month a,
商委_总部企业 b
where  a.nat_org_code(+)=b.nat_org_code and a.rep_date ={0} and flag_orginfo2=1 and type in (select * from table(strsplit(GetFalg_Type({2})))) and nvl({3},0)<>0
union
select '跨国公司总部企业' names ,round(sum(nvl({3},0))/10000,2) {3},count(1) entnum from t_cw_month a,
商委_跨国公司总部企业 b
where  a.nat_org_code(+)=b.nat_org_code and a.rep_date ={0} and flag_orginfo2=1 and type in (select * from table(strsplit(GetFalg_Type({2})))) and nvl({3},0)<>0) aa
,
(select '总部企业' names ,round(sum(nvl({3},0))/10000,2) {3},count(1) entnum from t_cw_month a,
商委_总部企业 b
where  a.nat_org_code(+)=b.nat_org_code and a.rep_date ={1} and flag_orginfo2=1 and type in (select * from table(strsplit(GetFalg_Type({2})))) and nvl({3},0)<>0
union
select '跨国公司总部企业' names ,round(sum(nvl({3},0))/10000,2) {3},count(1) entnum from t_cw_month a,
商委_跨国公司总部企业 b
where  a.nat_org_code(+)=b.nat_org_code and a.rep_date ={1} and flag_orginfo2=1 and type in (select * from table(strsplit(GetFalg_Type({2})))) and nvl({3},0)<>0) bb
where aa.names=bb.names
order by names desc
", beginTime, beginTime_Tq, type,colType);
            return SqlBaseOperation.Query(strSql.ToString());
        }

        /// <summary>
        ///企业类型 分类
        /// </summary>
        /// <param name="year"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<dynamic> WzTable01(string beginTime, string type, string colType)
        {
            var beginTime_Tq = beginTime.YearSubtract();
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"select bbb.ent_mtype_id,bbb.ent_mtype_name,decode(aaa.{3},null,0,aaa.{3}) {3},aaa.tbzs,aaa.zb,decode(aaa.entnum,null,0,aaa.entnum) entnum from
(select aa.ent_mtype_id,aa.ent_mtype_name,
aa.{3},
decode(bb.{3},0,0,round((aa.{3}-bb.{3})/abs(bb.{3})*100,2)) tbzs,
decode(aa.{3},0,0,round(aa.{3}*100/sum(aa.{3}) over(partition by null),2)) zb,
aa.entnum
from
(select c.ent_mtype_id, c.ent_mtype_name,round(sum(nvl({3},0))/10000,2) {3},count(1) entnum from t_cw_month a,
org_info2 b,
dic_enterprise_type c 
where a.nat_org_code(+)=b.nat_org_code 
and b.ent_type_id(+)=c.ent_btype_id
and rep_date ={0} 
and flag_orginfo2=1
and type in (select * from table(strsplit(GetFalg_Type({2}))))
and nvl({3},0) <>0
group by  c.ent_mtype_id,c.ent_mtype_name) aa
,
(select c.ent_mtype_id, c.ent_mtype_name,round(sum(nvl({3},0))/10000,2) {3},count(1) entnum from t_cw_month a,
org_info2 b,
dic_enterprise_type c 
where a.nat_org_code(+)=b.nat_org_code 
and b.ent_type_id(+)=c.ent_btype_id
and rep_date ={1} 
and flag_orginfo2=1
and type in (select * from table(strsplit(GetFalg_Type({2}))))
and nvl({3},0) <>0
group by  c.ent_mtype_id,c.ent_mtype_name) bb
where aa.ent_mtype_name=bb.ent_mtype_name)aaa
,
(select distinct ent_mtype_id,ent_mtype_name from dic_enterprise_type where ent_mtype_id in ('100','200','300')) bbb
where aaa.ent_mtype_id(+)=bbb.ent_mtype_id
order by ent_mtype_id", beginTime, beginTime_Tq, type,colType);
            return SqlBaseOperation.Query(strSql.ToString());
        }

        /// <summary>
        /// 企业类型 内外资税收占比
        /// </summary>
        /// <param name="year"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<dynamic> WzChart01(string beginTime, string type, string colType)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@" select bbb.ent_mtype_id,bbb.ent_mtype_name,decode(aaa.zb,null,0,aaa.zb) zb from
(select c.ent_mtype_id, c.ent_mtype_name,
round((ratio_to_report(sum(nvl(a.{2},0))) over())*100,2) zb  
from 
(select nat_org_code, {2} from t_cw_month where rep_date={0} and flag_orginfo2=1 and type in (select * from table(strsplit(GetFalg_Type({1})))) and nvl({2},0) <>0) a,
ORG_INFO2 b,
DIC_ENTERPRISE_TYPE c
where 
a.nat_org_code=b.nat_org_code
and b.ent_type_id(+)=c.ent_btype_id
group by c.ent_mtype_id, c.ent_mtype_name
) aaa
,
(select distinct ent_mtype_id,ent_mtype_name from dic_enterprise_type) bbb
where aaa.ent_mtype_id(+)=bbb.ent_mtype_id
order by ent_mtype_id", beginTime, type,colType);
            return SqlBaseOperation.Query(strSql.ToString());
        }

        /// <summary>
        /// 功能区 分类
        /// </summary>
        /// <param name="year"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<dynamic> GnqTable01(string beginTime, string type, string colType)
        {
            var beginTime_Tq = beginTime.YearSubtract();
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"
select bbb.id,bbb.GNQ_NAME,decode(aaa.{3},null,0,aaa.{3}) {3},aaa.tbzs,aaa.zb,decode(aaa.entnum,null,0,aaa.entnum) entnum from
(select aa.gnqId,aa.{3},
decode(bb.{3},0,0,round((aa.{3}-bb.{3})/abs(bb.{3})*100,2)) tbzs,
decode(aa.{3},0,0,round(aa.{3}*100/sum(aa.{3}) over(partition by null),2)) zb,aa.entnum
from  
(select case
when substr(FLAG_GNQ,1,1)=1 then '1'
when substr(FLAG_GNQ,2,1)=1 then '2'
when substr(FLAG_GNQ,3,1)=1 then '3'
when substr(FLAG_GNQ,4,1)=1 then '4'
when substr(FLAG_GNQ,5,1)=1 then '5'
when substr(FLAG_GNQ,6,1)=1 then '6'
else null end as gnqId , round(sum(nvl({3},0))/10000,2) {3},count(1) entnum
from t_cw_month a,
org_info2 b
where a.nat_org_code(+)=b.nat_org_code and rep_date={0}
and type in (select * from table(strsplit(GetFalg_Type({2})))) and nvl({3},0) <>0
group by  
case  
when substr(FLAG_GNQ,1,1)=1 then '1'
when substr(FLAG_GNQ,2,1)=1 then '2'
when substr(FLAG_GNQ,3,1)=1 then '3'
when substr(FLAG_GNQ,4,1)=1 then '4'
when substr(FLAG_GNQ,5,1)=1 then '5'
when substr(FLAG_GNQ,6,1)=1 then '6'
else null end) aa
,
(select case
when substr(FLAG_GNQ,1,1)=1 then '1'
when substr(FLAG_GNQ,2,1)=1 then '2'
when substr(FLAG_GNQ,3,1)=1 then '3'
when substr(FLAG_GNQ,4,1)=1 then '4'
when substr(FLAG_GNQ,5,1)=1 then '5'
when substr(FLAG_GNQ,6,1)=1 then '6'
else null end as gnqId , round(sum(nvl({3},0))/10000,2) {3},count(1) entnum
from t_cw_month a,
org_info2 b
where a.nat_org_code(+)=b.nat_org_code and rep_date={1}
and type in (select * from table(strsplit(GetFalg_Type({2})))) and nvl({3},0) <>0
group by  
case  
when substr(FLAG_GNQ,1,1)=1 then '1'
when substr(FLAG_GNQ,2,1)=1 then '2'
when substr(FLAG_GNQ,3,1)=1 then '3'
when substr(FLAG_GNQ,4,1)=1 then '4'
when substr(FLAG_GNQ,5,1)=1 then '5'
when substr(FLAG_GNQ,6,1)=1 then '6'
else null end) bb
where aa.gnqId=bb.gnqId ) aaa,
dic_gnq bbb
where  aaa.gnqId=bbb.id", beginTime, beginTime_Tq, type, colType);

            return SqlBaseOperation.Query(strSql.ToString());
        }

        /// <summary>
        /// 功能区 功能区资产总计占比
        /// </summary>
        /// <param name="year"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public IEnumerable<dynamic> GnqChart01(IDbConnection conn, string beginTime, string type, string colType)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"
select bbb.id,bbb.GNQ_NAME,aaa.zb from
(select aa.gnqId,bb.gnq_name,
decode(aa.{2},0,0,round(aa.{2}*100/sum(aa.{2}) over(partition by null),2)) zb
from
(select case
when substr(FLAG_GNQ,1,1)=1 then '1'
when substr(FLAG_GNQ,2,1)=1 then '2'
when substr(FLAG_GNQ,3,1)=1 then '3'
when substr(FLAG_GNQ,4,1)=1 then '4'
when substr(FLAG_GNQ,5,1)=1 then '5'
when substr(FLAG_GNQ,6,1)=1 then '6'
else null end as gnqId , round(sum(nvl({2},0))/10000,2) {2} from t_cw_month a,
org_info2 b
where a.nat_org_code(+)=b.nat_org_code and a.rep_date={0}12
and type in (select * from table(strsplit(GetFalg_Type({1})))) and nvl({2},0) <>0
group by  
case  
when substr(FLAG_GNQ,1,1)=1 then '1'
when substr(FLAG_GNQ,2,1)=1 then '2'
when substr(FLAG_GNQ,3,1)=1 then '3'
when substr(FLAG_GNQ,4,1)=1 then '4'
when substr(FLAG_GNQ,5,1)=1 then '5'
when substr(FLAG_GNQ,6,1)=1 then '6'
else null end) aa,
dic_gnq bb
where aa.gnqId=bb.id) aaa,
dic_gnq bbb
where  aaa.gnqId=bbb.id
", beginTime, type, colType);
            return conn.Query(strSql.ToString());
        }
    }
}
