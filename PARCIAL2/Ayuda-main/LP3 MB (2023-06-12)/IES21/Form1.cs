using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IES21
{
    public partial class Form1 : Form
    {
        Gente g;
        DataTable tg;
        int pos;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PPD.ShowDialog();
        }

        private void PD_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            pos = 0;
        }

        private void PD_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

        private void PD_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)

        {
            Font f1 = new Font("Verdana", 12);
            Font f2 = new Font("Comic Sans MS", 20, FontStyle.Bold);
            Font f3 = new Font("Verdana", 12, FontStyle.Underline); ;

            int y = e.MarginBounds.Top;
            int x = e.MarginBounds.Left;

            e.Graphics.DrawString("Reporte de Clientes", f2, Brushes.Black, x, y);
            y = y + (f2.Height * 2);

            e.Graphics.DrawString("Nombre del Cliente", f3, Brushes.Black, x, y);
            e.Graphics.DrawString("Correo Electrónico", f3, Brushes.Black, x + 300, y);
            y = y + (f3.Height * 2);


            while (pos<tg.Rows.Count)
            {
                e.Graphics.DrawString(tg.Rows[pos]["full_name"].ToString(), f1, Brushes.Black, x, y);
                e.Graphics.DrawString(tg.Rows[pos]["email"].ToString(), f1, Brushes.Black, x+ 300, y);
                y = y + f1.Height;

                if(y>e.MarginBounds.Bottom)
                {
                    break;
                }
                pos++;
            }

            if(pos < tg.Rows.Count)
            {
                e.HasMorePages = true;
            }else
            {
                e.HasMorePages = false;
            }
           

          

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            g = new Gente();
            tg = g.getGente();

        }
    }
}
