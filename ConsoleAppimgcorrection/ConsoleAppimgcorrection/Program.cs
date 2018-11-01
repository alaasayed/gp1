using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.ServiceModel;
using System.Configuration;
using System.IO;
namespace ConsoleAppimgcorrection
{
    class Program
    {
         
        static void Main(string[] args)
        {
            string imgpath, newimgpath;
            Console.WriteLine("please enter imagepath.jpg ");
            imgpath = "im14.jpg";
            //or use
           //imgpath= Console.ReadLine();
            Console.WriteLine("please enter newimagepath.jpg");
            newimgpath = "C:\\Users\\Owner\\Desktop\\newimg.jpg";
            //or use
           // newimgpath = Console.ReadLine();
           Bitmap im1 = new Bitmap(imgpath);
            Program pr1 = new Program();
          
        //  pr1.SetGamma(1.6d, 1.6d, 1.6d,im1,newimgpath);//0.2 to 5
          // pr1.Resize(2000, 500, im1, newimgpath);
            pr1.SetBrightness(30, im1, newimgpath);//-255 to 255
            //pr1.DrawRoi(im1, newimgpath);
          Console.WriteLine("test--------");

        }



       

        public void SetGamma(double red, double green, double blue,Bitmap _currentBitmap,string newpath)
        {
            Bitmap temp = (Bitmap)_currentBitmap;
            Bitmap bmap = (Bitmap)temp.Clone();
            Color c;
            byte[] redGamma = CreateGammaArray(red);
            byte[] greenGamma = CreateGammaArray(green);
            byte[] blueGamma = CreateGammaArray(blue);
            for (int i = 0; i < bmap.Width; i++)
            {
                for (int j = 0; j < bmap.Height; j++)
                {
                    c = bmap.GetPixel(i, j);
                    bmap.SetPixel(i, j, Color.FromArgb(redGamma[c.R],
                       greenGamma[c.G], blueGamma[c.B]));
                }
            }
            _currentBitmap = (Bitmap)bmap.Clone();
            _currentBitmap.Save(newpath);
        }
        private byte[] CreateGammaArray(double color)
        {
            byte[] gammaArray = new byte[256];
            for (int i = 0; i < 256; ++i)
            {
                gammaArray[i] = (byte)Math.Min(255,
        (int)((255.0 * Math.Pow(i / 255.0, 1.0 / color)) + 0.5));
            }
            return gammaArray;
        }
        public void Resize(int newWidth, int newHeight, Bitmap _currentBitmap,string newpath)
        { 
            if (newWidth != 0 && newHeight != 0)
            {
                Bitmap temp = (Bitmap)_currentBitmap;
                Bitmap bmap = new Bitmap(newWidth, newHeight, temp.PixelFormat);

                double nWidthFactor = (double)temp.Width / (double)newWidth;
                double nHeightFactor = (double)temp.Height / (double)newHeight;

                double fx, fy, nx, ny;
                int cx, cy, fr_x, fr_y;
                Color color1 = new Color();
                Color color2 = new Color();
                Color color3 = new Color();
                Color color4 = new Color();
                byte nRed, nGreen, nBlue;

                byte bp1, bp2;

                for (int x = 0; x < bmap.Width; ++x)
                {
                    for (int y = 0; y < bmap.Height; ++y)
                    {

                        fr_x = (int)Math.Floor(x * nWidthFactor);
                        fr_y = (int)Math.Floor(y * nHeightFactor);
                        cx = fr_x + 1;
                        if (cx >= temp.Width) cx = fr_x;
                        cy = fr_y + 1;
                        if (cy >= temp.Height) cy = fr_y;
                        fx = x * nWidthFactor - fr_x;
                        fy = y * nHeightFactor - fr_y;
                        nx = 1.0 - fx;
                        ny = 1.0 - fy;

                        color1 = temp.GetPixel(fr_x, fr_y);
                        color2 = temp.GetPixel(cx, fr_y);
                        color3 = temp.GetPixel(fr_x, cy);
                        color4 = temp.GetPixel(cx, cy);

                        // Blue
                        bp1 = (byte)(nx * color1.B + fx * color2.B);

                        bp2 = (byte)(nx * color3.B + fx * color4.B);

                        nBlue = (byte)(ny * (double)(bp1) + fy * (double)(bp2));

                        // Green
                        bp1 = (byte)(nx * color1.G + fx * color2.G);

                        bp2 = (byte)(nx * color3.G + fx * color4.G);

                        nGreen = (byte)(ny * (double)(bp1) + fy * (double)(bp2));

                        // Red
                        bp1 = (byte)(nx * color1.R + fx * color2.R);

                        bp2 = (byte)(nx * color3.R + fx * color4.R);

                        nRed = (byte)(ny * (double)(bp1) + fy * (double)(bp2));

                        bmap.SetPixel(x, y, System.Drawing.Color.FromArgb
                (255, nRed, nGreen, nBlue));
                    }
                }
                _currentBitmap = (Bitmap)bmap.Clone();
                _currentBitmap.Save(newpath);
            }
        }
        public void SetBrightness(int brightness,Bitmap _currentBitmap,string  newpath)
        {
            Bitmap temp = (Bitmap)_currentBitmap;
            Bitmap bmap = (Bitmap)temp.Clone();
            if (brightness < -255) brightness = -255;
            if (brightness > 255) brightness = 255;
            Color c;
            for (int i = 0; i < bmap.Width; i++)
            {
                for (int j = 0; j < bmap.Height; j++)
                {
                    c = bmap.GetPixel(i, j);
                    int cR = c.R + brightness;
                    int cG = c.G + brightness;
                    int cB = c.B + brightness;

                    if (cR < 0) cR = 1;
                    if (cR > 255) cR = 255;

                    if (cG < 0) cG = 1;
                    if (cG > 255) cG = 255;

                    if (cB < 0) cB = 1;
                    if (cB > 255) cB = 255;

                    bmap.SetPixel(i, j,
        Color.FromArgb((byte)cR, (byte)cG, (byte)cB));
                }
            }
            _currentBitmap = (Bitmap)bmap.Clone();
            _currentBitmap.Save(newpath);
        }
        //void DrawRoi(Image Image1,string newpath)
        //{
        //    Rectangle roi = new Rectangle();

