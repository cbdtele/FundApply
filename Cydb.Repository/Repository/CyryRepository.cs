using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cydb.Common.Helper;
using Cydb.Repository.Base;

namespace Cydb.Repository.Repository
{
    public class CyryRepository : ICyryRepository
    {
        private static readonly ISqlBaseOperation SqlBaseOperation = new SqlBaseOperation();

        /// <summary>
        /// 总体情况  从业人员、同比增速
        /// </summary>
        /// <param name="beginTime"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<dynamic> CYRY(string beginTime, string type)
        {
            var beginTime_Tq = beginTime.YearSubtract();
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"select a.cyry,decode(nvl(b.cyry,0),0,0,round((a.cyry-b.cyry)/abs(b.cyry)*100,2)) tbzs from 
(select sum(nvl(cyry,0)) cyry from t_cw_month 
where rep_date = {0} and flag_orginfo2=1 and type in (select * from table(strsplit(GetFalg_Type({2}))))and nvl(cyry,0)<>0 
)a,
(select sum(nvl(cyry,0)) cyry from t_cw_month 
where rep_date = {1} and flag_orginfo2=1 and type in (select * from table(strsplit(GetFalg_Type({2}))))and nvl(cyry,0)<>0 
)b", beginTime, beginTime_Tq, type);
            return SqlBaseOperation.Query(strSql.ToString());
        }

