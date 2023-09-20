using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ventanas
{

    internal class consultas
    {
        conexion mConexion;


        public consultas()
        {
            mConexion = new conexion();

        }

        public void insertars(int precio, int stock, string proveedor)
        {
            MySqlConnection conexion = mConexion.getConexion();

            string consulta = "INSERT INTO inven (precio, stock, proveedor) VALUE( @precio, @stock, @proveedor )";
            if (mConexion.getConexion() != null)
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
            MySqlConnection conexion = mConexion.getConexion();

            string consulta = "UPDATE inven SET id_Inventario = id_Inventario, precio = @precio, stock = @stock, proveedor = @proveedor";
            if (mConexion.getConexion() != null)
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


        public void selecion(string proveedors)
        {
            MySqlConnection conexion = mConexion.getConexion();
            MySqlDataReader mySqlDataReader = null;
            string consulta = "Select id_Inventario, precio , stock, proveedor FROM inven WHERE @proveedor";
            if (mConexion.getConexion() != null)
            {
                using (MySqlCommand command = new MySqlCommand(consulta, conexion))
                {
                    command.Parameters.AddWithValue("@proveedor", proveedors);

                    int filasAfectadas = command.ExecuteNonQuery();
                }
                List<string> proveedor = new List<string>();

                MySqlCommand mySqlCommand = new MySqlCommand(consulta);
                mySqlCommand.Connection = mConexion.getConexion();

            }
            else
            {
                return;
            }
        }



        public void Deletes(int id)
        {
            using (MySqlConnection conexion = mConexion.getConexion())
            {
                if (conexion != null)
                {
                    string consulta = $"DELETE FROM inven WHERE `id_Inventario` = @id";

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
    }
}
