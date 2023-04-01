using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image_processing_Denisov.myFilters.Точечные
{
    // Перенос
    internal class TransferFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int colorX = x + 50;
            if (colorX >= sourceImage.Width)
                return Color.FromArgb(0, 0, 0);
            Color sourceColor = sourceImage.GetPixel(colorX, y);
            Color resultColor = Color.FromArgb(
                    Clamp(sourceColor.R, 0, 255),
                    Clamp(sourceColor.G, 0, 255),
                    Clamp(sourceColor.B, 0, 255));
            return resultColor;
        }
    }
}
