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

                if (num == "0")
                {
                    if (context.Request.Params["applyTypeId"] != null)
                    {
                        string applyTypeId = context.Request.Params["applyTypeId"];
                        string applyTypeId_BigId = applyTypeId.Substring(0, 1);
                        List<Dic_ApplyTypeModel> list = dic_ApplyTypeModel.GetBigModelList(string.Format("applyTypeId_BigId={0}", applyTypeId_BigId));
                        string json = JsonConvert.SerializeObject(list);
                        context.Response.Write(json);
                    }
                    else
                    {
                        List<Dic_ApplyTypeModel> list = dic_ApplyTypeModel.GetBigModelList("1=1");
                        string json = JsonConvert.SerializeObject(list);
                        context.Response.Write(json);
                    }
                }
                else
                {
                    if (context.Request.Params["applyTypeId"] != null)
                    {
                        string applyTypeId = context.Request.Params["applyTypeId"];
                        string applyTypeId_SmallId = applyTypeId;
                        List<Dic_ApplyTypeModel> list = dic_ApplyTypeModel.GetModelList(string.Format(" ApplyTypeId_SmallId={0}", applyTypeId_SmallId));
                        string json = JsonConvert.SerializeObject(list);
                        context.Response.Write(json);
                    }
                    else
                    {
                        List<Dic_ApplyTypeModel> list = dic_ApplyTypeModel.GetModelList(string.Format("ApplyTypeId_SmallId={0}", num));
                        string json = JsonConvert.SerializeObject(list);
                        context.Response.Write(json);
                    }
                   
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