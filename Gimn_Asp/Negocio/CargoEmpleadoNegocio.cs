using Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Negocio
{
    public class CargoEmpleadoNegocio
    {
        private AccesoDatos DT;

        public CargoEmpleadoNegocio()
        {
            DT = new AccesoDatos();
        }

        public List<CargoEmpleado> ListarCargosEmpleados()
        {
            List<CargoEmpleado> cargoEmpleados = new List<CargoEmpleado>();
            try
            {
                DT.setearConsulta("SELECT ID, Descripcion FROM CargosEmpleados");
                DT.ejecutarLectura();
                while (DT.Lector.Read())
                {
                    CargoEmpleado cargoEmpleado = new CargoEmpleado();
                    cargoEmpleado.ID = Convert.ToInt32(DT.Lector["ID"]);
                    cargoEmpleado.Descripcion = Convert.ToString(DT.Lector["Descripcion"]);
                    cargoEmpleados.Add(cargoEmpleado);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                DT.cerrarConexion();
            }
            return cargoEmpleados;
        }

        public bool AgregarCargoEmpleado(CargoEmpleado cargo)
        {
            try
            {
                DT.setearConsulta("INSERT INTO CargosEmpleados (Descripcion) OUTPUT INSERTED.ID VALUES (@Descripcion)");
                DT.agregarParametro("@Descripcion", cargo.Descripcion);
                return DT.ejecutarAccion();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                DT.cerrarConexion();
            }
        }

        public bool EliminarCargoEmpleado(int id)
        {
            try
            {
                DT.setearConsulta("DELETE FROM CargosEmpleados WHERE ID = @ID");
                DT.agregarParametro("@ID", id);
                return DT.ejecutarAccion();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                DT.cerrarConexion();
            }
        }
    }
}
