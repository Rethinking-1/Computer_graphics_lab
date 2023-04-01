using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image_processing_Denisov.myFilters.Точечные
{

    // Эффект стекла
    internal class GlassFilter : Filters
    {
        Random rnd = new Random();
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {

   
            int colorX = x + (int)((rnd.NextDouble() - 0.5) * 10);
            int colorY = y + (int)((rnd.NextDouble() - 0.5) * 10);
            if (colorX >= sourceImage.Width ||
                colorX < 0 ||
                colorY >= sourceImage.Height ||
                colorY < 0)
            {
                Color sourceColor_ = sourceImage.GetPixel(x, y);
                return Color.FromArgb(
                    Clamp(sourceColor_.R, 0, 255),
                    Clamp(sourceColor_.G, 0, 255),
                    Clamp(sourceColor_.B, 0, 255));
            }
            Color sourceColor = sourceImage.GetPixel(colorX, colorY);
            Color resultColor = Color.FromArgb(
                    Clamp(sourceColor.R, 0, 255),
                    Clamp(sourceColor.G, 0, 255),
                    Clamp(sourceColor.B, 0, 255));
            return resultColor;
        }
    }
}