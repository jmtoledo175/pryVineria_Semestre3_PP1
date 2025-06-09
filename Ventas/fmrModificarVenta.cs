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
    public partial class fmrModificarVenta : Form
    {
        public fmrModificarVenta()
        {
            InitializeComponent();
        }

        private void fmrModificarVenta_Load(object sender, EventArgs e)
        {
            clsVenta.CargarVendedor(cmbVendedorActual);

            clsVenta.CargarIdVenta(cmbID);
           
            clsVenta.CargarDatoEnComboBox(cmbPago, cmbVendedor, cmbCliente);
        }

        private void cmdModificarProductos_Click(object sender, EventArgs e)
        {
            fmrModificarProductos fmrModificarProductos = new fmrModificarProductos();
            fmrModificarProductos.Show();
        }
        clsVenta clsVenta = new clsVenta();
        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            Int32 id = Convert.ToInt32(cmbVendedorActual.SelectedValue);
            DateTime fecha = dtpFecha.Value;
          
            dgvVentas.Rows.Clear();
            clsVenta.Buscar(id, fecha , dgvVentas);


           
        }

       
        private void cmbID_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void cmdGuardarDatos_Click(object sender, EventArgs e)
        {
            if (cmbVendedor.SelectedIndex != -1 && cmbCliente.SelectedIndex != -1 && cmbPago.SelectedIndex != -1 && txtCantidad.Text != "")
            {
                int IdVenta = Convert.ToInt32(cmbID.SelectedValue);

                Int32 cantidad = Convert.ToInt32(txtCantidad.Text);
                var vendedorSeleccionado = (KeyValuePair<int, string>)cmbVendedor.SelectedItem;
                int idVendedor = vendedorSeleccionado.Key; 
                string nombreVendedor = vendedorSeleccionado.Value; 
                var clienteSeleccionado = (KeyValuePair<int, string>)cmbCliente.SelectedItem;
                int idCliente = clienteSeleccionado.Key; 
                string nombreCliente = clienteSeleccionado.Value;
                string metodo = cmbPago.SelectedItem.ToString();

                clsVenta.ModificarVenta(cantidad, metodo, idVendedor, idCliente, IdVenta);

                cmbVendedor.SelectedIndex = -1;
                cmbPago.SelectedIndex = -1;
                cmbCliente.SelectedIndex = -1;
                txtCantidad.Text = "";
            }
            else
            {
                MessageBox.Show("Completa todos los campos");
            }
        }
    }
    }


