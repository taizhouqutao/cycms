using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Imaging;

namespace cycms.Web.admin
{
    public partial class num : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 在此处放置用户代码以初始化页面
            this.SetPageNoCache();
            this.CreateCheckCodeImage(GenerateCheckCode());
        }


        private void SetPageNoCache()
        {
            Response.Buffer = true;
            Response.ExpiresAbsolute = System.DateTime.Now.AddSeconds(-1);
            Response.Expires = 0;
            Response.CacheControl = "no-cache";
            Response.AddHeader("Pragma", "No-Cache");
        }
        private string GenerateCheckCode()
        {  //产生五位的随机字符串
            int number;
            char code;
            string checkCode = String.Empty;
            System.Random myrandom = new Random();
            for (int i = 0; i < 4; i++)
            {
                number = myrandom.Next();
                if (number % 2 == 0)
                {
                    code = (char)('0' + (char)(number % 10));
                }
                else
                {
                    code = (char)('a' + (char)(number) % 26);
                }
                checkCode += code;


            }
            Session["checkCode"] = checkCode;
            return checkCode;
            /*
            System.Random random = new Random();

            for (int i = 0; i < 5; i++)
            {
                number = random.Next();

                if (number % 2 == 0)
                    code = (char)('0' + (char)(number % 10));
                else
                    code = (char)('A' + (char)(number % 26));

                checkCode += code.ToString();
            }

            Session["CheckCode"] = checkCode;//用于客户端校验码比较

            return checkCode;*/
        }

        private void CreateCheckCodeImage(string checkCode)
        {  //将验证码生成图片显示
            if (checkCode == null || checkCode.Trim() == String.Empty)
                return;

            System.Drawing.Bitmap image = new System.Drawing.Bitmap((int)Math.Ceiling((checkCode.Length * 12.5)), 22);
            Graphics g = Graphics.FromImage(image);

            /*Bitmap myimage=new Bitmap(40,20);
            Graphics graphic=Graphics.FromImage(image);
			
            try{
            graphic.Clear(Color.White);
            Font font=new Font("Arial",12);
            System.Drawing.Drawing2D.LinearGradientBrush brush=new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(0,0,image.Width,image.Height),Color.Blue,Color.Black,1);
            graphic.DrawString(checkCode,font,brush,0,0);
*/
            try
            {
                //生成随机生成器 
                Random random = new Random();
                //
                //				//清空图片背景色 
                g.Clear(Color.White);

                //画图片的背景噪音线 
                for (int i = 0; i < 25; i++)
                {
                    int x1 = random.Next(image.Width);
                    int x2 = random.Next(image.Width);
                    int y1 = random.Next(image.Height);
                    int y2 = random.Next(image.Height);

                    g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
                }
                //
                Font font = new System.Drawing.Font("Arial", 12, (System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic));
                System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.DarkRed, Color.DarkRed, 1.2f, true);
                g.DrawString(checkCode, font, brush, 2, 2);

                //画图片的前景噪音点 
                for (int i = 0; i < 25; i++)
                {
                    int x = random.Next(image.Width);
                    int y = random.Next(image.Height);

                    image.SetPixel(x, y, Color.FromArgb(random.Next()));
                }

                //画图片的边框线 
                g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);

                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                Response.ClearContent();
                Response.ContentType = "image/Gif";
                Response.BinaryWrite(ms.ToArray());
            }
            finally
            {
                g.Dispose();
                image.Dispose();
            }
        }
    }
}