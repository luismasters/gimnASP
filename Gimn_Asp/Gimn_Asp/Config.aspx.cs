using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace Gimn_Asp
{
    public partial class Config : System.Web.UI.Page
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
                CargarCargosEmpleados();    
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
                    CargarSalones(); // Volver a cargar la lista de salones para incluir el nuevo
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
                    CargarSalones(); // Volver a cargar la lista de salones para reflejar los cambios
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
                    CargarCargosEmpleados(); // Volver a cargar la lista de cargos de empleados para incluir el nuevo
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
                    CargarCargosEmpleados(); // Volver a cargar la lista de cargos de empleados para reflejar los cambios
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
