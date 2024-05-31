using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class CobroNegocio
    {
        private AccesoDatos DT;
        public CobroNegocio()
        {
            DT = new AccesoDatos();
        }

        public List<Cobro> listarCobros()
        {
            List<Cobro> cobros = new List<Cobro>();
            try
            {
                DT.setearConsulta("select ID,IDPersona,IDTipoMembresia,FechaCobro from Cobros");
                DT.ejecutarLectura();
                while (DT.Lector.Read())
                {
                    Cobro cobro = new Cobro();
                    cobro.ID = Convert.ToInt32(DT.Lector["ID"]);
                    cobro.IDPersona = Convert.ToInt32(DT.Lector["IDPersona"]);
                    cobro.IDTipoMembresia = Convert.ToInt32(DT.Lector["IDTipoMembresia"]);
                    cobro.FechaCobro = Convert.ToDateTime(DT.Lector["FechaCobro"]);
                    cobros.Add(cobro);
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
            return cobros;
        }


        public bool AgregarCobro(Cobro cobro)
        {
            try
            {
                // Establecer la consulta para insertar un nuevo cobro
                DT.setearConsulta("INSERT INTO Cobros (IDPersonas, IDTipoMembresia, FechaCobro) VALUES (@IDPersona, @IDTipoMembresia, @FechaCobro)");

                // Agregar parámetros a la consulta
                DT.agregarParametro("@IDPersona", cobro.IDPersona);
                DT.agregarParametro("@IDTipoMembresia", cobro.IDTipoMembresia);
                DT.agregarParametro("@FechaCobro", cobro.FechaCobro);

                // Ejecutar la acción de inserción y obtener el resultado
                bool resultado = DT.ejecutarAccion();

                // Registro de depuración
                Console.WriteLine($"AgregarCobro: IDPersona={cobro.IDPersona}, IDTipoMembresia={cobro.IDTipoMembresia}, FechaCobro={cobro.FechaCobro}, Resultado={resultado}");

                return resultado;
            }
            catch (Exception ex)
            {
                // Registro de error
                Console.WriteLine($"Error al agregar el cobro: {ex.Message}");
                throw new Exception("Error al agregar el cobro", ex);
            }
            finally
            {
                // Cerrar la conexión a la base de datos
                DT.cerrarConexion();
            }
        }
    }
}
