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
    public partial class EditProject : System.Web.UI.Page
    {
        ProjectApplyBll projectApplyBll = new ProjectApplyBll();
        Dic_ApplyTypeBll dic_ApplyTypeBll = new Dic_ApplyTypeBll();
        List<Dic_ApplyTypeModel> Dic_ApplyTypeList = new List<Dic_ApplyTypeModel>();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        [WebMethod]
        public static string InitData(string userId)
        {
            ProjectApplyBll projectApplyBll = new ProjectApplyBll();
            ProjectApplyModel model = projectApplyBll.GetModel(int.Parse(userId));
            return JsonConvert.SerializeObject(model);
        }
        [WebMethod]
        public static string UpdateApplyProject(string id,string UserId,
            string Nat_Org_Code, string Company, string IndustryId, string YYSR, string TAX,
            string Employee, string RegAddress, string BusinessAddress, string TaxAddress, string ApplyTypeId, string ApplyFund,
            string ApplyTable, string Attachment, string Remarks, string ProjectLinkMan, string ProjectPosition, string ProjectMobilPhone, string ProjectEmail)
        {
            //int id = (Session["UsersModel"] as UsersModel).Id;

            //修改项目
            ProjectApplyBll projectApplyBll = new ProjectApplyBll();
            ProjectApplyModel projectApplyModel = new ProjectApplyModel();
            projectApplyModel.Id = int.Parse(id);
            projectApplyModel.UserId = int.Parse(UserId);
            projectApplyModel.Company = Company;
            projectApplyModel.IndustryId = int.Parse(IndustryId);
            projectApplyModel.YYSR = decimal.Parse(YYSR);
            projectApplyModel.TAX = decimal.Parse(TAX);
            projectApplyModel.Employee = int.Parse(Employee);
            projectApplyModel.RegAddress = RegAddress;
            projectApplyModel.BusinessAddress = BusinessAddress;
            projectApplyModel.TaxAddress = TaxAddress;
            projectApplyModel.ApplyTypeId = int.Parse(ApplyTypeId);
            projectApplyModel.ApplyFund = decimal.Parse(ApplyFund);
            projectApplyModel.ApplyTable = ApplyTable;
            projectApplyModel.Attachment = Attachment;
            projectApplyModel.Remarks = Remarks;
            projectApplyModel.ProjectLinkMan = ProjectLinkMan;
            projectApplyModel.ProjectPosition = ProjectPosition;
            projectApplyModel.ProjectMobilPhone = ProjectMobilPhone;
            projectApplyModel.ProjectEmail = ProjectEmail;
            projectApplyModel.ProjectState = 1;
            projectApplyModel.ApprovalFund = 0;
            projectApplyModel.ApprovalState = 1;
            projectApplyModel.CreateTime = DateTime.Now;
            projectApplyModel.UpdateTime = DateTime.Now;

            try
            {
                bool r = projectApplyBll.Update(projectApplyModel);            
                if (r )
                {
                    return "ok";
                }
                else
                {
                    return "no";
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
