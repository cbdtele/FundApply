using Cydb.Common.Helper;
using Cydb.Repository.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Cydb.Repository.Repository
{
    public class ShRepository : IShRepository
    {
        private static readonly ISqlBaseOperation SqlBaseOperation = new SqlBaseOperation();

        /// <summary>
        /// 从业人员、同比增速
        /// </summary>
        /// <param name="beginTime"></param>
        /// <returns></returns>
        public List<dynamic> SH(string beginTime)
        {
            var beginTime_Tq = beginTime.YearSubtract();
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"
select entnum, a.sh_sj,round((a.sh_sj-a1.sh_sj)/abs(a1.sh_sj)*100,2) tbzs,round(a.sh_sj/a.sh_jh*100,2) jhyl 
from 
(select count(entnum) entnum, round(sum(nvl(a.sh_sj,0))/10000,2) sh_sj,round(sum(nvl(a.sh_jh,0))/10000,2) sh_jh from
(select 1 entnum, sh_sj,sh_jh from 
(select nat_org_code,org_name,sum(sh_sj) sh_sj ,sum(sh_jh) sh_jh,industry_id,rep_date,flag_orginfo2 from t_sh_year_entlist where nat_org_code is not null group by nat_org_code,org_name,industry_id,rep_date,flag_orginfo2) a,
org_info2 b where a.nat_org_code=b.nat_org_code and rep_date ={0}) a) a
 ,
(select round(sum(nvl(a1.sh_sj,0))/10000,2) sh_sj,round(sum(nvl(a1.sh_jh,0))/10000,2) sh_jh from
(select sh_sj,sh_jh from 
(select nat_org_code,org_name,sum(sh_sj) sh_sj ,sum(sh_jh) sh_jh,industry_id,rep_date,flag_orginfo2 from t_sh_year_entlist where nat_org_code is not null group by nat_org_code,org_name,industry_id,rep_date,flag_orginfo2) a,
org_info2 b where a.nat_org_code=b.nat_org_code and rep_date ={1}) a1) a1
", beginTime, beginTime_Tq);
            return SqlBaseOperation.Query(strSql.ToString());
        }

        /// <summary>
        /// 水耗
        /// </summary>
        /// <param name="beginTime"></param>
        /// <returns></returns>
        public List<dynamic> Chart01(string beginTime)
        {
            var beginTime_Tq = beginTime.YearSubtract();
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"
select a.rep_date,round(sum(nvl(sh_sj,0))/10000,2) sh_sj from 
(select nat_org_code,org_name,sum(sh_sj) sh_sj ,industry_id,rep_date,flag_orginfo2 from t_sh_year_entlist where nat_org_code is not null group by nat_org_code,org_name,industry_id,rep_date,flag_orginfo2) a,
org_info2 b 
where a.nat_org_code=b.nat_org_code and a.rep_date<={0} 
group by rep_date
order by rep_date asc", beginTime, beginTime_Tq);
            return SqlBaseOperation.Query(strSql.ToString());
        }

        /// <summary>
        /// 水耗的增速
        /// </summary>
        /// <param name="beginTime"></param>
        /// <returns></returns>
        public List<dynamic> Chart02(string beginTime)
        {
            StringBuilder strSql = new StringBuilder();
            var year = Conv.ToInt(beginTime);
            for (var i = 2010; i <= year; i++)//TODO 由于2009年没有数据，2010的数据显示出来就是很大
            {
                strSql.AppendFormat(@"select {0} rep_date,
decode(a1.sh_sj,null,null,round((nvl(a.sh_sj,0)-nvl(a1.sh_sj,0))/abs(nvl(a1.sh_sj,0))*100,2))  tbzs from 
(select round(sum(nvl(sh_sj,0))/10000,2) sh_sj from 
(select nat_org_code,org_name,sum(sh_sj) sh_sj ,industry_id,rep_date,flag_orginfo2 from t_sh_year_entlist where nat_org_code is not null group by nat_org_code,org_name,industry_id,rep_date,flag_orginfo2) a,
org_info2 b where a.nat_org_code(+)=b.nat_org_code and rep_date ={0}) a,
(select round(sum(nvl(sh_sj,0))/10000,2) sh_sj from 
(select nat_org_code,org_name,sum(sh_sj) sh_sj ,industry_id,rep_date,flag_orginfo2 from t_sh_year_entlist where nat_org_code is not null group by nat_org_code,org_name,industry_id,rep_date,flag_orginfo2) a,
org_info2 b where a.nat_org_code(+)=b.nat_org_code and rep_date ={1}) a1    
", i, i - 1);
                if (i < year)
                    strSql.Append(" union all ");
            }
            return SqlBaseOperation.Query(strSql.ToString());
        }

        /// <summary>
        /// 统计口径 年份
        /// </summary>
        /// <param name="beginTime"></param>
        /// <returns></return
        public List<dynamic> GetAllByYear(string beginTime)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(string.Format(@"
select rep_date,round(sum(nvl(sh_sj,0))/10000,2) sh_sj,count(*) entnum from 
(select nat_org_code,org_name,sum(sh_sj) sh_sj ,industry_id,rep_date,flag_orginfo2 from t_sh_year_entlist where nat_org_code is not null group by nat_org_code,org_name,industry_id,rep_date,flag_orginfo2)
where flag_orginfo2=1 and rep_date <={0} 
group by rep_date  
order by rep_date desc", beginTime));
            return SqlBaseOperation.Query(strSql.ToString());
        }

        /// <summary>
        /// 行业分布 行业名称
        /// </summary>
        /// <param name="beginTime"></param>
        /// <returns></returns>
        public List<dynamic> HyfbTable01(string beginTime)
        {
            var beginTime_Tq = beginTime.YearSubtract();
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"
select cc.industry_mtype_name,cc.industry_mtype_id, 
decode(aa.sh_sj,null,0,aa.sh_sj) sh_sj,bb.t_sh_sj, round((aa.sh_sj-bb.t_sh_sj)/bb.t_sh_sj*100,2) tbzz ,aa.zb,
decode(aa.entnum,null,0,aa.entnum) entnum from
(select  d.industry_mtype_name,round(sum(nvl(sh_sj,0))/10000,2) sh_sj,round((ratio_to_report(sum(nvl(d.sh_sj,0))) over())*100,2) zb,count(entnum) entnum from 
(select c.industry_mtype_name, 1 entnum,a.sh_sj sh_sj from (select nat_org_code,org_name,sum(sh_sj) sh_sj ,industry_id,rep_date,flag_orginfo2 from t_sh_year_entlist where nat_org_code is not null group by nat_org_code,org_name,industry_id,rep_date,flag_orginfo2)  a,
org_info2 b,
ndic_industry c
where a.nat_org_code(+)=b.nat_org_code and b.industry_id=c.industry_type4_id(+) and rep_date={0}) d
group by industry_mtype_name) aa
,
(select  d.industry_mtype_name, count(entnum) entnum ,round(sum(nvl(sh_sj,0))/10000,2) t_sh_sj from 
(select c.industry_mtype_name, 1 entnum,a.sh_sj from (select nat_org_code,org_name,sum(sh_sj) sh_sj ,industry_id,rep_date,flag_orginfo2 from t_sh_year_entlist where nat_org_code is not null group by nat_org_code,org_name,industry_id,rep_date,flag_orginfo2)  a,
org_info2 b,
ndic_industry c
where a.nat_org_code(+)=b.nat_org_code and b.industry_id(+)=c.industry_type4_id and rep_date={1}) d
group by industry_mtype_name) bb ,
(select distinct industry_mtype_id, industry_mtype_name from ndic_industry)  cc
where  cc.industry_mtype_name=aa.industry_mtype_name(+) and cc.industry_mtype_name=bb.industry_mtype_name(+)
", beginTime, beginTime_Tq);
            return SqlBaseOperation.Query(strSql.ToString());
        }

        /// <summary>
        /// 行业分布 连续高速增长
        /// </summary>
        /// <param name="beginTime"></param>
        /// <returns></returns>
        public List<dynamic> HyfbTable02(string beginTime)
        {
            var beginTime_Tq = beginTime.YearSubtract();  //2015-->2014
            var beginTime_Tq_1 = beginTime.YearSubtract(2);  //2015-->2013
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"
select a.INDUSTRY_MTYPE_ID, a.INDUSTRY_MTYPE_NAME
,a1.ZS ZS_first, a2.ZS ZS_second
 from 
( select distinct INDUSTRY_MTYPE_ID, INDUSTRY_MTYPE_NAME from ndic_industry ) a,
(select c.industry_mtype_id,c.industry_mtype_name
,decode(sum(nvl(b.targetfield,0)),0,0,round(sum(nvl(a.targetfield,0)-(nvl(b.targetfield,0)))/abs(sum(nvl(b.targetfield,0)))*100,2)) ZS
from
(select industry_id,sum(nvl(sh_sj,0)) targetfield from (select nat_org_code,org_name,sum(sh_sj) sh_sj ,industry_id,rep_date,flag_orginfo2 from t_sh_year_entlist where nat_org_code is not null group by nat_org_code,org_name,industry_id,rep_date,flag_orginfo2) where rep_date ={0} and flag_orginfo2=1 group by industry_id) a,
(select industry_id,sum(nvl(sh_sj,0)) targetfield from (select nat_org_code,org_name,sum(sh_sj) sh_sj ,industry_id,rep_date,flag_orginfo2 from t_sh_year_entlist where nat_org_code is not null group by nat_org_code,org_name,industry_id,rep_date,flag_orginfo2) where rep_date ={1} and flag_orginfo2=1 group by industry_id) b,
ndic_industry c                                                                                                                                                  
where c.industry_type4_id=a.industry_id(+) and c.industry_type4_id=b.industry_id(+)                                                                              
group by c.industry_mtype_id,c.industry_mtype_name) a1,                                                                                                          
                                                                                                                                                                 
(select c.industry_mtype_id,c.industry_mtype_name                                                                                                                
,decode(sum(nvl(b.targetfield,0)),0,0,round(sum(nvl(a.targetfield,0)-(nvl(b.targetfield,0)))/abs(sum(nvl(b.targetfield,0)))*100,2)) ZS                                
from                                                                                                                                                             
(select industry_id,sum(nvl(sh_sj,0)) targetfield from (select nat_org_code,org_name,sum(sh_sj) sh_sj ,industry_id,rep_date,flag_orginfo2 from t_sh_year_entlist where nat_org_code is not null group by nat_org_code,org_name,industry_id,rep_date,flag_orginfo2) where rep_date ={1} and flag_orginfo2=1 group by industry_id) a,
(select industry_id,sum(nvl(sh_sj,0)) targetfield from (select nat_org_code,org_name,sum(sh_sj) sh_sj ,industry_id,rep_date,flag_orginfo2 from t_sh_year_entlist where nat_org_code is not null group by nat_org_code,org_name,industry_id,rep_date,flag_orginfo2) where rep_date ={2} and flag_orginfo2=1 group by industry_id) b,
ndic_industry c
where c.industry_type4_id=a.industry_id(+) and c.industry_type4_id=b.industry_id(+)
group by c.industry_mtype_id,c.industry_mtype_name) a2
where a.INDUSTRY_MTYPE_ID=a1.INDUSTRY_MTYPE_ID(+)
and a.INDUSTRY_MTYPE_ID=a2.INDUSTRY_MTYPE_ID(+)
and a1.ZS>=30 and a2.ZS>=30 order by a1.ZS desc", beginTime, beginTime_Tq, beginTime_Tq_1);
            return SqlBaseOperation.Query(strSql.ToString());
        }

        /// <summary>
        /// 行业分布 连续高速减少
        /// </summary>
        /// <param name="beginTime"></param>
        /// <returns></returns>
        public List<dynamic> HyfbTable03(string beginTime)
        {
            var beginTime_Tq = beginTime.YearSubtract();  //2015-->2014
            var beginTime_Tq_1 = beginTime.YearSubtract(2);  //2015-->2013
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"
select a.INDUSTRY_MTYPE_ID, a.INDUSTRY_MTYPE_NAME
,a1.ZS ZS_first, a2.ZS ZS_second
 from 
( select distinct INDUSTRY_MTYPE_ID, INDUSTRY_MTYPE_NAME from ndic_industry ) a,

(select c.industry_mtype_id,c.industry_mtype_name
,decode(sum(nvl(b.targetfield,0)),0,0,round(sum(nvl(a.targetfield,0)-(nvl(b.targetfield,0)))/abs(sum(nvl(b.targetfield,0)))*100,2)) ZS
from
(select industry_id,sum(nvl(sh_sj,0)) targetfield from (select nat_org_code,org_name,sum(sh_sj) sh_sj ,industry_id,rep_date,flag_orginfo2 from t_sh_year_entlist where nat_org_code is not null group by nat_org_code,org_name,industry_id,rep_date,flag_orginfo2) where rep_date ={0} and flag_orginfo2=1 group by industry_id) a,
(select industry_id,sum(nvl(sh_sj,0)) targetfield from (select nat_org_code,org_name,sum(sh_sj) sh_sj ,industry_id,rep_date,flag_orginfo2 from t_sh_year_entlist where nat_org_code is not null group by nat_org_code,org_name,industry_id,rep_date,flag_orginfo2) where rep_date ={1} and flag_orginfo2=1 group by industry_id) b,
ndic_industry c                                                                                                                                                  
where c.industry_type4_id=a.industry_id(+) and c.industry_type4_id=b.industry_id(+)                                                                              
group by c.industry_mtype_id,c.industry_mtype_name) a1,                                                                                                          
                                                                                                                                                                 
(select c.industry_mtype_id,c.industry_mtype_name                                                                                                                
,decode(sum(nvl(b.targetfield,0)),0,0,round(sum(nvl(a.targetfield,0)-(nvl(b.targetfield,0)))/abs(sum(nvl(b.targetfield,0)))*100,2)) ZS                                
from                                                                                                                                                             
(select industry_id,sum(nvl(sh_sj,0)) targetfield from (select nat_org_code,org_name,sum(sh_sj) sh_sj ,industry_id,rep_date,flag_orginfo2 from t_sh_year_entlist where nat_org_code is not null group by nat_org_code,org_name,industry_id,rep_date,flag_orginfo2) where rep_date ={1} and flag_orginfo2=1 group by industry_id) a,
(select industry_id,sum(nvl(sh_sj,0)) targetfield from (select nat_org_code,org_name,sum(sh_sj) sh_sj ,industry_id,rep_date,flag_orginfo2 from t_sh_year_entlist where nat_org_code is not null group by nat_org_code,org_name,industry_id,rep_date,flag_orginfo2) where rep_date ={2} and flag_orginfo2=1 group by industry_id) b,
ndic_industry c
where c.industry_type4_id=a.industry_id(+) and c.industry_type4_id=b.industry_id(+)
group by c.industry_mtype_id,c.industry_mtype_name) a2
where a.INDUSTRY_MTYPE_ID=a1.INDUSTRY_MTYPE_ID(+)
and a.INDUSTRY_MTYPE_ID=a2.INDUSTRY_MTYPE_ID(+)
and a1.ZS<=-30 and a2.ZS<=-30 order by a1.ZS asc
", beginTime, beginTime_Tq, beginTime_Tq_1);
            return SqlBaseOperation.Query(strSql.ToString());
        }

        /// <summary>
        /// 行业水耗占比分析
        /// </summary>
        /// <param name="beginTime"></param>
        /// <returns></returns>
        public List<dynamic> HyfbChart01(string beginTime)
        {
            var year = Conv.ToInt(beginTime);
            StringBuilder strSql = new StringBuilder();
            var minTime = 2010;//自动获取最初日期
            for (var i = year; i >= minTime; i--)
            {//rep_date 取1-12的值
                strSql.AppendFormat(@"select {0} rep_date,c.industry_mtype_name piename,
round(sum(nvl(a.sh_sj,0))/10000,2) pievalue,
round((ratio_to_report(sum(nvl(a.sh_sj,0))) over())*100,2) zb
from  
(select  nat_org_code,1 entnum,sh_sj from 
(select nat_org_code,org_name,sum(sh_sj) sh_sj ,sum(sh_jh) sh_jh ,industry_id,rep_date,flag_orginfo2 from t_sh_year_entlist where  nat_org_code is not null group by nat_org_code,org_name,industry_id,rep_date,flag_orginfo2)
where rep_date={0}) a,
org_info2 b,
ndic_industry c
where a.nat_org_code(+)=b.nat_org_code 
and b.industry_id(+)=c.industry_type4_id
group by  c.industry_mtype_name  ", i);
                if (i > minTime)
                    strSql.Append(" union all ");
            }
            return SqlBaseOperation.Query(strSql.ToString());
        }

        /// <summary>
        /// 产业分布 一二三次产业
        /// </summary>
        /// <param name="beginTime"></param>
        /// <returns></returns>
        public List<dynamic> CyfbTable01(string beginTime)
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
decode(aa.sh_sj,null,0,aa.sh_sj) sh_sj,
decode(aa.sh_sj,0,0,round((aa.sh_sj-bb.sh_sj)/abs(bb.sh_sj)*100,2)) tbzs,
decode(aa.sh_sj,0,0,round(aa.sh_sj*100/sum(aa.sh_sj) over(partition by null),2)) zb,
decode(aa.entnum,null,0,aa.entnum) entnum
from 
(select bb.flag_3c,aa.entnum,aa.sh_sj from
(select b.flag_3c,count(1) entnum, round(sum(nvl(sh_sj,0))/10000,2) sh_sj from 
(select nat_org_code,org_name,sum(sh_sj) sh_sj ,industry_id,rep_date,flag_orginfo2 from t_sh_year_entlist where nat_org_code is not null group by nat_org_code,org_name,industry_id,rep_date,flag_orginfo2) a,
org_info2 b 
where a.nat_org_code(+)=b.nat_org_code and rep_date ={0} and b.flag_3c<>0
group by b.flag_3c)aa,
(select distinct flag_3c from org_info2 where  flag_3c <>0) bb
where aa.flag_3c(+)=bb.flag_3c) aa
,
(select bb.flag_3c,aa.entnum,aa.sh_sj from
(select b.flag_3c,count(1) entnum, round(sum(nvl(sh_sj,0))/10000,2) sh_sj from (select nat_org_code,org_name,sum(sh_sj) sh_sj ,industry_id,rep_date,flag_orginfo2 from t_sh_year_entlist where nat_org_code is not null group by nat_org_code,org_name,industry_id,rep_date,flag_orginfo2) a,
org_info2 b 
where a.nat_org_code(+)=b.nat_org_code and rep_date ={1} and b.flag_3c<>0
group by b.flag_3c)aa,
(select distinct flag_3c from org_info2 where  flag_3c <>0) bb
where aa.flag_3c(+)=bb.flag_3c) bb
where aa.flag_3c=bb.flag_3c
order by  flag_3c asc", beginTime, beginTime_Tq);
            return SqlBaseOperation.Query(strSql.ToString());
        }

        /// <summary>
        /// 产业分布 主导产业
        /// </summary>
        /// <param name="beginTime"></param>
        /// <returns></returns>
        public List<dynamic> CyfbTable02(string beginTime)
        {
            var beginTime_Tq = beginTime.YearSubtract();
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"
select aa.DY_INDUSTRY_MTYPE_ID,aa.DY_INDUSTRY_MTYPE_NAME,aa.SH_SJ,
decode(aa.sh_sj,0,0,round((aa.sh_sj-bb.sh_sj)/abs(bb.sh_sj)*100,2)) tbzs,
decode(aa.sh_sj,0,0,round(aa.sh_sj*100/sum(aa.sh_sj) over(partition by null),2)) zb,aa.ENTNUM
from
(select DY_INDUSTRY_MTYPE_ID,c.dy_industry_mtype_name,round(sum(nvl(sh_sj,0))/10000,2) sh_sj,count(1) entnum from (select nat_org_code,org_name,sum(sh_sj) sh_sj ,industry_id,rep_date,flag_orginfo2 from t_sh_year_entlist where nat_org_code is not null group by nat_org_code,org_name,industry_id,rep_date,flag_orginfo2) a,
org_info2 b,
dic_dy_industry c 
where 
a.nat_org_code(+)=b.nat_org_code 
and b.industry_id=c.dy_industry_type4_id
and DY_INDUSTRY_MTYPE_ID in('X','W','J')
and rep_date ={0} 
group by  DY_INDUSTRY_MTYPE_ID, c.dy_industry_mtype_name
union
select DY_INDUSTRY_MTYPE_ID,c.dy_industry_mtype_name,round(sum(nvl(sh_sj,0))/10000,2) sh_sj,count(1) entnum from (select nat_org_code,org_name,sum(sh_sj) sh_sj ,industry_id,rep_date,flag_orginfo2 from t_sh_year_entlist where nat_org_code is not null group by nat_org_code,org_name,industry_id,rep_date,flag_orginfo2) a,
org_info2 b,
dic_dy_industry_new c
where 
a.nat_org_code(+)=b.nat_org_code 
and b.industry_id(+)=c.industry_id
and DY_INDUSTRY_MTYPE_ID in('GX')
and rep_date ={0} 
group by  DY_INDUSTRY_MTYPE_ID, c.dy_industry_mtype_name) aa
,
(select DY_INDUSTRY_MTYPE_ID,c.dy_industry_mtype_name,round(sum(nvl(sh_sj,0))/10000,2) sh_sj,count(1) entnum from (select nat_org_code,org_name,sum(sh_sj) sh_sj ,industry_id,rep_date,flag_orginfo2 from t_sh_year_entlist where nat_org_code is not null group by nat_org_code,org_name,industry_id,rep_date,flag_orginfo2) a,
org_info2 b,
dic_dy_industry c 
where 
a.nat_org_code(+)=b.nat_org_code 
and b.industry_id=c.dy_industry_type4_id
and DY_INDUSTRY_MTYPE_ID in('X','W','J')
and rep_date ={1} 
group by  DY_INDUSTRY_MTYPE_ID, c.dy_industry_mtype_name
union
select DY_INDUSTRY_MTYPE_ID,c.dy_industry_mtype_name,round(sum(nvl(sh_sj,0))/10000,2) sh_sj,count(1) entnum from (select nat_org_code,org_name,sum(sh_sj) sh_sj ,industry_id,rep_date,flag_orginfo2 from t_sh_year_entlist where nat_org_code is not null group by nat_org_code,org_name,industry_id,rep_date,flag_orginfo2) a,
org_info2 b,
dic_dy_industry_new c
where 
a.nat_org_code(+)=b.nat_org_code 
and b.industry_id(+)=c.industry_id
and DY_INDUSTRY_MTYPE_ID in('GX')
and rep_date ={1}
group by  DY_INDUSTRY_MTYPE_ID, c.dy_industry_mtype_name) bb
where aa.DY_INDUSTRY_MTYPE_ID=bb.DY_INDUSTRY_MTYPE_ID
order by DY_INDUSTRY_MTYPE_NAME desc", beginTime, beginTime_Tq);
            return SqlBaseOperation.Query(strSql.ToString());
        }

        /// <summary>
        /// 产业分布  一二三次产业水耗总量占比
        /// </summary>
        /// <param name="beginTime"></param>
        /// <returns></returns>
        public List<dynamic> CyfbChart01(string beginTime)
        {
            var beginTime_Tq = beginTime.YearSubtract();
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"
select case
when aa.flag_3c=1 then '第一产业'
when aa.flag_3c=2 then '第二产业'
when aa.flag_3c=3 then '第三产业' 
else null end FLAG_3C,
decode(aa.sh_sj,null,0,round(aa.sh_sj*100/sum(aa.sh_sj) over(partition by null),2)) zb
from 
(select bb.flag_3c,aa.entnum,aa.sh_sj from
(select b.flag_3c,count(1) entnum, round(sum(nvl(sh_sj,0))/10000,2) sh_sj from (select nat_org_code,org_name,sum(sh_sj) sh_sj ,industry_id,rep_date,flag_orginfo2 from t_sh_year_entlist where nat_org_code is not null group by nat_org_code,org_name,industry_id,rep_date,flag_orginfo2) a,org_info2 b 
where a.nat_org_code(+)=b.nat_org_code and rep_date ={0} and b.flag_3c<>0
group by b.flag_3c)aa,
(select distinct flag_3c from org_info2 where  flag_3c <>0) bb
where aa.flag_3c(+)=bb.flag_3c 
order by flag_3c) aa
,
(select bb.flag_3c,aa.entnum,aa.sh_sj from
(select b.flag_3c,count(1) entnum, round(sum(nvl(sh_sj,0))/10000,2) sh_sj from (select nat_org_code,org_name,sum(sh_sj) sh_sj ,industry_id,rep_date,flag_orginfo2 from t_sh_year_entlist where nat_org_code is not null group by nat_org_code,org_name,industry_id,rep_date,flag_orginfo2) a,org_info2 b 
where a.nat_org_code(+)=b.nat_org_code and rep_date ={1} and b.flag_3c<>0
group by b.flag_3c)aa,
(select distinct flag_3c from org_info2 where  flag_3c <>0) bb
where aa.flag_3c(+)=bb.flag_3c) bb
where aa.flag_3c=bb.flag_3c", beginTime, beginTime_Tq);
            return SqlBaseOperation.Query(strSql.ToString());
        }

        /// <summary>
        /// 产业分布 主导产业水耗总量占比
        /// </summary>
        /// <param name="beginTime"></param>
        /// <returns></returns>
        public string CyfbChart02(string beginTime)
        {
           string strSql=string.Format(@"select {0} rep_date,t.DY_INDUSTRY_MTYPE_NAME,t.SH_SJ,decode(t.sh_sj,0,0,round(t.sh_sj*100/sum(t.sh_sj) over(partition by null),2)) zb
from
(select DY_INDUSTRY_MTYPE_ID,c.dy_industry_mtype_name,round(sum(nvl(sh_sj,0))/10000,2) sh_sj,count(1) entnum from (select nat_org_code,org_name,sum(sh_sj) sh_sj ,industry_id,rep_date,flag_orginfo2 from t_sh_year_entlist where nat_org_code is not null group by nat_org_code,org_name,industry_id,rep_date,flag_orginfo2) a,
org_info2 b,
dic_dy_industry c 
where 
a.nat_org_code(+)=b.nat_org_code 
and b.industry_id=c.dy_industry_type4_id
and DY_INDUSTRY_MTYPE_ID in('X','W','J')
and rep_date ={0} 
group by  DY_INDUSTRY_MTYPE_ID, c.dy_industry_mtype_name
union
select DY_INDUSTRY_MTYPE_ID,c.dy_industry_mtype_name,round(sum(nvl(sh_sj,0))/10000,2) sh_sj,count(1) entnum from (select nat_org_code,org_name,sum(sh_sj) sh_sj ,industry_id,rep_date,flag_orginfo2 from t_sh_year_entlist where nat_org_code is not null group by nat_org_code,org_name,industry_id,rep_date,flag_orginfo2) a,
org_info2 b,
dic_dy_industry_new c
where 
a.nat_org_code(+)=b.nat_org_code 
and b.industry_id(+)=c.industry_id
and DY_INDUSTRY_MTYPE_ID in('GX')
and rep_date ={0} 
group by  DY_INDUSTRY_MTYPE_ID, c.dy_industry_mtype_name) t
order by DY_INDUSTRY_MTYPE_NAME desc", beginTime);
            return strSql;
        }

        /// <summary>
        /// 形态类别
        /// </summary>
        /// <param name="beginTime"></param>
        /// <returns></returns>
        public List<dynamic> XtlbTable01(string beginTime)
        {
            var beginTime_Tq = beginTime.YearSubtract();
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"
select aa.names,aa.sh_sj,bb.sh_sj,decode(aa.sh_sj,0,0,round((aa.sh_sj-bb.sh_sj)/bb.sh_sj*100,2)) tbzz,aa.entnum
from 
(select '总部企业' names ,round(sum(nvl(sh_sj,0))/10000,2) sh_sj,count(1) entnum from (select nat_org_code,org_name,sum(sh_sj) sh_sj ,industry_id,rep_date,flag_orginfo2 from t_sh_year_entlist where nat_org_code is not null group by nat_org_code,org_name,industry_id,rep_date,flag_orginfo2) a,
商委_总部企业 b
where  a.nat_org_code(+)=b.nat_org_code and a.rep_date ={0}
union
select '跨国公司总部企业' names ,round(sum(nvl(sh_sj,0))/10000,2) sh_sj,count(1) entnum from (select nat_org_code,org_name,sum(sh_sj) sh_sj ,industry_id,rep_date,flag_orginfo2 from t_sh_year_entlist where nat_org_code is not null group by nat_org_code,org_name,industry_id,rep_date,flag_orginfo2) a,
商委_跨国公司总部企业 b
where  a.nat_org_code(+)=b.nat_org_code and a.rep_date ={0}) aa
,
(select '总部企业' names ,round(sum(nvl(sh_sj,0))/10000,2) sh_sj,count(1) entnum from (select nat_org_code,org_name,sum(sh_sj) sh_sj ,industry_id,rep_date,flag_orginfo2 from t_sh_year_entlist where nat_org_code is not null group by nat_org_code,org_name,industry_id,rep_date,flag_orginfo2) a,
商委_总部企业 b
where  a.nat_org_code(+)=b.nat_org_code and a.rep_date ={1}
union
select '跨国公司总部企业' names ,round(sum(nvl(sh_sj,0))/10000,2) sh_sj,count(1) entnum from (select nat_org_code,org_name,sum(sh_sj) sh_sj ,industry_id,rep_date,flag_orginfo2 from t_sh_year_entlist where nat_org_code is not null group by nat_org_code,org_name,industry_id,rep_date,flag_orginfo2) a,
商委_跨国公司总部企业 b
where  a.nat_org_code(+)=b.nat_org_code and a.rep_date ={1}) bb
where aa.names=bb.names
order by names desc
", beginTime, beginTime_Tq);
            return SqlBaseOperation.Query(strSql.ToString());
        }

        /// <summary>
        /// 企业类型 分类
        /// </summary>
        /// <param name="beginTime"></param>
        /// <returns></returns>
        public List<dynamic> WzTable01(string beginTime)
        {
            var beginTime_Tq = beginTime.YearSubtract();
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"
select bbb.ent_mtype_id,bbb.ent_mtype_name,decode(aaa.sh_sj,null,0,aaa.sh_sj) sh_sj,aaa.tbzs,aaa.zb,decode(aaa.entnum,null,0,aaa.entnum) entnum from
(select aa.ent_mtype_id,aa.ent_mtype_name,
aa.sh_sj,
decode(bb.sh_sj,0,0,round((aa.sh_sj-bb.sh_sj)/abs(bb.sh_sj)*100,2)) tbzs,
decode(aa.sh_sj,0,0,round(aa.sh_sj*100/sum(aa.sh_sj) over(partition by null),2)) zb,
aa.entnum
from
(select c.ent_mtype_id, c.ent_mtype_name,round(sum(nvl(sh_sj,0))/10000,2) sh_sj,count(1) entnum
 from 
(select nat_org_code,org_name,sum(sh_sj) sh_sj ,industry_id,rep_date,flag_orginfo2 from t_sh_year_entlist where nat_org_code is not null group by nat_org_code,org_name,industry_id,rep_date,flag_orginfo2) a,
org_info2 b,
dic_enterprise_type c 
where 
a.nat_org_code(+)=b.nat_org_code 
and b.ent_type_id(+)=c.ent_btype_id
and rep_date ={0} 
group by  c.ent_mtype_id,c.ent_mtype_name) aa
,
(select c.ent_mtype_id, c.ent_mtype_name,round(sum(nvl(sh_sj,0))/10000,2) sh_sj,count(1) entnum from 
(select nat_org_code,org_name,sum(sh_sj) sh_sj ,industry_id,rep_date,flag_orginfo2 from t_sh_year_entlist where nat_org_code is not null group by nat_org_code,org_name,industry_id,rep_date,flag_orginfo2) a,
org_info2 b,
dic_enterprise_type c 
where 
a.nat_org_code(+)=b.nat_org_code 
and b.ent_type_id(+)=c.ent_btype_id
and rep_date ={1} 
group by  c.ent_mtype_id,c.ent_mtype_name) bb
where aa.ent_mtype_name=bb.ent_mtype_name)aaa
,
(select distinct ent_mtype_id,ent_mtype_name from dic_enterprise_type where ent_mtype_id in ('100','200','300')) bbb
where aaa.ent_mtype_id(+)=bbb.ent_mtype_id
order by ent_mtype_id", beginTime, beginTime_Tq);
            return SqlBaseOperation.Query(strSql.ToString());
        }

        /// <summary>
        /// 企业类型 内外资水耗占比分析
        /// </summary>
        /// <param name="beginTime"></param>
        /// <returns></returns>
        public List<dynamic> WzChart01(string beginTime)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"
select bbb.ent_mtype_id,bbb.ent_mtype_name,decode(aaa.zb,null,0,aaa.zb) zb from
(select aa.ent_mtype_id,aa.ent_mtype_name,decode(aa.sh_sj,0,0,round(aa.sh_sj*100/sum(aa.sh_sj) over(partition by null),2)) zb
from
(select c.ent_mtype_id, c.ent_mtype_name,round(sum(nvl(sh_sj,0))/10000,2) sh_sj
from (select nat_org_code,org_name,sum(sh_sj) sh_sj ,industry_id,rep_date,flag_orginfo2 from t_sh_year_entlist where nat_org_code is not null group by nat_org_code,org_name,industry_id,rep_date,flag_orginfo2) a,
org_info2 b,
dic_enterprise_type c 
where 
a.nat_org_code(+)=b.nat_org_code 
and b.ent_type_id(+)=c.ent_btype_id
and rep_date ={0} 
group by  c.ent_mtype_id,c.ent_mtype_name) aa) aaa
,
(select distinct ent_mtype_id,ent_mtype_name from dic_enterprise_type) bbb
where aaa.ent_mtype_id(+)=bbb.ent_mtype_id
order by ent_mtype_id
", beginTime);
            return SqlBaseOperation.Query(strSql.ToString());
        }

        /// <summary>
        /// 功能区 分类
        /// </summary>
        /// <param name="beginTime"></param>
        /// <returns></returns>
        public List<dynamic> GnqTable01(string beginTime)
        {
            var beginTime_Tq = beginTime.YearSubtract();
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"
select bbb.id,bbb.gnq_name,decode(aaa.sh_sj,null,0,aaa.sh_sj) sh_sj,aaa.tbzs,aaa.zb,decode(aaa.entnum,null,0,aaa.entnum) entnum from
(select aa.gnqid,aa.sh_sj,
decode(bb.sh_sj,0,0,round((aa.sh_sj-bb.sh_sj)/abs(bb.sh_sj)*100,2)) tbzs,
decode(aa.sh_sj,0,0,round(aa.sh_sj*100/sum(aa.sh_sj) over(partition by null),2)) zb,aa.entnum
from  
(select case
when substr(FLAG_GNQ,1,1)=1 then '1'
when substr(FLAG_GNQ,2,1)=1 then '2'
when substr(FLAG_GNQ,3,1)=1 then '3'
when substr(FLAG_GNQ,4,1)=1 then '4'
when substr(FLAG_GNQ,5,1)=1 then '5'
when substr(FLAG_GNQ,6,1)=1 then '6'
else null end as gnqId , round(sum(nvl(sh_sj,0))/10000,2) sh_sj,count(1) entnum
from (select nat_org_code,org_name,sum(sh_sj) sh_sj ,industry_id,rep_date,flag_orginfo2 from t_sh_year_entlist where nat_org_code is not null group by nat_org_code,org_name,industry_id,rep_date,flag_orginfo2) a,
org_info2 b
where a.nat_org_code(+)=b.nat_org_code and rep_date={0}
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
else null end as gnqId , round(sum(nvl(sh_sj,0))/10000,2) sh_sj,count(1) entnum
from (select nat_org_code,org_name,sum(sh_sj) sh_sj ,industry_id,rep_date,flag_orginfo2 from t_sh_year_entlist where nat_org_code is not null group by nat_org_code,org_name,industry_id,rep_date,flag_orginfo2) a,
org_info2 b
where a.nat_org_code(+)=b.nat_org_code and rep_date={1}
group by  
case  
when substr(FLAG_GNQ,1,1)=1 then '1'
when substr(FLAG_GNQ,2,1)=1 then '2'
when substr(FLAG_GNQ,3,1)=1 then '3'
when substr(FLAG_GNQ,4,1)=1 then '4'
when substr(FLAG_GNQ,5,1)=1 then '5'
when substr(FLAG_GNQ,6,1)=1 then '6'
else null end) bb
where aa.gnqId=bb.gnqId )aaa
,
dic_gnq bbb 
where aaa.gnqId=bbb.id", beginTime, beginTime_Tq);
            return SqlBaseOperation.Query(strSql.ToString());
        }

        /// <summary>
        /// 功能区水耗占比分析
        /// </summary>
        /// <param name="beginTime"></param>
        /// <returns></returns>
        public IEnumerable<dynamic> GnqChart01(System.Data.IDbConnection conn, string beginTime)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"select bb.id,bb.gnq_name,
decode(aa.sh_sj,0,0,round(aa.sh_sj*100/sum(aa.sh_sj) over(partition by null),2)) zb
from
(select case
when substr(FLAG_GNQ,1,1)=1 then '1'
when substr(FLAG_GNQ,2,1)=1 then '2'
when substr(FLAG_GNQ,3,1)=1 then '3'
when substr(FLAG_GNQ,4,1)=1 then '4'
when substr(FLAG_GNQ,5,1)=1 then '5'
when substr(FLAG_GNQ,6,1)=1 then '6'
else null end as gnqId , round(sum(nvl(sh_sj,0))/10000,2) sh_sj from (select nat_org_code,org_name,sum(sh_sj) sh_sj ,industry_id,rep_date,flag_orginfo2 from t_sh_year_entlist where nat_org_code is not null group by nat_org_code,org_name,industry_id,rep_date,flag_orginfo2) a,
org_info2 b
where a.nat_org_code(+)=b.nat_org_code and rep_date={0}
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
where aa.gnqId=bb.id", beginTime);
            return SqlBaseOperation.Query(strSql.ToString());
        }
    }
}
