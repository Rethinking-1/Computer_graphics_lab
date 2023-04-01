﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image_processing_Denisov.myFilters.Точечные
{
    internal class GrayScaleFilter : Filters
    {
        // Переводящит изображение из цветного в полутоновое (в оттенках серого)
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            double intensity = 0.299 * sourceColor.R + 0.587 * sourceColor.G + 0.114 * sourceColor.B;
            Color resultColor = Color.FromArgb((int)intensity,
                                               (int)intensity,
                                               (int)intensity);
            return resultColor;
        }
    }
}
