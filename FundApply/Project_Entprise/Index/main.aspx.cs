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
                int userId = (Session["UsersModel"] as FundApply.Model.UsersModel).Id;
                projectApplyModelList = projectApplyBll.GetModelList(string.Format("UserId={0}", userId));
                projectApplytHistoryModelLis = projectApplyBll.GetModelList(string.Format("UserId={0} and datediff(year,CreateTime,GETDATE())!=0 ",userId));
            }
        }


        [WebMethod]
        public static string ExistsProject(string userId)
        {
            ProjectApplyBll projectApplyBll = new ProjectApplyBll();
            bool result = projectApplyBll.ExistsProject(int.Parse(userId));
            if (result)
            {
                return "true";
            }
            else
            {
                return "false";
            }
        }

        [WebMethod]
        public static string Del(string id)
        {
            ProjectApplyBll projectApplyBll = new ProjectApplyBll();
            ProjectApply_CheckBll projectApply_CheckBll = new ProjectApply_CheckBll();
            ProjectApply_ModifyContentBll projectApply_ModifyContent = new ProjectApply_ModifyContentBll();
            //int projectApplyId = projectApplyBll.GetModel(id).Id;
            try
            {
                int projectApplyId = int.Parse(id);
                bool result = projectApplyBll.Delete(projectApplyId);
                bool resultCheck = projectApply_CheckBll.DeleteByProjectApplyId(projectApplyId);
                bool resultModifyContent = projectApply_ModifyContent.DeleteByProjectApplyId(projectApplyId);

                if (result)
                {
                    return "true";
                }
                else
                {
                    return "false";
                }
            }
            catch (Exception)
            {

                throw;
            }


        }
    }
}