using FundApply.BLL;
using FundApply.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FundApply.Project_Entprise.UserInfo
{
    public partial class main : Page
    {
        UsersBll usersBll = new UsersBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["UsersModel"] == null)
            //{
            //    Response.Write("<script>alert('登陆成功');  window.location.href = 'login.aspx';</script>");
            //}
            if (!IsPostBack)
            {
                InitModel();
            }
        }

        public void InitModel()
        {
            UsersModel usersModel = Session["UsersModel"] as UsersModel;
            Nat_Org_Code.Value = usersModel.Nat_Org_Code;
            Company.Value = usersModel.Company;
            LinkMan1.Value = usersModel.LinkMan1;
            MobilePhone1.Value = usersModel.MobilePhone1;
            Telephone1.Value = usersModel.Telephone1;
            Email1.Value = usersModel.Email1;
            LinkMan2.Value = usersModel.LinkMan2;
            MobilePhone2.Value = usersModel.MobilePhone2;
            Telephone2.Value = usersModel.Telephone2;
            Email2.Value = usersModel.Email2;
            Password.Value = usersModel.Password;
        }

        protected void Modify_Click(object sender, EventArgs e)
        {
            UsersModel usersModel = new UsersModel();
            usersModel.Id = (Session["UsersModel"] as UsersModel).Id;
            usersModel.Nat_Org_Code = Nat_Org_Code.Value;
            usersModel.Company = Company.Value;
            usersModel.LinkMan1 = LinkMan1.Value;
            usersModel.MobilePhone1 = MobilePhone1.Value;
            usersModel.Telephone1 = Telephone1.Value;
            usersModel.Email1 = Email1.Value;
            usersModel.LinkMan2 = LinkMan2.Value;
            usersModel.MobilePhone2 = MobilePhone2.Value;
            usersModel.Telephone2 = Telephone2.Value;
            usersModel.Email2 = Email2.Value;
            usersModel.Password = Password.Value;
            usersModel.UpdateTime = DateTime.Now;
            try
            {
                bool type = usersBll.Update(usersModel);
                if (type)
                {
                    Response.Write("<script>alert('修改成功！');</script>");
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}