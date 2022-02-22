using System;
using System.Drawing;

namespace WpfApp1.Business
{
    public static class GrayScaleImage
    {
        public static Bitmap Grayscale(Bitmap bitmap)
        {
            if (bitmap == null)
            {
                throw new ArgumentException("No Image. Please Load Image.");
            }

            int width = bitmap.Width, height = bitmap.Height;                                                                                        //Assign the variables for traversing the image
            System.Drawing.Color actual, newC;
            Bitmap final = bitmap.Clone(new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height), bitmap.PixelFormat);                                              

            for (int x = 0; x < width; x++)                                                                                                          //Traversed by width                                                                                                 
            {
                for (int y = 0; y < height; y++)                                                                                                     //Traversed by height
                {
                    actual = bitmap.GetPixel(x, y);
                    int avg = (actual.R + actual.G + actual.B) / 3;
                    newC = Color.FromArgb(avg, avg, avg);                                                                                            //New color is assigned
                    final.SetPixel(x, y, newC);
                }
            }
            return final;
        }
    }
}
