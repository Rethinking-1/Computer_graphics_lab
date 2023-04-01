using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace Image_processing_Denisov
{
    class Grad : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            return new Color();
        }

        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Bitmap resultImage = sourceImage;
            Bitmap img1 = sourceImage;
            Bitmap img2 = sourceImage;
            Dilation dilation = new Dilation();
            Erosion erosion = new Erosion();
            Bitmap tmp1 = dilation.processImage(img1, worker);
            Bitmap tmp2 = erosion.processImage(img2, worker);
            for(int i = 0; i < resultImage.Width; i++)
                for(int j = 0; j < resultImage.Height; j++)
                {
                    int R = Clamp(tmp1.GetPixel(i, j).R - tmp2.GetPixel(i, j).R, 0, 255);
                    int G = Clamp(tmp1.GetPixel(i, j).G - tmp2.GetPixel(i, j).G, 0, 255);
                    int B = Clamp(tmp1.GetPixel(i, j).B - tmp2.GetPixel(i, j).B, 0, 255);
                    resultImage.SetPixel(i, j, Color.FromArgb(Clamp(R, 0, 255), Clamp(G, 0, 255), Clamp(B, 0, 255)));
                }
            return resultImage;
        }
    }
}
