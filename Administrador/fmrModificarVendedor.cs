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
    public partial class fmrModificarVendedor : Form
    {
        public fmrModificarVendedor()
        {
            InitializeComponent();
        }

        clsVendedores clsVendedores = new clsVendedores();
        private void fmrModificarVendedor_Load(object sender, EventArgs e)
        {
            clsVendedores.CargarVendedores(cmbVendedor);
          
        }

        private void btnModificafr_Click(object sender, EventArgs e)
        {
            
            if (cmbVendedor.SelectedValue != null)
            {
                int idVendedorSeleccionado = Convert.ToInt32(cmbVendedor.SelectedValue);

                string nombre = txtNombre.Text;
                int edad = Convert.ToInt32(txtEdad.Text);
                int dni = Convert.ToInt32(txtDni.Text);
                string direccion = txtDireccion.Text;
                string telefono = txtTelefono.Text;
                string email = txtEmail.Text;

                clsVendedores.ModificarVendedor(idVendedorSeleccionado, nombre, dni, edad, direccion, telefono, email);

            }
            else
            {
                MessageBox.Show("Selecciona un vendedor primero.");
            }
        }

        private void cmbVendedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbVendedor.SelectedValue != null)
            {
                DataRowView row = (DataRowView)cmbVendedor.SelectedItem;
                int idVendedorSeleccionado = Convert.ToInt32(row["Dni"]);

                clsVendedores.CargarDatosVendedor(idVendedorSeleccionado, txtNombre, txtDni, txtEdad, txtDireccion, txtTelefono, txtEmail);
            }
        }
    }
}
