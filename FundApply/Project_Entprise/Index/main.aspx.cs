using FundApply.BLL;
using FundApply.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FundApply.Project_Entprise.Index
{
    public partial class main : System.Web.UI.Page
    {
        protected List<ProjectApplyModel> projectApplyModelList = new List<ProjectApplyModel>();
        protected List<ProjectApplyModel> projectApplytHistoryModelLis = new List<ProjectApplyModel>();
        ProjectApplyBll projectApplyBll = new ProjectApplyBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                projectApplyModelList = projectApplyBll.GetModelList(string.Format("UserId=1"));
                projectApplytHistoryModelLis = projectApplyBll.GetModelList(string.Format("UserId=1 and datediff(year,CreateTime,GETDATE())!=0 "));
            }
        }


        [WebMethod]
        public static string ExistsProject()
        {
            ProjectApplyBll projectApplyBll = new ProjectApplyBll();
            bool result = projectApplyBll.ExistsProject(1);
            if (result)
            {
                return "true";
            }
            else
            {
                return "false";
            }
        }
    }
}