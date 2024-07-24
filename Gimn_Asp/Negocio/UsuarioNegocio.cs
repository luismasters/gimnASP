using Dominio;
using System;
using System.Data.SqlClient;

namespace Negocio
{
    public class UsuarioNegocio
    {
        private AccesoDatos DT;

        public UsuarioNegocio()
        {
            DT = new AccesoDatos();
        }

        public Usuario AutenticarEmpleado(string nombreUsuario, string clave)
        {
            Usuario usuario = null;

            try
            {
                string consulta = @"
                SELECT u.ID, u.NombreUsuario, u.Clave
                FROM Usuarios u
                INNER JOIN Empleados e ON u.ID = e.IDUsuario
                WHERE u.NombreUsuario = @NombreUsuario AND u.Clave = @Clave";

                DT.setearConsulta(consulta);
                DT.agregarParametro("@NombreUsuario", nombreUsuario);
                DT.agregarParametro("@Clave", clave);
                DT.ejecutarLectura();

                if (DT.Lector.Read())
                {
                    usuario = new Usuario
                    {
                        ID = Convert.ToInt32(DT.Lector["ID"]),
                        NombreUsuario = DT.Lector["NombreUsuario"].ToString(),
                        Clave = DT.Lector["Clave"].ToString()
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la autenticación del empleado", ex);
            }
            finally
            {
                DT.cerrarConexion();
            }
            return usuario;
        }

        public Usuario AutenticarMiembro(string nombreUsuario, string clave)
        {
            Usuario usuario = null;

            try
            {
                string consulta = @"
                SELECT u.ID, u.NombreUsuario, u.Clave
                FROM Usuarios u
                INNER JOIN Miembros m ON u.ID = m.IDUsuario
                WHERE u.NombreUsuario = @NombreUsuario AND u.Clave = @Clave";

                DT.setearConsulta(consulta);
                DT.agregarParametro("@NombreUsuario", nombreUsuario);
                DT.agregarParametro("@Clave", clave);
                DT.ejecutarLectura();

                if (DT.Lector.Read())
                {
                    usuario = new Usuario
                    {
                        ID = Convert.ToInt32(DT.Lector["ID"]),
                        NombreUsuario = DT.Lector["NombreUsuario"].ToString(),
                        Clave = DT.Lector["Clave"].ToString()
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la autenticación del miembro", ex);
            }
            finally
            {
                DT.cerrarConexion();
            }
            return usuario;
        }

        public bool AgregarUsuario(Usuario usuario, out string errorMessage)
        {
            errorMessage = string.Empty;

            try
            {
                DT.setearConsulta("INSERT INTO Usuarios (NombreUsuario, Clave) VALUES (@NombreUsuario, @Clave)");
                DT.agregarParametro("@NombreUsuario", usuario.NombreUsuario);
                DT.agregarParametro("@Clave", usuario.Clave);

                return DT.ejecutarAccion();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    errorMessage = "El nombre de usuario ingresado ya está registrado.";
                    return false;
                }
                throw;
            }
            catch (Exception ex)
            {
                errorMessage = "Ocurrió un error al intentar agregar el usuario: " + ex.Message;
                return false;
            }
            finally
            {
                DT.cerrarConexion();
            }
        }

        public Usuario BuscarUsuarioPorNombre(string nombreUsuario)
        {
            Usuario usuario = null;

            try
            {
                string consulta = "SELECT ID, NombreUsuario, Clave FROM Usuarios WHERE NombreUsuario = @NombreUsuario";

                DT.setearConsulta(consulta);
                DT.agregarParametro("@NombreUsuario", nombreUsuario);
                DT.ejecutarLectura();

                if (DT.Lector.Read())
                {
                    usuario = new Usuario
                    {
                        ID = Convert.ToInt32(DT.Lector["ID"]),
                        NombreUsuario = DT.Lector["NombreUsuario"].ToString(),
                        Clave = DT.Lector["Clave"].ToString()
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el usuario por nombre", ex);
            }
            finally
            {
                DT.cerrarConexion();
            }

            return usuario;
        }

        public bool ModificarUsuario(Usuario usuario, out string errorMessage)
        {
            errorMessage = string.Empty;

            try
            {
                DT.setearConsulta("UPDATE Usuarios SET NombreUsuario = @NombreUsuario, Clave = @Clave WHERE ID = @ID");
                DT.agregarParametro("@NombreUsuario", usuario.NombreUsuario);
                DT.agregarParametro("@Clave", usuario.Clave);
                DT.agregarParametro("@ID", usuario.ID);

                return DT.ejecutarAccion();
            }
            catch (Exception ex)
            {
                errorMessage = "Ocurrió un error al intentar modificar el usuario: " + ex.Message;
                return false;
            }
            finally
            {
                DT.cerrarConexion();
            }
        }
    }
}
