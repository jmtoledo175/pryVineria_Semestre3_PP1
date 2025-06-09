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
    public partial class fmrAgregarCliente : Form
    {
        public fmrAgregarCliente()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            clsClientes clientes = new clsClientes();
            clientes.Nombre = txtNombre.Text;
            clientes.Dni = Convert.ToInt32(txtDni.Text);
            clientes.Edad = Convert.ToInt32(txtEdad.Text);
            clientes.Direccion = txtDireccion.Text;
            clientes.Telefono = Convert.ToInt64(txtTelefono.Text);
            clientes.Email = txtEmail.Text;


            clientes.Agregar();
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
