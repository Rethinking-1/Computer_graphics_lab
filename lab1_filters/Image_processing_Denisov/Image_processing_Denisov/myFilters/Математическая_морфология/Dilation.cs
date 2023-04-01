﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Image_processing_Denisov
{
// Расширение
    internal class Dilation : Filters
    {
        int[,] mask = new int[3, 3] { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } };
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int radiusX = mask.GetLength(0) / 2;
            int radiusY = mask.GetLength(1) / 2;

            float resultR = 0;
            float resultG = 0;
            float resultB = 0;

            for (int i = -radiusY; i <= radiusY; i++)
                for (int j = -radiusX; j <= radiusX; j++)
                {
                    int idX = Clamp(x + j, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + i, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    if ((mask[j + radiusX, i + radiusY] == 1) && (neighborColor.R > resultR))
                        resultR = neighborColor.R;
                    if ((mask[j + radiusX, i + radiusY] == 1) && (neighborColor.G > resultG))
                        resultG = neighborColor.G;
                    if ((mask[j + radiusX, i + radiusY] == 1) && (neighborColor.B > resultB))
                        resultB = neighborColor.B;
                }
            return Color.FromArgb(Clamp((int)resultR, 0, 255),
                                  Clamp((int)resultG, 0, 255),
                                  Clamp((int)resultB, 0, 255));

        }

    }
}
