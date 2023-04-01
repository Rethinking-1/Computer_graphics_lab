using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image_processing_Denisov.myFilters.Матричные
{
    internal class SobelFilterX : MatrixFilter
    {
        // Вычисляет приближенное значение градиента яркости изображения.
        public SobelFilterX()
        {
            int size = 3;
            kernel = new float[size, size];

            kernel[0, 0] = -1;
            kernel[1, 0] =  0;
            kernel[2, 0] =  1;

            kernel[0, 1] = -2;
            kernel[1, 1] =  0;
            kernel[2, 1] =  2;

            kernel[0, 2] = -1;
            kernel[1, 2] =  0;
            kernel[2, 2] =  1;
        }

    }
}
