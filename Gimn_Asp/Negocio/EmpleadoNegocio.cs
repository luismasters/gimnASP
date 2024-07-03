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
            List<Empleado> empleados = new List<Empleado>();
            try
            {
                Dt.setearConsulta("SELECT E.ID, E.IDPersona, E.IDCargoEmpleado, P.DNI, P.Nombre, P.Apellido, P.Email, P.FechaNacimiento, C.Descripcion AS CargoDescripcion " +
                                  "FROM Empleados E " +
                                  "INNER JOIN Personas P ON E.IDPersona = P.ID " +
                                  "INNER JOIN CargosEmpleados C ON E.IDCargoEmpleado = C.ID");
                Dt.ejecutarLectura();
                while (Dt.Lector.Read())
                {
                    Empleado empleado = new Empleado
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
                    empleados.Add(empleado);
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
            return empleados;
        }




        public List<Empleado> ListarInstructores()
        {
            List<Empleado> instructores = new List<Empleado>();
            try
            {
                Dt.setearConsulta("SELECT E.ID, P.Nombre, P.Apellido FROM Empleados E INNER JOIN Personas P ON E.IDPersona = P.ID INNER JOIN CargosEmpleados C ON E.IDCargoEmpleado = C.ID WHERE C.Descripcion = 'Instructor de salon'");
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
    





    public bool AgregarEmpleado(Empleado empleado, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                // Verificar si la persona existe
                PersonaNegocio personaNegocio = new PersonaNegocio();
                Persona personaExistente = personaNegocio.BuscarPersona(empleado.DNI);

                if (personaExistente == null)
                {
                    // Si no existe, agregar la persona
                    bool personaAgregada = personaNegocio.AgregarPersona(empleado, out errorMessage);
                    if (!personaAgregada)
                    {
                        return false;
                    }

                    // Recuperar el IDPersona de la persona recién agregada
                    personaExistente = personaNegocio.BuscarPersona(empleado.DNI);
                    empleado.IDPersona = personaExistente.IDPersona;
                }
                else
                {
                    // Si la persona ya existe, usar su ID
                    empleado.IDPersona = personaExistente.IDPersona;
                }

                // Agregar el empleado
                Dt.setearConsulta("INSERT INTO Empleados(IDPersona, IDCargoEmpleado) OUTPUT INSERTED.Id VALUES (@IDPersona, @IDCargoEmpleado)");
                Dt.agregarParametro("@IDPersona", empleado.IDPersona);
                Dt.agregarParametro("@IDCargoEmpleado", empleado.cargoEmpleado.ID);

                return Dt.ejecutarAccion();
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
            finally
            {
                Dt.cerrarConexion();
            }
        }
    }
}
