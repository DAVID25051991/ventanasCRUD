using MySql.Data.MySqlClient;
using System;
using System.Windows;
using System.Windows.Controls;

namespace ventanas
{
    /// <summary>
    /// Lógica de interacción para Update.xaml
    /// </summary>
    public partial class Update : Window
    {
        private conexion mConexion;

        public Update()
        {
            InitializeComponent();
            mConexion = new conexion();
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void borrar(string valor)
        {
            txboxIDInventario.Text = "";
            txboxPrecio.Text = "";
            txboxProveedor.Text = "";
            txboxStock.Text = "";
            MessageBox.Show(valor);
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(txboxIDInventario.Text);
            int precio = int.Parse(txboxPrecio.Text);
            int stock = int.Parse(txboxStock.Text);
            string proveedor = txboxProveedor.Text;


            using (MySqlConnection conexion = mConexion.getConexion())
            {
                if (conexion != null)
                {
                    string consulta = "UPDATE inventario SET precio = @precio, Stock = @stock, proveedor=@proveedor WHERE `inventario`.`id_Inventario` = @id";

                    using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@id", id);
                        comando.Parameters.AddWithValue("@precio", precio);
                        comando.Parameters.AddWithValue("@stock", stock);
                        comando.Parameters.AddWithValue("@proveedor", proveedor);


                        int filasAfectadas = comando.ExecuteNonQuery();
                        if (filasAfectadas > 0)
                        {
                            borrar("Datos Actualizados");
                        }
                        else
                        {
                            MessageBox.Show("No se pudo actualizar los datos");
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
