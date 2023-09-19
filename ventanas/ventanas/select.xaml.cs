using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ventanas
{
    public partial class select : Window
    {
        private conexion mConexion;
        public select()
        {
            InitializeComponent();
            mConexion = new conexion();
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void btnSelect_Click_1(object sender, RoutedEventArgs e)
        {
            string proveedor = txboxProveedor.Text;

            using (MySqlConnection conexion = mConexion.getConexion())
            {
                if (conexion != null)
                {
                    string consulta = "SELECT id_Inventario, precio, Stock, proveedor FROM inventario WHERE proveedor = @proveedor";

                    using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@proveedor", proveedor);

                        try
                        {
                            conexion.Open();
                            MySqlDataReader reader = comando.ExecuteReader();

                            List<string> resultados = new List<string>(); // Lista para almacenar los resultados

                            // Procesar los resultados y agregarlos a la lista
                            while (reader.Read())
                            {
                                int idResultado = reader.GetInt32(0); // id_Inventario
                                decimal precioResultado = reader.GetDecimal(1); // precio
                                int stockResultado = reader.GetInt32(2); // Stock
                                string proveedorResultado = reader.GetString(3); // proveedor

                                string resultado = $"ID: {idResultado}, Precio: {precioResultado}, Stock: {stockResultado}, Proveedor: {proveedorResultado}";
                                resultados.Add(resultado);
                            }

                            reader.Close(); // Cerrar el lector de resultados

                            // Mostrar los resultados en un mensaje
                            if (resultados.Count > 0)
                            {
                                string mensaje = string.Join(Environment.NewLine, resultados);
                                MessageBox.Show("Resultados:\n" + mensaje);
                            }
                            else
                            {
                                MessageBox.Show("No se encontraron resultados para el proveedor especificado.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al ejecutar la consulta: " + ex.Message);
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



