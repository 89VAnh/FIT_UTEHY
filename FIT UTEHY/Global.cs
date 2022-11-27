using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FIT_UTEHY
{
    public class Global
    {
        private static TaiKhoan currentUser = null; //tài khoản đang được đăng nhập
        public static TaiKhoan CurrentUser { get; set; } //lấy ra và đặt tt tài khoản

        public static byte[] ImgToBase64(Image img, System.Drawing.Imaging.ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, format);
                byte[] imgBytes = ms.ToArray();
                return imgBytes;
            }
        }
        public static Image Base64ToImg(byte[] imgBytes)
        {
            MemoryStream ms = new MemoryStream(imgBytes, 0, imgBytes.Length);
            ms.Write(imgBytes, 0, imgBytes.Length);
            Image img = Image.FromStream(ms, true);
            return img;
        }
    }
}
