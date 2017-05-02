using FundApply.BLL;
using FundApply.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FundApply.Project_Entprise
{
    public partial class AddProject : System.Web.UI.Page
    {
        ProjectApplyBll projectApplyBll = new ProjectApplyBll();
        Dic_ApplyTypeBll dic_ApplyTypeBll = new Dic_ApplyTypeBll();
        List<Dic_ApplyTypeModel> Dic_ApplyTypeList = new List<Dic_ApplyTypeModel>();

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    InitWeb();
            //}
        }
        public void InitWeb()
        {
            UsersModel usersModel = Session["UsersModel"] as UsersModel;
            txtNat_Org_Code.Value = usersModel.Nat_Org_Code;
            txtCompany.Value = usersModel.Company;
            //行业下拉框
            Dic_IndustryBll dic_IndustryBll = new Dic_IndustryBll();
            List<Dic_IndustryModel> Dic_IndustryList = new List<Dic_IndustryModel>();
            drpIndustryId.DataTextField = "IndustryName";
            drpIndustryId.DataValueField = "IndustryId";
            drpIndustryId.DataSource = dic_IndustryBll.GetModelList("1=1");
            drpIndustryId.DataBind();

            //申请类型 二级联动
            //drpApplyTypeBig.DataTextField = "ApplyTypeId_BigName";
            //drpApplyTypeBig.DataValueField = "ApplyTypeId_BigId";
            //drpApplyTypeBig.DataSource = dic_ApplyTypeBll.GetModelList();//
            //drpApplyTypeBig.DataBind();

            //drpApplyTypeSmall.DataTextField = "ApplyTypeId_SmallName";
            //drpApplyTypeSmall.DataValueField = "ApplyTypeId_SmallId";
            //drpApplyTypeSmall.DataSource = dic_ApplyTypeBll.GetModelList(string.Format("ApplyTypeId_BigId={0}", drpApplyTypeBig.SelectedValue));//
            //drpApplyTypeSmall.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int id = (Session["UsersModel"] as UsersModel).Id;
            ProjectApplyModel projectApplyModel = new ProjectApplyModel();
            projectApplyModel.UserId = id;
            projectApplyModel.Company = txtCompany.Value;
            projectApplyModel.IndustryId = int.Parse(drpIndustryId.SelectedValue);
            projectApplyModel.YYSR = decimal.Parse(txtYYSR.Value);
            projectApplyModel.TAX = decimal.Parse(txtYYSR.Value);
            projectApplyModel.Employee = int.Parse(txtEmployee.Value);
            projectApplyModel.RegAddress = txtRegAddress.Value;
            projectApplyModel.BusinessAddress = txtBusinessAddress.Value;
            //projectApplyModel.ApplyTypeId = int.Parse(drpApplyTypeSmall.SelectedValue);
            projectApplyModel.ApplyFund = decimal.Parse(txtApplyFund.Value);
            projectApplyModel.Attachment = txtAttachment.FileName;
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
                int i = projectApplyBll.Add(projectApplyModel);
                if (i > 0)
                {
                    Response.Write("<script>alert('添加申报成功');</script>");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
