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
    public partial class fmrModificarProductos : Form
    {
        public fmrModificarProductos()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmdAgregarNuevoProd_Click(object sender, EventArgs e)
        {
            fmrAgregarNuevoProducto fmrAgregarNuevoProducto = new fmrAgregarNuevoProducto();
            fmrAgregarNuevoProducto.Show();
        }
    }
}
