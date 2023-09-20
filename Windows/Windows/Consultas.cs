using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Windows
{
    internal class Consultas
    {
        Conexion mconexion;
        public Consultas()
        {
            mconexion = new Conexion();
        }
        public void insertars(int precio, int stock, string proveedor)
        {
            MySqlConnection conexion = mconexion.GetConexion();

            string consulta = "INSERT INTO inventario (precio, stock, proveedor) VALUE( @precio, @stock, @proveedor )";
            if (mconexion.GetConexion() != null)
            {
                using (MySqlCommand command = new MySqlCommand(consulta, conexion))
                {
                    command.Parameters.AddWithValue("@precio", precio);
                    command.Parameters.AddWithValue("@stock", stock);
                    command.Parameters.AddWithValue("@proveedor", proveedor);

                    int filasAfectadas = command.ExecuteNonQuery();
                }
            }
            else
            {
                return;
            }
        }


        public void updates(int id_invent, int precio, int stock, string proveedor)
        {
            MySqlConnection conexion = mconexion.GetConexion();

            string consulta = "UPDATE inventario SET id_Inventario = id_Inventario, precio = @precio, stock = @stock, proveedor = @proveedor";
            if (mconexion.GetConexion() != null)
            {
                using (MySqlCommand command = new MySqlCommand(consulta, conexion))
                {
                    command.Parameters.AddWithValue("@id_Inventario", id_invent);
                    command.Parameters.AddWithValue("@precio", precio);
                    command.Parameters.AddWithValue("@stock", stock);
                    command.Parameters.AddWithValue("@proveedor", proveedor);

                    int filasAfectadas = command.ExecuteNonQuery();
                }
            }
            else
            {
                return;
            }
        }



        public void Deletes(int id)
        {
            using (MySqlConnection conexion = mconexion.GetConexion())
            {
                if (conexion != null)
                {
                    string consulta = $"DELETE FROM inventario WHERE `id_Inventario` = @id";

                    using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@id", id);

                        int filasAfectadas = comando.ExecuteNonQuery();
                        if (filasAfectadas > 0)
                        {
                            MessageBox.Show("Hola");
                        }
                        else
                        {
                            MessageBox.Show("No se pudo eliminar el registro");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Error al conectar a la base de datos");
                }
            }
        }







        public List<string> Select(string proveedor)
        {
            List<string> resultados = new List<string>();

            try
            {
                using (MySqlConnection conexion = mconexion.GetConexion())
                {
                    if (conexion != null)
                    {
                        if (conexion.State == ConnectionState.Closed) // Verifica si la conexión está cerrada
                        {
                            conexion.Open(); // Abre la conexión si está cerrada

                            string consulta = "SELECT id_Inventario, precio, stock, proveedor FROM inventario WHERE proveedor = @proveedor";

                            using (MySqlCommand command = new MySqlCommand(consulta, conexion))
                            {
                                command.Parameters.AddWithValue("@proveedor", proveedor);

                                using (MySqlDataReader reader = command.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        int idResultado = reader.GetInt32(0);
                                        decimal precioResultado = reader.GetDecimal(1);
                                        int stockResultado = reader.GetInt32(2);
                                        string proveedorResultado = reader.GetString(3);

                                        string resultado = $"ID: {idResultado}, Precio: {precioResultado}, Stock: {stockResultado}, Proveedor: {proveedorResultado}";
                                        resultados.Add(resultado);
                                    }
                                }

                                if (resultados.Count == 0)
                                {
                                    resultados.Add("No se encontraron resultados para el proveedor especificado.");
                                }
                            }
                        }
                        else
                        {
                            resultados.Add("La conexión ya está abierta.");
                        }
                    }
                    else
                    {
                        resultados.Add("Error al conectar a la base de datos.");
                    }
                }
            }
            catch (Exception ex)
            {
                resultados.Add("Error: " + ex.Message);
            }

            return resultados;
        }
    }
}


