using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace Gimn_Asp
{
    public partial class DetalleReservas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int horarioId;
                if (int.TryParse(Request.QueryString["HorarioID"], out horarioId))
                {
                    CargarReservas(horarioId);
                }
                else
                {
                    // Manejar el caso en que el ID no sea válido
               
                }
            }
        }

        private void CargarReservas(int horarioId)
        {
            ReservaNegocio reservaNegocio = new ReservaNegocio();
            List<Reserva> reservas = reservaNegocio.ObtenerReservasPorHorario(horarioId);
            gvReservas.DataSource = reservas;
            gvReservas.DataBind();
        }
    }
}
