using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WpfApp1.Business
{
    public class BitmapImageConverter
    {
        public static BitmapSource ConvertToBitmapSource(Bitmap bmp)
        {
            if (bmp == null)
            {
                throw new ArgumentNullException("The image cannot be null");
            }
            var bitmapData = bmp.LockBits(new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, bmp.PixelFormat);    //Copy of the bitmap is generated, using the LockBits method to lock the existing bitmap in the system memory.
            var bitmapSource = BitmapSource.Create(bitmapData.Width, bitmapData.Height, 96, 96, PixelFormats.Bgr24, null, bitmapData.Scan0, bitmapData.Stride * 
                bitmapData.Height, bitmapData.Stride);bmp.UnlockBits(bitmapData);

            return bitmapSource;
        }
    }
}


