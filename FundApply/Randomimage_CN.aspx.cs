using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

public partial class mis_Randomimage_CN : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string randomcode = CreateRegionCode(4);
        HttpCookie imgCookie2 = null;
        if (this.Request.Cookies["ValidateCode"] == null)
        {
            imgCookie2 = new HttpCookie("ValidateCode");
            imgCookie2.Value = this.Server.UrlEncode(randomcode);
            this.Response.Cookies.Add(imgCookie2);
        }
        else
        {
            imgCookie2 = new HttpCookie("ValidateCode");
            imgCookie2.Value = this.Server.UrlEncode(randomcode);
            this.Response.Cookies.Add(imgCookie2);
        }
        this.CreateImage(randomcode);
    }
    public string CreateRegionCode(int n)
    {
        string strchar = "0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
        string[] VcArray = strchar.Split(',');
        string VNum = "";
        int temp = -1;
        Random rand = new Random();
        for (int i = 1; i < n + 1; i++)
        {
            if (temp != -1)
            {
                rand = new Random(i * temp * unchecked((int)DateTime.Now.Ticks));

            }
            int t = rand.Next(35);
            if (temp != -1 && temp == t)
            {
                return CreateRegionCode(n);
            }
            temp = t;
            VNum += VcArray[t];
        }
        return VNum;
    }
    public void CreateImage(string CheckCode)
    {
        Random rand = new Random();
        int iwidth = (int)(CheckCode.Length * 12);
        System.Drawing.Bitmap image = new System.Drawing.Bitmap(iwidth, 14);
        Graphics g = Graphics.FromImage(image);
        g.Clear(Color.White);
        //画图片的背景噪音线5条

        for (int i = 0; i < 5; i++)
        {
            int x1 = rand.Next(image.Width);
            int x2 = rand.Next(image.Width);
            int y1 = rand.Next(image.Height);
            int y2 = rand.Next(image.Height);
            g.DrawLine(new Pen(Color.Silver), x1, x2, y1, y2);
        }
        //定义颜色
        Color[] c = { Color.Black, Color.Red, Color.DarkBlue, Color.Green, Color.Orange, Color.Brown, Color.DarkCyan, Color.Purple, Color.YellowGreen };
        //定义字体 
        string[] font = { "Verdana", "Microsoft Sans Serif", "Comic Sans MS", "Arial", "宋体", "新宋体" };

        ////随机输出噪点
        //for (int i = 0; i < 50; i++)
        //{
        //    int x = rand.Next(image.Width);
        //    int y = rand.Next(image.Height);
        //    g.DrawRectangle(new Pen(Color.LightGray, 0), x, y, 1, 1);
        //}

        //输出不同字体和颜色的验证码字符

        for (int i = 0; i < CheckCode.Length; i++)
        {
            int cindex = rand.Next(7);
            int findex = rand.Next(6);

            Font f = new System.Drawing.Font(font[1], 10, System.Drawing.FontStyle.Bold);
            Brush b = new System.Drawing.SolidBrush(c[0]);
            int ii = 4;
            if ((i + 1) % 2 == 0)
            {
                ii = 2;
            }
            g.DrawString(CheckCode.Substring(i, 1), f,b, 3 + (i * 10), -1);
        }
        ////画一个边框


        //g.DrawRectangle(new Pen(Color.Black, 0), 0, 0, image.Width - 1, image.Height - 1);

        //输出到浏览器
        System.IO.MemoryStream ms = new System.IO.MemoryStream();
        image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
        HttpContext.Current.Response.ClearContent();
        //Response.ClearContent();
        HttpContext.Current.Response.ContentType = "image/Png";
        HttpContext.Current.Response.BinaryWrite(ms.ToArray());
        g.Dispose();
        image.Dispose();
    }
}
