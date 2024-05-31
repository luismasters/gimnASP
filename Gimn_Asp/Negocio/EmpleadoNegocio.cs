using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Dt.setearConsulta("select ID,IDPersona,IDCargoEmpleado,NombreUsuario,Clave from Empleados");
                Dt.ejecutarLectura();
                while (Dt.Lector.Read())
                {
                    Empleado empleado = new Empleado();
                    empleado.ID = Convert.ToInt32(Dt.Lector["ID"]);
                    empleado.IDPersona = Convert.ToInt32(Dt.Lector["IDPersona"]);
                    empleado.IDCargoEmpleado = Convert.ToInt32(Dt.Lector["IDCargoEmpleado"]);
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

        public bool AgregarEmpleado(Empleado empleado)
        {
            try
            {
                Dt.setearConsulta("insert into Empleados(IDPersona,IDCargoEmpleado,NombreUsuario,Clave)" + "OUTPUT INSERTED.Id VALUES (@IDPersona,@IDCargoEmpleado,@NombreUsuario,@Clave)");
                Dt.agregarParametro("@IDPersona", empleado.IDPersona);
                Dt.agregarParametro("@IDCargoEmpleado", empleado.IDCargoEmpleado);
                return Dt.ejecutarAccion();

            }
            catch (Exception)
            {
                throw;
            }
            finally { Dt.cerrarConexion(); }
        }










    }
}
