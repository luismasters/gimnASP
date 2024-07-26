using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class SalonNegocio
    {

        private AccesoDatos DT;

        public SalonNegocio()
        {
            DT = new AccesoDatos();
        }


        public bool AgregarSalon(Salon salon, out string errorMessage)
        {
            errorMessage = string.Empty;

            try
            {
                DT.setearConsulta("INSERT INTO Salones(Nombre, Capacidad) OUTPUT INSERTED.ID VALUES (@Nombre, @Capacidad)");
                DT.agregarParametro("@Nombre", salon.Nombre);
                DT.agregarParametro("@Capacidad", salon.capacidad);
                return DT.ejecutarAccion();
            }
            catch (Exception ex)
            {
                errorMessage = "Error al intentar agregar el salón: " + ex.Message;
                return false;
            }
            finally
            {
                DT.cerrarConexion();
            }
        }

        public List<Salon> ListarSalones()
        {
            List<Salon> salones = new List<Salon>();
            try
            {
                DT.setearConsulta("SELECT ID, Nombre, Capacidad FROM Salones");
                DT.ejecutarLectura();
                while (DT.Lector.Read())
                {
                    Salon salon = new Salon
                    {
                        ID = Convert.ToInt32(DT.Lector["ID"]),
                        Nombre = DT.Lector["Nombre"].ToString(),
                        capacidad = Convert.ToInt32(DT.Lector["Capacidad"])
                    };
                    salones.Add(salon);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los salones: " + ex.Message);
            }
            finally
            {
                DT.cerrarConexion();
            }
            return salones;
        }

        public bool EliminarSalon(int id, out string errorMessage)
        {
            errorMessage = string.Empty;

            try
            {
                DT.setearConsulta("delete from Salones where ID = @ID");
                DT.agregarParametro("@ID", id);
                return DT.ejecutarAccion();
            }
            catch (Exception ex)
            {
                errorMessage = "Error al intentar eliminar el salón: " + ex.Message;
                return false;
            }
            finally
            {
                DT.cerrarConexion();
            }
        }



        public bool ModificarSalon(Salon salon, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                DT.setearConsulta("UPDATE Salones SET Nombre = @Nombre, Capacidad = @Capacidad WHERE ID = @ID");
                DT.agregarParametro("@ID", salon.ID);
                DT.agregarParametro("@Nombre", salon.Nombre);
                DT.agregarParametro("@Capacidad", salon.capacidad);
                return DT.ejecutarAccion();
            }
            catch (Exception ex)
            {
                errorMessage = "Error al intentar modificar el salón: " + ex.Message;
                return false;
            }
            finally
            {
                DT.cerrarConexion();
            }
        }






    }




}

