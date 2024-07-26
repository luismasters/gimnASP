using Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Negocio
{
    public class EmpleadoNegocio
    {
        private AccesoDatos Dt;

        public EmpleadoNegocio()
        {
            Dt = new AccesoDatos();
        }

        public List<Empleado> ListarEmpleados()
        {
            List<Empleado> lista = new List<Empleado>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT E.ID, P.DNI, P.Nombre, P.Apellido, P.Email, C.Descripcion as Cargo, E.EstadoActivo " +
                                     "FROM Empleados E " +
                                     "INNER JOIN Personas P ON E.IDPersona = P.ID " +
                                     "INNER JOIN CargosEmpleados C ON E.IDCargoEmpleado = C.ID");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Empleado emp = new Empleado
                    {
                        ID = (int)datos.Lector["ID"],
                        DNI = (string)datos.Lector["DNI"],
                        Nombre = (string)datos.Lector["Nombre"],
                        Apellido = (string)datos.Lector["Apellido"],
                        Email = (string)datos.Lector["Email"],
                        cargoEmpleado = new CargoEmpleado { Descripcion = (string)datos.Lector["Cargo"] },
                        EstadoActivo = (bool)datos.Lector["EstadoActivo"]
                    };
                    lista.Add(emp);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public bool ObtenerEstadoActivo(int idEmpleado)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT EstadoActivo FROM Empleados WHERE ID = @ID");
                datos.agregarParametro("@ID", idEmpleado);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    return (bool)datos.Lector["EstadoActivo"];
                }
                throw new Exception("Empleado no encontrado");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void CambiarEstadoActivo(int idEmpleado, bool nuevoEstado)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Empleados SET EstadoActivo = @Estado WHERE ID = @ID");
                datos.agregarParametro("@Estado", nuevoEstado);
                datos.agregarParametro("@ID", idEmpleado);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    
    public List<Empleado> ListarInstructores()
        {
            List<Empleado> instructores = new List<Empleado>();
            try
            {
                Dt.setearConsulta("SELECT E.ID, P.Nombre, P.Apellido " +
                                  "FROM Empleados E " +
                                  "INNER JOIN Personas P ON E.IDPersona = P.ID " +
                                  "WHERE E.IDRol = @IDRol");
                Dt.agregarParametro("@IDRol", 3); // Filtrar por IDRol = 3
                Dt.ejecutarLectura();
                while (Dt.Lector.Read())
                {
                    Empleado instructor = new Empleado
                    {
                        ID = Convert.ToInt32(Dt.Lector["ID"]),
                        Nombre = Dt.Lector["Nombre"].ToString(),
                        Apellido = Dt.Lector["Apellido"].ToString()
                    };
                    instructores.Add(instructor);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los instructores", ex);
            }
            finally
            {
                Dt.cerrarConexion();
                Dt.limpiarParametros();
            }
            return instructores;
        }

        public Empleado BuscarEmpleadoPorIDPersona(int idPersona)
        {
            Empleado empleado = null;
            try
            {
                Dt.setearConsulta("SELECT E.ID, E.IDPersona, E.IDCargoEmpleado, P.DNI, P.Nombre, P.Apellido, P.Email, P.FechaNacimiento, C.Descripcion AS CargoDescripcion " +
                                  "FROM Empleados E " +
                                  "INNER JOIN Personas P ON E.IDPersona = P.ID " +
                                  "INNER JOIN CargosEmpleados C ON E.IDCargoEmpleado = C.ID " +
                                  "WHERE E.IDPersona = @IDPersona");
                Dt.agregarParametro("@IDPersona", idPersona);
                Dt.ejecutarLectura();
                if (Dt.Lector.Read())
                {
                    empleado = new Empleado
                    {
                        ID = Convert.ToInt32(Dt.Lector["ID"]),
                        IDPersona = Convert.ToInt32(Dt.Lector["IDPersona"]),
                        DNI = Dt.Lector["DNI"].ToString(),
                        Nombre = Dt.Lector["Nombre"].ToString(),
                        Apellido = Dt.Lector["Apellido"].ToString(),
                        Email = Dt.Lector["Email"].ToString(),
                        FechaNacimiento = Convert.ToDateTime(Dt.Lector["FechaNacimiento"]),
                        cargoEmpleado = new CargoEmpleado
                        {
                            ID = Convert.ToInt32(Dt.Lector["IDCargoEmpleado"]),
                            Descripcion = Dt.Lector["CargoDescripcion"].ToString()
                        }
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Dt.cerrarConexion();
            }
            return empleado;
        }

        public Empleado BuscarEmpleadoPorDNI(string DNI)
        {
            Empleado empleado = null;
            try
            {
                Dt.setearConsulta("SELECT E.ID, E.IDPersona, E.IDCargoEmpleado, P.DNI, P.Nombre, P.Apellido, P.Email, P.FechaNacimiento, C.Descripcion AS CargoDescripcion " +
                                  "FROM Empleados E " +
                                  "INNER JOIN Personas P ON E.IDPersona = P.ID " +
                                  "INNER JOIN CargosEmpleados C ON E.IDCargoEmpleado = C.ID " +
                                  "WHERE P.DNI = @DNI");
                Dt.agregarParametro("@DNI", DNI);
                Dt.ejecutarLectura();
                if (Dt.Lector.Read())
                {
                    empleado = new Empleado
                    {
                        ID = Convert.ToInt32(Dt.Lector["ID"]),
                        IDPersona = Convert.ToInt32(Dt.Lector["IDPersona"]),
                        DNI = Dt.Lector["DNI"].ToString(),
                        Nombre = Dt.Lector["Nombre"].ToString(),
                        Apellido = Dt.Lector["Apellido"].ToString(),
                        Email = Dt.Lector["Email"].ToString(),
                        FechaNacimiento = Convert.ToDateTime(Dt.Lector["FechaNacimiento"]),
                        cargoEmpleado = new CargoEmpleado
                        {
                            ID = Convert.ToInt32(Dt.Lector["IDCargoEmpleado"]),
                            Descripcion = Dt.Lector["CargoDescripcion"].ToString()
                        }
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Dt.cerrarConexion();
            }
            return empleado;
        }

        public bool AgregarEmpleado(Empleado empleado, out string errorMessage)
        {
            errorMessage = string.Empty;
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("sp_CrearUsuarioYEmpleado");
                datos.agregarParametro("@NombreUsuario", empleado.usuario.NombreUsuario);
                datos.agregarParametro("@Clave", empleado.usuario.Clave);
                datos.agregarParametro("@DNI", empleado.DNI);
                datos.agregarParametro("@Nombre", empleado.Nombre);
                datos.agregarParametro("@Apellido", empleado.Apellido);
                datos.agregarParametro("@Email", empleado.Email);
                datos.agregarParametro("@FechaNacimiento", empleado.FechaNacimiento);
                datos.agregarParametro("@IDCargoEmpleado", empleado.cargoEmpleado.ID);
                datos.agregarParametro("@IDRol", empleado.rol.ID);
                datos.agregarParametro("@EstadoActivo", empleado.EstadoActivo);

                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    string resultado = datos.Lector["Resultado"].ToString();
                    if (resultado.Contains("Error") || resultado.Contains("ya está registrado"))
                    {
                        errorMessage = resultado;
                        return false;
                    }
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                errorMessage = "Error inesperado: " + ex.Message;
                return false;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public Empleado BuscarEmpleadoPorUsuario(string nombreUsuario)
        {
            Empleado empleado = null;
            try
            {
                Dt.setearConsulta(@"
        SELECT 
            E.ID AS EmpleadoID, 
            E.IDPersona, 
            E.IDCargoEmpleado, 
            E.EstadoActivo, 
            P.DNI, 
            P.Nombre, 
            P.Apellido, 
            P.Email, 
            P.FechaNacimiento, 
            C.Descripcion AS CargoDescripcion, 
            R.ID AS RolID, 
            R.Nombre AS RolDescripcion
        FROM 
            Empleados E
        INNER JOIN 
            Personas P ON E.IDPersona = P.ID
        INNER JOIN 
            CargosEmpleados C ON E.IDCargoEmpleado = C.ID
        INNER JOIN 
            Usuarios U ON E.IDUsuario = U.ID
        INNER JOIN 
            Roles R ON R.ID = E.IDRol
        WHERE 
            U.NombreUsuario = @NombreUsuario AND E.EstadoActivo = 1"); // Agregué la condición E.EstadoActivo = 1
                Dt.agregarParametro("@NombreUsuario", nombreUsuario);
                Dt.ejecutarLectura();
                if (Dt.Lector.Read())
                {
                    empleado = new Empleado
                    {
                        ID = Convert.ToInt32(Dt.Lector["EmpleadoID"]),
                        IDPersona = Convert.ToInt32(Dt.Lector["IDPersona"]),
                        DNI = Dt.Lector["DNI"].ToString(),
                        Nombre = Dt.Lector["Nombre"].ToString(),
                        Apellido = Dt.Lector["Apellido"].ToString(),
                        Email = Dt.Lector["Email"].ToString(),
                        FechaNacimiento = Convert.ToDateTime(Dt.Lector["FechaNacimiento"]),
                        cargoEmpleado = new CargoEmpleado
                        {
                            ID = Convert.ToInt32(Dt.Lector["IDCargoEmpleado"]),
                            Descripcion = Dt.Lector["CargoDescripcion"].ToString()
                        },
                        rol = new Rol
                        {
                            ID = Convert.ToInt32(Dt.Lector["RolID"]),
                            Descripcion = Dt.Lector["RolDescripcion"].ToString()
                        },
                        EstadoActivo = Convert.ToBoolean(Dt.Lector["EstadoActivo"])
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el empleado por nombre de usuario", ex);
            }
            finally
            {
                Dt.cerrarConexion();
            }
            return empleado;
        }


        public Empleado ObtenerEmpleado(int idEmpleado)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT E.ID, P.DNI, P.Nombre, P.Apellido, P.Email, P.FechaNacimiento, " +
                                     "E.IDCargoEmpleado, C.Descripcion as CargoDescripcion, " +
                                     "E.IDRol, R.Nombre as RolDescripcion, E.EstadoActivo, " +
                                     "U.ID as IDUsuario, U.NombreUsuario " +
                                     "FROM Empleados E " +
                                     "INNER JOIN Personas P ON E.IDPersona = P.ID " +
                                     "INNER JOIN CargosEmpleados C ON E.IDCargoEmpleado = C.ID " +
                                     "INNER JOIN Roles R ON E.IDRol = R.ID " +
                                     "LEFT JOIN Usuarios U ON E.IDUsuario = U.ID " +
                                     "WHERE E.ID = @ID");
                datos.agregarParametro("@ID", idEmpleado);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    return new Empleado
                    {
                        ID = (int)datos.Lector["ID"],
                        DNI = (string)datos.Lector["DNI"],
                        Nombre = (string)datos.Lector["Nombre"],
                        Apellido = (string)datos.Lector["Apellido"],
                        Email = (string)datos.Lector["Email"],
                        FechaNacimiento = (DateTime)datos.Lector["FechaNacimiento"],
                        cargoEmpleado = new CargoEmpleado
                        {
                            ID = (int)datos.Lector["IDCargoEmpleado"],
                            Descripcion = (string)datos.Lector["CargoDescripcion"]
                        },
                        rol = new Rol
                        {
                            ID = (int)datos.Lector["IDRol"],
                            Descripcion = (string)datos.Lector["RolDescripcion"]
                        },
                        EstadoActivo = (bool)datos.Lector["EstadoActivo"],
                        usuario = new Usuario
                        {
                            ID = datos.Lector["IDUsuario"] != DBNull.Value ? (int)datos.Lector["IDUsuario"] : 0,
                            NombreUsuario = datos.Lector["NombreUsuario"] != DBNull.Value ? (string)datos.Lector["NombreUsuario"] : null
                        }
                    };
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void ModificarEmpleado(Empleado empleado)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Personas SET Nombre = @Nombre, Apellido = @Apellido, " +
                                     "Email = @Email, FechaNacimiento = @FechaNacimiento " +
                                     "WHERE DNI = @DNI; " +
                                     "UPDATE Empleados SET IDCargoEmpleado = @IDCargo, IDRol = @IDRol, " +
                                     "EstadoActivo = @EstadoActivo " +
                                     "WHERE ID = @ID");

                datos.agregarParametro("@ID", empleado.ID);
                datos.agregarParametro("@DNI", empleado.DNI);
                datos.agregarParametro("@Nombre", empleado.Nombre);
                datos.agregarParametro("@Apellido", empleado.Apellido);
                datos.agregarParametro("@Email", empleado.Email);
                datos.agregarParametro("@FechaNacimiento", empleado.FechaNacimiento);
                datos.agregarParametro("@IDCargo", empleado.cargoEmpleado.ID);
                datos.agregarParametro("@IDRol", empleado.rol.ID);
                datos.agregarParametro("@EstadoActivo", empleado.EstadoActivo);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

    }
}
