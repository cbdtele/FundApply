using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FundApply.Project_CYB.Index
{
    public partial class ApplyProject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var ss=Request.Params["Nat_Org_Code"];
        }
    }
}