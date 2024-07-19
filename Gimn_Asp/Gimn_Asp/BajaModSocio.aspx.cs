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
    public partial class BajaModSocio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Código para ejecutar al cargar la página, si es necesario
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
                lblMensaje.Text = "Persona encontrada.";
            }
            else
            {
                lblMensaje.Text = "Persona no encontrada.";
                txtNombre.Text = "";
                txtApellido.Text = "";
                txtEmail.Text = "";
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
                    lblMensaje.Text = "Persona actualizada correctamente.";
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
                    txtNombre.Text = "";
                    txtApellido.Text = "";
                    txtEmail.Text = "";
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
    }
}