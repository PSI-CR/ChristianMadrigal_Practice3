using System;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Drawing;
using Microsoft.Win32;
using WpfApp1.Business;
using WpfApp1.Presentation;
using System.Drawing.Imaging;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace WpfApp1
{
  
    public partial class MainWindow : Window, IImageViewer
    {

        private FiltersApplicator _filtersAplicator;
        string _filePath;

        int nTotalNumber = 0;
        int nCurrentItem = 0;

        List<string> ImageFilenames = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
            _filtersAplicator = new FiltersApplicator(this);
        }


        public object ImgFoto { get; private set; }

        private void LoadImage(object sender, RoutedEventArgs e)                       
        {
           
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "Archivos jpg (*.jpg) |*.jpg";

            if (openFileDialog.ShowDialog() == true)
            {
                string sFileName = openFileDialog.FileName;
                ImageFilenames = openFileDialog.FileNames.ToList();

                Uri fileUri = new Uri(ImageFilenames[0]);
                _filePath = openFileDialog.FileName;
                ImageLoad.Source = new BitmapImage(fileUri);
                TextBox1.Text = openFileDialog.FileName;
            }

            if (ImageFilenames.Count > 0)
                nTotalNumber = ImageFilenames.Count;
        }


        public void DisplayImage(Bitmap bitmap)
        {
            ImageLoad.Source = BitmapImageConverter.ConvertToBitmapSource(bitmap);
        }

        public void DisplayImage(object bitmapnew)
        {
            throw new NotImplementedException();
        }


        private void OptionGrayScale(object sender, RoutedEventArgs e)
        {
            try
            {
                _filtersAplicator.ConvetToGrayScale(new Bitmap(_filePath));                                         // Invok the grayscale method
            }
            catch (Exception)
            {
                MessageBox.Show("Please, load Image");
            }
        }


        private void OptionExit(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();                                                          //Closes the program
        }

        private void OptionSobel(object sender, RoutedEventArgs e)                                                  //Methodo Filter Sobel
        {
            try
            {
                _filtersAplicator.ApplyFilterSobel(new Bitmap(_filePath));                                         
            }
            catch (Exception)
            {
                MessageBox.Show("Please, load Image");
            }
        }



        private void OptionPrewitt(object sender, RoutedEventArgs e)                                               //Methodo Filter Prewitt
        {
            try
            {
                _filtersAplicator.ApplyFilterPrewitt(new Bitmap(_filePath));
            }
            catch (Exception)
            {
                MessageBox.Show("No Image. Please Load Image.");
            }
        }


        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                nCurrentItem--;

                if (nCurrentItem < 0)
                {
                    nCurrentItem = 0;
                }
                else if (nCurrentItem < nTotalNumber)
                {
                    Image.FromFile(ImageFilenames[nCurrentItem]);
                    Uri fileUri = new Uri(ImageFilenames[nCurrentItem]);
                    _filePath = ImageFilenames[nCurrentItem];
                    TextBox1.Text = ImageFilenames[nCurrentItem];
                    ImageLoad.Source = new BitmapImage(fileUri);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please, load Image");
            }
        }

        private void ButtonNext_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                nCurrentItem++;

                if (nCurrentItem > nTotalNumber - 1)
                {

                    nCurrentItem = nTotalNumber - 1;
                }
                else
                {
                    Image.FromFile(ImageFilenames[nCurrentItem]);
                    Uri fileUri = new Uri(ImageFilenames[nCurrentItem]);
                    _filePath = ImageFilenames[nCurrentItem];
                    TextBox1.Text = ImageFilenames[nCurrentItem];
                    ImageLoad.Source = new BitmapImage(fileUri);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please, load Image");
            }
        }


        private void OptionSave(object sender, RoutedEventArgs e)
        {
            try
            {
                var saveFileDialog = new SaveFileDialog()
                {
                    Filter = "Image Files (*.jpg)|*.jpg"
                };

                if (saveFileDialog.ShowDialog() == true)
                {
                    var encoder = new PngBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create((BitmapSource)ImageLoad.Source));
                    using (FileStream stream = new FileStream(saveFileDialog.FileName, FileMode.Create))
                    encoder.Save(stream);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void Filters(object sender, RoutedEventArgs e)
        {

        }
    } 
}

