using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Drawing.Printing;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;
using System.Reflection;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace pryVineriaTPO
{
    internal class clsVenta
    {
        private OleDbConnection _connection = new OleDbConnection();
        private OleDbCommand _command = new OleDbCommand();
        private OleDbDataAdapter _adapter = new OleDbDataAdapter();

        private string CadenaConexion = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Vineria.mdb ";
        private string Producto = "Producto";
        private string Vendedores = "Vendedores";
        private string Clientes = "Clientes";
        private string Ventas = "Ventas";
        private string TarjetaNum = "TarjetaNumero";
        int idVentaGenerada = 0;
        private string nom;
        private Int32 prec;
        private Int32 cantProd;
        private DateTime Fech;
        private string MedioPag;
        private Int32 Tot;
        private Int32 idVent;
        private Int32 idClient;
        private Int32 Vend;
        public string Nombre
        {
            get { return nom; }
            set { nom = value; }
        }

        public Int32 PrecioUnitario
        {
            get { return prec; }
            set { prec = value; }
        }

        public Int32 IdVenta
        {
            get { return idVent; }
            set { idVent = value; }
        }

        public DateTime Fecha
        {
            get { return Fech; }
            set { Fech = value; }
        }

        public Int32 Cantidad
        {
            get { return cantProd; }
            set { cantProd = value; }
        }
        public Int32 Vendedor
        {
            get { return Vend; }
            set { Vend = value; }
        }

        public string MedioPago
        {
            get { return MedioPag; }
            set { MedioPag = value; }
        }

        public Int32 IdCliente
        {
            get { return idClient; }
            set { idClient = value; }
        }


        public void CargarVendedor(System.Windows.Forms.ComboBox combo)
        {
            try
            {
                _connection.ConnectionString = CadenaConexion;
                _connection.Open();

                _command.Connection = _connection;
                _command.CommandType = CommandType.TableDirect;
                _command.CommandText = Vendedores;


                _adapter = new OleDbDataAdapter(_command);
                DataSet ds = new DataSet();
                _adapter.Fill(ds);

                combo.DataSource = ds.Tables[0];
                combo.ValueMember = "IdVendedor";
                combo.DisplayMember = "Nombre";

                _connection.Close();
            }

            catch (Exception e)
            {

                MessageBox.Show(e.ToString());
                _connection.Close();
            }
        }

        public void CargarCliente(System.Windows.Forms.ComboBox combo)
        {
            try
            {
                _connection.ConnectionString = CadenaConexion;
                _connection.Open();

                _command.Connection = _connection;
                _command.CommandType = CommandType.TableDirect;
                _command.CommandText = Clientes;


                _adapter = new OleDbDataAdapter(_command);
                DataSet ds = new DataSet();
                _adapter.Fill(ds);

                combo.DataSource = ds.Tables[0];
                combo.ValueMember = "IdCliente";
                combo.DisplayMember = "Nombre";

                _connection.Close();
            }
            catch (Exception e)
            {

                MessageBox.Show(e.ToString());
                _connection.Close();
            }
        }
        public void CargarProducto(System.Windows.Forms.ComboBox combo)
        {
            try
            {
                _connection.ConnectionString = CadenaConexion;
                _connection.Open();

                _command.Connection = _connection;
                _command.CommandType = CommandType.TableDirect;
                _command.CommandText = Producto;


                _adapter = new OleDbDataAdapter(_command);
                DataSet ds = new DataSet();
                _adapter.Fill(ds);

                combo.DataSource = ds.Tables[0];
                combo.ValueMember = "IdProducto";
                combo.DisplayMember = "Nombre";



                _connection.Close();
            }
            catch (Exception e)
            {

                MessageBox.Show(e.ToString());
                _connection.Close();
            }
        }

        public void CargarIdVenta(System.Windows.Forms.ComboBox combo)
        {
            try
            {
                _connection.ConnectionString = CadenaConexion;
                _connection.Open();

                _command.Connection = _connection;
                _command.CommandType = CommandType.TableDirect;
                _command.CommandText = Ventas;


                _adapter = new OleDbDataAdapter(_command);
                DataSet ds = new DataSet();
                _adapter.Fill(ds);

                combo.DataSource = ds.Tables[0];
                combo.ValueMember = "IdVentas";
                combo.DisplayMember = "IdVentas";



                _connection.Close();
            }
            catch (Exception e)
            {

                MessageBox.Show(e.ToString());
                _connection.Close();
            }
        }


        public void Agregar(Int32 Cantidad, Int32 Vendedor, DateTime fecha, Int32 Cliente, string medio, decimal total)
        {

            try
            {
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
                _connection.ConnectionString = CadenaConexion;
                _connection.Open();

                _command.Connection = _connection;
                _command.CommandType = CommandType.TableDirect;
                _command.CommandText = Ventas;


                _adapter = new OleDbDataAdapter(_command);
                DataSet ds = new DataSet();
                _adapter.Fill(ds, Ventas);
                DataTable tabla = ds.Tables["Ventas"];

                DataRow fila = tabla.NewRow();


                fila["CantidadDeProductos"] = Cantidad;
                fila["IdVendedor"] = Vendedor;
                fila["Fecha"] = fecha;
                fila["IdCliente"] = Cliente;
                fila["MedioDePago"] = medio;
                fila["Total"] = total;

                tabla.Rows.Add(fila);
                OleDbCommandBuilder oleDbCommandBuilder = new OleDbCommandBuilder(_adapter);
                _adapter.Update(ds, Ventas);
                ds.Clear();
                _adapter.Fill(ds, Ventas);

                DataRow[] filas = tabla.Select("", "IdVentas DESC");
                if (filas.Length > 0)
                {
                    idVentaGenerada = Convert.ToInt32(filas[0]["IdVentas"]);
                }


                _connection.Close();


            }
            catch (Exception e)
            {

                MessageBox.Show(e.ToString());
                MessageBox.Show(idVentaGenerada.ToString());
                _connection.Close();

            }

        }

        public void AgregarTarjeta(Int64 Tarjeta)
        {

            try
            {

                _connection.ConnectionString = CadenaConexion;
                _connection.Open();

                _command.Connection = _connection;
                _command.CommandType = CommandType.TableDirect;
                _command.CommandText = TarjetaNum;


                _adapter = new OleDbDataAdapter(_command);
                DataSet ds = new DataSet();
                _adapter.Fill(ds, TarjetaNum);

                DataTable tabla = ds.Tables[TarjetaNum];
                DataRow fila = tabla.NewRow();

                fila["idVentas"] = idVentaGenerada;
                fila["Numero"] = Tarjeta;


                tabla.Rows.Add(fila);
                OleDbCommandBuilder oleDbCommandBuilder = new OleDbCommandBuilder(_adapter);
                _adapter.Update(ds, TarjetaNum);



                _connection.Close();


            }
            catch (Exception e)
            {

                MessageBox.Show(e.ToString());
            }
        }


        public void Buscar(Int32 idvendedor, DateTime fecha, DataGridView dgvVentas)
        {
            try
            {
                _connection.ConnectionString = CadenaConexion;
                _connection.Open();

                _command.Connection = _connection;
                _command.CommandType = CommandType.TableDirect;
                _command.CommandText = Ventas;

                OleDbDataReader oleDbDataReader = _command.ExecuteReader();

                if (oleDbDataReader != null)
                {
                    bool ventasEncontradas = false;
                    dgvVentas.Rows.Clear();
                    while (oleDbDataReader.Read())
                    {
                        int ventaId = oleDbDataReader.GetInt32(0);
                        int vendedorId = oleDbDataReader.GetInt32(2);
                        DateTime ventaFecha = oleDbDataReader.GetDateTime(3);
                        int cantidad = oleDbDataReader.GetInt32(1);


                        if (vendedorId == idvendedor && ventaFecha.Date == fecha.Date)
                        {
                            dgvVentas.Rows.Add(ventaId, ventaFecha, cantidad, vendedorId);
                            ventasEncontradas = true;
                        }


                    }
                    if (!ventasEncontradas)
                    {
                        MessageBox.Show("No se encontraron ventas registradas.");

                    }
                }
                _connection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public void Buscar(DateTime fecha, DataGridView dgvVentas)
        {
            try
            {
                _connection.ConnectionString = CadenaConexion;
                _connection.Open();

                _command.Connection = _connection;
                _command.CommandType = CommandType.TableDirect;
                _command.CommandText = Ventas;

                OleDbDataReader oleDbDataReader = _command.ExecuteReader();

                if (oleDbDataReader != null)
                {
                    bool ventasEncontradas = false;
                    dgvVentas.Rows.Clear();
                    while (oleDbDataReader.Read())
                    {
                        int ventaId = oleDbDataReader.GetInt32(0);
                        int vendedorId = oleDbDataReader.GetInt32(2);
                        DateTime ventaFecha = oleDbDataReader.GetDateTime(3);
                        int cantidad = oleDbDataReader.GetInt32(1);


                        if (ventaFecha.Date == fecha.Date)
                        {
                            dgvVentas.Rows.Add(ventaId, ventaFecha, cantidad, vendedorId);
                            ventasEncontradas = true;
                        }



                    }
                    if (!ventasEncontradas)
                    {
                        MessageBox.Show("No se encontraron ventas registradas.");

                    }
                }
                _connection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public void CargarDatosVentas(Int32 idVenta)
        {
            try
            {
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }

                _connection.ConnectionString = CadenaConexion;
                _connection.Open();

                string sql = "SELECT CantidadDeProductos, IdVendedor, IdCliente, MedioDePago FROM Ventas WHERE IdVentas = ?";
                OleDbCommand command = new OleDbCommand(sql, _connection);
                command.Parameters.AddWithValue("@IdVentas", idVenta);
                OleDbDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Cantidad = Convert.ToInt32(reader["CantidadDeProductos"]);
                    MedioPago = reader["MedioDePago"].ToString();
                    int idVendedor = Convert.ToInt32(reader["IdVendedor"]);
                    int idCliente = Convert.ToInt32(reader["IdCliente"]);
                }

                reader.Close();
                _connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos del cliente: " + ex.Message);
            }
        }

        public void CargarDatoEnComboBox(System.Windows.Forms.ComboBox cmbPago, System.Windows.Forms.ComboBox cmbVendedor, System.Windows.Forms.ComboBox cmbCliente)
        {
            try
            {
                _connection.ConnectionString = CadenaConexion;
                _connection.Open();


                string sqlMedioPago = "SELECT DISTINCT MedioDePago FROM Ventas";
                OleDbCommand commandMedioPago = new OleDbCommand(sqlMedioPago, _connection);
                OleDbDataReader readerMedioPago = commandMedioPago.ExecuteReader();
                if (readerMedioPago.HasRows)
                {
                    cmbPago.Items.Clear();

                    while (readerMedioPago.Read())
                    {
                        string medioPago = readerMedioPago["MedioDePago"].ToString();
                        cmbPago.Items.Add(medioPago);
                    }

                }
                readerMedioPago.Close();




                string sqlVendedor = "SELECT IdVendedor, Nombre FROM Vendedores";
                OleDbCommand commandVendedor = new OleDbCommand(sqlVendedor, _connection);
                OleDbDataReader readerVendedor = commandVendedor.ExecuteReader();

                if (readerVendedor.HasRows)
                {
                    cmbVendedor.Items.Clear();
                    while (readerVendedor.Read())
                    {
                        int idVendedor = Convert.ToInt32(readerVendedor["IdVendedor"]);
                        string nombreVendedor = readerVendedor["Nombre"].ToString();
                        cmbVendedor.Items.Add(new KeyValuePair<int, string>(idVendedor, nombreVendedor));
                    }
                }
                readerVendedor.Close();





                string sqlCliente = "SELECT IdCliente, Nombre FROM Clientes";
                OleDbCommand commandCliente = new OleDbCommand(sqlCliente, _connection);
                OleDbDataReader readerCliente = commandCliente.ExecuteReader();

                if (readerCliente.HasRows)
                {
                    cmbCliente.Items.Clear();
                    while (readerCliente.Read())
                    {
                        int idCliente = Convert.ToInt32(readerCliente["IdCliente"]);
                        string nombreCliente = readerCliente["Nombre"].ToString();
                        cmbCliente.Items.Add(new KeyValuePair<int, string>(idCliente, nombreCliente));
                    }
                }
                readerCliente.Close();


                _connection.Close();
            }
            catch (Exception e)
            {

                MessageBox.Show(e.ToString());
                _connection.Close();
            }

        }

        public void ModificarVenta(int cantidad, string metodo, int vendedor, int cliente, int idVenta)
        {
            try
            {
                string sql = "UPDATE Ventas SET CantidadDeProductos = ?, MedioDePago = ?, IdVendedor = ?, IdCliente = ? WHERE IdVentas = ?";

                _connection.ConnectionString = CadenaConexion;
                _connection.Open();

                OleDbCommand command = new OleDbCommand(sql, _connection);
                command.Parameters.AddWithValue("@CantidadDeProductos", cantidad);
                command.Parameters.AddWithValue("@MedioDePago", metodo);
                command.Parameters.AddWithValue("@IdVendedor", vendedor);
                command.Parameters.AddWithValue("@IdCliente", cliente);
                command.Parameters.AddWithValue("@IdVentas", idVenta);

                command.ExecuteNonQuery();
                _connection.Close();

                MessageBox.Show("Venta Modificado");

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                _connection.Close();
            }

        }

        public void Imprimir(PrintPageEventArgs reporte)
        {

            try
            {
                Font Titulo1 = new Font("Calibri", 20, FontStyle.Bold);
                Font Titulo2 = new Font("Calibri", 10, FontStyle.Bold);
                Font tipoLetra = new Font("Calibri", 8);


                Int32 linea = 200;
                Int32 columna1 = 100;
                Int32 columna2 = 250;
                Int32 columna3 = 400;
                Int32 columna4 = 550;


                reporte.Graphics.DrawString("Listado de ventas", Titulo1, Brushes.Red, 100, 100);
                reporte.Graphics.DrawString("Código", Titulo2, Brushes.DarkBlue, columna1, 150);
                reporte.Graphics.DrawString("Fecha", Titulo2, Brushes.DarkBlue, columna2, 150);
                reporte.Graphics.DrawString("Medio de Pago", Titulo2, Brushes.DarkBlue, columna3, 150);
                reporte.Graphics.DrawString("Total", Titulo2, Brushes.DarkBlue, columna4, 150);


                _connection.ConnectionString = CadenaConexion;
                _connection.Open();

                _command.Connection = _connection;
                _command.CommandType = CommandType.TableDirect;
                _command.CommandText = "Ventas";
                _adapter = new OleDbDataAdapter(_command);

                DataSet ds = new DataSet();
                _adapter.Fill(ds, "Ventas");


                if (ds.Tables["Ventas"].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables["Ventas"].Rows)
                    {

                        reporte.Graphics.DrawString(row["IdVentas"].ToString(), tipoLetra, Brushes.Black, columna1, linea);
                        reporte.Graphics.DrawString(Convert.ToDateTime(row["Fecha"]).ToString("dd/MM/yyyy"), tipoLetra, Brushes.Black, columna2, linea);
                        reporte.Graphics.DrawString(row["MedioDePago"].ToString(), tipoLetra, Brushes.Black, columna3, linea);
                        reporte.Graphics.DrawString(row["Total"].ToString(), tipoLetra, Brushes.Black, columna4, linea);


                        linea += 15;
                    }
                }

                _connection.Close();

            }
            catch (Exception e)
            {

                MessageBox.Show(e.ToString());
            }
        }

        public void Mostrar(Chart Gra)
        {
            _connection.ConnectionString = CadenaConexion;
            _connection.Open();

            string sql = "SELECT FORMAT(Fecha, 'yyyy-mm') AS Mes, SUM(Total) AS TotalPorMes " +
                   "FROM Ventas " +
                   "GROUP BY FORMAT(Fecha, 'yyyy-mm') " +
                   "ORDER BY FORMAT(Fecha, 'yyyy-mm')";

            _command.Connection = _connection;
            _command.CommandType = CommandType.Text;
            _command.CommandText = sql;
            _adapter = new OleDbDataAdapter(_command);
            DataTable dt = new DataTable();
            _adapter.Fill(dt);

            Gra.Series.Clear();

            var series = new Series("Datos")
            {
                ChartType = SeriesChartType.Column
            };


            foreach (DataRow row in dt.Rows)
            {

                series.Points.AddXY(row["Mes"].ToString(), Convert.ToDouble(row["TotalPorMes"]));
            }

            Gra.Series.Add(series);
            Gra.ChartAreas[0].AxisX.Title = "Mes";
            Gra.ChartAreas[0].AxisY.Title = "Total de ventas";
            _connection.Close();
        }


      

    }

}

