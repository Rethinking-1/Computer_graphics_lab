using Image_processing_Denisov.myFilters.Матричные;
using Image_processing_Denisov.myFilters.Точечные;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Image_processing_Denisov
{
    public partial class Form1 : Form
    {
        Bitmap image;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Создаём диалог для открытия окна
            OpenFileDialog dialog = new OpenFileDialog();
            // Для удобства открытия только изображений, чтобы в окне проводника не было видно других файлов
            dialog.Filter = "Image files|*.png;*.jpg;*.bmp|All files(*.*)|*.*";
            // Проверка, выбрал ли пользователь файл
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                image = new Bitmap(dialog.FileName);
                // Визуализация картинки
                pictureBox1.Image = image;
                pictureBox1.Refresh();
            }
        }

        private void инверсияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvertFilter filter = new InvertFilter();
            //Bitmap resultImage = filter.processImage(image);
            //pictureBox1.Image = resultImage;
            //pictureBox1.Refresh();

            // Чтобы фильтр запускался в отдельном потоке
            backgroundWorker1.RunWorkerAsync(filter);
            // pictureBox1.Refresh();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //Выполняет код одного из фильтров
            Bitmap newImage = ((Filters)e.Argument).processImage(image, backgroundWorker1);
            if (backgroundWorker1.CancellationPending != true)
                image = newImage;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Изменяет цвет полосы
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Визуализирует обработанное изображение на форме и обнуляет полосу прогресса
            if (!e.Cancelled)
            {
                pictureBox1.Image = image;
                pictureBox1.Refresh();
            }
            progressBar1.Value = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }

        private void размытиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Обычное размытие
            Filters filter = new BlurFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void гауссовскоеРазмытиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Гауссовское размытие

            Filters filter = new GaussianFilter();
            backgroundWorker1.RunWorkerAsync(filter);

        }

        private void grayScalyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Оттенки серого
            Filters filrer = new GrayScaleFilter();
            backgroundWorker1.RunWorkerAsync(filrer);
        }

        private void сепияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Песочно-коричниевые оттенки
            Filters filter = new SepiaFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void увеличитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Увеличение яркости
            Filters filter = new BrightnessFilterUp();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void уменьшитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Уменьшение яркости
            Filters filter = new BrightnessFilterDown();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        
        }
        private void серыйМирToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Filters filter = new GrayWorld(image);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void собельYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Вычисляет приближенное значение градиента яркости изображения (Y).
            Filters filter = new SobelFilterY();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void собельXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Вычисляет приближенное значение градиента яркости изображения (X).
            Filters filter = new SobelFilterX();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void резкозToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Увеличение резкости
            Filters filter = new SharpnessFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void тиснениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Ядро + сдвиг по яркости + нормировка
            Filters filter = new EmbossingFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void волныToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Волны
            Filters filter = new WavesFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void переносToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Перенос
            Filters filter = new TransferFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void эффектСтеклаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Эффект стекла
            Filters filter = new GlassFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void операторЩарраXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Выделение границ
            Filters filter = new ScharrOperatorX();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void операторЩарраYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Выделение границ
            Filters filter = new ScharrOperatorY();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Сохранение картинки
            ImageFormat format = ImageFormat.Png;
            // Создаём диалог для открытия окна
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            // Для удобства открытия только изображений, чтобы в окне проводника не было видно лишних файлов
            saveFileDialog.Filter = "png Image|*.png|jpg Image|*.jpg|bmp Image|*.bmp";
            // Подпись диалогового окна
            saveFileDialog.Title = "Сохранить файл";
            // Проверка, выбрал ли пользователь файл
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string extension = System.IO.Path.GetExtension(saveFileDialog.FileName);
                switch (extension)
                {
                    case ".png":
                        format = ImageFormat.Png;
                        break;
                    case ".jpg":
                        format = ImageFormat.Jpeg;
                        break;
                    case ".bmp":
                        format = ImageFormat.Bmp;
                        break;
                }
                pictureBox1.Image.Save(saveFileDialog.FileName, format);
            }
        }

        private void собельToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // X+Y
            Filters filter = new SobelFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void dilationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Расширение
            Filters filter = new Dilation();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void erosionсужениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Сужение
            Filters filter = new Erosion();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void openingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Opening();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void closingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Closing();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void gradToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Grad();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void медианныйФильтрToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new MedianFilter(2);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void линейноеРастяжениеГистограммыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new linearHistogramStretch(image);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void зеркалоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Mirror();
            backgroundWorker1.RunWorkerAsync(filter);
        }
    }
}
    