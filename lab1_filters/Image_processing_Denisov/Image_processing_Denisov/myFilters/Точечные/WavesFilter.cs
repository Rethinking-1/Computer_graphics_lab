using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace Image_processing_Denisov.myFilters.Точечные
{

    class WavesFilter : Filters
    {//Волны
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int colorX = Math.Abs((int)(x + 20 * Math.Sin(2 * Math.PI * y / 220)));
            if (colorX >= sourceImage.Width)
                colorX = x;
            Color sourceColor = sourceImage.GetPixel(colorX, y);
            Color resultColor =  Color.FromArgb(
                    Clamp(sourceColor.R, 0, 255),
                    Clamp(sourceColor.G, 0, 255),
                    Clamp(sourceColor.B, 0, 255));
            return resultColor;
        }
    }
}
