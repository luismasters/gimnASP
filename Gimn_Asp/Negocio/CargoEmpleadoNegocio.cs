using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                DT.setearConsulta("select ID,Descripcion from CargosEmpleados");
                DT.ejecutarLectura();
                while (DT.Lector.Read())
                {
                    CargoEmpleado cargoempleado = new CargoEmpleado();
                    cargoempleado.ID = Convert.ToInt32(DT.Lector["ID"]);
                    cargoempleado.Descripcion = Convert.ToString(DT.Lector["Descripcion"]);
                    cargoEmpleados.Add(cargoempleado);
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
                DT.setearConsulta("insert into CargosEmpleados(Descripcion)" + "OUTPUT INSERTED.Id VALUES (@Descripcion)");
                DT.agregarParametro("@Descripcion", cargo.Descripcion);
                return DT.ejecutarAccion();
            }
            catch (Exception)
            {
                throw;
            }
            finally { DT.cerrarConexion(); }
        }






    }
}
