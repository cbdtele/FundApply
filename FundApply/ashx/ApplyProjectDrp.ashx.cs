using FundApply.BLL;
using FundApply.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FundApply.ashx
{
    /// <summary>
    /// ApplyProjectDrp 的摘要说明
    /// </summary>
    public class ApplyProjectDrp : IHttpHandler
    {

        Dic_ApplyTypeBll dic_ApplyTypeModel = new Dic_ApplyTypeBll();
        public void ProcessRequest(HttpContext context)
        {

            if (context.Request.Params["n"] != null)
            {
                string num = context.Request.Params["n"].ToString();
                context.Response.ContentType = "text/plain";
                List<Dic_ApplyTypeModel> dic_ApplyTypeModelList = dic_ApplyTypeModel.GetModelList();
                string json = JsonConvert.SerializeObject(dic_ApplyTypeModelList);

                context.Response.Write(json);
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