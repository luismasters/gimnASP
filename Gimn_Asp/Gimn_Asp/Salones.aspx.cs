using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace Gimn_Asp
{
    public partial class Salones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarSalones();
            }
        }

        private void CargarSalones()
        {
            try
            {
                SalonNegocio salonNegocio = new SalonNegocio();
                List<Salon> salones = salonNegocio.ListarSalones();
                gvSalones.DataSource = salones;
                gvSalones.DataBind();
            }
            catch (Exception ex)
            {
                lblMensajeSalon.Text = "Error al cargar los salones: " + ex.Message;
            }
        }

        protected void btnAgregarSalon_Click(object sender, EventArgs e)
        {
            try
            {
                Salon salon = new Salon
                {
                    Nombre = txtNombreSalon.Text,
                    capacidad = int.Parse(txtCapacidad.Text)
                };

                SalonNegocio salonNegocio = new SalonNegocio();
                string errorMessage;
                bool exito = salonNegocio.AgregarSalon(salon, out errorMessage);

                if (exito)
                {
                    lblMensajeSalon.ForeColor = System.Drawing.Color.Green;
                    lblMensajeSalon.Text = "Salón agregado con éxito.";
                    CargarSalones();
                }
                else
                {
                    lblMensajeSalon.ForeColor = System.Drawing.Color.Red;
                    lblMensajeSalon.Text = errorMessage;
                }
            }
            catch (Exception ex)
            {
                lblMensajeSalon.ForeColor = System.Drawing.Color.Red;
                lblMensajeSalon.Text = "Error al agregar el salón: " + ex.Message;
            }
        }

        protected void gvSalones_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int idSalon = Convert.ToInt32(gvSalones.DataKeys[e.RowIndex].Value);
                SalonNegocio salonNegocio = new SalonNegocio();
                string errorMessage;
                bool exito = salonNegocio.EliminarSalon(idSalon, out errorMessage);

                if (exito)
                {
                    lblMensajeSalon.ForeColor = System.Drawing.Color.Green;
                    lblMensajeSalon.Text = "Salón eliminado con éxito.";
                    CargarSalones();
                }
                else
                {
                    lblMensajeSalon.ForeColor = System.Drawing.Color.Red;
                    lblMensajeSalon.Text = errorMessage;
                }
            }
            catch (Exception ex)
            {
                lblMensajeSalon.ForeColor = System.Drawing.Color.Red;
                lblMensajeSalon.Text = "Error al eliminar el salón: " + ex.Message;
            }
        }
    }
}