using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image_processing_Denisov.myFilters.Матричные
{
    internal class GaussianFilter : MatrixFilter
    {
        public GaussianFilter() 
        {
            // Создаёт фильтр размером 7 * 7 и с коэффициентом сигма, равным 2
            createGaussianKernel(7, 2);
        }
        public void createGaussianKernel(int radius, float sigma) 
        {
            // Определяем размер ядра
            int size = 2 * radius + 1;
            // Создаём ядро фильтра
            kernel = new float[size, size];
            // Коэффициент нормировки ядра
            float norm = 0;
            // Рассчитываем ядро линейного фильтра
            for (int i = -radius; i <= radius; i++)
                for (int j =  -radius; j <= radius; j++)
                {
                    kernel[i + radius, j + radius] = (float)(Math.Exp(-(i * i + j * j) / (2 * sigma * sigma)));
                    norm += kernel[i + radius, j + radius];
                }
            // Нормируем ядро
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    kernel[i, j] /= norm;
        }
    }
}
