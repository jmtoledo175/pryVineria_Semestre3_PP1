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
    public partial class fmrModificarCliente : Form
    {
        public fmrModificarCliente()
        {
            InitializeComponent();
        }

        clsClientes clsClientes = new clsClientes();
        private void fmrModificarCliente_Load(object sender, EventArgs e)
        {
            clsClientes.CargarCombo(cmbCliente);
        }

        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCliente.SelectedValue != null)
            {
                
                DataRowView row = (DataRowView)cmbCliente.SelectedItem;
                int idClienteSeleccionado = Convert.ToInt32(row["IdCliente"]);

                clsClientes.CargarDatosClientes(idClienteSeleccionado, txtNombre, txtDni, txtEdad, txtDireccion, txtTelefono, txtEmail);
            }
        }

        private void btnModificafr_Click(object sender, EventArgs e)
        {
            if (cmbCliente.SelectedValue != null)
            {
                int idClienteSeleccionado = Convert.ToInt32(cmbCliente.SelectedValue);

                string nombre = txtNombre.Text;
                int edad = Convert.ToInt32(txtEdad.Text);
                int dni = Convert.ToInt32(txtDni.Text);
                string direccion = txtDireccion.Text;
                string telefono = txtTelefono.Text;
                string email = txtEmail.Text;

                clsClientes.ModificarClientes(idClienteSeleccionado, nombre, dni, edad, direccion, telefono, email);

            }
            else
            {
                MessageBox.Show("Selecciona un vendedor primero.");
            }
        }
    }
}
