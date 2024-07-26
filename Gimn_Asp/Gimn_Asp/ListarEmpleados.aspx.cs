using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace Gimn_Asp
{
    public partial class ListarEmpleados : System.Web.UI.Page
    {



        protected void Page_Load(object sender, EventArgs e)
        {



            if (Convert.ToInt32(Session["Rol"]) != 1)
            {
                Response.Redirect("Login.aspx");


            }


            if (!IsPostBack)
            {
                CargarEmpleados();
            }
        }

        private void CargarEmpleados()
        {
            EmpleadoNegocio negocio = new EmpleadoNegocio();
            gvEmpleados.DataSource = negocio.ListarEmpleados();
            gvEmpleados.DataBind();
        }

        protected void gvEmpleados_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int idEmpleado = Convert.ToInt32(e.CommandArgument);
            EmpleadoNegocio negocio = new EmpleadoNegocio();

            if (e.CommandName == "Modificar")
            {
                // Redirigir a la página de modificación
                Response.Redirect($"ModificarEmpleado.aspx?id={idEmpleado}");
            }
            else if (e.CommandName == "CambiarEstado")
            {
                try
                {
                    bool nuevoEstado = !negocio.ObtenerEstadoActivo(idEmpleado);
                    negocio.CambiarEstadoActivo(idEmpleado, nuevoEstado);
                    lblMensaje.Text = nuevoEstado ? "Empleado activado con éxito." : "Empleado dado de baja con éxito.";
                    CargarEmpleados(); // Recargar la lista para reflejar los cambios
                }
                catch (Exception ex)
                {
                    lblMensaje.Text = "Error al cambiar el estado del empleado: " + ex.Message;
                }
            }
        }
    }
}