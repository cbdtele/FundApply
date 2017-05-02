using FundApply.BLL;
using FundApply.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace FundApply.ashx
{
    /// <summary>
    /// IndustryDrp 的摘要说明
    /// </summary>
    public class IndustryDrp : IHttpHandler
    {
        Dic_IndustryBll dic_IndustryBll = new Dic_IndustryBll();
        public void ProcessRequest(HttpContext context)
        {

            if (context.Request.Params["n"] != null)
            {
                string num = context.Request.Params["n"].ToString();
                context.Response.ContentType = "text/plain";
                if (context.Request.Params["industryId"] !=null)
                {
                    List<Dic_IndustryModel> list = dic_IndustryBll.GetModelList(string.Format("Industryid={0}", context.Request.Params["industryId"]));
                    string json = JsonConvert.SerializeObject(list);
                    context.Response.Write(json);
                }
                else
                {
                    List<Dic_IndustryModel> list = dic_IndustryBll.GetModelList("1=1");
                    string json = JsonConvert.SerializeObject(list);
                    context.Response.Write(json);
                }
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}