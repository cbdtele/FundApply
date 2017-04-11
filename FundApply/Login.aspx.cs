using System;
using System.Web;
using System.Web.Services;
//using Cydb.Common.Helper;
//using Cydb.Repository.Base;
//using Cydb.Repository.UserControl.TimeUserControl;
using Newtonsoft.Json;
using System.Collections.Generic;

public partial class Login : System.Web.UI.Page
{

    public string Verification = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        //Verification = DESHelper.Encode(DateTime.Now.ToString("hhmm")); //防伪戳
        //if (Request.QueryString["t"] == "out")
        //{
        //    if (Session["UserId"] != null)
        //    {
        //        var logid = new SqlToLogin().GetLogDataByUserId(Session["UserId"].ToString()).LOGID;
        //        UserHelper.CreateLog(logid, DateTime.Now, 1);
        //    }
        //}
    }

    //[WebMethod]
    //public static string LoginCheck(string name, string password, string verification)
    //{
    //    if (string.IsNullOrWhiteSpace(verification))
    //    {
    //        return JsonConvert.SerializeObject(new { state = false, message = "拦截到非法登陆请求，请联系网站管理员。" });
    //    }
    //    if (Conv.ToInt(DateTime.Now.ToString("hhmm")) - Conv.ToInt(DESHelper.Decode(verification)) > 3)
    //    {
    //        return JsonConvert.SerializeObject(new { state = false, message = "您登陆等待时间过长，已失效，请刷新页面重新登陆！" });
    //    }
    //    var userInfo = new SqlToLogin().CheckLogin(name, password);
    //    //var userInfo = new SqlToLogin().CheckLogin(name, MD5Helper.Md5_32Bit(password));
    //    if (userInfo != null)
    //    {
    //        if (userInfo.STATUS == 0)
    //        {
    //            //return JsonConvert.SerializeObject(new { state = true, message = "登陆成功，但未开启登陆权限！" });
    //            return JsonConvert.SerializeObject(new { state = false, message = "登陆失败,未开启登陆权限！" });
    //        }
    //        HttpContext.Current.Session["User"] = userInfo;
    //        HttpContext.Current.Session["UserId"] = userInfo.USERID;
    //        HttpContext.Current.Session["RoleEntity"] = new SqlToLogin().GetRoleData(userInfo.USERID);

    //        var ss = HttpContext.Current.Session["RoleEntity"];
    //        var sss = ss;

    //        //记录登陆日志
    //        int l_status = 0;//异常退出 未规范退出
    //        string l_out_logid = "";
    //        UserHelper.CreateLog2(int.Parse(userInfo.USERID), DateTime.Now, userInfo.USERNAME, l_status, IpHelper.GetIp(), out l_out_logid);
    //        //Session.Add("LogId", l_out_logid);

    //        return JsonConvert.SerializeObject(new { state = true, message = userInfo.STATUS });
    //    }
    //    return JsonConvert.SerializeObject(new { state = false, message = "帐号或者密码错误！" });
    //}
}