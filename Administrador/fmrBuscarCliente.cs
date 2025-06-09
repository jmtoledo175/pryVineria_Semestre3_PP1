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
    public partial class fmrBuscarCliente : Form
    {
        public fmrBuscarCliente()
        {
            InitializeComponent();
        }

        clsClientes clientes = new clsClientes();
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            clientes.Buscar(Convert.ToInt32(txtDni.Text));

            if (Convert.ToInt32(txtDni.Text) == clientes.Dni)
            {
                dgvGrilla.Rows.Add(clientes.Dni, clientes.Nombre, clientes.Edad, clientes.Direccion, clientes.Telefono, clientes.Email);
            }
            else
            {
                MessageBox.Show("Cliente no registrado.");
            }
        }
    }
}
