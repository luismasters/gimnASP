using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Web.UI;

namespace Gimn_Asp
{
    public partial class VerReservas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {



            if (Convert.ToInt32(Session["Rol"]) != 2)
            {
                Response.Redirect("Login.aspx");


            }
            if (!IsPostBack)
            {
                CargarReservas();
            }
        }

        private void CargarReservas()
        {
            if (Session["MiembroID"] != null)
            {
                int idMiembro = Convert.ToInt32(Session["MiembroID"]);
                ReservaNegocio reservaNegocio = new ReservaNegocio();
                List<Reserva> reservas = reservaNegocio.ObtenerReservasPorMiembro(idMiembro);
                gvReservas.DataSource = reservas;
                gvReservas.DataBind();
            }
            else
            {
                lblMessage.Text = "No se ha encontrado la sesión del miembro.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}
