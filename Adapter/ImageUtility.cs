using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Web;
namespace Adapte
{
    public class ImageUtility
    {
        public ImageUtility() { }

        private static Size NewSize(int maxWidth, int maxHeight, int width, int height)
        {
            double w = 0.0;
            double h = 0.0;
            double sw = Convert.ToDouble(width);
            double sh = Convert.ToDouble(height);
            double mw = Convert.ToDouble(maxWidth);
            double mh = Convert.ToDouble(maxHeight);

            if (sw < mw && sh < mh)
            {
                w = sw;
                h = sh;
            }
            else if ((sw / sh) > (mw / mh))
            {
                w = maxWidth;
                //h = (w * sh) / sw;  瞿涛2013-5-16
                h = maxHeight;
            }
            else
            {
                h = maxHeight;
                //w = (h * sw) / sh; 瞿涛2013-5-16
                w = maxWidth;
            }
            w = maxWidth;
            h = maxHeight;
            return new Size(Convert.ToInt32(w), Convert.ToInt32(h));
        }

        /// <summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="fileName">原始图片路径</param>
        /// <param name="newFile">新图片的保存路径</param>
        /// <param name="maxHeight">图片容器的高度</param>
        /// <param name="maxWidth">图片容器的宽度</param>
        public static void MakeSmallImage(string Filename, string newFile, int maxHeight, int maxWidth)
        {
            System.Drawing.Image img = Image.FromFile(Filename);
            MakeSmallImage(img, newFile, maxHeight, maxWidth);
        }
        /// <summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="file">上传的图片</param>
        /// <param name="newFile">新图片的保存路径</param>
        /// <param name="maxHeight">图片容器的高度</param>
        /// <param name="maxWidth">图片容器的宽度</param>
        public static void MakeSmallImage(HttpPostedFile file, string newFile, int maxHeight, int maxWidth)
        {
            System.Drawing.Image img = Image.FromStream(file.InputStream);
            MakeSmallImage(img, newFile, maxHeight, maxWidth);
        }

        public static void MakeSmallImage(Image img, string newFile, int maxHeight, int maxWidth)
        {
            System.Drawing.Imaging.ImageFormat thisFormat = img.RawFormat;
            Size newSize = NewSize(maxWidth, maxHeight, img.Width, img.Height);
            Bitmap outBmp = new Bitmap(newSize.Width, newSize.Height);
            Graphics g = Graphics.FromImage(outBmp);
            // 设置画布的描绘质量
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(img, new Rectangle(0, 0, newSize.Width, newSize.Height),
                0, 0, img.Width, img.Height, GraphicsUnit.Pixel);
            g.Dispose();
            // 以下代码为保存图片时，设置压缩质量
            EncoderParameters encoderParams = new EncoderParameters();
            long[] quality = new long[1];
            //quality[0] = 50;
            quality[0] = 90;//叶晓丰修改

            EncoderParameter encoderParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
            encoderParams.Param[0] = encoderParam;
            //获得包含有关内置图像编码解码器的信息的ImageCodecInfo 对象。
            ImageCodecInfo[] arrayICI = ImageCodecInfo.GetImageEncoders();
            ImageCodecInfo jpegICI = null;
            for (int x = 0; x < arrayICI.Length; x++)
            {
                if (arrayICI[x].FormatDescription.Equals("JPEG"))
                {
                    jpegICI = arrayICI[x];//设置JPEG编码
                    break;
                }
            }
            if (jpegICI != null)
            {
                outBmp.Save(newFile, jpegICI, encoderParams);
            }
            else
            {
                outBmp.Save(newFile, thisFormat);
            }
            img.Dispose();
            outBmp.Dispose();
        }
    }
}
