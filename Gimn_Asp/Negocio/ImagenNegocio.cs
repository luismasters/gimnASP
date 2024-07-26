using Dominio;
using System;
using System.Data.SqlClient;

namespace Negocio
{
    public class ImagenNegocio
    {
        private AccesoDatos DT;
        public ImagenNegocio()
        {
            DT = new AccesoDatos();
        }

        public bool GuardarOActualizarImagen(int idPersona, byte[] datosImagen)
        {
            try
            {
                Imagen imagenExistente = CargarImagenPorIDPersona(idPersona);

                if (imagenExistente == null)
                {
                    // Si no existe, insertamos una nueva imagen
                    return InsertarImagen(idPersona, datosImagen);
                }
                else
                {
                    // Si existe, actualizamos la imagen
                    return ActualizarImagen(idPersona, datosImagen);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar o actualizar la imagen", ex);
            }
        }

        public bool InsertarImagen(int idPersona2, byte[] datosImagen)
        {
            try
            {
                DT.setearConsulta("INSERT INTO Imagenes (IDPersona, Archivo) VALUES (@IDPersona2, @Archivo)");
                DT.agregarParametro("@IDPersona2", idPersona2);
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

        public bool ActualizarImagen(int idPersona1, byte[] datosImagen)
        {
            try
            {
                DT.setearConsulta("UPDATE Imagenes SET Archivo = @Archivo WHERE IDPersona = @IDPersona1");
                DT.agregarParametro("@IDPersona1", idPersona1);
                DT.agregarParametro("@Archivo", datosImagen);
                return DT.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar la imagen", ex);
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
                DT.setearConsulta("SELECT ID, IDPersona, Archivo FROM Imagenes WHERE IDPersona = @IDPersona");
                DT.agregarParametro("@IDPersona", idPersona);
                DT.ejecutarLectura();

                if (DT.Lector.Read())
                {
                    Imagen imagen = new Imagen
                    {
                        ID = Convert.ToInt32(DT.Lector["ID"]),
                        IDPersona = Convert.ToInt32(DT.Lector["IDPersona"]),
                        Archivo = (byte[])DT.Lector["Archivo"]
                    };
                    return imagen;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cargar la imagen", ex);
            }
            finally
            {
                DT.cerrarConexion();
            }
        }

        public string UrlPerfilImagen(Imagen imagen)
        {
            if (imagen != null && imagen.Archivo != null)
            {
                string base64String = Convert.ToBase64String(imagen.Archivo);
                return "data:image/jpeg;base64," + base64String;
            }
            return "https://www.shutterstock.com/image-vector/blank-avatar-photo-place-holder-600nw-1095249842.jpg";
        }
    }
}