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
            if (Convert.ToInt32(Session["Rol"]) != 1)
            {
                Response.Redirect("Login.aspx");
            }

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
                lblMensaje.Text = "Error al cargar los salones: " + ex.Message;
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
                    lblMensaje.ForeColor = System.Drawing.Color.Green;
                    lblMensaje.Text = "Salón agregado con éxito.";
                    CargarSalones();
                    LimpiarCampos();
                }
                else
                {
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    lblMensaje.Text = "Error al agregar el salón: " + errorMessage;
                }
            }
            catch (Exception ex)
            {
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Text = "Error al agregar el salón: " + ex.Message;
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
                    lblMensaje.ForeColor = System.Drawing.Color.Green;
                    lblMensaje.Text = "Salón eliminado con éxito.";
                    CargarSalones();
                }
                else
                {
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    lblMensaje.Text = "Error al eliminar el salón: " + errorMessage;
                }
            }
            catch (Exception ex)
            {
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Text = "Error al eliminar el salón: " + ex.Message;
            }
        }

        protected void gvSalones_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvSalones.EditIndex = e.NewEditIndex;
            CargarSalones();
        }

        protected void gvSalones_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow row = gvSalones.Rows[e.RowIndex];
                int id = Convert.ToInt32(gvSalones.DataKeys[e.RowIndex].Value);

                TextBox txtNombre = (TextBox)row.FindControl("txtNombre");
                TextBox txtCapacidad = (TextBox)row.FindControl("txtCapacidad");

                if (txtNombre != null && txtCapacidad != null)
                {
                    string nombre = txtNombre.Text;
                    int capacidad;

                    if (int.TryParse(txtCapacidad.Text, out capacidad))
                    {
                        Salon salon = new Salon
                        {
                            ID = id,
                            Nombre = nombre,
                            capacidad = capacidad
                        };

                        SalonNegocio salonNegocio = new SalonNegocio();
                        string errorMessage;
                        bool exito = salonNegocio.ModificarSalon(salon, out errorMessage);

                        if (exito)
                        {
                            lblMensaje.ForeColor = System.Drawing.Color.Green;
                            lblMensaje.Text = "Salón modificado con éxito.";
                            gvSalones.EditIndex = -1;
                            CargarSalones();
                        }
                        else
                        {
                            lblMensaje.ForeColor = System.Drawing.Color.Red;
                            lblMensaje.Text = "Error al modificar el salón: " + errorMessage;
                        }
                    }
                    else
                    {
                        lblMensaje.ForeColor = System.Drawing.Color.Red;
                        lblMensaje.Text = "La capacidad ingresada no es válida.";
                    }
                }
                else
                {
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    lblMensaje.Text = "No se pudieron encontrar los controles de edición.";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Text = "Error al modificar el salón: " + ex.Message;
            }
        }

        protected void gvSalones_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvSalones.EditIndex = -1;
            CargarSalones();
        }

        private void LimpiarCampos()
        {
            txtNombreSalon.Text = string.Empty;
            txtCapacidad.Text = string.Empty;
        }
    }
}