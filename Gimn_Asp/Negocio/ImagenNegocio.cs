using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ImagenNegocio
    {
        private AccesoDatos DT;

        public ImagenNegocio()
        {
            DT = new AccesoDatos();
        }

        public bool AgregarImagen(Imagen imagen)
        {
            try
            {
                DT.setearConsulta("INSERT INTO Imagenes (IDPersona, Archivo) VALUES (@IDPersona, @Archivo)");

                DT.agregarParametro("@IDPersona", imagen.IDPersona);
                DT.agregarParametro("@Archivo", imagen.Archivo);

                return DT.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar la imagen", ex);
            }
            finally
            {
                DT.cerrarConexion();
            }
        }


        // Método para insertar una imagen en la base de datos
        public bool InsertarImagen(int idPersona, byte[] datosImagen)
        {
            try
            {
                DT.setearConsulta("INSERT INTO Imagenes (IDPersona, Archivo) VALUES (@IDPersona, @Archivo)");

                DT.agregarParametro("@IDPersona", idPersona);
                DT.agregarParametro("@Archivo", datosImagen);

                return DT.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar la imagen", ex);
            }
            finally
            {
                DT.cerrarConexion();
            }
        }

        public Imagen CargarImagenPorIDPersona(int idPersona)
        {
            try
            {
                // Establecer la consulta SQL para seleccionar los datos de la imagen
                DT.setearConsulta("SELECT ID, IDPersona, Archivo FROM Imagenes WHERE IDPersona = @IDPersona");

                // Agregar parámetro para el ID de la persona a la consulta
                DT.agregarParametro("@IDPersona", idPersona);

                // Ejecutar la consulta para obtener los datos de la imagen
                DT.ejecutarLectura();

                // Verificar si se encontraron resultados
                if (DT.Lector.Read())
                {
                    // Leer los datos de la imagen desde la base de datos
                    Imagen imagen = new Imagen
                    {
                        ID = Convert.ToInt32(DT.Lector["ID"]),
                        IDPersona = Convert.ToInt32(DT.Lector["IDPersona"]),
                        Archivo = (byte[])DT.Lector["Archivo"]
                    };

                    // Devolver la instancia de la clase Imagen con los datos de la imagen cargados
                    return imagen;
                }

                // Si no se encuentra ninguna imagen para el ID de persona especificado, devolver null
                return null;
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción y relanzarla
                throw new Exception("Error al cargar la imagen", ex);
            }
            finally
            {
                // Cerrar la conexión después de ejecutar la consulta
                DT.cerrarConexion();
            }
        }

        public string UrlPerfilImagen(Imagen imagen)
        {

            if(imagen != null && imagen.Archivo!=null)
            {
              string base64String = Convert.ToBase64String(imagen.Archivo);
             return  "data:image/jpeg;base64," + base64String;



            }

            return "https://www.shutterstock.com/image-vector/blank-avatar-photo-place-holder-600nw-1095249842.jpg";


        }

    }
}
