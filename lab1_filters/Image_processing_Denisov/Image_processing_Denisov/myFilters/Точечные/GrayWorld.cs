using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image_processing_Denisov.myFilters.Точечные
{
    internal class GrayWorld : Filters
    {
        double R_ = 0;
        double G_ = 0;
        double B_ = 0;
        public GrayWorld(Bitmap sourceImage)
        {
            // Подсчёт всех цветов естественной сцены
            for (int x = 0; x < sourceImage.Width; x++) 
                for (int y = 0;  y < sourceImage.Height; y++)
                {
                    Color sourceColor = sourceImage.GetPixel(x, y);
                    R_ += sourceColor.R;
                    G_ += sourceColor.G; 
                    B_ += sourceColor.B;
                }
            // Средние яркости по всем каналам
            R_ /= sourceImage.Width * sourceImage.Height;
            G_ /= sourceImage.Width * sourceImage.Height;
            B_ /= sourceImage.Width * sourceImage.Height;
        }
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            // Гипотеза: сумма всех цветов на изображении естественной сцены дает серый цвет
            Color sourceColor = sourceImage.GetPixel(x, y);
            double avg = (R_ + G_ + B_) / 3;
            // Масштабирование яркости пикселей
            int resultR = (int)(sourceColor.R * avg / R_);
            int resultG = (int)(sourceColor.G * avg / G_);
            int resultB = (int)(sourceColor.B * avg / B_);

            Color resultColor = Color.FromArgb(
                    Clamp(resultR, 0, 255),
                    Clamp(resultG, 0, 255),
                    Clamp(resultB, 0, 255));
            return resultColor;
        }
    }
}