        /// <summary>
        /// 历年1-n月税收与从业人员
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
select aaa.rep_date,
decode(aaa.cyry,null,0,aaa.cyry) cyry,
decode(bbb.tax,null,0,bbb.tax) tax from
(select b.rep_date,a.cyry from
(select  substr(rep_date,0,4) rep_date,sum(nvl(cyry,0)）cyry from t_cw_month 
where substr(rep_date,5,2) ={1} and flag_orginfo2=1 and type in (select * from table(strsplit(GetFalg_Type({2}))))and nvl(cyry,0)<>0 
group by substr(rep_date,0,4))a,
(select distinct substr(sjrq,0,4) rep_date from org_info_time_tj where substr(sjrq,0,4) between 2010 and 2016) b
where a.rep_date(+)=b.rep_date) aaa
,
(
select bb.rep_date,aa.tax from 
(select substr(rep_date,0,4) rep_date,round(sum(nvl(tax,0)）/100000000,2) tax from 
(
select a.nat_org_code,rep_date,tax from t_tax3 a,
(select nat_org_code from t_cw_month where rep_date={0}{1} and flag_orginfo2=1 and type in (select * from table(strsplit(GetFalg_Type({2}))))and nvl(cyry,0)<>0)b
where a.nat_org_code(+)=b.nat_org_code 
)
group by  substr(rep_date,0,4)) aa,
(select distinct substr(sjrq,0,4) rep_date from org_info_time_tj where substr(sjrq,0,4) between 2010 and {0}) bb
where aa.rep_date(+)=bb.rep_date
)bbb
where aaa.rep_date=bbb.rep_date
order by aaa.rep_date", beginTime_year, beginTime_month, type);
            return SqlBaseOperation.Query(strSql.ToString());
        }

        /// <summary>
        /// 历年全年1-n月税收与从业人员
        /// </summary>
        /// <param name="beginTime"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<dynamic> Chart02(string beginTime, string type)
        {
            var beginTime_year = TimeHelper.GetYear(beginTime);
            var beginTime_month = TimeHelper.GetMonth(beginTime);
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"
select aaa.rep_date,
decode(aaa.cyry,null,0,aaa.cyry) cyry,
decode(bbb.tax,null,0,bbb.tax) tax from
(select b.rep_date,a.cyry from
(select  substr(rep_date,0,4) rep_date,sum(nvl(cyry,0)）cyry from t_cw_month 
where substr(rep_date,5,2) =12 and flag_orginfo2=1 and type in (select * from table(strsplit(GetFalg_Type({2}))))and nvl(cyry,0)<>0 
group by substr(rep_date,0,4))a,
(select distinct substr(sjrq,0,4) rep_date from org_info_time_tj where substr(sjrq,0,4) between 2010 and {0}) b
where a.rep_date(+)=b.rep_date) aaa
,
(

select bb.rep_date,aa.tax from 
(select substr(rep_date,0,4) rep_date,round(sum(nvl(tax,0)）/100000000,2) tax from 
(
select a.nat_org_code,rep_date,tax from t_tax3 a,
(select nat_org_code from t_cw_month where rep_date={0}{1} and flag_orginfo2=1 and type in (select * from table(strsplit(GetFalg_Type({2}))))and nvl(cyry,0)<>0)b
where a.nat_org_code(+)=b.nat_org_code 
)
group by  substr(rep_date,0,4)) aa,
(select distinct substr(sjrq,0,4) rep_date from org_info_time_tj where substr(sjrq,0,4) between 2010 and {0}) bb
where aa.rep_date(+)=bb.rep_date

)bbb
where aaa.rep_date=bbb.rep_date
order by aaa.rep_date", beginTime_year, beginTime_month, type);
            return SqlBaseOperation.Query(strSql.ToString());
        }

        /// <summary>
        /// 人均税收、从业人员 TOP10
        /// </summary>
        /// <param name="beginTime"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<dynamic> ShuiShou_CYRY_List_Sql(string beginTime, string type)
        {
            var startTime = TimeHelper.GetYear(beginTime) + "01";
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"select bb.nat_org_code,bb.org_name,aa.cyry,aa.tax,aa.rj_tax from
(
select a.nat_org_code,a.cyry,round(nvl(b.tax,0)/10000,2) tax, round(nvl(b.tax,0)/10000/a.cyry,2)  rj_tax  from 
(select nat_org_code, sum(nvl(cyry,0)) cyry from t_cw_month
where rep_date ={0} and flag_orginfo2=1 and type in (select * from table(strsplit(GetFalg_Type({2}))))and nvl(cyry,0)<>0 
group by nat_org_code
) a,
(select nat_org_code, sum(nvl(tax,0)) tax from t_Tax3 where rep_date between {1} and {0} group  by nat_org_code) b
where a.nat_org_code = b.nat_org_code(+)
)aa,
(select nat_org_code,org_name from org_info2) bb
where aa.nat_org_code=bb.nat_org_code", beginTime, startTime, type);
            return SqlBaseOperation.Query(strSql.ToString());
        }

        /// <summary>
        /// 口径说明 年份
        /// </summary>
        /// <param name="beginTime"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<dynamic> GetAllByYear(string beginTime,string type)
        {
            var beginTime_year = TimeHelper.GetYear(beginTime);
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"select b.rep_date, decode(a.cyry, null, 0, a.cyry) cyry, decode(a.entnum, null, 0, a.entnum) entnum from
(select substr(rep_date, 0, 4) rep_date, sum(nvl(cyry, 0)) cyry, count(*) entnum from t_cw_month
where flag_orginfo2 = 1 and substr(rep_date, 5, 2) = 12 and type in (select * from table(strsplit(GetFalg_Type({1}))))and nvl(cyry, 0) <> 0
group by substr(rep_date, 0, 4)
order by rep_date desc)a,
(select distinct substr(sjrq, 0, 4) rep_date from org_info_time_tj where substr(sjrq, 0, 4)<={0}) b
 where a.rep_date(+) = b.rep_date
order by rep_date desc", beginTime_year, type);
            return SqlBaseOperation.Query(strSql.ToString());
        }

        /// <summary>
        /// 口径说明 月份
        /// </summary>
        /// <param name="beginTime"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<dynamic> GetMonthByYear(string year, string type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"select rep_date,sum(nvl(cyry,0)) cyry,count(*) entnum from t_cw_month 
where substr(rep_date, 0, 4) = {0} and substr(rep_date,5,2) in(02,05,08,11,12) and flag_orginfo2 = 1 and type in (select * from table(strsplit(GetFalg_Type({1}))))and nvl(cyry, 0) <> 0
group by rep_date
order by rep_date desc", year, type);
            return SqlBaseOperation.Query(strSql.ToString());
        }

        /// <summary>
        /// 行业分布  行业名称
        /// </summary>
        /// <param name="beginTime"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<dynamic> HyfbTable01(string beginTime, string type)
        {
            var beginTime_Tq = beginTime.YearSubtract();
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"
 select bb.industry_mtype_name,bb.INDUSTRY_MTYPE_ID,
 decode(aa.cyry,null,0,aa.cyry) cyry,aa.tbzz,aa.zb,
 decode(aa.entnum,null,0,aa.entnum) entnum from
 (
select a.industry_mtype_name,a.cyry,decode(b.cyry,0,0,round((nvl(a.cyry,0)-nvl(b.cyry,0))/nvl(b.cyry,1)*100,2)) tbzz,a.zb,a.entnum from
(select b.industry_mtype_name, sum(nvl(a.cyry,0)) cyry ,round((ratio_to_report(sum(nvl(cyry,0))) over())*100,2) zb,count(1) entnum from t_cw_month a , ndic_industry b  
where a.industry_id=b.industry_type4_id and rep_date ={0} and flag_orginfo2=1 and type in (select * from table(strsplit(GetFalg_Type({2}))))and nvl(cyry,0)<>0 
group by  b.industry_mtype_name 
) a,
 (select b.industry_mtype_name, sum(nvl(a.cyry,0)) cyry from t_cw_month a , ndic_industry b  
where a.industry_id=b.industry_type4_id and rep_date ={1} and flag_orginfo2=1 and type in (select * from table(strsplit(GetFalg_Type({2}))))and nvl(cyry,0)<>0 
group by  b.industry_mtype_name 
) b
where a.industry_mtype_name=b.industry_mtype_name) aa
,
(select distinct industry_mtype_name,INDUSTRY_MTYPE_ID from ndic_industry) bb
where aa.industry_mtype_name(+)=bb.industry_mtype_name
order by cyry desc", beginTime, beginTime_Tq, type);
            return SqlBaseOperation.Query(strSql.ToString());
        }

        /// <summary>
        /// 行业分布 行业从业人员占比分析
        /// </summary>
        /// <param name="beginTime"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<dynamic> HyfbChart01(string beginTime, string type)
        {
            var beginTime_year = TimeHelper.GetYear(beginTime);           
            var strSql = new StringBuilder();
            //自动获取最初日期
            var minTime = 2010;
            for (var i = beginTime_year; i >= minTime; i--)
            {   //rep_date 取1-12的值
                strSql.AppendFormat(@"
select {0} rep_date, b.industry_mtype_name PIENAME,sum(nvl(a.cyry,0)) PIEVALUE,round((ratio_to_report(sum(nvl(a.cyry,0))) over())*100,2) zb 
from t_cw_month a,ndic_industry b 
where a.industry_id = b.industry_type4_id and rep_date ={0}12 and flag_orginfo2=1 and type in (select * from table(strsplit(GetFalg_Type({1}))))and nvl(cyry,0)<>0 
group by  b.industry_mtype_name ", i, type);
                if (i > minTime)
                    strSql.Append(" union all ");
            }
            return SqlBaseOperation.Query(strSql.ToString()).OrderBy(t => t.REP_DATE).ToList(); ;
        }

        /// <summary>
        /// 产业分布
        /// </summary>
        /// <param name="beginTime"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<dynamic> CyfbTable01(string beginTime, string type)
        {
            var beginTime_start = TimeHelper.GetYear(beginTime) + "01";
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"
select rownum,t.* from
(
select bbb.DY_INDUSTRY_MTYPE_ID,bbb.DY_INDUSTRY_MTYPE_NAME,
decode(aaa.CYRY,null,0,aaa.CYRY) CYRY,
decode(aaa.TAX,null,0,aaa.TAX) TAX,
decode(aaa.ENTNUM,null,0,aaa.ENTNUM) ENTNUM,
decode(aaa.cyry,0,0,round(aaa.tax/aaa.cyry,2)) rj_tax,
decode(aaa.entnum,0,0,round(aaa.cyry/aaa.entnum,0)) rj_entnum from 
(
select bb.dy_industry_mtype_id,bb.dy_industry_mtype_name,sum(nvl(aa.cyry,0)) cyry,round(sum(aa.tax)/10000,2) tax,count(1) entnum from 
(select a.nat_org_code,a.industry_id,nvl(a.cyry,0) cyry,nvl(b.tax,0) tax from 
t_cw_month a, 
(select nat_org_code ,sum(nvl(tax,0)) tax from  t_Tax3 where rep_Date>={1} and rep_date<={0} group by nat_org_code) b
where a.nat_org_code=b.nat_org_code(+)
and a.rep_date={0} and flag_orginfo2=1 and a.type in (select * from table(strsplit(GetFalg_Type({2}))))and nvl(cyry,0)<>0 )aa
,
dic_dy_industry bb
where aa.industry_id=bb.dy_industry_type4_id and bb.DY_INDUSTRY_MTYPE_ID in('X','W','J')
group by  dy_industry_mtype_id,dy_industry_mtype_name
union 
select bb.dy_industry_mtype_id,bb.dy_industry_mtype_name,sum(nvl(aa.cyry,0)) cyry,round(sum(aa.tax)/10000,2) tax ,count(1) entnum from 
(select a.nat_org_code,a.industry_id,nvl(a.cyry,0) cyry,nvl(b.tax,0) tax from 
t_cw_month a, 
(select nat_org_code ,sum(nvl(tax,0)) tax from  t_Tax3 where rep_Date>={1} and rep_date<={0} group by nat_org_code) b
where a.nat_org_code=b.nat_org_code(+)
and a.rep_date={0} and flag_orginfo2=1 and a.type in (select * from table(strsplit(GetFalg_Type({2}))))and nvl(cyry,0)<>0 )aa
,
dic_dy_industry_new bb
where aa.industry_id=bb.industry_id and bb.DY_INDUSTRY_MTYPE_ID in('GX')
group by  dy_industry_mtype_id,dy_industry_mtype_name
)aaa,
(
select distinct DY_INDUSTRY_MTYPE_ID ,dy_industry_mtype_name from dic_dy_industry where DY_INDUSTRY_MTYPE_ID in ('X','W','J')  union
select distinct DY_INDUSTRY_MTYPE_ID ,dy_industry_mtype_name from dic_dy_industry_new where DY_INDUSTRY_MTYPE_ID in ('GX')
)bbb
where aaa.DY_INDUSTRY_MTYPE_ID(+) =bbb.DY_INDUSTRY_MTYPE_ID
) t", beginTime, beginTime_start, type);
            return SqlBaseOperation.Query(strSql.ToString());
        }

        /// <summary>
        /// 企业类型
        /// </summary>
        /// <param name="beginTime"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<dynamic> WzTable01(string beginTime, string type)
        {
            var beginTime_start = TimeHelper.GetYear(beginTime) + "01";
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"
select bbb.ENT_MTYPE_ID,bbb.ENT_MTYPE_NAME,
decode(aaa.ENTNUM,0,0,aaa.entnum)entnum,aaa.CYRY,aaa.TAX,aaa.RJ_TAX,aaa.RJ_ENTNUM  from
(select  aa.ent_mtype_id,aa.ent_mtype_name,aa.entnum,aa.cyry,aa.tax,round(aa.tax/aa.cyry,2) rj_tax,round(aa.cyry/aa.entnum,0) rj_entnum from
(select c.ent_mtype_id,c.ent_mtype_name, sum(nvl(cyry,0)) cyry , round(sum(nvl(tax,0))/10000,2) tax,count(1) entnum from
(select a.nat_org_code,a.industry_id,a.cyry,nvl(b.tax,0) tax from 
t_cw_month a, 
(select nat_org_code ,sum(nvl(tax,0)) tax from  t_Tax3 where rep_Date>={1} and rep_date<={0} group by nat_org_code) b
where a.nat_org_code=b.nat_org_code(+)
and a.rep_date={0} and flag_orginfo2=1 and a.type in (select * from table(strsplit(GetFalg_Type({2}))))and nvl(cyry,0)<>0 )a 
,org_info2 b
, dic_enterprise_type c
where a.nat_org_code=b.nat_org_code and b.ent_type_id=c.ent_btype_id 
group by c.ent_mtype_id, c.ent_mtype_name) aa
) aaa
,
(select distinct  ent_mtype_id,ent_mtype_name from  dic_enterprise_type where ent_mtype_id in ('100','200','300')) bbb
where aaa.ent_mtype_id(+) =bbb.ent_mtype_id
order by bbb.ENT_MTYPE_ID asc", beginTime, beginTime_start, type);
            return SqlBaseOperation.Query(strSql.ToString());
        }
    }

}
