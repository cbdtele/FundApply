using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace FundApply
{
    public class BasePage : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsersModel"]==null)
            {
                Response.Redirect("Project_Entprise/Login.aspx");
            }
           
        }
    }
}