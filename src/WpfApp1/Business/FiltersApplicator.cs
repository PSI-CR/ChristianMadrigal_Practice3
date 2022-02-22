using System;
using System.Drawing;
using WpfApp1.Presentation;

namespace WpfApp1.Business
{
    public class FiltersApplicator
    {
        IImageViewer _imageViewer;

        public FiltersApplicator(IImageViewer ImagViewer)
        {
            _imageViewer = ImagViewer;
        }

        public void ConvetToGrayScale(Bitmap bitmap)
        {
            if(bitmap == null)
            {
                throw new ArgumentNullException("No Image. Please load Image");
            }
            var bitmapnew = GrayScaleImage.Grayscale(bitmap);
            _imageViewer.DisplayImage(bitmapnew);
        }

        public void ApplyFilterSobel(Bitmap bitmap)
        {
            if(bitmap == null)
            {
                throw new ArgumentNullException("No Image. Please load Image");
            }
            var bitmapnew = FilterSobel.ApplicateFilterSobel(bitmap);
            _imageViewer.DisplayImage(bitmapnew);
        }

        public void ApplyFilterPrewitt(Bitmap bitmap)
        {
            if(bitmap==null)
            {
                throw new ArgumentNullException("No Image. Please load Image");
            }
            var bitmapnew = FilterPrewitt.ApplicateFilterPrewitt(bitmap);
            _imageViewer.DisplayImage(bitmapnew);
        }
    }
}
