using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gimn_Asp
{
    public partial class AgregarSocio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            string DNI = txtDNI.Text;

            PersonaNegocio personaNegocio = new PersonaNegocio();
            Persona persona = new Persona();
            persona = personaNegocio.BuscarPersona(DNI);

            if (persona != null)
            {
                // Verificar si se seleccionó un archivo
                if (fileUploadImagen.HasFile)
                {
                    // Obtener los datos binarios de la imagen
                    byte[] datosImagen = fileUploadImagen.FileBytes;

                    // Obtener el ID de la persona desde algún lugar, por ejemplo, un control TextBox





                    int idPersona = persona.ID;

                    // Instanciar la clase ImagenNegocio
                    ImagenNegocio negocioImagen = new ImagenNegocio();

                    try
                    {
                        // Insertar la imagen en la base de datos
                        negocioImagen.InsertarImagen(idPersona, datosImagen);
                        lblMensaje.Text = "La imagen se guardó correctamente en la base de datos.";
                    }
                    catch (Exception ex)
                    {
                        lblMensaje.Text = "Error al guardar la imagen: " + ex.Message;
                    }
                }
                else
                {
                    // Mostrar un mensaje de error si no se seleccionó un archivo
                    lblMensaje.Text = "Por favor seleccione un archivo.";
                }





            }
            else
            {
                lblMensaje.Text = "EL Dni no esta registrado";


            }


        }


    }
}