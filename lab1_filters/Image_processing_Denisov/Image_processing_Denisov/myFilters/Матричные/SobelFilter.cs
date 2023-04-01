using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image_processing_Denisov.myFilters.Матричные
{
    internal class SobelFilter : MatrixFilter
    {
        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Bitmap resultImage = sourceImage;
            SobelFilterX sfX = new SobelFilterX();
            SobelFilterY sfY = new SobelFilterY();
            Bitmap tmp1 = sfX.processImage(resultImage, worker);
            Bitmap tmp2 = sfY.processImage(tmp1, worker);
            return tmp2;
        }
    }
}
