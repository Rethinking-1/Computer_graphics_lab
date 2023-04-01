using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace Image_processing_Denisov
{
    abstract class Filters
    {
        // Вычисляет значение пикселя отфильтрованного изображения, и для каждого из фильтров уникальна
        protected abstract Color calculateNewPixelColor(Bitmap sourceImage, int x, int y);

        // Приведение значений цвета пикселя к допустимому диапазону 
        public int Clamp(int value, int min, int max)
        {
            if(value < min)
                return min;
            if(value > max) 
                return max; 
            return value; 
        }

        // Общая для всех фильтров часть
        public virtual Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            // Создание пустого изображения
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);

            for (int i = 0; i < sourceImage.Width; i++)
            {
                // Cигнализирует элементу BackgroundWorker о текущем прогрессе.
                worker.ReportProgress((int)((float)i / resultImage.Width * 100));
                if (worker.CancellationPending)
                    return null;
                // Обход всех пикселей
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    resultImage.SetPixel(i, j, calculateNewPixelColor(sourceImage, i, j));
                }
            }
            return resultImage;
        }
    }
}
