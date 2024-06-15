using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gimn_Asp
{
    public partial class AgragarActividades : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarClasesSalon();
            }
        }

     

        private void CargarClasesSalon()
        {
            try
            {
                ClaseSalonNegocio claseSalonNegocio = new ClaseSalonNegocio();
                List<ClaseSalon> clasesSalon = claseSalonNegocio.ListarClasesSalon();
                gvClasesSalon.DataSource = clasesSalon;
                gvClasesSalon.DataBind();
            }
            catch (Exception ex)
            {
                lblMensajeClaseSalon.Text = "Error al cargar las clases de salón: " + ex.Message;
            }
        }

   

        protected void btnAgregarClaseSalon_Click(object sender, EventArgs e)
        {
            try
            {
                ClaseSalon claseSalon = new ClaseSalon
                {
                    NombreClase = txtNombreClaseSalon.Text
                };

                ClaseSalonNegocio claseSalonNegocio = new ClaseSalonNegocio();
                string errorMessage;
                bool exito = claseSalonNegocio.AgregarClaseSalon(claseSalon, out errorMessage);

                if (exito)
                {
                    lblMensajeClaseSalon.ForeColor = System.Drawing.Color.Green;
                    lblMensajeClaseSalon.Text = "Clase de salón agregada con éxito.";
                    CargarClasesSalon(); // Volver a cargar la lista de clases de salón para incluir la nueva
                }
                else
                {
                    lblMensajeClaseSalon.ForeColor = System.Drawing.Color.Red;
                    lblMensajeClaseSalon.Text = errorMessage;
                }
            }
            catch (Exception ex)
            {
                lblMensajeClaseSalon.ForeColor = System.Drawing.Color.Red;
                lblMensajeClaseSalon.Text = "Error al agregar la clase de salón: " + ex.Message;
            }
        }

        

        protected void gvClasesSalon_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int idClaseSalon = Convert.ToInt32(gvClasesSalon.DataKeys[e.RowIndex].Value);
                ClaseSalonNegocio claseSalonNegocio = new ClaseSalonNegocio();
                string errorMessage;
                bool exito = claseSalonNegocio.EliminarClaseSalon(idClaseSalon, out errorMessage);

                if (exito)
                {
                    lblMensajeClaseSalon.ForeColor = System.Drawing.Color.Green;
                    lblMensajeClaseSalon.Text = "Clase de salón eliminada con éxito.";
                    CargarClasesSalon(); // Volver a cargar la lista de clases de salón para reflejar los cambios
                }
                else
                {
                    lblMensajeClaseSalon.ForeColor = System.Drawing.Color.Red;
                    lblMensajeClaseSalon.Text = errorMessage;
                }
            }
            catch (Exception ex)
            {
                lblMensajeClaseSalon.ForeColor = System.Drawing.Color.Red;
                lblMensajeClaseSalon.Text = "Error al eliminar la clase de salón: " + ex.Message;
            }
        }
    }
}