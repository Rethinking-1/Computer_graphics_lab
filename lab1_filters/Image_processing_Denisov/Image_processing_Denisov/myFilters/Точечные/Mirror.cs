using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Image_processing_Denisov.myFilters.Точечные
{
    class Mirror : Filters
    {

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color colorY = new Color();
            if (y > sourceImage.Height / 2)
            {
                colorY = sourceImage.GetPixel(x, sourceImage.Height - y);
            }
            else
                colorY = sourceImage.GetPixel(x, y);
            Color resultColor = Color.FromArgb(
                    Clamp(colorY.R, 0, 255),
                    Clamp(colorY.G, 0, 255),
                    Clamp(colorY.B, 0, 255));
            return resultColor;

        }
    }
}
