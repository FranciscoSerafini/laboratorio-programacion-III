using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace dibujar_con_picture
{
    public partial class Form1 : Form
    {
        Graphics grafico;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            grafico = pictureBox1.CreateGraphics();

            int x;
            int y;
            int i = 0;

            for ( y = 0; y < pictureBox1.Height - 20; y = y + 20)
            {
                for ( x = 0; x < pictureBox1.Width - 20; x = x +20)
                {
                    if (i%2 == 0)
                    {
                        grafico.FillRectangle(Brushes.Black, x, y, 20, 20);
                    }
                    else
                    {
                        grafico.FillRectangle(Brushes.Red, x, y, 20, 20);
                    }
                    i++;
                }
            }

        }
    }
}
