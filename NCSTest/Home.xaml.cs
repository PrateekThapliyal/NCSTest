using System;
using System.Collections.Generic;
using System.Linq;
//using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Threading;

namespace NCSTest
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.WindowHeight = 177.347;
            ErrorText.Text = "";

            System.Windows.Application.Current.MainWindow.Hide();
            Bitmap screenShot = CaptureScreen();

            ImageCodecInfo jpegCodec = ImageType();

            EncoderParameters compressionSettings = CompressionConfiguration();

            bool result = SaveImage(screenShot, jpegCodec, compressionSettings);

            System.Windows.Application.Current.MainWindow.Show();

        }

        public Bitmap CaptureScreen()
        {
            try
            {
                Thread.Sleep(200);
                Bitmap grabScreen = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
                                                Screen.PrimaryScreen.Bounds.Height);
                using (Graphics capturedScreen = Graphics.FromImage(grabScreen))
                {
                    capturedScreen.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                                     Screen.PrimaryScreen.Bounds.Y,
                                     0, 0,
                                     grabScreen.Size,
                                     CopyPixelOperation.SourceCopy);
                }

                return grabScreen;
            }
            catch (Exception )
            {
                this.WindowHeight = 247.833;
                ErrorText.Text = "Error! Something went wrong while taking the screenshot. Please retry or restart the application.";
                return null;
            }
        }

        public ImageCodecInfo ImageType()
        {
            try
            {
                ImageCodecInfo[] codecsCollection = ImageCodecInfo.GetImageEncoders();
                for (int i = 0; i < codecsCollection.Length; i++)
                    if (codecsCollection[i].MimeType == "image/jpeg")
                        return codecsCollection[i];

                this.WindowHeight = 227.833;
                ErrorText.Text = "Error! Couldn't determine the image type. Please retry or restart the application.";
                return null;
            }
            catch (Exception)
            {
                this.WindowHeight = 247.833;
                ErrorText.Text = "Error! Something went wrong while determining the image type. Please retry or restart the application.";
                return null;
            }
        }

        public EncoderParameters CompressionConfiguration()
        {
            try
            {
                long quality = Convert.ToInt64(qualitySlider.Value);
                EncoderParameter compressionSettings = new EncoderParameter(Encoder.Quality, quality);
                EncoderParameters qualityParameter = new EncoderParameters(1);
                qualityParameter.Param[0] = compressionSettings;
                return qualityParameter;
            }
            catch (Exception)
            {
                this.WindowHeight = 227.833;
                ErrorText.Text = "Error! Something went wrong during compression. Please retry or restart the application.";
                return null;
            }
        }

        public bool SaveImage(Bitmap screenShot, ImageCodecInfo codecType, EncoderParameters compressionSettings)
        {
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                path += @"\ScreenGrab.jpg";

                screenShot.Save(path, codecType, compressionSettings);
                return true;
            }
            catch (Exception)
            {
                this.WindowHeight = 227.833;
                ErrorText.Text = "Error! Couldn't save the image. Please retry or restart the application.";
                return false;
            }
        }

    }
}
