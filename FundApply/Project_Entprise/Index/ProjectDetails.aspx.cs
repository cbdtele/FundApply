using FundApply.BLL;
using FundApply.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FundApply.Project_Entprise
{
    public partial class ProjectDetails : System.Web.UI.Page
    {
        ProjectApplyBll projectApplyBll = new ProjectApplyBll();
        Dic_ApplyTypeBll dic_ApplyTypeBll = new Dic_ApplyTypeBll();
        List<Dic_ApplyTypeModel> Dic_ApplyTypeList = new List<Dic_ApplyTypeModel>();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        [WebMethod]
        public static string InitData(string id)
        {
            ProjectApplyBll projectApplyBll = new ProjectApplyBll();
            ProjectApplyModel model = projectApplyBll.GetModel(id);
            return JsonConvert.SerializeObject(model);
        }        
    }
}
