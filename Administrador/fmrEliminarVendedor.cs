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
    public partial class fmrEliminarVendedor : Form
    {
        public fmrEliminarVendedor()
        {
            InitializeComponent();
        }

        clsVendedores clsVendedores = new clsVendedores();
        private void fmrEliminarVendedor_Load(object sender, EventArgs e)
        {
            clsVendedores.CargarCombo(cmbVendedor);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clsVendedores.Quitar(cmbVendedor);
            clsVendedores.CargarCombo(cmbVendedor);
        }
    }
}
