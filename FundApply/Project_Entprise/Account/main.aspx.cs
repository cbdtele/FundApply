using FundApply.BLL;
using FundApply.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FundApply.Project_Entprise.Account
{
    public partial class main : Page
    {
        UsersBll usersBll = new UsersBll();
        protected  void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitModel();
            }

        }


        public void InitModel()
        {
            UsersModel usersModel = Session["UsersModel"] as UsersModel;
            Nat_Org_Code.Value = usersModel.Nat_Org_Code;
            Email1.Value = usersModel.Email1;
            Password.Value = usersModel.Password;
        }

        protected void Modify_Click(object sender, EventArgs e)
        {
            UsersModel usersModel = new UsersModel();
            usersModel.Id = (Session["UsersModel"] as UsersModel).Id;
            usersModel.Nat_Org_Code = Nat_Org_Code.Value;
            usersModel.Email1 = Email1.Value;
            usersModel.Password = Password.Value;
            usersModel.UpdateTime = DateTime.Now;
            try
            {
                bool type = usersBll.UpdateAccount(usersModel);
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