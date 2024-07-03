using Dominio;
using System;
using System.Collections.Generic;
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

        public List<Usuario> ListarUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                DT.setearConsulta("SELECT ID, IDPersona, IDRol, NombreUsuario, Clave FROM Usuarios");
                DT.ejecutarLectura();
                while (DT.Lector.Read())
                {
                    Usuario usuario = new Usuario
                    {
                        ID = Convert.ToInt32(DT.Lector["ID"]),
                        IDPersona = Convert.ToInt32(DT.Lector["IDPersona"]),
                        IDRol = Convert.ToInt32(DT.Lector["IDRol"]),
                        NombreUsuario = DT.Lector["NombreUsuario"].ToString(),
                        Clave = DT.Lector["Clave"].ToString()
                    };
                    usuarios.Add(usuario);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DT.cerrarConexion();
            }
            return usuarios;
        }

        public Usuario AutenticarUsuario(string nombreUsuario, string clave)
        {
            Usuario usuario = null;
            try
            {
                DT.setearConsulta("SELECT ID, IDPersona, IDRol, NombreUsuario, Clave FROM Usuarios WHERE NombreUsuario = @NombreUsuario AND Clave = @Clave");
                DT.agregarParametro("@NombreUsuario", nombreUsuario);
                DT.agregarParametro("@Clave", clave);
                DT.ejecutarLectura();

                if (DT.Lector.Read())
                {
                    usuario = new Usuario
                    {
                        ID = Convert.ToInt32(DT.Lector["ID"]),
                        IDPersona = Convert.ToInt32(DT.Lector["IDPersona"]),
                        IDRol = Convert.ToInt32(DT.Lector["IDRol"]),
                        NombreUsuario = DT.Lector["NombreUsuario"].ToString(),
                        Clave = DT.Lector["Clave"].ToString()
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
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
                DT.setearConsulta("INSERT INTO Usuarios (IDPersona, IDRol, NombreUsuario, Clave) VALUES (@IDPersona, @IDRol, @NombreUsuario, @Clave)");
                DT.agregarParametro("@IDPersona", usuario.IDPersona);
                DT.agregarParametro("@IDRol", usuario.IDRol);
                DT.agregarParametro("@NombreUsuario", usuario.NombreUsuario);
                DT.agregarParametro("@Clave", usuario.Clave);

                return DT.ejecutarAccion();
            }
            catch (SqlException ex)
            {
                // Error number for unique constraint violation
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    errorMessage = "El nombre de usuario ingresado ya está registrado.";
                    return false;
                }
                // Propagate other SQL exceptions
                throw;
            }
            catch (Exception ex)
            {
                // Manejo de otras excepciones
                errorMessage = "Ocurrió un error al intentar agregar el usuario: " + ex.Message;
                return false;
            }
            finally
            {
                DT.cerrarConexion();
            }
        }

        public bool ModificarUsuario(Usuario usuario, out string errorMessage)
        {
            errorMessage = string.Empty;

            try
            {
                DT.setearConsulta("UPDATE Usuarios SET IDPersona = @IDPersona, IDRol = @IDRol, NombreUsuario = @NombreUsuario, Clave = @Clave WHERE ID = @ID");
                DT.agregarParametro("@IDPersona", usuario.IDPersona);
                DT.agregarParametro("@IDRol", usuario.IDRol);
                DT.agregarParametro("@NombreUsuario", usuario.NombreUsuario);
                DT.agregarParametro("@Clave", usuario.Clave);
                DT.agregarParametro("@ID", usuario.ID);

                return DT.ejecutarAccion();
            }
            catch (Exception ex)
            {
                // Manejo de otras excepciones
                errorMessage = "Ocurrió un error al intentar modificar el usuario: " + ex.Message;
                return false;
            }
            finally
            {
                DT.cerrarConexion();
            }
        }

        public Usuario BuscarUsuarioPorDNI(string dni)
        {
            Usuario usuario = null;
            try
            {
                // Primero obtenemos la persona con el DNI proporcionado
                PersonaNegocio personaNegocio = new PersonaNegocio();
                Persona persona = personaNegocio.BuscarPersona(dni);

                if (persona != null)
                {
                    // Si la persona existe, buscamos el usuario correspondiente
                    DT.setearConsulta("SELECT ID, IDPersona, IDRol, NombreUsuario, Clave FROM Usuarios WHERE IDPersona = @IDPersona");
                    DT.agregarParametro("@IDPersona", persona.IDPersona);
                    DT.ejecutarLectura();

                    if (DT.Lector.Read())
                    {
                        usuario = new Usuario
                        {
                            ID = Convert.ToInt32(DT.Lector["ID"]),
                            IDPersona = Convert.ToInt32(DT.Lector["IDPersona"]),
                            IDRol = Convert.ToInt32(DT.Lector["IDRol"]),
                            NombreUsuario = DT.Lector["NombreUsuario"].ToString(),
                            Clave = DT.Lector["Clave"].ToString()
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DT.cerrarConexion();
            }
            return usuario;
        }
    }
}
