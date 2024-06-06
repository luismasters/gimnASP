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

                Miembro miembro = new Miembro();
                MiembroNegocio miembroNegocio = new MiembroNegocio();

                miembro = miembroNegocio.BuscarUltimoRegMiembro(persona.ID);

                if (miembro != null)
                {
                    TipoMembresia tipoMembresia = new TipoMembresia();
                    TipoMembresiaNegocio tipoMembresiaNegocio = new TipoMembresiaNegocio();
                    tipoMembresia = tipoMembresiaNegocio.BuscarMembresia(miembro.TipoMembresia);

                    lblNombre.Text = $"{persona.Nombre} {persona.Apellido}";
                    lblTipoMembresia.Text = tipoMembresia.Descripcion;
                    lblFechaInicio.Text = miembro.FechaInicio.ToString("dd/MMMM/yyyy");
                    lblFechaVencimiento.Text = miembro.FechaFin.ToString("dd/MMMM/yyyy");

                    Dominio.Imagen imagen = new Imagen();
                    ImagenNegocio imagenNegocio = new ImagenNegocio();

                     imagen=imagenNegocio.CargarImagenPorIDPersona(miembro.IDPersona);

                    imgFoto.ImageUrl=imagenNegocio.UrlPerfilImagen(imagen);



                    if (miembro.FechaFin >= DateTime.Now)
                    {
                        lblAcceso.Text = "Acceso permitido";
                        lblAcceso.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        lblAcceso.Text = "Membresía vencida";
                        lblAcceso.ForeColor = System.Drawing.Color.Red;
                    }

                    pnlCard.Visible = true;
                }
                else
                {
                    pnlCard.Visible = false;
                }




            }
            else
            {
              
            }
        }
    }
}
