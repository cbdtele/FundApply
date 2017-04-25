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
    public partial class EditProject : System.Web.UI.Page
    {
        ProjectApplyBll projectApplyBll = new ProjectApplyBll();
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
            // userId = 2;
            ProjectApplyModel projectApplyModel = projectApplyBll.GetModel(userId);
            txtNat_Org_Code.Value = usersModel.Nat_Org_Code;
            txtCompany.Value = usersModel.Company;

            txtCompany.Value = projectApplyModel.Company;
            //drpIndustryId.SelectedValue = projectApplyModel.IndustryId.ToString();
            txtYYSR.Value = projectApplyModel.YYSR.ToString();
            txtTAX.Value = projectApplyModel.TAX.ToString();
            txtEmployee.Value = projectApplyModel.Employee.ToString();
            txtRegAddress.Value = projectApplyModel.RegAddress;
            txtBusinessAddress.Value = projectApplyModel.BusinessAddress;
            txtApplyTypeId.Value = projectApplyModel.ApplyTypeId.ToString();
            txtApplyFund.Value = projectApplyModel.ApplyFund.ToString();
            txtAttachment.Value = projectApplyModel.Attachment;
            txtProjectLinkMan.Value = projectApplyModel.ProjectLinkMan;
            txtProjectPosition.Value = projectApplyModel.ProjectPosition;
            txtProjectMobilPhone.Value = projectApplyModel.ProjectMobilPhone;
            txtProjectEmail.Value = projectApplyModel.ProjectEmail;

            //行业下拉框        
            Dic_IndustryBll dic_IndustryBll = new Dic_IndustryBll();
            List<Dic_IndustryModel> Dic_IndustryList = new List<Dic_IndustryModel>();
            drpIndustryId.DataTextField = "IndustryName";
            drpIndustryId.DataValueField = "IndustryId";
            drpIndustryId.SelectedValue = projectApplyModel.IndustryId.ToString();
            drpIndustryId.DataSource = dic_IndustryBll.GetModelList("1=1");
            drpIndustryId.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int id = (Session["UsersModel"] as UsersModel).Id;
            ProjectApplyModel projectApplyModel = new ProjectApplyModel();
            //projectApplyModel.Nat_Org_Code = txtNat_Org_Code.Value;
            projectApplyModel.UserId = id;
            projectApplyModel.Company = txtCompany.Value;
            projectApplyModel.IndustryId = int.Parse(drpIndustryId.SelectedValue);
            projectApplyModel.YYSR = decimal.Parse(txtYYSR.Value);
            projectApplyModel.TAX = decimal.Parse(txtYYSR.Value);
            projectApplyModel.Employee = int.Parse(txtEmployee.Value);
            projectApplyModel.RegAddress = txtRegAddress.Value;
            projectApplyModel.BusinessAddress = txtBusinessAddress.Value;
            projectApplyModel.ApplyTypeId = int.Parse(txtApplyTypeId.Value);
            projectApplyModel.ApplyFund = decimal.Parse(txtApplyFund.Value);
            projectApplyModel.Attachment = txtAttachment.Value;
            projectApplyModel.ProjectLinkMan = txtProjectLinkMan.Value;
            projectApplyModel.ProjectPosition = txtProjectPosition.Value;
            projectApplyModel.ProjectMobilPhone = txtProjectMobilPhone.Value;
            projectApplyModel.ProjectEmail = txtProjectEmail.Value;
            projectApplyModel.ProjectState = 1;
            projectApplyModel.ApprovalFund = 0;
            projectApplyModel.ApprovalState = 1;
            projectApplyModel.CreateTime = DateTime.Now;
            projectApplyModel.UpdateTime = DateTime.Now;
            try
            {
                bool type = projectApplyBll.Update(projectApplyModel);
                if (type)
                {
                    Response.Write("<script>alert('修改成功');</script>");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
