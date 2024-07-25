using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class TipoMembresiaNegocio
    {
        private AccesoDatos Dt;

        public TipoMembresiaNegocio()
        {
            Dt = new AccesoDatos();
        }
        public List<TipoMembresia> ListarTiposMembresias()
        {
            List<TipoMembresia> tipoMembresias = new List<TipoMembresia>();
            try
            {
                Dt.setearConsulta("select ID,Descripcion,Precio from TiposMembresias");
                Dt.ejecutarLectura();
                while (Dt.Lector.Read())
                {
                    TipoMembresia tipoMembresia = new TipoMembresia();
                    tipoMembresia.ID = Convert.ToInt32(Dt.Lector["ID"]);
                    tipoMembresia.Descripcion = Convert.ToString(Dt.Lector["Descripcion"]);
                    tipoMembresia.Precio = Convert.ToDecimal(Dt.Lector["Precio"]);
                    tipoMembresias.Add(tipoMembresia);
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
            return tipoMembresias;
        }

           public TipoMembresia BuscarMembresia(int ID) {

            TipoMembresia ti=new TipoMembresia();

            try
            {
                Dt.setearConsulta("select ID,Descripcion,Precio from TiposMembresias where ID=@ID");
                Dt.agregarParametro("@ID", ID);
                Dt.ejecutarLectura();


                while(Dt.Lector.Read())
                {
                    ti.ID = Convert.ToInt32(Dt.Lector["ID"]);
                    ti.Descripcion = Convert.ToString(Dt.Lector["Descripcion"]);
                    ti.Precio = Convert.ToDecimal(Dt.Lector["Precio"]);

                }

            }
            catch (Exception)
            {

                throw;
            }
            
            finally { Dt.cerrarConexion();}



            return ti;
        }
        public bool EliminarTipoMembresia(int id)
        {
            try
            {
                Dt.setearConsulta("DELETE FROM TiposMembresias WHERE ID = @ID");
                Dt.agregarParametro("@ID", id);
                return Dt.ejecutarAccion();
            }
            catch (Exception)
            {
                throw;
            }
            finally { Dt.cerrarConexion(); }
        }

        public bool ModificarTipoMembresia(TipoMembresia tipoMembresia)
        {
            try
            {
                Dt.setearConsulta("UPDATE TiposMembresias SET Descripcion = @Descripcion, Precio = @Precio WHERE ID = @ID");
                Dt.agregarParametro("@ID", tipoMembresia.ID);
                Dt.agregarParametro("@Descripcion", tipoMembresia.Descripcion);
                Dt.agregarParametro("@Precio", tipoMembresia.Precio);
                return Dt.ejecutarAccion();
            }
            catch (Exception)
            {
                throw;
            }
            finally { Dt.cerrarConexion(); }
        }

        public bool AgregarTipoMembresia(TipoMembresia tipoMembresia)
        {
            try
            {
                Dt.setearConsulta("insert into TiposMembresias(Descripcion,Precio)" + "OUTPUT INSERTED.Id VALUES (@Descripcion,@Precio)");
                Dt.agregarParametro("@Descripcion", tipoMembresia.Descripcion);
                Dt.agregarParametro("@Precio", tipoMembresia.Precio);
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
