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
        private MiembroNegocio miembroNegocio = new MiembroNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPersonas();
            }
        }

        protected void LoadPersonas()
        {
            List<Miembro> miembros = miembroNegocio.ListarUltimosMiembros();
            Session["Personas"] = miembros; // Guardar la lista completa en sesión para filtrar
            BindListBox(miembros);
        }

        protected void BindListBox(List<Miembro> miembros)
        {
            lstPersonas.DataSource = miembros;
            lstPersonas.DataTextField = "NombreCompleto"; // Usar una propiedad combinada para mostrar nombre completo
            lstPersonas.DataValueField = "DNI";
            lstPersonas.DataBind();
        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string filter = txtBuscar.Text.ToLower();
            List<Miembro> miembros = Session["Personas"] as List<Miembro>;

            if (!string.IsNullOrWhiteSpace(filter))
            {
                miembros = miembros.Where(p =>
                    p.DNI.ToLower().Contains(filter) ||
                    p.Nombre.ToLower().Contains(filter) ||
                    p.Apellido.ToLower().Contains(filter)).ToList();
            }

            BindListBox(miembros);
        }

        protected void lstPersonas_SelectedIndexChanged(object sender, EventArgs e)
        {
            string dni = lstPersonas.SelectedValue;
            Persona persona = personaNegocio.BuscarPersona(dni);
            if (persona != null)
            {

                Miembro miembro = new Miembro();

                miembro = miembroNegocio.BuscarUltimoRegMiembro(persona.IDPersona);

                if (miembro != null)
                {
                    TipoMembresia tipoMembresia = new TipoMembresia();
                    TipoMembresiaNegocio tipoMembresiaNegocio = new TipoMembresiaNegocio();
                    tipoMembresia = tipoMembresiaNegocio.BuscarMembresia(miembro.TipoMembresia);

                    lblNombre.Text = $"{miembro.Nombre} {miembro.Apellido}";
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
