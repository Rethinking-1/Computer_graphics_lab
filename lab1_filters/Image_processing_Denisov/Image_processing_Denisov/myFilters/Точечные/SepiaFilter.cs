using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image_processing_Denisov.myFilters.Точечные
{
    internal class SepiaFilter : Filters
    {
        //Переводит цветное изображение в изображение песочно-коричневых оттенков.
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            double intensity = 0.299 * sourceColor.R + 0.587 * sourceColor.G + 0.114 * sourceColor.B;
            // Нужно было подобрать:
            // 15, 25 не плохо
            // 35 хорошо
            // 55 много
            // 100 интересно(на логотипах)
            double k = 33;  
            double resultR = intensity + 2 * k;
            double resultG = intensity + 0.5 * k;
            double resultB = intensity - 1 * k;

            // Приведение всех значений к допустимому интервалу
            Color resultColor = Color.FromArgb(
                    Clamp((int)resultR, 0, 255),
                    Clamp((int)resultG, 0, 255),
                    Clamp((int)resultB, 0, 255));
            return resultColor;
        }
    }
}
