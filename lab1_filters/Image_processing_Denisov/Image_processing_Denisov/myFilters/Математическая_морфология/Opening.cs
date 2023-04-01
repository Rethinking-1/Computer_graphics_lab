using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace Image_processing_Denisov
{
    // open(A, B) = (A (-) B) (+) B
    // Opening удаляет мелкие (шумные, лишние или нежелательные) объекты с переднего плана
    // (обычно это яркие объекты или отдельные пиксели) изображения, помещая их на задний план.

    class Opening : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            return new Color();
        }

        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Bitmap resultImage = sourceImage;
            Erosion erosion = new Erosion();
            Dilation dilation = new Dilation();
            Bitmap tmp1 = erosion.processImage(resultImage, worker);
            Bitmap tmp2 = dilation.processImage(tmp1, worker);
            return tmp2;
        }
    }
}
