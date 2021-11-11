using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aplicacion.AccesoDatos;

namespace Aplicacion
{
    public partial class frmPrincipal : Form
    {
        bool carga = false;
        List<int> datos = new List<int>();
        List<string> nDatos = new List<string>();

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarCarreras();
            CargarMaterias();
            cboCarreras.SelectedIndex = cboMaterias.SelectedIndex = -1;
            carga = true;
        }

        private void btnConsulta1_Click(object sender, EventArgs e)
        {
            BorrarListas();
            datos.Add((int)cboMaterias.SelectedValue);
            nDatos.Add("@idMateria");
            dgvGrilla.DataSource = HelperDao.ObtenerInstancia().ConsultaVariosSQL("SP_PROMEDIO_AÑO_MATERIA", datos, nDatos);
        }

        private void BorrarListas()
        {
            datos.Clear();
            nDatos.Clear();            
        }

        private void CargarCarreras()
        {
            DataTable tabla = HelperDao.ObtenerInstancia().ConsultaSQL("SP_CONSULTAR_CARRRERAS");
            cboCarreras.DataSource = tabla;
            cboCarreras.DisplayMember = tabla.Columns[1].ColumnName;
            cboCarreras.ValueMember = tabla.Columns[0].ColumnName;
        }

        private void CargarMaterias()
        {
            DataTable tabla = HelperDao.ObtenerInstancia().ConsultaSQL("SP_CONSULTAR_MATERIAS");
            cboMaterias.DataSource = tabla;
            cboMaterias.DisplayMember = tabla.Columns[1].ColumnName;
            cboMaterias.ValueMember = tabla.Columns[0].ColumnName;
        }

        private void cboCarreras_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(carga && cboCarreras.SelectedIndex > -1)
            {
                lblDescMateria.Text = cboCarreras.SelectedValue.ToString();
            }
        }

        private void cboMaterias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (carga && cboMaterias.SelectedIndex > -1)
            {
                lblDescMateria.Text = cboMaterias.SelectedValue.ToString();
            }
        }

        private void lblDescMateria_Click(object sender, EventArgs e)
        {

        }

        private void btnConsulta2_Click(object sender, EventArgs e)
        {
            BorrarListas();
            lblInt1.Text = "Edad 1";
            lblInt2.Text = "Edad 2";
            datos.Add(int.Parse(txtInt1.Text));
            datos.Add(int.Parse(txtInt2.Text));
            nDatos.Add("@edad1");
            nDatos.Add("@edad2");
            dgvGrilla.DataSource = HelperDao.ObtenerInstancia().ConsultaVariosSQL("SP_ALUMNOS_RANGO_EDAD", datos, nDatos);
        }

        private void btnConsulta3_Click(object sender, EventArgs e)
        {
            BorrarListas();
            datos.Add(int.Parse(cboCarreras.SelectedValue.ToString()));
            nDatos.Add("@idCarrera");
            dgvGrilla.DataSource = HelperDao.ObtenerInstancia().ConsultaVariosSQL("SP_ALUMNOS_CARRERAS", datos, nDatos);
        }

        private void btnConsulta4_Click(object sender, EventArgs e)
        {
            BorrarListas();
            datos.Add((int)cboMaterias.SelectedValue);
            nDatos.Add("@idMateria");
            dgvGrilla.DataSource = HelperDao.ObtenerInstancia().ConsultaVariosSQL("SP_ALMUNOS_INASISTENCIAS_POR_MATERIA", datos, nDatos);
        }

        private void btnConsulta5_Click(object sender, EventArgs e)
        {
            BorrarListas();
            datos.Add((int)cboMaterias.SelectedValue);
            nDatos.Add("@idMateria");
            dgvGrilla.DataSource = HelperDao.ObtenerInstancia().ConsultaVariosSQL("SP_FINALES_APROBADOS", datos, nDatos);
        }

        private void btnConsulta6_Click(object sender, EventArgs e)
        {
            BorrarListas();
            lblInt1.Text = "Legajo 1";
            lblInt2.Text = "Legajo 2";
            datos.Add(int.Parse(txtInt1.Text));
            datos.Add(int.Parse(txtInt2.Text));
            nDatos.Add("@lMin");
            nDatos.Add("@lMax");
            dgvGrilla.DataSource = HelperDao.ObtenerInstancia().ConsultaVariosSQL("SP_MATRICULAS_POR_RANGO_LEGAJO", datos, nDatos);
        }

        private void btnConsulta7_Click(object sender, EventArgs e)
        {
            BorrarListas();
            lblInt1.Text = "Legajo 1";
            datos.Add(int.Parse(txtInt1.Text));
            nDatos.Add("@legajo");
            dgvGrilla.DataSource = HelperDao.ObtenerInstancia().ConsultaVariosSQL("SP_INSCIP_MATERIAS_ALUMNO", datos, nDatos);
        }

        private void btnConsulta8_Click(object sender, EventArgs e)
        {
            BorrarListas();
            datos.Add((int)cboMaterias.SelectedValue);
            nDatos.Add("@idMateria");
            dgvGrilla.DataSource = HelperDao.ObtenerInstancia().ConsultaVariosSQL("SP_DOCENTES_POR_MATERIA", datos, nDatos);
        }
    }
}
