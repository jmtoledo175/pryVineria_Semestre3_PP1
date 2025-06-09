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
    public partial class fmrVisualizacionStock : Form
    {
        public fmrVisualizacionStock()
        {
            InitializeComponent();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            fmrModificarStock frm = new fmrModificarStock();
            frm.ShowDialog();
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            fmrAgregarProductosStock fmrAgregarProductosStock = new fmrAgregarProductosStock();
            fmrAgregarProductosStock.ShowDialog();
        }
    }
}