        //    roi.X = 500;
        //    roi.Y = 500;
        //    roi.Width = 1000;
        //    roi.Height =  100;
        //    List<System.Windows.Media.Color> colors = new List<System.Windows.Media.Color>();
        //    colors.Add(System.Windows.Media.Colors.Red);
        //    colors.Add(System.Windows.Media.Colors.Blue);

        //    BitmapPalette palette = new BitmapPalette(colors);
        //    System.Windows.Media.PixelFormat pf =
        //        System.Windows.Media.PixelFormats.Indexed1;
        //    int width = Image1.Width;
        //    int height = Image1.Height;
        //    int stride = width / pf.BitsPerPixel;

        //    byte[] pixels = new byte[height * stride];

        //    for (int i = 0; i < height * stride; ++i)
        //    {
        //        if (i < height * stride / 2)
        //        {
        //            pixels[i] = 0x00;
        //        }
        //        else
        //        {
        //            pixels[i] = 0xff;
        //        }
        //    }

        //    BitmapSource imagesrc = BitmapSource.Create(
        //        width,
        //        height,
        //        96,
        //        96,
        //        pf,
        //        palette,
        //        pixels,
        //        stride);
        //   int regionCoords = new Int32Rect(100, 100, 200, 200);
        //    byte[] regionData = new byte[ 100];
        //    imagesrc.CopyPixels(100, regionData, pixels, 0);
        //    BitmapSource regionImage = BitmapSource.Create( 200, 200, 96, 96, pf, null, regionData, 100);

        //    FileStream stream = new FileStream("empty.tif", FileMode.Create);
        //    TiffBitmapEncoder encoder = new TiffBitmapEncoder();
        //    //TextBlock myTextBlock = new TextBlock();
        //    //myTextBlock.Text = "Codec Author is: " + encoder.CodecInfo.Author.ToString();
        //    encoder.Frames.Add(BitmapFrame.Create(regionImage));

        //    encoder.Save(stream);


        //    //BitmapSource regionImage = BitmapSource.Create(Image1.Width, Image1.Height, 96, 96, PixelFormats.Bgr32, null, Image1.Bits, Image1.Width * Image1.BytesPerPixel);
        //    using (Graphics g = Graphics.FromImage(Image1))
        //        {

        //            g.SetClip(roi);
        //           //g.ScaleTransform(10.2F,10.2F);
        //            g.Save();

        //            Bitmap imnew = new Bitmap(1000,100,g);
        //            imnew.Save(newpath);

        //        }



        //}

    }
}