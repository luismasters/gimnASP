﻿using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace Gimn_Asp
{
    public partial class ReservarClases : System.Web.UI.Page
    {





        protected void Page_Load(object sender, EventArgs e)
        {


            
                if (Convert.ToBoolean(Session["vencido"]) == true)
            {

                Session["Mensaje"] = "No puedes realizar reservas.Por favor, renueva tu suscripción para disfrutar de nuestras actividades.";
                Session["URL"] = "UserDashboar.aspx";

                Response.Redirect("Error401.aspx");


                    //string script = "alert('No puedes realizar reservas. Por favor, renueva tu suscripción para disfrutar de nuestras actividades.'); window.location.href='UserDashboar.aspx';";
                   // ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);
                }

            if (Convert.ToInt32(Session["Rol"]) != 5  && Convert.ToInt32(Session["Rol"]) != 7)
            {

                Session["Mensaje"] = "No puedes realizar reservas, Tu membresia no contempla actividades de salon";
                Session["URL"] = "UserDashboar.aspx";

                Response.Redirect("Error401.aspx");
            }




            if (!IsPostBack)
            {
                CargarHorariosDisponibles();
            }
        }

        private void CargarHorariosDisponibles()
        {
            HorarioClaseNegocio negocio = new HorarioClaseNegocio();
            List<HorarioClase> horarios = negocio.ListarHorariosDisponibles();
            gvHorariosDisponibles.DataSource = horarios;
            gvHorariosDisponibles.DataBind();
        }

        public string FormatearFecha(object fecha)
        {
            DateTime fechaClase = (DateTime)fecha;
            return fechaClase.ToString("dddd d 'de' MMMM", new CultureInfo("es-ES"));
        }



        protected void gvHorariosDisponibles_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Reservar")
            {
                // Este es solo un ejemplo para manejar el comando "Reservar"
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvHorariosDisponibles.Rows[index];

                // Obtener ID del miembro desde la sesión
                int idMiembro = Convert.ToInt32(Session["MiembroID"]);

                // Obtener ID del horario de la fila seleccionada
                int horarioId = Convert.ToInt32(gvHorariosDisponibles.DataKeys[index].Value);

                // Obtener IDs de la clase de salón y del salón desde el horario
                HorarioClaseNegocio horarioClaseNegocio = new HorarioClaseNegocio();
                HorarioClase horarioClase = horarioClaseNegocio.ObtenerHorarioClasePorId(horarioId);
                int idClaseSalon = horarioClase.claseSalon.ID;
                int idSalon = horarioClase.salon.ID;

                // Lógica para realizar la reserva
                ReservaNegocio reservaNegocio = new ReservaNegocio();
                string mensajeError;
                bool exito = reservaNegocio.HacerReserva(horarioId, idMiembro, idClaseSalon, idSalon, out mensajeError);

                if (exito)
                {
                    lblMessage.Text = "Reserva realizada con éxito.";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblMessage.Text = mensajeError;
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }

                // Recargar los horarios disponibles
                CargarHorariosDisponibles();
            }
        }
    }
}
