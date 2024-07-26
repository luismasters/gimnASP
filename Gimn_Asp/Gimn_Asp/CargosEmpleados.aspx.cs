using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace Gimn_Asp
{
    public partial class CargosEmpleados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (Convert.ToInt32(Session["Rol"]) != 1)
            {


                Session["Mensaje"] = "Solo el Administrador puede Realizar esta accion. por favor inicia sesion nuevamente";
                Session["URL"] = "Login.aspx";

                Response.Redirect("Error401.aspx");



            }



            if (!IsPostBack)
            {
                CargarCargosEmpleados();
            }
        }

        private void CargarCargosEmpleados()
        {
            try
            {
                CargoEmpleadoNegocio cargoEmpleadoNegocio = new CargoEmpleadoNegocio();
                List<CargoEmpleado> cargosEmpleados = cargoEmpleadoNegocio.ListarCargos();
                gvCargosEmpleados.DataSource = cargosEmpleados;
                gvCargosEmpleados.DataBind();
            }
            catch (Exception ex)
            {
                lblMensajeCargoEmpleado.Text = "Error al cargar los cargos de empleados: " + ex.Message;
            }
        }

        protected void btnAgregarCargoEmpleado_Click(object sender, EventArgs e)
        {
            try
            {
                CargoEmpleado cargo = new CargoEmpleado
                {
                    Descripcion = txtDescripcionCargoEmpleado.Text
                };

                CargoEmpleadoNegocio cargoEmpleadoNegocio = new CargoEmpleadoNegocio();
                bool exito = cargoEmpleadoNegocio.AgregarCargo(cargo);

                if (exito)
                {
                    lblMensajeCargoEmpleado.ForeColor = System.Drawing.Color.Green;
                    lblMensajeCargoEmpleado.Text = "Cargo de empleado agregado con éxito.";
                    CargarCargosEmpleados();
                }
                else
                {
                    lblMensajeCargoEmpleado.ForeColor = System.Drawing.Color.Red;
                    lblMensajeCargoEmpleado.Text = "Error al agregar el cargo de empleado.";
                }
            }
            catch (Exception ex)
            {
                lblMensajeCargoEmpleado.ForeColor = System.Drawing.Color.Red;
                lblMensajeCargoEmpleado.Text = "Error al agregar el cargo de empleado: " + ex.Message;
            }
        }

        protected void gvCargosEmpleados_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int idCargoEmpleado = Convert.ToInt32(gvCargosEmpleados.DataKeys[e.RowIndex].Value);
                CargoEmpleadoNegocio cargoEmpleadoNegocio = new CargoEmpleadoNegocio();
                bool exito = cargoEmpleadoNegocio.EliminarCargoEmpleado(idCargoEmpleado);

                if (exito)
                {
                    lblMensajeCargoEmpleado.ForeColor = System.Drawing.Color.Green;
                    lblMensajeCargoEmpleado.Text = "Cargo de empleado eliminado con éxito.";
                    CargarCargosEmpleados();
                }
                else
                {
                    lblMensajeCargoEmpleado.ForeColor = System.Drawing.Color.Red;
                    lblMensajeCargoEmpleado.Text = "Error al eliminar el cargo de empleado.";
                }
            }
            catch (Exception ex)
            {
                lblMensajeCargoEmpleado.ForeColor = System.Drawing.Color.Red;
                lblMensajeCargoEmpleado.Text = "Error al eliminar el cargo de empleado: " + ex.Message;
            }
        }
    }
}