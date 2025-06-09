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
    public partial class fmrEliminarVenta : Form
    {
        public fmrEliminarVenta()
        {
            InitializeComponent();
        }

        private void cmdModificar_Click(object sender, EventArgs e)
        {
            fmrModificarVenta fmrModificarVenta = new fmrModificarVenta();
            fmrModificarVenta.Show();
        }

        clsVenta clsVenta = new clsVenta();
        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            Int32 id = Convert.ToInt32(cmbVendedor.SelectedValue);
            DateTime fecha = dtpFecha.Value;

            dgvVentas.Rows.Clear();
            clsVenta.Buscar(id, fecha, dgvVentas);

        }

        private void fmrEliminarVenta_Load(object sender, EventArgs e)
        {
            clsVenta.CargarVendedor(cmbVendedor);
        }

        private void dgvVentas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvVentas.Columns["Eliminar"].Index && e.RowIndex >= 0)
            {
                if (!dgvVentas.Rows[e.RowIndex].IsNewRow)
                {
                    DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar esta venta?",
                                                          "Confirmación de eliminación",
                                                          MessageBoxButtons.YesNo,
                                                          MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        dgvVentas.Rows.RemoveAt(e.RowIndex);
                        MessageBox.Show("Venta eliminada");
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
