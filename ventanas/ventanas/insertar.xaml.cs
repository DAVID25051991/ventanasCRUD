using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ventanas
{
    /// <summary>
    /// Lógica de interacción para insertar.xaml
    /// </summary>
    public partial class insertar : Window
    {
        private conexion mConexion;
        public insertar()
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

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(txboxIDInventario.Text);
            int precio = int.Parse(txboxPrecio.Text);
            int Stock = int.Parse(txboxStock.Text);
            string proveedor = txboxProveedor.Text;


            using (MySqlConnection conexion = mConexion.getConexion())
            {
                if (conexion != null)
                {
                    string consulta = "INSERT INTO inventario (id_Inventario, precio, Stock, proveedor) " +
                  "VALUES (@id, @precio, @stock, @proveedor)";

                    using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@id", id);
                        comando.Parameters.AddWithValue("@precio", precio);
                        comando.Parameters.AddWithValue("@Stock", Stock);
                        comando.Parameters.AddWithValue("@proveedor", proveedor);

                        int filasAfectadas = comando.ExecuteNonQuery();
                        if (filasAfectadas > 0)
                        {
                            borrar("Usuario agregado");
                        }
                        else
                        {
                            MessageBox.Show("No se pudo agregar el usuario");
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
