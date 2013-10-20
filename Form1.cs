using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace rectangle_sample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fil = new OpenFileDialog();
            fil.Filter = "Image Files(*.jpg; *.jpeg; *.png; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (fil.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(fil.FileName);
                               
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Please load a image first!");
                return;
            }
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            int height = bmp.Height;
            int width = bmp.Width;
            int[,] array = new int[width, height];
            Color col;

            for (int i = 1; i < width; i++)
            {

                for (int j = 1; j < height; j++)
                {


                    col = bmp.GetPixel(i, j);

                    int pixel = col.R;

                    array[i, j] = pixel;



                }

            }

            EdgeDectection edgeDectection = new EdgeDectection();
            Pen p = new Pen(Color.Red);

            edgeDectection.getWordsNew(array, 1, width, 1, height);
            MessageBox.Show("Number of Words Found: " + edgeDectection.words.Count);
            foreach (CustomWord word in edgeDectection.words) {
                int rectWidth2 = word.XMin - word.XMax;
                int rectHeight2 = word.YMin - word.YMax;

                Rectangle rec2 = new Rectangle(word.XMax, word.YMax, rectWidth2, rectHeight2);
                pictureBox1.CreateGraphics().DrawRectangle(p, rec2);

            
            }

        }
    }
}
