using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Practica1_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Bitmap myPic;
        private Bitmap final;

        public MainWindow()
        {
            InitializeComponent();
        }

        public object ImgFoto { get; private set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog OpenFileDialog = new OpenFileDialog();
            OpenFileDialog.Filter = "Archivos jpg (*.jpg) |*.jpg";

            if (OpenFileDialog.ShowDialog() == true)
            {
                Uri fileUri = new Uri(OpenFileDialog.FileName);
                _ImgLoad.Source = new BitmapImage(fileUri);
            }
        }

        private void _BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (final != null)
            {
                SaveFileDialog s = new SaveFileDialog();
                s.Filter = "Bitmap (*.jpg)|*.jpg";                                  // Defines the format of the stored image
                s.ShowDialog();
                if (s.FileName != null)
                {
                    final.Save(s.FileName);
                }
            }
        }

        private void _BtnGrayscale_Click(object sender, RoutedEventArgs e)
        {
        
            int w = myPic.Width, h = myPic.Height;                                 // Variables are declared for the width and height of the image
            System.Drawing.Color actual, newC;
         
            final = new Bitmap(w, h);                                              // Bitmap receives variables the width and height

            for (int x = 0; x < w; x++)                                            // Scrolls through each pixel of the Bitmap
            {
                for (int y = 0; y < h; y++)
                {
                    actual = myPic.GetPixel(x, y);
                    newC = System.Drawing.Color.FromArgb(actual.R, actual.R, actual.R);           //Sets new color

                    final.SetPixel(x, y, newC);
                }
            }
            _ImgLoad.Source = final;

            //BitmapImage myBitmapImagen = new BitmapImage();

            //myBitmapImagen.BeginInit();
            //myBitmapImagen.UriSource = new Uri(@"sampleImages/WaterLilies.jpg", UriKind.Relative);

            //myBitmapImagen.DecodePixelWidth = 200;
            //myBitmapImagen.EndInit();

            //FormatConvertedBitmap newFormatedBitmapSource = FormatConvertedBitmap();

            //newFormatedBitmapSource.BeginInit();
            //newFormatedBitmapSource = myBitmapImagen;

            //newFormatedBitmapSource.DestinationFormat = PixelFormats.Gray32Float;
            //newFormatedBitmapSource.EndInit();

            //Image myImagen = new Image();
            //_ImgLoad.Width = 200;
            //_ImgLoad.Source = newFormatedBitmapSource;

            //StackPanel stackPanel = new StackPanel();
            //_ImgLoad.Source.Add(myImagen);
            //this.Content = _ImgLoad.Source;

        }


    
        private FormatConvertedBitmap FormatConvertedBitmap()
        {
            throw new NotImplementedException();
        }
    }
}
