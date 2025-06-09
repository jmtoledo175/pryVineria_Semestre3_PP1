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
    public partial class fmrListadoVentas : Form
    {
        public fmrListadoVentas()
        {
            InitializeComponent();
        }

        clsVenta clsVenta = new clsVenta();
        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            DateTime fecha = dtpFecha.Value;
            clsVenta.Buscar(fecha, dgvVentas);
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            prtVentana.ShowDialog();
            prtDocumento.PrinterSettings = prtVentana.PrinterSettings;
            prtDocumento.Print();
            MessageBox.Show("Reporte impreso correctamente");
        }

        private void prtDocumento_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
           
            clsVenta.Imprimir(e);
        }
    }
}
