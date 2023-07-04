using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AGRICULTURA
{
    public partial class Form1 : Form
    {
        Localidades objL;
        Cultivos objC;
        Produccion objP;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            objL = new Localidades();
            objC = new Cultivos();
            objP = new Produccion();

            objL.ver(cbLocalidad);
            objC.ver(cbCultivo);
            objL.ver(lbLocalidad);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

            try
            {
                bool valor = objP.actualizar((int)cbLocalidad.SelectedValue, (int)cbCultivo.SelectedValue, Convert.ToInt32(txtToneladas.Text));
                if (valor == true)
                {
                    txtToneladas.Text = "";
                }
                else
                {
                    MessageBox.Show("ESTOS DATOS YA ESTAN REGISTRADOS ...", "ERROR");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("INGRESE NUMEROS EN TONELADAS ...", "ERROR");
            }

           

        }

        private void btnGraficar_Click(object sender, EventArgs e)
        {
            objP.graficar((int)lbLocalidad.SelectedValue, chart1);

        }
    }
}
