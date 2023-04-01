using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image_processing_Denisov.myFilters.Точечные
{
    internal class BrightnessFilterDown : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            // Уменьшает яркость изображения P.S. можно добавить выбор коэффициента яркости
            Color sourceColor = sourceImage.GetPixel(x, y);
            double k = 15; // Коэффициент яркости
            double resultR = sourceColor.R - k;
            double resultG = sourceColor.G - k;
            double resultB = sourceColor.B - k;
            // Приведение всех значений к допустимому интервалу
            Color resultColor = Color.FromArgb(
                    Clamp((int)resultR, 0, 255),
                    Clamp((int)resultG, 0, 255),
                    Clamp((int)resultB, 0, 255));
            return resultColor;
        }
    }
}
