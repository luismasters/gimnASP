using Dominio;
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
                DT.setearConsulta("INSERT INTO Miembros (IDPersona, IDTipoMembresia, IDUsuario, IDRol, EstadoActivo, FechaInicio, FechaFin) OUTPUT INSERTED.ID VALUES (@IDPersona, @IDTipoMembresia, @IDUsuario, @IDRol, @EstadoActivo, @FechaInicio, @FechaFin)");

                // Agregar parámetros a la consulta
                DT.agregarParametro("@IDPersona", miembro.IDPersona);
                DT.agregarParametro("@IDTipoMembresia", miembro.TipoMembresia);
                DT.agregarParametro("@IDUsuario", miembro.usuario.ID);
                DT.agregarParametro("@IDRol", miembro.rol.ID);
                DT.agregarParametro("@EstadoActivo", miembro.EstadoActivo);
                DT.agregarParametro("@FechaInicio", miembro.FechaInicio);
                DT.agregarParametro("@FechaFin", miembro.FechaFin);

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

        public bool AgregarMiembroExistente(Miembro miembro)
        {
            // Validate member object (implement validation logic here)

            try
            {
                // Use descriptive variable names
                int memberId = miembro.IDPersona;
                int membershipTypeId = miembro.TipoMembresia;
                int userId = miembro.usuario.ID;
                int roleId = miembro.rol.ID;
                bool isActive = miembro.EstadoActivo;
                DateTime startDate = miembro.FechaInicio;
                DateTime endDate = miembro.FechaFin;

                // Set parameterized query
                DT.setearConsulta("INSERT INTO Miembros (IDPersona, IDTipoMembresia, IDUsuario, IDRol, EstadoActivo, FechaInicio, FechaFin) OUTPUT INSERTED.ID VALUES (@memberId, @membershipTypeId, @userId, @roleId, @isActive, @startDate, @endDate)");

                // Add parameters
                DT.agregarParametro("@memberId", memberId);
                DT.agregarParametro("@membershipTypeId", membershipTypeId);
                DT.agregarParametro("@userId", userId);
                DT.agregarParametro("@roleId", roleId);
                DT.agregarParametro("@isActive", isActive);
                DT.agregarParametro("@startDate", startDate);
                DT.agregarParametro("@endDate", endDate);

                // Execute and handle potential errors
                DT.ejecutarAccion();

                return true; // Or return a more meaningful value based on success/failure
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine($"Error adding member: {ex.Message}");

                // Provide informative message to user (optional)
                // ...

                // Decide on appropriate action (e.g., retry, rollback)
                return false; // Or throw an exception
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
                // Configurar la consulta SQL para buscar el miembro por IDPersona
                DT.setearConsulta(@"SELECT TOP 1 M.ID, M.IDPersona, M.IDTipoMembresia, M.FechaInicio, M.FechaFin, M.IDRol, M.IDUsuario,
            P.DNI, P.Nombre, P.Apellido, T.Descripcion AS TipoMembresiaDescripcion 
            FROM Miembros M
            INNER JOIN Personas P ON M.IDPersona = P.ID
            INNER JOIN TiposMembresias T ON M.IDTipoMembresia = T.ID
            INNER JOIN Usuarios U ON M.IDUsuario = U.ID
            WHERE M.IDPersona = @IDPersona 
            ORDER BY M.FechaInicio DESC");

                // Agregar el parámetro a la consulta
                DT.agregarParametro("@IDPersona", IDPersona);

                // Ejecutar la lectura
                DT.ejecutarLectura();

                // Leer los datos del miembro
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
                        TipoMembresiaDescripcion = DT.Lector["TipoMembresiaDescripcion"].ToString(),
                        rol = new Rol
                        {
                            ID = Convert.ToInt32(DT.Lector["IDRol"])
                        },
                        usuario = new Usuario
                        {
                            ID = Convert.ToInt32(DT.Lector["IDUsuario"])
                        }
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el miembro", ex);
            }
            finally
            {
                // Cerrar la conexión a la base de datos
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
        public Miembro BuscarUltimoRegMiembroPorUsername(string username)
        {
            Miembro miembro = null;
            try
            {
                // Configurar la consulta SQL para buscar el miembro por nombre de usuario
                DT.setearConsulta(@"SELECT TOP 1 M.ID, M.IDPersona, M.IDTipoMembresia, M.FechaInicio, M.FechaFin, M.IDRol, M.IDUsuario,
            P.DNI, P.Nombre, P.Apellido, T.Descripcion AS TipoMembresiaDescripcion 
            FROM Miembros M
            INNER JOIN Personas P ON M.IDPersona = P.ID
            INNER JOIN TiposMembresias T ON M.IDTipoMembresia = T.ID
            INNER JOIN Usuarios U ON M.IDUsuario = U.ID
            WHERE U.NombreUsuario = @Username 
            ORDER BY M.FechaInicio DESC");

                // Agregar el parámetro a la consulta
                DT.agregarParametro("@Username", username);

                // Ejecutar la lectura
                DT.ejecutarLectura();

                // Leer los datos del miembro
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
                        TipoMembresiaDescripcion = DT.Lector["TipoMembresiaDescripcion"].ToString(),
                        rol = new Rol
                        {
                            ID = Convert.ToInt32(DT.Lector["IDRol"])
                        },
                        usuario = new Usuario
                        {
                            ID = Convert.ToInt32(DT.Lector["IDUsuario"])
                        }
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el miembro por nombre de usuario", ex);
            }
            finally
            {
                // Cerrar la conexión a la base de datos
                DT.cerrarConexion();
            }
            return miembro;
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
