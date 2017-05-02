using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace FundApply
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string lspass = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Button1.Attributes.Add("onclick", "javascript:return checkAll();");
            }

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            //首先判断该登录名称和email是否存在  
            string sql = "select * from t_users where u_username='" + username.Text.Trim() + "' and u_email='" + email.Text.Trim() + "' and u_class='0' and u_valid='1'";
            DataTable dt = new DataTable();
            if (dt.Rows.Count < 1)
            {
                Response.Write("<script>alert('登录名称或Email地址错误！，请重新填写后再试。');</script>");

            }
            else
            {
                //首先给现在的数据库t_users附上一个临时密码  
                //Response.Write(CreateRandomCode(8));  
                lspass = CreateRandomCode(8);
                sql = "update t_users set u_getpwd='" + lspass + "' where u_username='" + username.Text.Trim() + "' and u_email='" + email.Text.Trim() + "' and u_class='0' and u_valid='1'";
                //if (new SQLTool().ExecuteSql(sql) >= 0)  
                //{  
                sendEmail(email.Text.Trim(), username.Text.Trim());
                Response.Write("<script>alert('临时密码已经发送到您的注册Email中，请在下一页面中修改密码。');window.location.href='getpwdconfirm.aspx';</script>");
                //}  
            }
        }
        public void sendEmail(string email, string name)
        {
            try
            {
                jmail.Message jmessage = new jmail.Message();
                jmessage.Charset = "GB2312";
                jmessage.From = "392055011@qq.com";
                // 发信地址   
                jmessage.MailServerUserName = "392055011";
                //smtp认证用户名(注:如为网易用户,不加要@163.com,只要前面部分即可)  
                jmessage.MailServerPassWord = "lwj15838604213@@";
                // smtp论证用户名密码   

                jmessage.FromName = "108人力银行";
                // 发信人   
                jmessage.ReplyTo = "86085005@163.com";
                // 回复地址   
                
                //jmessage.C;//邮件内容为html  
                jmessage.Subject = "108人力银行临时密码";

                //string strbody = "";
                //strbody += new functions().getInfoXX("t_pagetexts", "p_name", "找回密码邮件反馈-个人", "p_value").Replace("$", name).Replace("@%", lspass);
                //jmessage.HTMLBody = strbody;
                // 邮件标题   
                jmessage.AddRecipient(email, "", "");
                jmessage.Send("smtp.qq.com", false);//发送邮件smtp.163.com  
                jmessage.Close();//关闭对象,释放资源  


            }
            catch (Exception err)
            {
                Response.Write(err);
            }
        }
        /// <summary>  
        /// 功能：产生数字和字符混合的随机字符串  
        /// </summary>  
        /// <param name="codecount">字符串的个数</param>  
        /// <returns></returns>  
        private string CreateRandomCode(int codecount)
        {

            // 数字和字符混合字符串  
            string allchar = "0,1,2,3,4,5,6,7,8,9,a,b,c,d,e,f,g,h,i,j,k,l,m,n";
            //分割成数组  
            string[] allchararray = allchar.Split(',');
            string randomcode = "";

            //随机数实例  
            System.Random rand = new System.Random(unchecked((int)DateTime.Now.Ticks));
            for (int i = 0; i < codecount; i++)
            {
                //获取一个随机数  
                int t = rand.Next(allchararray.Length);
                //合成随机字符串  
                randomcode += allchararray[t];
            }
            return randomcode;
        }

    }
}