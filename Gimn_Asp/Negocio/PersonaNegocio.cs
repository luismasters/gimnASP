using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class PersonaNegocio
    {
        private AccesoDatos DT;
        public PersonaNegocio()
        {
            DT = new AccesoDatos();
        }

        public List<Persona> listarPersona()
        {
            List<Persona> personas = new List<Persona>();
            try
            {
                DT.setearConsulta("select ID,DNI,Nombre,Apellido,Email,FechaNacimiento from Personas");
                DT.ejecutarLectura();
                while (DT.Lector.Read())
                {
                    Persona persona = new Persona();
                    persona.IDPersona = Convert.ToInt32(DT.Lector["ID"]);
                    persona.DNI = DT.Lector["DNI"].ToString();
                    persona.Nombre = DT.Lector["Nombre"].ToString();
                    persona.Apellido = DT.Lector["Apellido"].ToString();
                    persona.Email = DT.Lector["Email"].ToString();
                    persona.FechaNacimiento = (DateTime)DT.Lector["FechaNacimiento"];
                    personas.Add(persona);
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
            return personas;
        }
        public bool AgregarPersona(Persona persona)
        {
            try
            {

                DT.setearConsulta("insert into Personas(DNI,Nombre,Apellido,Email,FechaNacimiento)" + "OUTPUT INSERTED.Id VALUES (@DNIP,@Nombre,@Apellido,@Email,@FechaNacimiento)");
                DT.agregarParametro("@DNIP", persona.DNI);
                DT.agregarParametro("@Nombre", persona.Nombre);
                DT.agregarParametro("@Apellido", persona.Apellido);
                DT.agregarParametro("@Email", persona.Email);
                DT.agregarParametro("@FechaNacimiento", persona.FechaNacimiento);

                return DT.ejecutarAccion();
            }
            catch (Exception)
            {
                throw;
            }
            finally { DT.cerrarConexion(); }

        }


        public bool DNIRegistrado(string DNI)
        {
            PersonaNegocio PersonaNegocio = new PersonaNegocio();
            List<Persona> lista = new List<Persona>();
            lista = PersonaNegocio.listarPersona();
            foreach (Persona persona in lista)
            {
                if (persona.DNI == DNI)
                {
                    return true;
                }
            }
            return false;
        }






        public Persona BuscarPersona(string dni)
        {
            Persona persona = null; // Inicializa persona como null para manejar casos en los que no se encuentra
            try
            {
                // Configura la consulta SQL
                DT.setearConsulta("SELECT ID, DNI, Nombre, Apellido, Email, FechaNacimiento FROM Personas WHERE DNI = @DNI");

                // Agrega el parámetro a la consulta
                DT.agregarParametro("@DNI", dni);

                // Ejecuta la consulta
                DT.ejecutarLectura();

                // Procesa los resultados de la consulta
                if (DT.Lector.Read())
                {
                    persona = new Persona(); // Crea una nueva instancia de Persona solo si hay resultados
                    persona.IDPersona = Convert.ToInt32(DT.Lector["ID"]);
                    persona.DNI = DT.Lector["DNI"].ToString();
                    persona.Nombre = DT.Lector["Nombre"].ToString();
                    persona.Apellido = DT.Lector["Apellido"].ToString();
                    persona.Email = DT.Lector["Email"].ToString();
                    persona.FechaNacimiento = (DateTime)DT.Lector["FechaNacimiento"];
                }
            }
            catch (Exception ex)
            {
                // Maneja la excepción y registra el error
                Console.Error.WriteLine($"Error al buscar persona con DNI {dni}: {ex.Message}");
                // Puedes lanzar una excepción más específica si es necesario
                throw new Exception($"Error al buscar persona con DNI {dni}", ex);
            }
            finally
            {
                // Asegúrate de cerrar la conexión y limpiar parámetros
                DT.cerrarConexion();
                DT.limpiarParametros(); // Limpia los parámetros después de cada consulta
            }

            return persona; // Devuelve la persona o null si no se encuentra
        }

    }
}