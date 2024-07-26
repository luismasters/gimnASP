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
            try
            {
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

                lblError.Visible = false;
            }
            catch (Exception ex)
            {
                lblError.Text = "Error al cargar el horario: " + ex.Message;
                lblError.Visible = true;
            }
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fechaInicio = DateTime.Parse(txtFechaInicio.Text);
                DateTime fechaFin = DateTime.Parse(txtFechaFin.Text);
                CargarHorarioInstructor(fechaInicio, fechaFin);
            }
            catch (Exception ex)
            {
                lblError.Text = "Error al filtrar: " + ex.Message;
                lblError.Visible = true;
            }
        }

        private int ObtenerIdInstructorActual()
        {
            try
            {
                return Convert.ToInt32(Session["EmpleadoID"]);
            }
            catch (Exception)
            {
                throw new Exception("No se pudo obtener el ID del instructor. Por favor, inicie sesión nuevamente.");
            }
        }
    }
}