﻿using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class MiembroNegocio
    {
        private AccesoDatos DT;

        public MiembroNegocio()
        {
            DT = new AccesoDatos();
        }

        public List<Miembro> ListarMiembros()
        {
            List<Miembro> miembros = new List<Miembro>();
            try
            {
                DT.setearConsulta("select ID,IDPersona,IDTipoMembresia,NombreUsuario,Clave,FechaInicio,FechaFin from Miembros");
                DT.ejecutarLectura();

                while (DT.Lector.Read())
                {
                    Miembro miembro = new Miembro();
                    miembro.IDMiembro = Convert.ToInt32(DT.Lector["ID"]);
                    miembro.IDPersona = Convert.ToInt32(DT.Lector["IDPersona"]);
                    miembro.TipoMembresia = Convert.ToInt32(DT.Lector["IDTipoMembresia"]);
                    miembro.FechaInicio = Convert.ToDateTime(DT.Lector["FechaInicio"]);
                    miembro.FechaFin = Convert.ToDateTime(DT.Lector["FechaFin"]);
                    miembros.Add(miembro);
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
            return miembros;
        }


        public bool AgregarMiembro(Miembro miembro)
        {
            try
            {
                // Verificar si la persona existe
                PersonaNegocio personaNegocio = new PersonaNegocio();
                Persona personaExistente = personaNegocio.BuscarPersona(miembro.DNI);

                if (personaExistente == null)
                {
                    // Si no existe, agregar la persona
                    bool personaAgregada = personaNegocio.AgregarPersona(miembro);
                    if (!personaAgregada)
                    {
                        return false;
                    }

                    // Recuperar el IDPersona de la persona recién agregada
                    personaExistente = personaNegocio.BuscarPersona(miembro.DNI);
                    miembro.IDPersona = personaExistente.IDPersona;
                }
                else
                {
                    // Si la persona ya existe, usar su ID
                    miembro.IDPersona = personaExistente.IDPersona;
                }

                // Establecer la consulta para insertar un nuevo miembro
                DT.setearConsulta("INSERT INTO Miembros (IDPersona, IDTipoMembresia) OUTPUT INSERTED.ID VALUES (@IDPersona, @IDTipoMembresia)");

                // Agregar parámetros a la consulta
                DT.agregarParametro("@IDPersona", miembro.IDPersona);
                DT.agregarParametro("@IDTipoMembresia", miembro.TipoMembresia);

                // Ejecutar la acción de inserción y obtener el resultado
                int insertedId = DT.ejecutarAccionReturn();

                // Registro de depuración
                Console.WriteLine($"AgregarMiembro: IDPersona={miembro.IDPersona}, IDTipoMembresia={miembro.TipoMembresia}, Resultado={insertedId}");

                return insertedId > 0;
            }
            catch (Exception ex)
            {
                // Registro de error
                Console.WriteLine($"Error al agregar el miembro: {ex.Message}");
                return false;
            }
            finally
            {
                // Cerrar la conexión a la base de datos
                DT.cerrarConexion();
            }
        }

      


        public Miembro BuscarUltimoRegMiembro(string DNI)
        {
            Miembro miembro = null;
            try
            {
                DT.setearConsulta(@"SELECT TOP 1 M.ID, M.IDPersona, M.IDTipoMembresia, M.FechaInicio, M.FechaFin, 
                            P.DNI, P.Nombre, P.Apellido, T.Descripcion AS TipoMembresiaDescripcion 
                            FROM Miembros M
                            INNER JOIN Personas P ON M.IDPersona = P.ID
                            INNER JOIN TiposMembresias T ON M.IDTipoMembresia = T.ID
                            WHERE P.DNI = @DNI 
                            ORDER BY M.FechaInicio DESC");
                DT.agregarParametro("@DNI", DNI);
                DT.ejecutarLectura();
                if (DT.Lector.Read())
                {
                    miembro = new Miembro
                    {
                        IDMiembro = Convert.ToInt32(DT.Lector["ID"]),
                        IDPersona = Convert.ToInt32(DT.Lector["IDPersona"]),
                        TipoMembresia = Convert.ToInt32(DT.Lector["IDTipoMembresia"]),
                        FechaInicio = Convert.ToDateTime(DT.Lector["FechaInicio"]),
                        FechaFin = Convert.ToDateTime(DT.Lector["FechaFin"]),
                        DNI = DT.Lector["DNI"].ToString(),
                        Nombre = DT.Lector["Nombre"].ToString(),
                        Apellido = DT.Lector["Apellido"].ToString(),
                        TipoMembresiaDescripcion = DT.Lector["TipoMembresiaDescripcion"].ToString()
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el miembro", ex);
            }
            finally
            {
                DT.cerrarConexion();
            }
            return miembro;
        }



        public Miembro BuscarUltimoRegMiembro(int IDPersona)
        {
            Miembro miembro = null;
            try
            {
                DT.setearConsulta(@"SELECT TOP 1 M.ID, M.IDPersona, M.IDTipoMembresia, M.FechaInicio, M.FechaFin, 
                            P.DNI, P.Nombre, P.Apellido, T.Descripcion AS TipoMembresiaDescripcion 
                            FROM Miembros M
                            INNER JOIN Personas P ON M.IDPersona = P.ID
                            INNER JOIN TiposMembresias T ON M.IDTipoMembresia = T.ID
                            WHERE M.IDPersona = @IDPersona 
                            ORDER BY M.FechaInicio DESC");
                DT.agregarParametro("@IDPersona", IDPersona);
                DT.ejecutarLectura();
                if (DT.Lector.Read())
                {
                    miembro = new Miembro
                    {
                        IDMiembro = Convert.ToInt32(DT.Lector["ID"]),
                        IDPersona = Convert.ToInt32(DT.Lector["IDPersona"]),
                        TipoMembresia = Convert.ToInt32(DT.Lector["IDTipoMembresia"]),
                        FechaInicio = Convert.ToDateTime(DT.Lector["FechaInicio"]),
                        FechaFin = Convert.ToDateTime(DT.Lector["FechaFin"]),
                        DNI = DT.Lector["DNI"].ToString(),
                        Nombre = DT.Lector["Nombre"].ToString(),
                        Apellido = DT.Lector["Apellido"].ToString(),
                        TipoMembresiaDescripcion = DT.Lector["TipoMembresiaDescripcion"].ToString()
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el miembro", ex);
            }
            finally
            {
                DT.cerrarConexion();
            }
            return miembro;
        }

        public bool ActualizarFechaFin(int idMiembro)
        {
            try
            {
                // Calcular la nueva FechaFin sumando 30 días a la fecha de hoy
                DateTime nuevaFechaFin = DateTime.Today.AddDays(30);

                // Establecer la consulta para actualizar la FechaFin del miembro con base en su ID
                DT.setearConsulta("UPDATE Miembros SET FechaFin = @NuevaFechaFin WHERE IDPersona = @IDMiembro");

                // Agregar los parámetros a la consulta
                DT.agregarParametro("@NuevaFechaFin", nuevaFechaFin);
                DT.agregarParametro("@IDMiembro", idMiembro);

                // Ejecutar la acción de actualización
                return DT.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar la fecha de fin del miembro", ex);
            }
            finally
            {
                // Cerrar la conexión
                DT.cerrarConexion();
            }


        }

        public List<Miembro> ListarMiembrosVencidos()
        {
            List<Miembro> miembros = new List<Miembro>();
            try
            {
                // Consulta SQL para obtener miembros con membresía vencida
                DT.setearConsulta(@"
            SELECT P.DNI, P.Nombre, P.Apellido, M.ID, M.IDPersona, M.IDTipoMembresia, M.FechaInicio, M.FechaFin
            FROM Miembros M
            INNER JOIN Personas P ON P.ID = M.IDPersona
            WHERE M.ID IN (
                SELECT MAX(ID) 
                FROM Miembros 
                GROUP BY IDPersona
            )
            AND M.FechaFin < GETDATE();
        ");
                DT.ejecutarLectura();

                while (DT.Lector.Read())
                {
                    Miembro miembro = new Miembro();
                    miembro.DNI = DT.Lector["DNI"].ToString();
                    miembro.Nombre = DT.Lector["Nombre"].ToString();
                    miembro.Apellido = DT.Lector["Apellido"].ToString();
                    miembro.IDMiembro = Convert.ToInt32(DT.Lector["ID"]);
                    miembro.IDPersona = Convert.ToInt32(DT.Lector["IDPersona"]);
                    miembro.TipoMembresia = Convert.ToInt32(DT.Lector["IDTipoMembresia"]);
                    miembro.FechaInicio = Convert.ToDateTime(DT.Lector["FechaInicio"]);
                    miembro.FechaFin = Convert.ToDateTime(DT.Lector["FechaFin"]);
                    miembros.Add(miembro);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los miembros con membresía vencida", ex);
            }
            finally
            {
                DT.cerrarConexion();
            }
            return miembros;
        }

        public List<Miembro> ListarUltimosMiembros()
        {
            List<Miembro> miembros = new List<Miembro>();
            try
            {
                // Consulta SQL para obtener el último registro por cada IDPersona
                DT.setearConsulta(@"
            SELECT P.DNI, P.Nombre, P.Apellido, M.ID, M.IDPersona, M.IDTipoMembresia, M.FechaInicio, M.FechaFin
FROM Miembros M
INNER JOIN Personas P ON P.ID = M.IDPersona
WHERE M.ID IN (
    SELECT MAX(ID) 
    FROM Miembros 
    GROUP BY IDPersona
);
        ");
                DT.ejecutarLectura();

                while (DT.Lector.Read())
                {
                    Miembro miembro = new Miembro();
                    miembro.DNI = DT.Lector["DNI"].ToString();
                    miembro.Nombre = DT.Lector["Nombre"].ToString(); // Agrega esta línea
                    miembro.Apellido = DT.Lector["Apellido"].ToString(); // Agrega esta línea
                    miembro.IDMiembro = Convert.ToInt32(DT.Lector["ID"]);
                    miembro.IDPersona = Convert.ToInt32(DT.Lector["IDPersona"]);
                    miembro.TipoMembresia = Convert.ToInt32(DT.Lector["IDTipoMembresia"]);
                    miembro.FechaInicio = Convert.ToDateTime(DT.Lector["FechaInicio"]);
                    miembro.FechaFin = Convert.ToDateTime(DT.Lector["FechaFin"]);
                    miembros.Add(miembro);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los últimos registros de los miembros", ex);
            }
            finally
            {
                DT.cerrarConexion();
            }
            return miembros;
        }


    }
}
