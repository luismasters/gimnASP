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
                    miembro.ID = Convert.ToInt32(DT.Lector["ID"]);
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
                // Establecer la consulta para insertar un nuevo miembro
                DT.setearConsulta("INSERT INTO Miembros (IDPersona, IDTipoMembresia) OUTPUT INSERTED.ID VALUES (@IDPer, @IDTipoMembresia)");

                // Agregar parámetros a la consulta
                DT.agregarParametro("@IDPer", miembro.IDPersona);
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
                throw new Exception("Error al agregar el miembro", ex);
            }
            finally
            {
                // Cerrar la conexión a la base de datos
                DT.cerrarConexion();
            }
        }






        public Miembro BuscarUltimoRegMiembro(int IDPersona)
        {
            Miembro miembro = null;
            try
            {
                // Asumiendo que la columna FechaInicio puede determinar el orden de los registros
                DT.setearConsulta("SELECT TOP 1 ID, IDPersona, IDTipoMembresia, FechaInicio, FechaFin FROM Miembros WHERE IDPersona = @IDPersona ORDER BY FechaInicio DESC");
                DT.agregarParametro("@IDPersona", IDPersona);
                DT.ejecutarLectura();
                if (DT.Lector.Read())
                {
                    miembro = new Miembro
                    {
                        ID = Convert.ToInt32(DT.Lector["ID"]),
                        IDPersona = Convert.ToInt32(DT.Lector["IDPersona"]),
                        TipoMembresia = Convert.ToInt32(DT.Lector["IDTipoMembresia"]),
                        FechaInicio = Convert.ToDateTime(DT.Lector["FechaInicio"]),
                        FechaFin = Convert.ToDateTime(DT.Lector["FechaFin"])
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


    }
}
