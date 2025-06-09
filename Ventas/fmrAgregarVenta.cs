using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryVineriaTPO
{
    public partial class fmrAgregarVenta : Form
    {
        public fmrAgregarVenta()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        clsVenta clsVenta = new clsVenta();
        private void fmrAgregarVenta_Load(object sender, EventArgs e)
        {
            clsVenta.CargarVendedor(cmbVendedor);
            clsVenta.CargarCliente(cmbCliente);
            clsVenta.CargarProducto(cmbProducto);

            txtNumeroCbuTarj.Enabled = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            DataRowView rowView = (DataRowView)cmbProducto.SelectedItem;

            decimal precioUnitario = Convert.ToDecimal(rowView["Precio Unitario"]);
            int cantidad = int.Parse(txtCantidad.Text);
            decimal subtotal = cantidad * precioUnitario;
            dataGridView1.Rows.Add(cmbProducto.Text.ToString(), txtCantidad.Text.ToString(), precioUnitario, subtotal);


        }
        private decimal SumatoriaSubtotal = 0;
        private void btnCalcularTotal_Click(object sender, EventArgs e)
        {
            SumatoriaSubtotal = 0;
            decimal des = nupDescuento.Value;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {

                decimal subtotalVenta = Convert.ToDecimal(row.Cells[3].Value);
                SumatoriaSubtotal += subtotalVenta;
            }
            txtSubtotal.Text = SumatoriaSubtotal.ToString();
            if (des > 0)
            {
                decimal DescuentoAplicable = (SumatoriaSubtotal * des) / 100;

                decimal total = SumatoriaSubtotal - DescuentoAplicable;

                txtTotal.Text = total.ToString();
            }
            else
            {
                txtTotal.Text = SumatoriaSubtotal.ToString();
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int metodo = Convert.ToInt32(cmbMetodo.SelectedIndex);
            if (metodo == 1 || metodo == 2)
            {
                txtNumeroCbuTarj.Enabled = true;
            }
            else
            {
                txtNumeroCbuTarj.Enabled = false;
            }

          

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int VendedorSeleccionado = Convert.ToInt32(cmbVendedor.SelectedValue);
            int ClienteSeleccionado = Convert.ToInt32(cmbCliente.SelectedValue);
            DateTime dateTime = dtpFecha.Value;
            int metodo = Convert.ToInt32(cmbMetodo.SelectedIndex);
            int Totalcantidad = 0;
            string MetodoSeleccionado = null;

            if (cmbMetodo.SelectedItem != null)
            {
                MetodoSeleccionado = cmbMetodo.SelectedItem.ToString();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un método de pago.");
                return;
            }

            bool isValid = true;


            if (dataGridView1.Rows.Count <= 1)
            {
                MessageBox.Show("Por favor, agregue productos a la venta.");
                isValid = false;
            }


            if (metodo == 1 || metodo == 2) 
            {
                if (txtNumeroCbuTarj.TextLength != 16)
                {
                    MessageBox.Show("Debe ingresar los 16 dígitos de la tarjeta.");
                    isValid = false;
                }
            }

            if (isValid)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    Int32 cantidad = Convert.ToInt32(row.Cells["Column2"].Value);
                    Totalcantidad += cantidad;
                }
                clsVenta.Agregar(Totalcantidad, VendedorSeleccionado, dateTime, ClienteSeleccionado, MetodoSeleccionado, SumatoriaSubtotal);
                if (!string.IsNullOrEmpty(txtNumeroCbuTarj.Text))
                {
                    clsVenta.AgregarTarjeta(Convert.ToInt64(txtNumeroCbuTarj.Text));
                }
                MessageBox.Show("Venta agregada");
            }


        }

        private void txtNumeroCbuTarj_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
           dataGridView1.Rows.Clear();
            txtCantidad.Text = "";
            txtNumeroCbuTarj.Text = "";
            txtSubtotal.Text = "";
            txtTotal.Text = "";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
            if (e.ColumnIndex == dataGridView1.Columns["Column5"].Index && e.RowIndex >= 0)
            {
                if (!dataGridView1.Rows[e.RowIndex].IsNewRow)
                {
                    DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar este producto?",
                                                          "Confirmación de eliminación",
                                                          MessageBoxButtons.YesNo,
                                                          MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        dataGridView1.Rows.RemoveAt(e.RowIndex);
                        MessageBox.Show("Producto eliminado");
                    }
                }
            }
            else
            {
                MessageBox.Show("No se puede eliminar una fila vacía.");
            }
        }


    }
}
