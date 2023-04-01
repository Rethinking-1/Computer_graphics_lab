using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image_processing_Denisov.myFilters.Матричные
{
    internal class ScharrOperatorY : MatrixFilter
    {
        public ScharrOperatorY()
        {
            int size = 3;
            kernel = new float[size, size];

            kernel[0, 0] = 3;
            kernel[1, 0] = 10;
            kernel[2, 0] = 3;

            kernel[0, 1] = 0;
            kernel[1, 1] = 0;
            kernel[2, 1] = 0;

            kernel[0, 2] =-3;
            kernel[1, 2] =-10;
            kernel[2, 2] =-3;
        }
    }
}
