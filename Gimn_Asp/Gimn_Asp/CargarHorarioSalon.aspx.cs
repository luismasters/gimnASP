using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace Gimn_Asp
{
    public partial class CargarHorarioSalon : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarClasesSalon();
                CargarSalones();
                CargarHorariosClases();
            }
        }

        private void CargarClasesSalon()
        {
            try
            {
                ClaseSalonNegocio claseSalonNegocio = new ClaseSalonNegocio();
                List<ClaseSalon> clasesSalon = claseSalonNegocio.ListarClasesSalon();
                ddlClaseSalon.DataSource = clasesSalon;
                ddlClaseSalon.DataTextField = "NombreClase";
                ddlClaseSalon.DataValueField = "ID";
                ddlClaseSalon.DataBind();
            }
            catch (Exception ex)
            {
                lblMensajeHorarioClase.Text = "Error al cargar las clases de salón: " + ex.Message;
            }
        }

        private void CargarSalones()
        {
            try
            {
                SalonNegocio salonNegocio = new SalonNegocio();
                List<Salon> salones = salonNegocio.ListarSalones();
                ddlSalon.DataSource = salones;
                ddlSalon.DataTextField = "Nombre";
                ddlSalon.DataValueField = "ID";
                ddlSalon.DataBind();
            }
            catch (Exception ex)
            {
                lblMensajeHorarioClase.Text = "Error al cargar los salones: " + ex.Message;
            }
        }

        private void CargarHorariosClases(DateTime? fechaInicio = null, DateTime? fechaFin = null)
        {
            try
            {
                HorarioClaseNegocio horarioClaseNegocio = new HorarioClaseNegocio();
                List<HorarioClase> horariosClases;
                if (fechaInicio.HasValue && fechaFin.HasValue)
                {
                    horariosClases = horarioClaseNegocio.ListarHorariosClasesPorSemana(fechaInicio.Value, fechaFin.Value);
                }
                else
                {
                    horariosClases = horarioClaseNegocio.ListarHorariosClases();
                }

                gvHorariosClases.DataSource = horariosClases;
                gvHorariosClases.DataBind();
            }
            catch (Exception ex)
            {
                lblMensajeHorarioClase.Text = "Error al cargar los horarios de clases: " + ex.Message;
            }
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fechaInicio = DateTime.Parse(txtFechaInicio.Text);
                DateTime fechaFin = DateTime.Parse(txtFechaFin.Text);

                if (fechaInicio > fechaFin)
                {
                    lblMensajeHorarioClase.ForeColor = System.Drawing.Color.Red;
                    lblMensajeHorarioClase.Text = "La fecha de inicio no puede ser posterior a la fecha de fin.";
                    return;
                }

                CargarHorariosClases(fechaInicio, fechaFin);
            }
            catch (Exception ex)
            {
                lblMensajeHorarioClase.Text = "Error al filtrar los horarios de clases: " + ex.Message;
            }
        }

        protected void btnAgregarHorarioClase_Click(object sender, EventArgs e)
        {
            try
            {
                HorarioClase horarioClase = new HorarioClase
                {
                    claseSalon = new ClaseSalon { ID = int.Parse(ddlClaseSalon.SelectedValue) },
                    salon = new Salon { ID = int.Parse(ddlSalon.SelectedValue) },
                    Fecha = DateTime.Parse(txtFecha.Text),
                    HoraInicio = txtHoraInicio.Text,
                    HoraFin = txtHoraFin.Text
                };

                HorarioClaseNegocio horarioClaseNegocio = new HorarioClaseNegocio();
                string errorMessage;
                bool exito = horarioClaseNegocio.AgregarHorarioClase(horarioClase, out errorMessage);

                if (exito)
                {
                    lblMensajeHorarioClase.ForeColor = System.Drawing.Color.Green;
                    lblMensajeHorarioClase.Text = "Horario de clase agregado con éxito.";
                    CargarHorariosClases();
                }
                else
                {
                    lblMensajeHorarioClase.ForeColor = System.Drawing.Color.Red;
                    lblMensajeHorarioClase.Text = errorMessage;
                }
            }
            catch (Exception ex)
            {
                lblMensajeHorarioClase.ForeColor = System.Drawing.Color.Red;
                lblMensajeHorarioClase.Text = "Error al agregar el horario de clase: " + ex.Message;
            }
        }

        protected void gvHorariosClases_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int idHorarioClase = Convert.ToInt32(gvHorariosClases.DataKeys[e.RowIndex].Value);
                HorarioClaseNegocio horarioClaseNegocio = new HorarioClaseNegocio();
                bool exito = horarioClaseNegocio.EliminarHorarioClase(idHorarioClase);

                if (exito)
                {
                    lblMensajeHorarioClase.ForeColor = System.Drawing.Color.Green;
                    lblMensajeHorarioClase.Text = "Horario de clase eliminado con éxito.";
                    CargarHorariosClases();
                }
                else
                {
                    lblMensajeHorarioClase.ForeColor = System.Drawing.Color.Red;
                    lblMensajeHorarioClase.Text = "Error al eliminar el horario de clase.";
                }
            }
            catch (Exception ex)
            {
                lblMensajeHorarioClase.ForeColor = System.Drawing.Color.Red;
                lblMensajeHorarioClase.Text = "Error al eliminar el horario de clase: " + ex.Message;
            }
        }
    }
}
