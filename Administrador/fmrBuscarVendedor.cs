using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryVineriaTPO.Administrador
{
    public partial class fmrBuscarVendedor : Form
    {
        public fmrBuscarVendedor()
        {
            InitializeComponent();
        }

        clsVendedores clsVendedores = new clsVendedores();
        private void button1_Click(object sender, EventArgs e)
        {
            clsVendedores.Buscar(Convert.ToInt32(txtDni.Text));

            if (Convert.ToInt32(txtDni.Text) == clsVendedores.Dni) {
                dgvGrilla.Rows.Add(clsVendedores.Dni, clsVendedores.Nombre, clsVendedores.Edad, clsVendedores.Direccion, clsVendedores.Telefono, clsVendedores.Email);
            }
            else
            {
                MessageBox.Show("Vendedor no registrado.");
            }
        }
    }
}
