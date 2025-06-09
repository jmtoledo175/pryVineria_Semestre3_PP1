using pryVineriaTPO.Administrador;
using pryVineriaTPO.Ventas;
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
    public partial class fmrVineria : Form
    {
        public fmrVineria()
        {
            InitializeComponent();
        }

        private void presupuestosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void agregarVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmrAgregarVenta fmrAgregarVenta = new fmrAgregarVenta();
            fmrAgregarVenta.Show();
        }

        private void modificarVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmrModificarVenta fmrModificarVenta = new fmrModificarVenta();
            fmrModificarVenta.Show();
        }

        private void eliminarVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmrEliminarVenta fmrEliminarVenta= new fmrEliminarVenta();
            fmrEliminarVenta.Show();
        }

        private void modificaciónDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmrModificarStock fmrModificarStock = new fmrModificarStock();
            fmrModificarStock.Show();
        }

        private void generarReporteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmrGenerarPresupuesto fmrGenerarPresupuesto = new fmrGenerarPresupuesto();
            fmrGenerarPresupuesto.Show();
        }

        private void agregarVendedorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fmrAgregarVendedor fmrAgregarVendedor = new fmrAgregarVendedor();
            fmrAgregarVendedor.Show();
        }

        private void modificarVendedorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fmrModificarVendedor fmrModificarVendedor = new fmrModificarVendedor();
            fmrModificarVendedor.Show();
        }

        private void eliminarVendedorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fmrEliminarVendedor fmrEliminarVendedor = new fmrEliminarVendedor();
            fmrEliminarVendedor.Show();
        }

        private void agregarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmrAgregarCliente fmrAgregarCliente = new fmrAgregarCliente();
            fmrAgregarCliente.Show();
        }

        private void modificarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmrModificarCliente fmrModificarCliente = new fmrModificarCliente(); 
            fmrModificarCliente.Show();
        }

        private void eliminarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmrEliminarCliente fmrEliminarCliente = new fmrEliminarCliente(); 
            fmrEliminarCliente.Show();
        }

        private void consultarPresupuestosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmrConsultarPresupuesto fmrConsultarPresupuesto = new fmrConsultarPresupuesto();
            fmrConsultarPresupuesto.Show();
        }

        private void modificarPresupuestoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmrModificarPresupuesto fmrModificarPresupuesto = new fmrModificarPresupuesto();
            fmrModificarPresupuesto.Show();
        }

        private void visualizaciónDeStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmrVisualizacionStock fmrVisualizacionStock = new fmrVisualizacionStock();
            fmrVisualizacionStock.Show();
        }

        private void buscarVendedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmrBuscarVendedor fmrBuscarVendedor = new fmrBuscarVendedor();
            fmrBuscarVendedor.Show();
        }

        private void buscarVendedorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fmrBuscarCliente fmrBuscarCliente = new fmrBuscarCliente();
            fmrBuscarCliente.Show();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            fmrListadoVentas fmrListadoVentas = new fmrListadoVentas();
            fmrListadoVentas.Show();
        }

        private void estadisticasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmrEstadisticas fmrEstadisticas = new fmrEstadisticas();
            fmrEstadisticas.Show();
        }
    }
}
