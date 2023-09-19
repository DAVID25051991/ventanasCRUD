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
        Window mWindow;

        public consultas()
        {
            mConexion = new conexion();
            mWindow = new Window();
        }
    }
}
