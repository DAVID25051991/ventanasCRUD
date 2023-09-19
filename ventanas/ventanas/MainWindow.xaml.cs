using System.Windows;
using System.Windows.Controls.Primitives;

namespace ventanas
{
    public partial class MainWindow : Window
    {
        Update windowsUpdate;
        delete windowsDelete;
        insertar windowsInsert;
        select windowsSelect;

        public MainWindow()
        {
            InitializeComponent();

            // Inicializa las ventanas secundarias aquí
            windowsUpdate = new Update();
            windowsDelete = new delete();
            windowsInsert = new insertar();
            windowsSelect = new select();
        }

            private void btnEliminar_Click(object sender, RoutedEventArgs e)
            {
                if (windowsDelete == null || !windowsDelete.IsVisible)
                {
                    windowsDelete = new delete();
                    windowsDelete.ShowDialog();
                }
            }

            private void btnUdate_Click(object sender, RoutedEventArgs e)
            {
                if (windowsUpdate == null || !windowsUpdate.IsVisible)
                {
                    windowsUpdate = new Update();
                    windowsUpdate.ShowDialog();
                }
            }

            private void btnselect_Click(object sender, RoutedEventArgs e)
            {
                if (windowsSelect == null || !windowsSelect.IsVisible)
                {
                    windowsSelect = new select();
                    windowsSelect.ShowDialog();
                }
            }

            private void btnSalir_Click(object sender, RoutedEventArgs e)
            {
                this.Close();
            }

            private void btnInsert_Click(object sender, RoutedEventArgs e)
            {
                if (windowsInsert == null || !windowsInsert.IsVisible)
                {
                    windowsInsert = new insertar();
                    windowsInsert.ShowDialog();
                }
            }
        }
    }

