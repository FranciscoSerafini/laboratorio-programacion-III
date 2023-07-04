using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Windows.Forms.DataVisualization.Charting;

namespace SP3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        clsProvincia objProvincia;
        clsDepartamentos objDepto;
        clsIncendios objIncendios;
        clsTipoIncendio objTipo;

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                objProvincia = new clsProvincia();
                objDepto = new clsDepartamentos();
                objIncendios = new clsIncendios();
                objTipo = new clsTipoIncendio();
            }
            catch (Exception)
            {
                MessageBox.Show("Problemas con las tablas");
                
            }
            DataTable dtProvincia = new DataTable();
            DataTable dtDepartamentos = new DataTable();

            dtProvincia = objProvincia.getTabla();
            dtDepartamentos = objDepto.getTabla();

            
            
            TreeNode incendios = treeView1.Nodes.Add("INCENDIOS");
            foreach (DataRow filaProvincia in dtProvincia.Rows)
            {
               TreeNode Provincia =  incendios.Nodes.Add(filaProvincia["Provincia"].ToString(), filaProvincia["Nombre"].ToString());
                Provincia.Tag = filaProvincia["Provincia"].ToString();
               foreach (DataRow filaDepto in dtDepartamentos.Rows)
               {
                  if (Provincia.Tag.ToString() == filaDepto["Provincia"].ToString())
                  {
                        TreeNode Departamentos = Provincia.Nodes.Add(filaDepto["Nombre"].ToString());
                        Departamentos.Tag = filaDepto["Departamento"].ToString();
                  }
               }
            }

        }

        private void tvwIncendios_AfterSelect(object sender, TreeViewEventArgs e)
        {
           
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            DataTable dtProvincia = new DataTable();
            DataTable dtDepartamentos = new DataTable();
            DataTable dtIncendios = new DataTable();
            DataTable dtTipo = new DataTable();

            dtProvincia = objProvincia.getTabla();
            dtDepartamentos = objDepto.getTabla();
            dtIncendios = objIncendios.getTabla();
            dtTipo = objTipo.getTabla();


            dataGridView1.Rows.Clear();
            int totalIncendios = 0;
            int cantidadTotal = 0;
            int f = 0;
            foreach (DataRow filaTipo in dtTipo.Rows)
            {
                dataGridView1.Rows.Add(filaTipo["Descripcion"].ToString());
                if (e.Node.Level == 0)
                {
                    foreach (DataRow  filaIncendio in dtIncendios.Rows)
                    {
                        if (filaTipo["TipoIncendio"].ToString() == filaIncendio["TipoIncendio"].ToString())
                        {

                            totalIncendios = totalIncendios + Convert.ToInt32(filaIncendio["Cantidad"]);

                        }
                    }
                    dataGridView1.Rows[f].Cells[1].Value = totalIncendios;
                    cantidadTotal = cantidadTotal + totalIncendios;
                    totalIncendios = 0;
                    f = f + 1;


                }
                else if(e.Node.Level == 1)
                {

                    foreach (DataRow filaProvincia in dtProvincia.Rows) 
                    {
                       
                        foreach (DataRow filaDepto in dtDepartamentos.Rows)
                        {
                            if (filaProvincia["Provincia"].ToString() == filaDepto["Provincia"].ToString())
                            {
                                foreach (DataRow filaIncendio in dtIncendios.Rows)
                                {

                                    if (filaDepto["Departamento"].ToString() == filaIncendio["Departamento"].ToString())
                                    {
                                        if (filaTipo["TipoIncendio"].ToString() == filaIncendio["TipoIncendio"].ToString())
                                        {
                                            totalIncendios = totalIncendios + Convert.ToInt32(filaIncendio["Cantidad"]);
                                        }
                                        
                                    }
                                    
                                }
                               
                            }
                            
                        }
                        
                    }
                    dataGridView1.Rows[f].Cells[1].Value = totalIncendios;
                    totalIncendios = 0;
                    f = f + 1;
                }
            }
            
            lblTotal.Text = cantidadTotal.ToString();
           
        }

        private void cmdGrafico_Click(object sender, EventArgs e)
        {
            DataTable dtIncendios = new DataTable();
            DataTable dtTipo = new DataTable();

            dtIncendios = objIncendios.getTabla();
            dtTipo = objTipo.getTabla();


            chart1.Series.Clear();

            foreach (DataRow filaTipoIncendio in dtTipo.Rows)
            {
                Series serie = chart1.Series.Add(filaTipoIncendio["Descripcion"].ToString());
                int cantidad = 0;
                foreach (DataRow filaIncendio in dtIncendios.Rows)
                {
                   
                    if (filaTipoIncendio["TipoIncendio"].ToString() == filaIncendio["TipoIncendio"].ToString())
                    {
                        cantidad = cantidad + Convert.ToInt32(filaIncendio["Cantidad"]);

                    }

                }
                serie.Points.AddXY(filaTipoIncendio["Descripcion"].ToString(), cantidad);
            }
        }
    }
}
