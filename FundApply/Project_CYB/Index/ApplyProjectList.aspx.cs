using FundApply.BLL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FundApply.Project_CYB.Index
{
    public partial class ApplyProjectList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string GetApplyProjectList(string company)
        {
            ProjectApplyBll applyProjectBll = new ProjectApplyBll();
            DataTable dt = applyProjectBll.GetApplyProjectList(1, company).Tables[0];
            var json = JsonConvert.SerializeObject(dt);
            return json;
        }
    }
}