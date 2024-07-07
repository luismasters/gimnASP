using Dominio;
using Negocio;
using System;
using System.Web.UI;

namespace Gimn_Asp
{
    public partial class UserDashboar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDatosMiembro();
                CargarImagenMiembro();
            }
        }

        private void CargarDatosMiembro()
        {
            if (Session["MiembroID"] != null)
            {
                lblDNI.Text = Session["DNI"].ToString();
                lblNombre.Text = Session["Nombre"].ToString();
                lblApellido.Text = Session["Apellido"].ToString();
                lblTipoMembresia.Text = Session["TipoMembresia"].ToString();

                DateTime fechaInicio = (DateTime)Session["FechaInicio"];
                DateTime fechaFin = (DateTime)Session["FechaFin"];

                lblUltimoPeriodo.Text = $"Último Período: {fechaInicio:dd/MM/yyyy} al {fechaFin:dd/MM/yyyy}";

                if (fechaFin >= DateTime.Today)
                {
                    lblEstadoMembresia.Text = "Membresía Activa";
                    lblFechaProximoVencimiento.Text = "Fecha del próximo vencimiento: " + fechaFin.ToString("yyyy-MM-dd");
                    panelVencimiento.Visible = true;
                    lblEstadoMembresia.CssClass = "text-success";
                }
                else
                {
                    lblEstadoMembresia.Text = "Tu membresía expiró el " + fechaFin.ToString("yyyy-MM-dd") + ". Te esperamos para mejorar tu salud física.";
                    panelVencimiento.Visible = false;
                    lblEstadoMembresia.CssClass = "text-danger";
                }
            }
        }

        private void CargarImagenMiembro()
        {
            if (Session["IDPersona"] != null)
            {
                int idPersona = (int)Session["IDPersona"];
                ImagenNegocio imagenNegocio = new ImagenNegocio();
                Imagen imagen = imagenNegocio.CargarImagenPorIDPersona(idPersona);
                imgPerfil.ImageUrl = imagenNegocio.UrlPerfilImagen(imagen);
            }
        }

      

    }
}
