using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Image_processing_Denisov.myFilters.Матричные
{
//Тиснение
    class EmbossingFilter : MatrixFilter
    {
        public EmbossingFilter()
        {
            int size = 3;
            kernel = new float[size, size];

            kernel[0, 0] =  0;
            kernel[1, 0] =  1;
            kernel[2, 0] =  0;

            kernel[0, 1] =  1;
            kernel[1, 1] =  0;
            kernel[2, 1] = -1;

            kernel[0, 2] =  0;
            kernel[1, 2] = -1;
            kernel[2, 2] =  0;
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            // Поступающие на вход координаты текущего пикселя изображения, цвет которого мы собираемся считать.
            int radiusX = kernel.GetLength(0) / 2;
            int radiusY = kernel.GetLength(1) / 2;

            // Цветовые компоненты результирующего цвета. 
            float resultR = 0;
            float resultG = 0;
            float resultB = 0;
            // Ядро пикселя
            // Перебирают окрестность пикселя
            for (int l = -radiusY; l <= radiusY; l++)
                for (int k = -radiusX; k <= radiusX; k++)
                {
                    // Контроль граничных пикселей на выход за границы изображения
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    // В каждой из точек окрестности вычисляется цвет: умножение на значение из ядра и прибавление к результирующим компонентам цвета.
                    resultR += neighborColor.R * kernel[k + radiusX, l + radiusX];
                    resultG += neighborColor.G * kernel[k + radiusX, l + radiusY];
                    resultB += neighborColor.B * kernel[k + radiusX, l + radiusY];
                    // l и k означают положение элемента в матрице фильтра(ядре), если начало отсчета поместить в центр матрицы.
                }

            //Сдвиг по яркости + нормировка
            int light = -40;
            resultR += (255 + light) / 2;
            resultG += (255 + light) / 2;
            resultB += (255 + light) / 2;
            return Color.FromArgb(
                Clamp((int)(resultR), 0, 255),
                Clamp((int)(resultG), 0, 255),
                Clamp((int)(resultB), 0, 255)
                );
        }
    }
}
