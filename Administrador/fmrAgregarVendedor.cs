using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryVineriaTPO
{
    public partial class fmrAgregarVendedor : Form
    {
        public fmrAgregarVendedor()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            clsVendedores vendedor = new clsVendedores();
            vendedor.Nombre = txtNombre.Text;
            vendedor.Dni = Convert.ToInt32(txtDni.Text);
            vendedor.Edad = Convert.ToInt32(txtEdad.Text);
            vendedor.Direccion = txtDireccion.Text;
            vendedor.Telefono = Convert.ToInt64(txtTelefono.Text);
            vendedor.Email = txtEmail.Text;


            vendedor.Agregar();
            MessageBox.Show("Datos grabados!");
            txtNombre.Text = "";
            txtDni.Text = "";
            txtEdad.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtEmail.Text = "";
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            txtDni.Text = "";
            txtEdad.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtEmail.Text = "";
        }
    }
}
