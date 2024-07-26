using Dominio;
using Negocio;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gimn_Asp
{
    public partial class BajaModSocio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                panel.Visible = false;
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string dni = txtDNI.Text.Trim();
            if (string.IsNullOrEmpty(dni))
            {
                lblMensaje.Text = "Por favor, ingrese un DNI.";
                return;
            }

            PersonaNegocio personaNegocio = new PersonaNegocio();
            Persona persona = personaNegocio.BuscarPersona(dni);

            if (persona != null)
            {
                txtNombre.Text = persona.Nombre;
                txtApellido.Text = persona.Apellido;
                txtEmail.Text = persona.Email;

                // Cargar la imagen si existe
                ImagenNegocio imagenNegocio = new ImagenNegocio();
                Imagen imagen = imagenNegocio.CargarImagenPorIDPersona(persona.IDPersona);
                if (imagen != null)
                {
                    imgPerfil.ImageUrl = imagenNegocio.UrlPerfilImagen(imagen);
                }
                else
                {
                    imgPerfil.ImageUrl = "ruta/a/imagen/por/defecto.jpg";
                }

                panel.Visible = true;
                lblMensaje.Text = "Persona encontrada.";
            }
            else
            {
                lblMensaje.Text = "Persona no encontrada.";
                LimpiarCampos();
                panel.Visible = false;
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            string dni = txtDNI.Text.Trim();
            if (string.IsNullOrEmpty(dni))
            {
                lblMensaje.Text = "Por favor, ingrese un DNI.";
                return;
            }

            PersonaNegocio personaNegocio = new PersonaNegocio();
            Persona persona = personaNegocio.BuscarPersona(dni);

            if (persona != null)
            {
                persona.Nombre = txtNombre.Text.Trim();
                persona.Apellido = txtApellido.Text.Trim();
                persona.Email = txtEmail.Text.Trim();

                string errorMessage;
                bool success = personaNegocio.ActualizarPersona(persona, out errorMessage);

                if (success)
                {
                    // Actualizar la imagen si se ha subido una nueva
                    if (fileUploadImagen.HasFile)
                    {
                        ImagenNegocio imagenNegocio = new ImagenNegocio();
                        byte[] datosImagen = fileUploadImagen.FileBytes;
                        bool imagenGuardada = imagenNegocio.GuardarOActualizarImagen(persona.IDPersona, datosImagen);

                        if (imagenGuardada)
                        {
                            lblMensaje.Text = "Persona e imagen actualizadas correctamente.";
                        }
                        else
                        {
                            lblMensaje.Text = "Persona actualizada, pero hubo un problema al guardar la imagen.";
                        }
                    }
                    else
                    {
                        lblMensaje.Text = "Persona actualizada correctamente.";
                    }
                }
                else
                {
                    lblMensaje.Text = "Error al actualizar la persona: " + errorMessage;
                }
            }
            else
            {
                lblMensaje.Text = "Persona no encontrada.";
            }
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            string dni = txtDNI.Text.Trim();
            if (string.IsNullOrEmpty(dni))
            {
                lblMensaje.Text = "Por favor, ingrese un DNI.";
                return;
            }

            PersonaNegocio personaNegocio = new PersonaNegocio();
            Persona persona = personaNegocio.BuscarPersona(dni);

            if (persona != null)
            {
                bool success = personaNegocio.EliminarPersona(persona.IDPersona);
                if (success)
                {
                    lblMensaje.Text = "Persona eliminada correctamente.";
                    LimpiarCampos();
                    panel.Visible = false;
                }
                else
                {
                    lblMensaje.Text = "Error al eliminar la persona.";
                }
            }
            else
            {
                lblMensaje.Text = "Persona no encontrada.";
            }
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtEmail.Text = "";
            imgPerfil.ImageUrl = "";
        }
    }
}