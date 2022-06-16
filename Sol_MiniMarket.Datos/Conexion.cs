using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Sol_MiniMarket.Datos
{
    public class Conexion
    {
        private string Db;
        private string Servidor;
        private string Usuario;
        private string Clave;
        private bool Seguridad;
        private static Conexion con = null;

        public Conexion()
        {
            this.Db = "BD_MINIMARKET";
            this.Servidor = "DESKTOP-666JEBK\\SQLEXPRESS";
            this.Usuario = "sistemas";
            this.Clave = "root";
            this.Seguridad = false;
        }

        public SqlConnection CrearConexion()
        {
            SqlConnection dbConexion = new SqlConnection();

            try
            {
                dbConexion.ConnectionString = "Server=" + this.Servidor + "; Database=" + this.Db + ";";

                if (this.Seguridad)
                {
                    dbConexion.ConnectionString = dbConexion.ConnectionString + "Integrated Security = SSPI";

                }
                else
                {
                    dbConexion.ConnectionString = dbConexion.ConnectionString + "User Id=" + this.Usuario + ";Password=" + this.Clave;
                }

            }
            catch (Exception ex)
            {
                dbConexion = null;
                throw ex;
            }

            return dbConexion;
        }

        
        public static Conexion getInstancia()
        {
            if (con == null)
            {
                con = new Conexion();
            }

            return con;
        }


    }
}
