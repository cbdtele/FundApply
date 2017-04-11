using System;
using System.Web;
using System.Web.UI;

namespace BasePage {
    /// <summary>
    /// 用户权限控制
    /// </summary>
    public class BasePage : Page
    {
        /// <summary>
        /// 用户信息
        /// </summary>
        //protected UserEntity UserEntity { set; get; }
        public BasePage() { }

        //protected override void OnInit(EventArgs e) {
        //    base.OnInit(e);
        //    if (HttpContext.Current.Session["User"] == null) {
        //        Response.Write("<script>top.window.location.href='/Login.aspx'</script>");
        //        Response.End();
        //        return;
        //    }
        //    UserEntity = (UserEntity)HttpContext.Current.Session["User"];
        //}
        public string PGId
        {
            get
            {
                if (HttpContext.Current.Request.QueryString["PGId"] == null)
                {
                    return "";
                }
                else
                {
                    return HttpContext.Current.Request.QueryString["PGId"].ToString();
                }
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            ////要向pagebase先执行此方法，子类需重载OnLoad方法
            //if (HttpContext.Current.Request.Url.ToString().Contains("jxld") && HttpContext.Current.Session["RegionId"] == null)
            //{
            //    Response.Write("<script type='text/javascript'>window.top.location.href='/login.aspx'</script>");
            //}
            //else if (HttpContext.Current.Request.Url.ToString().Contains("BuildingPlatform")
            //    && HttpContext.Current.Session["Project_Id"] == null)
            //{
            //    Response.Write("<script type='text/javascript'>window.top.location.href='/login.aspx'</script>");
            //    Response.End();
            //}
            //else if (HttpContext.Current.Request.Url.ToString().Contains("LouYuArea")
            //&& HttpContext.Current.Session["UserId"] == null)
            //{
            //    Response.Write("<script type='text/javascript'>window.top.location.href='/login.aspx'</script>");
            //}
            //else if (HttpContext.Current.Session["UserId"] == null
            //    && !HttpContext.Current.Request.Url.ToString().Contains("jxld")
            //    && !HttpContext.Current.Request.Url.ToString().Contains("BuildingPlatform")
            //    && !HttpContext.Current.Request.Url.ToString().Contains("LouYuArea"))
            //{
            //    Response.Write("<script type='text/javascript'>window.top.location.href='/login.aspx'</script>");
            //}
            //else
            //{
            //    if (HttpContext.Current.Session["UserId"] != null)
            //    {

            //        //int uid = int.Parse(HttpContext.Current.Session["UserId"].ToString());
            //        string uid = HttpContext.Current.Session["UserId"].ToString();
            //        ViewState["num"] = ViewState["num"] == null ? "0" : "1";
            //        if (ViewState["num"].ToString() == "0")
            //        {
            //            UserHelper.CreateLog_OperOne(uid, DateTime.Now, this.PGId, IpHelper.GetIp());
            //            ViewState["num"] = "1";
            //        }
            //    }

            //    if (Session["fun3"] != null)
            //    {
            //        int fun3 = int.Parse(Session["fun3"].ToString());
            //        if (fun3 == 0)
            //        {
            //            this.Page.RegisterStartupScript("", "<script> document.onselectstart=function(){return false;}; </script>");
            //        }
            //    }
            //}
            //base.OnLoad(e);
        }
    }
}