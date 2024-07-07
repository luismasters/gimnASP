using Dominio;
using System;
using System.Collections.Generic;

namespace Negocio
{
    public class ReservaNegocio
    {
        private AccesoDatos DT;

        public ReservaNegocio()
        {
            DT = new AccesoDatos();
        }

        public bool AgregarReserva(Reserva reserva, out string errorMessage)
        {
            errorMessage = string.Empty;

            try
            {
                DT.setearConsulta("INSERT INTO Reservas(IDClaseSalon, IDSalone, IDMiembro, IDHorarioClase) OUTPUT INSERTED.ID VALUES (@IDClaseSalon, @IDSalone, @IDMiembro, @IDHorarioClase)");
                DT.agregarParametro("@IDClaseSalon", reserva.claseSalon.ID);
                DT.agregarParametro("@IDSalone", reserva.salon.ID);
                DT.agregarParametro("@IDMiembro", reserva.miembro.IDMiembro);
                DT.agregarParametro("@IDHorarioClase", reserva.horarioClase.ID);
                return DT.ejecutarAccion();
            }
            catch (Exception ex)
            {
                errorMessage = "Error al intentar agregar la reserva: " + ex.Message;
                return false;
            }
            finally
            {
                DT.cerrarConexion();
            }
        }

        public List<Reserva> ObtenerReservasPorHorario(int horarioId)
        {
            List<Reserva> reservas = new List<Reserva>();
            try
            {
                DT.setearConsulta(@"
                    SELECT R.ID, P.Nombre, P.Apellido, H.Fecha, H.HoraInicio, H.HoraFin
                    FROM Reservas R
                    INNER JOIN Miembros M ON R.IDMiembro = M.ID
                    INNER JOIN Personas P ON M.IDPersona = P.ID
                    INNER JOIN HorariosClases H ON R.IDHorarioClase = H.ID
                    WHERE R.IDHorarioClase = @HorarioID AND H.Fecha >= GETDATE()");
                DT.agregarParametro("@HorarioID", horarioId);
                DT.ejecutarLectura();
                while (DT.Lector.Read())
                {
                    Reserva reserva = new Reserva
                    {
                        ID = Convert.ToInt32(DT.Lector["ID"]),
                        miembro = new Miembro
                        {
                            Nombre = DT.Lector["Nombre"].ToString(),
                            Apellido = DT.Lector["Apellido"].ToString()
                        },
                        horarioClase = new HorarioClase
                        {
                            Fecha = Convert.ToDateTime(DT.Lector["Fecha"]),
                            HoraInicio = DT.Lector["HoraInicio"].ToString(),
                            HoraFin = DT.Lector["HoraFin"].ToString()
                        }
                    };
                    reservas.Add(reserva);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener reservas por horario", ex);
            }
            finally
            {
                DT.cerrarConexion();
                DT.limpiarParametros();
            }
            return reservas;
        }

        public List<Reserva> ObtenerReservasPorMiembro(int idMiembro)
        {
            List<Reserva> reservas = new List<Reserva>();

            try
            {
                DT.setearConsulta(@"
                    SELECT R.ID, R.IDClaseSalon, R.IDSalone, R.IDMiembro, R.IDHorarioClase, 
                           H.Fecha, H.HoraInicio, H.HoraFin, 
                           C.Descripcion AS NombreClase, 
                           S.Nombre AS NombreSalon, 
                           P.Nombre AS NombreInstructor, P.Apellido AS ApellidoInstructor
                    FROM Reservas R
                    INNER JOIN HorariosClases H ON R.IDHorarioClase = H.ID
                    INNER JOIN ClasesSalon C ON R.IDClaseSalon = C.ID
                    INNER JOIN Salones S ON R.IDSalone = S.ID
                    INNER JOIN Empleados E ON H.IDInstructor = E.ID
                    INNER JOIN Personas P ON E.IDPersona = P.ID
                    WHERE R.IDMiembro = @IDMiembro AND H.Fecha >= GETDATE()
                    ORDER BY H.Fecha, H.HoraInicio");
                DT.agregarParametro("@IDMiembro", idMiembro);
                DT.ejecutarLectura();

                while (DT.Lector.Read())
                {
                    Reserva reserva = new Reserva
                    {
                        ID = Convert.ToInt32(DT.Lector["ID"]),
                        claseSalon = new ClaseSalon
                        {
                            ID = Convert.ToInt32(DT.Lector["IDClaseSalon"]),
                            NombreClase = DT.Lector["NombreClase"].ToString()
                        },
                        salon = new Salon
                        {
                            ID = Convert.ToInt32(DT.Lector["IDSalone"]),
                            Nombre = DT.Lector["NombreSalon"].ToString()
                        },
                        miembro = new Miembro { IDMiembro = Convert.ToInt32(DT.Lector["IDMiembro"]) },
                        horarioClase = new HorarioClase
                        {
                            ID = Convert.ToInt32(DT.Lector["IDHorarioClase"]),
                            Fecha = Convert.ToDateTime(DT.Lector["Fecha"]),
                            HoraInicio = DT.Lector["HoraInicio"].ToString(),
                            HoraFin = DT.Lector["HoraFin"].ToString(),
                            Instructor = new Empleado
                            {
                                Nombre = DT.Lector["NombreInstructor"].ToString(),
                                Apellido = DT.Lector["ApellidoInstructor"].ToString()
                            }
                        }
                    };
                    reservas.Add(reserva);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las reservas del miembro", ex);
            }
            finally
            {
                DT.cerrarConexion();
                DT.limpiarParametros();
            }

            return reservas;
        }


        private bool TieneReservaParaElDia(int idHorarioClase, int idMiembro)
        {
            try
            {
                DT.setearConsulta(@"SELECT COUNT(*) 
                                    FROM Reservas R 
                                    INNER JOIN HorariosClases H ON R.IDHorarioClase = H.ID 
                                    WHERE R.IDMiembro = @IDMiembro AND H.Fecha = 
                                        (SELECT Fecha FROM HorariosClases WHERE ID = @IDHorarioClase)");
                DT.agregarParametro("@IDHorarioClase", idHorarioClase);
                DT.agregarParametro("@IDMiembro", idMiembro);
                DT.ejecutarLectura();

                if (DT.Lector.Read() && Convert.ToInt32(DT.Lector[0]) > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al verificar reservas para el día", ex);
            }
            finally
            {
                DT.cerrarConexion();
                DT.limpiarParametros();
            }
        }

        public bool HacerReserva(int idHorarioClase, int idMiembro, int idClaseSalon, int idSalon, out string mensajeError)
        {
            mensajeError = string.Empty;
            try
            {
                if (TieneReservaParaElDia(idHorarioClase, idMiembro))
                {
                    mensajeError = "Ya tienes una reserva para este día.";
                    return false;
                }

                // Hacer la reserva
                DT.setearConsulta(@"INSERT INTO Reservas (IDClaseSalon, IDSalone, IDMiembro, IDHorarioClase) 
                                    VALUES (@IDClaseSalon, @IDSalone, @IDMiembro, @IDHorarioClase)");
                DT.agregarParametro("@IDClaseSalon", idClaseSalon);
                DT.agregarParametro("@IDSalone", idSalon);
                DT.agregarParametro("@IDMiembro", idMiembro);
                DT.agregarParametro("@IDHorarioClase", idHorarioClase);

                return DT.ejecutarAccion();
            }
            catch (Exception ex)
            {
                mensajeError = "Error al realizar la reserva: " + ex.Message;
                return false;
            }
            finally
            {
                DT.cerrarConexion();
                DT.limpiarParametros();
            }
        }
    }
}
