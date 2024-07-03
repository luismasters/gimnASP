using Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Negocio
{
    public class HorarioClaseNegocio
    {
        private AccesoDatos DT;

        public HorarioClaseNegocio()
        {
            DT = new AccesoDatos();
        }

        public bool AgregarHorarioClase(HorarioClase horarioClase, out string errorMessage)
        {
            errorMessage = string.Empty;

            try
            {
                if (ExisteClaseEnFranjaHoraria(horarioClase))
                {
                    errorMessage = "Ya existe una clase en la misma franja horaria para la fecha especificada en el mismo salón.";
                    return false;
                }

                DT.setearConsulta("INSERT INTO HorariosClases (IDClaseSalon, Fecha, HoraInicio, HoraFin, IDSalon,IDInstructor) OUTPUT INSERTED.ID VALUES (@IDClaseSalon, @Fecha, @HoraInicio, @HoraFin, @IDSalon,@IDInstructor)");
                DT.agregarParametro("@IDClaseSalon", horarioClase.claseSalon.ID);
                DT.agregarParametro("@Fecha", horarioClase.Fecha);
                DT.agregarParametro("@HoraInicio", horarioClase.HoraInicio);
                DT.agregarParametro("@HoraFin", horarioClase.HoraFin);
                DT.agregarParametro("@IDSalon", horarioClase.salon.ID);
                DT.agregarParametro("@IDInstructor", horarioClase.Instructor.ID);
                bool resultado = DT.ejecutarAccion();
                return resultado;
            }
            catch (Exception ex)
            {
                errorMessage = "Error al agregar el horario de clase: " + ex.Message;
                return false;
            }
            finally
            {
                DT.cerrarConexion();
                DT.limpiarParametros();
            }
        }

        private bool ExisteClaseEnFranjaHoraria(HorarioClase horarioClase)
        {
            try
            {
                DT.setearConsulta("SELECT COUNT(*) FROM HorariosClases WHERE Fecha = @Fecha AND IDSalon = @IDSalon AND ((HoraInicio <= @HoraInicio AND HoraFin > @HoraInicio) OR (HoraInicio < @HoraFin AND HoraFin >= @HoraFin) OR (HoraInicio >= @HoraInicio AND HoraFin <= @HoraFin))");
                DT.agregarParametro("@Fecha", horarioClase.Fecha);
                DT.agregarParametro("@HoraInicio", horarioClase.HoraInicio);
                DT.agregarParametro("@HoraFin", horarioClase.HoraFin);
                DT.agregarParametro("@IDSalon", horarioClase.salon.ID);
                DT.ejecutarLectura();
                DT.Lector.Read();
                int count = (int)DT.Lector[0];
                return count > 0;
            }
            finally
            {
                DT.cerrarConexion();
                DT.limpiarParametros();
            }
        }

        public List<HorarioClase> ListarHorariosClases()
        {
            List<HorarioClase> horariosClases = new List<HorarioClase>();
            try
            {
                DT.setearConsulta(@"SELECT H.ID, H.Fecha, H.HoraInicio, H.HoraFin, C.Descripcion AS NombreClase, 
                            S.Nombre AS NombreSalon, P.Nombre AS NombreInstructor, P.Apellido AS ApellidoInstructor
                            FROM HorariosClases H 
                            INNER JOIN ClasesSalon C ON H.IDClaseSalon = C.ID 
                            INNER JOIN Salones S ON H.IDSalon = S.ID
                            INNER JOIN Empleados E ON H.IDInstructor = E.ID
                            INNER JOIN Personas P ON E.IDPersona = P.ID");
                DT.ejecutarLectura();
                while (DT.Lector.Read())
                {
                    HorarioClase horarioClase = new HorarioClase
                    {
                        ID = Convert.ToInt32(DT.Lector["ID"]),
                        Fecha = Convert.ToDateTime(DT.Lector["Fecha"]),
                        HoraInicio = DT.Lector["HoraInicio"].ToString(),
                        HoraFin = DT.Lector["HoraFin"].ToString(),
                        claseSalon = new ClaseSalon { NombreClase = DT.Lector["NombreClase"].ToString() },
                        salon = new Salon { Nombre = DT.Lector["NombreSalon"].ToString() },
                        Instructor = new Empleado
                        {
                            Nombre = DT.Lector["NombreInstructor"].ToString(),
                            Apellido = DT.Lector["ApellidoInstructor"].ToString()
                        }
                    };
                    horariosClases.Add(horarioClase);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los horarios de clases", ex);
            }
            finally
            {
                DT.cerrarConexion();
                DT.limpiarParametros();
            }
            return horariosClases;
        }


        public List<HorarioClase> ListarHorariosClasesPorSemana(DateTime fechaInicio, DateTime fechaFin)
        {
            List<HorarioClase> horariosClases = new List<HorarioClase>();
            try
            {
                DT.setearConsulta(@"SELECT H.ID, H.Fecha, H.HoraInicio, H.HoraFin, C.Descripcion AS NombreClase, 
                            S.Nombre AS NombreSalon, P.Nombre AS NombreInstructor, P.Apellido AS ApellidoInstructor
                            FROM HorariosClases H 
                            INNER JOIN ClasesSalon C ON H.IDClaseSalon = C.ID 
                            INNER JOIN Salones S ON H.IDSalon = S.ID
                            INNER JOIN Empleados E ON H.IDInstructor = E.ID
                            INNER JOIN Personas P ON E.IDPersona = P.ID
                            WHERE H.Fecha BETWEEN @FechaInicio AND @FechaFin");
                DT.agregarParametro("@FechaInicio", fechaInicio);
                DT.agregarParametro("@FechaFin", fechaFin);
                DT.ejecutarLectura();
                while (DT.Lector.Read())
                {
                    HorarioClase horarioClase = new HorarioClase
                    {
                        ID = Convert.ToInt32(DT.Lector["ID"]),
                        Fecha = Convert.ToDateTime(DT.Lector["Fecha"]),
                        HoraInicio = DT.Lector["HoraInicio"].ToString(),
                        HoraFin = DT.Lector["HoraFin"].ToString(),
                        claseSalon = new ClaseSalon { NombreClase = DT.Lector["NombreClase"].ToString() },
                        salon = new Salon { Nombre = DT.Lector["NombreSalon"].ToString() },
                        Instructor = new Empleado
                        {
                            Nombre = DT.Lector["NombreInstructor"].ToString(),
                            Apellido = DT.Lector["ApellidoInstructor"].ToString()
                        }
                    };
                    horariosClases.Add(horarioClase);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los horarios de clases por semana", ex);
            }
            finally
            {
                DT.cerrarConexion();
                DT.limpiarParametros();
            }
            return horariosClases;
        }

        public bool EliminarHorarioClase(int id)
        {
            try
            {
                DT.setearConsulta("DELETE FROM HorariosClases WHERE ID = @ID");
                DT.agregarParametro("@ID", id);
                return DT.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el horario de clase", ex);
            }
            finally
            {
                DT.cerrarConexion();
                DT.limpiarParametros();
            }
        }
    }
}
