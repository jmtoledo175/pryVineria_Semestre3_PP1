using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms;
using System.IO;

namespace pryVineriaTPO
{
    internal class clsVendedores
    {
        private OleDbConnection _connection = new OleDbConnection();
        private OleDbCommand _command = new OleDbCommand();
        private OleDbDataAdapter _adapter = new OleDbDataAdapter();

        private string CadenaConexion = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Vineria.mdb ";
        private string Vendedores = "Vendedores";



        private string nom;
        private Int32 dni;
        private Int32 edad;
        private string direc;
        private Int64 tel;
        private string mail;

        public string Nombre
        {
            get { return nom; }
            set { nom = value; }
        }

        public Int32 Dni
        {
            get { return dni; }
            set { dni = value; }
        }

        public Int32 Edad
        {
            get { return edad; }
            set { edad = value; }
        }

        public string Direccion
        {
            get { return direc; }
            set { direc = value; }
        }

        public Int64 Telefono
        {
            get { return tel; }
            set { tel = value; }
        }

        public string Email
        {
            get { return mail; }
            set { mail = value; }
        }


        public void Agregar()
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
                _adapter.Fill(ds, Vendedores);

                DataTable tabla = ds.Tables[Vendedores];
                DataRow fila = tabla.NewRow();

                fila["Nombre"] = nom;
                fila["Dni"] = dni;
                fila["Edad"] = edad;
                fila["Direccion"] = direc;
                fila["Telefono"] = tel;
                fila["Email"] = mail;

                tabla.Rows.Add(fila);
                OleDbCommandBuilder oleDbCommandBuilder = new OleDbCommandBuilder(_adapter);
                _adapter.Update(ds, Vendedores);

                _connection.Close();


            }
            catch (Exception e)
            {

                MessageBox.Show(e.ToString());
            }
        }


        public void CargarVendedores(System.Windows.Forms.ComboBox combo)
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

        public void CargarDatosVendedor(int idVendedor, System.Windows.Forms.TextBox txtNombre, System.Windows.Forms.TextBox txtDni, System.Windows.Forms.TextBox txtEdad, System.Windows.Forms.TextBox txtDireccion, System.Windows.Forms.TextBox txtTelefono, System.Windows.Forms.TextBox txtEmail)
        {
            try
            {
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }

                _connection.ConnectionString = CadenaConexion;
                _connection.Open();

                string sql = "SELECT Nombre, Dni, Edad, Direccion, Telefono, Email FROM Vendedores WHERE Dni = ?";
                OleDbCommand command = new OleDbCommand(sql, _connection);
                command.Parameters.AddWithValue("@Dni", idVendedor);

                OleDbDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    txtNombre.Text = reader["Nombre"].ToString();
                    txtDni.Text = reader["Dni"].ToString();
                    txtEdad.Text = reader["Edad"].ToString();
                    txtDireccion.Text = reader["Direccion"].ToString();
                    txtTelefono.Text = reader["Telefono"].ToString();
                    txtEmail.Text = reader["Email"].ToString();
                }

                reader.Close();
                _connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos del vendedor: " + ex.Message);
            }
        }

        public void ModificarVendedor(int idVendedor, string nombre, int dni, int edad, string direccion, string telefono, string email)
        {
            try
            {
                string sql = "UPDATE Vendedores SET Nombre = ?, Edad = ?, Direccion = ?, Telefono = ?, Email = ?, Dni = ? WHERE IdVendedor = ?";

                _connection.ConnectionString = CadenaConexion;
                _connection.Open();

                OleDbCommand command = new OleDbCommand(sql, _connection);
                command.Parameters.AddWithValue("@Nombre", nombre); 
                command.Parameters.AddWithValue("@Edad", edad);
                command.Parameters.AddWithValue("@Direccion", direccion);
                command.Parameters.AddWithValue("@Telefono", telefono);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Dni", dni);
                command.Parameters.AddWithValue("@IdVendedor", idVendedor);

                command.ExecuteNonQuery();
                _connection.Close();

                MessageBox.Show("Vendedor Modificado");

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

        }

        public void CargarCombo(System.Windows.Forms.ComboBox combo)
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

        public void Quitar(System.Windows.Forms.ComboBox combo)
        {
            try
            {
                _connection.ConnectionString = CadenaConexion;
                _connection.Open();
                string sql = "DELETE FROM Vendedores WHERE IdVendedor = ?";
                OleDbCommand _command = new OleDbCommand(sql, _connection);
                
                _command.Parameters.AddWithValue("@IdVendedor", combo.SelectedValue);


                        int rowsAffected = _command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Vendedor eliminado correctamente.");
                        }
                        else
                        {
                            MessageBox.Show("No se encontró el vendedor.");
                        }
                _connection.Close();
                combo.DataSource = null;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el Vendedor: " + ex.Message);
            }


        }


        public void Buscar(Int32 dniText)
        {
            try
            {
                _connection.ConnectionString = CadenaConexion;
                _connection.Open();

                _command.Connection = _connection;
                _command.CommandType = CommandType.TableDirect;
                _command.CommandText = Vendedores;

                OleDbDataReader oleDbDataReader = _command.ExecuteReader();

                if (oleDbDataReader != null)
                {
                    while (oleDbDataReader.Read())
                    {

                        if (oleDbDataReader.GetInt32(2) == dniText)
                        {

                            Nombre = oleDbDataReader.GetString(1);
                            Dni = oleDbDataReader.GetInt32(2);
                            Edad = oleDbDataReader.GetInt32(3);
                            Direccion = oleDbDataReader.GetString(4);
                            Telefono = Convert.ToInt64(oleDbDataReader.GetValue(5));
                            Email = oleDbDataReader.GetString(6);
                        }
                    }
                }
                _connection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }


       
    }
}
