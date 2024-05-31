using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gimn_Asp
{
    public partial class Socios : Page
    {
        private PersonaNegocio personaNegocio = new PersonaNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPersonas();
            }
        }

        protected void LoadPersonas()
        {
            List<Persona> personas = personaNegocio.listarPersona();
            Session["Personas"] = personas; // Guardar la lista completa en sesión para filtrar
            BindListBox(personas);
        }

        protected void BindListBox(List<Persona> personas)
        {
            lstPersonas.DataSource = personas;
            lstPersonas.DataTextField = "NombreCompleto"; // Usar una propiedad combinada para mostrar nombre completo
            lstPersonas.DataValueField = "DNI";
            lstPersonas.DataBind();
        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string filter = txtBuscar.Text.ToLower();
            List<Persona> personas = Session["Personas"] as List<Persona>;

            if (!string.IsNullOrWhiteSpace(filter))
            {
                personas = personas.Where(p =>
                    p.DNI.ToLower().Contains(filter) ||
                    p.Nombre.ToLower().Contains(filter) ||
                    p.Apellido.ToLower().Contains(filter)).ToList();
            }

            BindListBox(personas);
        }

        protected void lstPersonas_SelectedIndexChanged(object sender, EventArgs e)
        {
            string dni = lstPersonas.SelectedValue;
            Persona persona = personaNegocio.BuscarPersona(dni);
            if (persona != null)
            {
                gvPersonas.DataSource = new List<Persona> { persona };
                gvPersonas.DataBind();
            }
            else
            {
                gvPersonas.DataSource = null;
                gvPersonas.DataBind();
            }
        }
    }
}
