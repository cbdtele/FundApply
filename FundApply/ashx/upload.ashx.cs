using System;
using System.Collections.Generic;
using System.Web;
using System.IO;

namespace yuyue.upload
{
    /// <summary>
    /// upload 的摘要说明
    /// </summary>
    public class upload : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            try
            {
                HttpPostedFile file;
                for (int i = 0; i < context.Request.Files.Count; ++i)
                {
                    file = context.Request.Files[i];
                    if (file == null || file.ContentLength == 0 || string.IsNullOrEmpty(file.FileName)) continue;
                    string filename = DateTime.Now.ToString("yyyyMMddHHmmss") + RndNumStr(6) + Path.GetExtension(file.FileName);

                    /********************文件夹**************************/
                    string year=DateTime.Now.Year.ToString();
                    string monthday = DateTime.Now.ToString("MMdd");

                    if (!Directory.Exists(HttpContext.Current.Server.MapPath("/uploads/")+year))
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath("/uploads/") + year);
                    }
                    if (!Directory.Exists(HttpContext.Current.Server.MapPath("/uploads/") + year + "/" + monthday))
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath("/uploads/") + year + "/" + monthday);
                    }
                    file.SaveAs(HttpContext.Current.Server.MapPath("/uploads/" + year + "/" + monthday + "/" + filename));
                    context.Response.Write("/uploads/" + year + "/" + monthday + "/" + filename);

                }
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                context.Response.Write(ex.Message);
                context.Response.End();
            }
            finally
            {
                context.Response.End();
            }
        }

        #region 该方法用于生成指定位数的随机字符串
        /// <summary>
        /// 该方法用于生成指定位数的随机字符串
        /// </summary>
        /// <param name="VcodeNum">参数是随机数的位数</param>
        /// <returns>返回一个随机数字符串</returns>
        public static string RndNumStr(int VcodeNum)
        {
            string[] source = { "0", "1", "1", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };

            string checkCode = String.Empty;
            Random random = new Random();
            for (int i = 0; i < VcodeNum; i++)
            {
                checkCode += source[random.Next(0, source.Length)];

            }
            return checkCode;
        }
        #endregion

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}