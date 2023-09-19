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
    /// Lógica de interacción para delete.xaml
    /// </summary>
    public partial class delete : Window
    {
        private conexion mConexion;
        public delete()
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

        private void btndelete_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(txboxIDInventario.Text);

            using (MySqlConnection conexion = mConexion.getConexion())
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
                            borrar("Registro eliminado");
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

        private void btndelete_Click(object sender, object e)
        {

        }
    }
}
    

