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
    public partial class Login : System.Web.UI.Page
    {

        UsersBll usersBll = new UsersBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            InitWeb();
        }

        public void InitWeb()
        {
            string type = "";
            if (!string.IsNullOrEmpty(Request.QueryString["type"]))
            {
                type = Request.QueryString["type"] == "login" ? "login" : "register";
            }
            switch (type)
            {
                case "login": LoginGo(); break;
                case "register": RegisterGo(); break;
                default: break;
            }
        }
        protected void LoginGo()
        {
            string nat_Org_Code = Request.Params["logname"];
            string password = Request.Params["logpassword"];
            var usersModel = usersBll.GetModel(nat_Org_Code, password);
            if (usersModel == null)
            {
                Response.Write("<script>alert('用户名或密码错误')</script>");
            }
            else
            {
                Session["Nat_Org_Code"] = usersModel.Nat_Org_Code;
                Session["UsersModel"] = usersModel;
                Response.Write("<script>alert('登陆成功');  window.location.href = 'parentmain.aspx';</script>");
            }
        }

        protected void RegisterGo()
        {
            UsersModel usersModel = new UsersModel();
            usersModel.Nat_Org_Code = Request.Params["Nat_Org_Code"];
            usersModel.Company = Request.Params["Company"];
            usersModel.Password = Request.Params["Password"];
            usersModel.LinkMan1 = Request.Params["LinkMan1"];
            usersModel.MobilePhone1 = Request.Params["MobilePhone1"];
            usersModel.Telephone1 = Request.Params["Telephone1"];

            usersModel.Email1 = Request.Params["Email1"];
            usersModel.LinkMan2 = Request.Params["Linkman2"];
            usersModel.MobilePhone2 = Request.Params["MobilePhone2"];
            usersModel.Telephone2 = Request.Params["Telephone2"];
            usersModel.Email2 = Request.Params["Email2"];
            usersModel.State = 1;
            usersModel.CreateTime = DateTime.Now;
            usersModel.UpdateTime = DateTime.Now;
            try
            {
                int i = usersBll.Add(usersModel);
                if (i > 0)
                {

                    Session["Nat_Org_Code"] = Request.Params["Nat_Org_Code"];
                    string nat_Org_Code = Request.Params["Nat_Org_Code"];
                    string password = Request.Params["Password"];
                    var usersModelL = usersBll.GetModel(nat_Org_Code, password);
                    Session["UsersModel"] = usersModelL;
                    Response.Write("<script>alert('注册成功！'); window.location.href = 'parentmain.aspx';</script>");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [WebMethod]
        public static string CheckExists(string nat_Org_Code)
        {
            string result = "";
            UsersBll usersBll = new UsersBll();
            bool type = usersBll.Exists(nat_Org_Code);
            if (type)
            {
                result = "true";
            }
            else
            {
                result = "false";
            }
            return result;
        }
    }
}