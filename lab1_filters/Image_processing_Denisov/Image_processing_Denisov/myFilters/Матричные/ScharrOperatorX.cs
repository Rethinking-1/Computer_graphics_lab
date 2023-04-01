using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image_processing_Denisov.myFilters.Матричные
{
    internal class ScharrOperatorX : MatrixFilter
    {

        public ScharrOperatorX() 
        {
            int size = 3;
            kernel = new float[size, size];

            kernel[0, 0] =  3;
            kernel[1, 0] =  0;
            kernel[2, 0] = -3;

            kernel[0, 1] =  10;
            kernel[1, 1] =  0;
            kernel[2, 1] = -10;

            kernel[0, 2] =  3;
            kernel[1, 2] =  0;
            kernel[2, 2] = -3;
        }
    }
}
