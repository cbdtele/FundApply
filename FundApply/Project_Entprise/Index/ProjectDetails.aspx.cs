using FundApply.BLL;
using FundApply.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FundApply.Project_Entprise
{
    public partial class ProjectDetails : System.Web.UI.Page
    {
        ProjectApplyBll projectApplyBll = new ProjectApplyBll();
        Dic_IndustryBll dic_IndustryBll = new Dic_IndustryBll();
        Dic_ApplyTypeBll dic_ApplyTypeBll = new Dic_ApplyTypeBll();
        List<Dic_ApplyTypeModel> Dic_ApplyTypeList = new List<Dic_ApplyTypeModel>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitWeb();
            }

        }

        public void InitWeb()
        {
            UsersModel usersModel = Session["UsersModel"] as UsersModel;
            int userId = usersModel.Id;
            ProjectApplyModel projectApplyModel = projectApplyBll.GetModel(userId);
            txtNat_Org_Code.Value = usersModel.Nat_Org_Code;
            txtCompany.Value = usersModel.Company;
            txtCompany.Value = projectApplyModel.Company;
            drpIndustryId.Value = dic_IndustryBll.GetNameById(projectApplyModel.IndustryId);
            txtYYSR.Value = projectApplyModel.YYSR.ToString();
            txtTAX.Value = projectApplyModel.TAX.ToString();
            txtEmployee.Value = projectApplyModel.Employee.ToString();
            txtRegAddress.Value = projectApplyModel.RegAddress;
            txtBusinessAddress.Value = projectApplyModel.BusinessAddress;
            drpApplyTypeBig.Value = dic_ApplyTypeBll.GetNameById(projectApplyModel.ApplyTypeId).ApplyTypeId_BigName;
            drpApplyTypeSmall.Value = dic_ApplyTypeBll.GetNameById(projectApplyModel.ApplyTypeId).ApplyTypeId_SmallName;
            txtApplyFund.Value = projectApplyModel.ApplyFund.ToString();
            txtAttachment.Value = projectApplyModel.Attachment;
            txtProjectLinkMan.Value = projectApplyModel.ProjectLinkMan;
            txtProjectPosition.Value = projectApplyModel.ProjectPosition;
            txtProjectMobilPhone.Value = projectApplyModel.ProjectMobilPhone;
            txtProjectEmail.Value = projectApplyModel.ProjectEmail;           
        }

    }
}