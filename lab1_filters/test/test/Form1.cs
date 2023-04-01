using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test
{
    public partial class Form1 : Form
    {
        Bitmap image;

        public Form1()
        {
            InitializeComponent();
        }

        private void фильтрыToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Диалог для открытия файла
            OpenFileDialog dialog = new OpenFileDialog();
            // Для удобства открытия только изображений, чтобы в окне проводника не было видно других файлов
            dialog.Filter = "Image files|*.png;*.jpg;*.bmp|All files(*.*)|*.*";
            // Проверка, выбрал ли пользователь файл
            if (dialog.ShowDialog() == DialogResult.OK)
                image = new Bitmap(dialog.FileName);
            // Визуализация картинки
            pictureBox1 .Image = image;
            pictureBox1.Refresh();


        }
    }
}
