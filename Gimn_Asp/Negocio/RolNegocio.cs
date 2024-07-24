using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class RolNegocio
    {
        private AccesoDatos Dt;

        public RolNegocio()
        {
            Dt = new AccesoDatos();
        }

        public List<Rol> ListarRoles()
        {
            List<Rol> roles = new List<Rol>();
            try
            {
                Dt.setearConsulta("SELECT ID, Nombre FROM Roles");
                Dt.ejecutarLectura();
                while (Dt.Lector.Read())
                {
                    roles.Add(new Rol
                    {
                        ID = Convert.ToInt32(Dt.Lector["ID"]),
                        Descripcion = Dt.Lector["Nombre"].ToString()
                    });
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
            return roles;
        }
    }
}