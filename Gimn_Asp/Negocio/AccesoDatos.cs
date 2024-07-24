using System;
using System.Data.SqlClient;

namespace Negocio
{
    public class AccesoDatos
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        public SqlDataReader Lector
        {
            get { return lector; }
        }

        public AccesoDatos()
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
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar la acción", ex);
            }
            finally
            {
                conexion.Close();
                comando.Parameters.Clear();
            }
        }

        public object ejecutarEscalar()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                return comando.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar el escalar", ex);
            }
            finally
            {
                conexion.Close();
                comando.Parameters.Clear();
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
        public int ejecutarAccionReturn()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                // Ejecuta la consulta y obtiene el ID insertado
                object resultado = comando.ExecuteScalar();
                if (resultado != null && int.TryParse(resultado.ToString(), out int id))
                {
                    return id;
                }
                return 0; // o manejar el caso donde no se obtiene un ID válido
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar la acción y obtener el ID", ex);
            }
            finally
            {
                conexion.Close();
                comando.Parameters.Clear();
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
    }
}
