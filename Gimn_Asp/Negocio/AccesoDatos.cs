using System;
using System.Data.SqlClient;

namespace Negocio
{
    public class AccesoDatos
    {
        private SqlConnection conexion; // para conectarse a la base de datos
        private SqlCommand comando; // para ejecutar comandos SQL
        private SqlDataReader lector; // para leer datos de la base de datos

        public SqlDataReader Lector // propiedad para devolver el lector
        {
            get { return lector; }
        }

        public AccesoDatos() // constructor
        {
            conexion = new SqlConnection("server=.\\SQLEXPRESS; database=Gimnasio2; integrated security=true");
            comando = new SqlCommand();
        }

        public void setearConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        public void agregarParametro(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }

        public bool ejecutarAccion()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                return true; // La operación fue exitosa
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar la acción", ex);
            }
            finally
            {
                conexion.Close();
                comando.Parameters.Clear(); // Limpiar los parámetros después de ejecutar la acción
            }
        }

        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar la lectura", ex);
            }
        }

        public void cerrarConexion()
        {
            if (lector != null && !lector.IsClosed)
                lector.Close();
            if (conexion.State == System.Data.ConnectionState.Open)
                conexion.Close();
        }

        public void limpiarParametros()
        {
            comando.Parameters.Clear();
        }

        public int ejecutarAccionReturn()
        {
            try
            {
                comando.Connection = conexion;
                conexion.Open();
                return (int)comando.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar la acción y retornar el valor", ex);
            }
            finally
            {
                conexion.Close();
                comando.Parameters.Clear(); // Limpiar los parámetros después de ejecutar la acción
            }
        }
      

    }
}
