using System;
using System.Collections.Generic;
using System.Linq;
using Dominio;
using Negocio;

namespace Gimn_Asp
{
    public partial class HorarioInstructor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarHorarioInstructor();
            }
        }

        private void CargarHorarioInstructor(DateTime? fechaInicio = null, DateTime? fechaFin = null)
        {
            // Aquí deberías obtener el ID del instructor actual (por ejemplo, de la sesión)
            int idInstructorActual = ObtenerIdInstructorActual();

            HorarioClaseNegocio horarioClaseNegocio = new HorarioClaseNegocio();
            List<HorarioClase> horariosInstructor;

            if (fechaInicio.HasValue && fechaFin.HasValue)
            {
                horariosInstructor = horarioClaseNegocio.ListarHorariosClasesPorInstructor(idInstructorActual, fechaInicio.Value, fechaFin.Value);
            }
            else
            {
                horariosInstructor = horarioClaseNegocio.ListarHorariosClasesPorInstructor(idInstructorActual);
            }

            gvHorarioInstructor.DataSource = horariosInstructor;
            gvHorarioInstructor.DataBind();
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            DateTime fechaInicio = DateTime.Parse(txtFechaInicio.Text);
            DateTime fechaFin = DateTime.Parse(txtFechaFin.Text);
            CargarHorarioInstructor(fechaInicio, fechaFin);
        }

        private int ObtenerIdInstructorActual()
        {
            // Implementa la lógica para obtener el ID del instructor actual
            // Por ejemplo, podrías obtenerlo de la sesión si lo has guardado allí al iniciar sesión
            return Convert.ToInt32(Session["EmpleadoID"]);
        }
    }
}