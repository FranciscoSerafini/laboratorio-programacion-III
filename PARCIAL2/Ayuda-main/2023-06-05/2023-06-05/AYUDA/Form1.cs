using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AYUDA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            llenarGrilla();
        }

        private void llenarGrilla()
        {
            string[] localidades = { "ONCATIVO", "RIO IV", "SAN FRANCISCO" };
            string[] profesiones = { "PLOMERO", "DOCTOR", "MECANICO", "ABOGADO", "PROGRAMADOR" };

            grilla.Columns.Add("LOCALIDAD", "LOCALIDAD");
         
            foreach (string profesion in profesiones)
            {
                grilla.Columns.Add(profesion, profesion);
            }

            foreach(string localidad in localidades)
            {
                grilla.Rows.Add(localidad);
            }

            grilla.Rows[0].Cells["ABOGADO"].Value = "123";
            grilla.Rows[0].Cells["PLOMERO"].Value = "234";
        }
    }
}
