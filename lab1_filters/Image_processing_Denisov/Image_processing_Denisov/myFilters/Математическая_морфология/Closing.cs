using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace Image_processing_Denisov
{
    // close(A, B) = (A (+) B) (-) B=A ● B
    // Closing удаляет небольшие дыры на переднем плане (шум, потерянные или желаемые к заполнению) 
    // объекты с переднего плана(обычно это темные объекты или отдельные пиксели) изображения, помещая их из фона на передний план.
    class Closing : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            return new Color();
        }

        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Bitmap resultImage = sourceImage;
            Dilation dilation = new Dilation();
            Erosion erosion = new Erosion();
            Bitmap tmp1 = dilation.processImage(resultImage, worker);
            Bitmap tmp2 = erosion.processImage(tmp1, worker);
            return tmp2;
        }
    }
}
