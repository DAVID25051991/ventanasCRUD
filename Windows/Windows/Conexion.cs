using MySql.Data.MySqlClient;

namespace Windows
{
    internal class Conexion
    {
        private MySqlConnection conexion;
        private string server = "localhost"; // Dirección del servidor de la base de datos (en este caso local).
        private string database = "inventario"; // Nombre de la base de datos a la que se conectará.
        private string user = "root"; // Nombre de usuario de la base de datos.
        private string password = ""; // Contraseña de la base de datos (en este caso, parece estar vacía).
        private string cadenaConexion; // Cadena de conexión que se utilizará para conectarse a la base de datos.

        public Conexion()
        {
            // En el constructor de la clase, se construye la cadena de conexión utilizando los valores definidos anteriormente.
            cadenaConexion = "Server=" + server +
                "; Database=" + database +
                "; User=" + user +
                "; Password=" + password;
        }

        public MySqlConnection GetConexion()
        {
            if (conexion == null)
            {
                conexion = new MySqlConnection(cadenaConexion);
                conexion.Open();
            }
            return conexion;
        }
    }
}
