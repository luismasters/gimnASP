using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace Gimn_Asp
{
    public partial class VerificarReservasAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {



            if (Convert.ToInt32(Session["Rol"]) != 2)
            {
                Response.Redirect("Login.aspx");


            }


            if (!IsPostBack)
            {
                CargarHorariosClases();
            }
        }

        private void CargarHorariosClases()
        {
            HorarioClaseNegocio negocio = new HorarioClaseNegocio();
            List<HorarioClase> horarios = negocio.ListarHorariosDisponibles();
            gvHorariosClases.DataSource = horarios;
            gvHorariosClases.DataBind();
        }

        protected void gvHorariosClases_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "VerReservas")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int horarioId = Convert.ToInt32(gvHorariosClases.DataKeys[index].Value);

                // Redirigir a la página de detalle de reservas con el ID del horario
                Response.Redirect($"DetalleReservas.aspx?HorarioID={horarioId}");
            }
        }
    }
}
