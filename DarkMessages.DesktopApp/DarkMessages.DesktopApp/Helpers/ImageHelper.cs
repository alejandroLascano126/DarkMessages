using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkMessages.DesktopApp.Helpers
{
    public static class ImageHelper
    {
        public static Image ConvertBytesToImage(byte[] imageData)
        {
            using (MemoryStream ms = new MemoryStream(imageData))
            {
                return Image.FromStream(ms);
            }
        }

        public static Image ResizeImage(Image image, int width, int height)
        {
            var resizedBitmap = new Bitmap(width, height);
            using (var graphics = Graphics.FromImage(resizedBitmap))
            {
                graphics.DrawImage(image, 0, 0, width, height);
            }
            return resizedBitmap;
        } 

        public static byte[] ConvertImageToBytes(Image image)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));

            try
            {
                using (var ms = new MemoryStream())
                {
                    image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    return ms.ToArray();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error converting image to bytes: {ex.Message}");
                return null;
            }
        }
    }
}
