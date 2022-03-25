using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageChanging
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap("Grapes.png");
            pictureBox1.Image = bitmap;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Bitmap oldBitmap = (Bitmap)pictureBox1.Image;
            Bitmap newBitmap = new Bitmap(oldBitmap.Width, oldBitmap.Height);

            Color white = Color.White;
            Color black = Color.Black;

            var oldVerticalPixel = oldBitmap.GetPixel(0, 0);
            int oldVerticalI = 0;
            int oldVerticalJ = 0;
            var oldHorizontalPixel = oldBitmap.GetPixel(0, 0);
            int oldHorizontalI = 0;
            int oldHorizontalJ = 0;

            for (int i = 0; i < newBitmap.Width; i++)
            {
                for (int j = 0; j < newBitmap.Height; j++)
                {
                    var pixel = oldBitmap.GetPixel(i, j);

                    if (pixel == oldVerticalPixel && pixel == oldHorizontalPixel)
                    {
                        newBitmap.SetPixel(oldVerticalI, oldVerticalJ, white);
                    }
                    else
                    {
                        newBitmap.SetPixel(oldVerticalI, oldVerticalJ, black);
                    }



                    oldVerticalPixel = pixel;
                    oldVerticalI = i;
                    oldVerticalJ = j;
                    oldHorizontalJ = j;
                    oldHorizontalI = i != 0 ? i - 1 : 0;
                    oldHorizontalPixel = oldBitmap.GetPixel(oldHorizontalI, oldHorizontalJ);
                }
            }

            pictureBox1.Image = newBitmap;
        }
    }
}
