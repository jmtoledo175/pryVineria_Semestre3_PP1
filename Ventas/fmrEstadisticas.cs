using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryVineriaTPO.Ventas
{
    public partial class fmrEstadisticas : Form
    {
        public fmrEstadisticas()
        {
            InitializeComponent();
        }

        clsVenta clsVenta = new clsVenta();
        private void bnt1_Click(object sender, EventArgs e)
        {
            clsVenta.Mostrar(chart1);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
