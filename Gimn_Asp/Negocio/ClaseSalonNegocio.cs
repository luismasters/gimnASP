using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ClaseSalonNegocio
    {

        private AccesoDatos DT;

        public ClaseSalonNegocio()
        {
            DT = new AccesoDatos();
        }

        public bool AgregarClaseSalon(ClaseSalon claseSalon, out string errorMessage)
        {
            errorMessage = string.Empty;

            try
            {
                DT.setearConsulta("INSERT INTO ClasesSalon(Descripcion) OUTPUT INSERTED.ID VALUES (@Descripcion)");
                DT.agregarParametro("@Descripcion", claseSalon.NombreClase);
                return DT.ejecutarAccion();
            }
            catch (Exception ex)
            {
                errorMessage = "Error al intentar agregar la clase de salón: " + ex.Message;
                return false;
            }
            finally
            {
                DT.cerrarConexion();
            }
        }

        public List<ClaseSalon> ListarClasesSalon()
        {
            List<ClaseSalon> clasesSalon = new List<ClaseSalon>();
            try
            {
                DT.setearConsulta("SELECT ID, Descripcion AS NombreClase FROM ClasesSalon");
                DT.ejecutarLectura();
                while (DT.Lector.Read())
                {
                    ClaseSalon claseSalon = new ClaseSalon
                    {
                        ID = Convert.ToInt32(DT.Lector["ID"]),
                        NombreClase = DT.Lector["NombreClase"].ToString()
                    };
                    clasesSalon.Add(claseSalon);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar las clases de salón: " + ex.Message);
            }
            finally
            {
                DT.cerrarConexion();
            }
            return clasesSalon;
        }

        public bool EliminarClaseSalon(int id, out string errorMessage)
        {
            errorMessage = string.Empty;

            try
            {
                DT.setearConsulta("DELETE FROM ClasesSalon WHERE ID = @ID");
                DT.agregarParametro("@ID", id);
                return DT.ejecutarAccion();
            }
            catch (Exception ex)
            {
                errorMessage = "Error al intentar eliminar la clase de salón: " + ex.Message;
                return false;
            }
            finally
            {
                DT.cerrarConexion();
            }
        }




    }
}
