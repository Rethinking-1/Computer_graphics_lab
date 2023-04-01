using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace Image_processing_Denisov.myFilters.Точечные
{
    class linearHistogramStretch : Filters
    {
            double ymax = 0; // Яркость 
            double ymin = 1;

            public linearHistogramStretch(Bitmap sourceImage)
            {
                for (int i = 0; i < sourceImage.Width; i++)
                    for (int j = 0; j < sourceImage.Height; j++)
                    {
                    // Получение максимальной и минимальной яркости пикселя
                        Color color = sourceImage.GetPixel(i, j);
                        double y = color.GetBrightness();
                        ymax = (y > ymax) ? y : ymax;
                        ymin = (y < ymin) ? y : ymin;
                    }
            }
            protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
            {
                Color sourceColor = sourceImage.GetPixel(x, y);
                double Brightness = sourceColor.GetBrightness();
                double resultR = (Brightness - ymin) * 255 / (ymax - ymin);
                double resultG = (Brightness - ymin) * 255 / (ymax - ymin);
                double resultB = (Brightness - ymin) * 255 / (ymax - ymin);
                Color resultColor = Color.FromArgb(
                    Clamp((int)resultR, 0, 255), 
                    Clamp((int)resultG, 0, 255), 
                    Clamp((int)resultB, 0, 255));
                return resultColor;
            }
    }
}
