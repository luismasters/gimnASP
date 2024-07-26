using System;
using System.Collections.Generic;
using Dominio;
using Negocio;

namespace Gimn_Asp
{
    public partial class ModificarEmpleado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (Convert.ToInt32(Session["Rol"]) != 1)
            {
                Response.Redirect("Login.aspx");


            }


            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    int idEmpleado = Convert.ToInt32(Request.QueryString["id"]);
                    CargarEmpleado(idEmpleado);
                    CargarCargos();
                    CargarRoles();
                }
                else
                {
                    Response.Redirect("ListarEmpleados.aspx");
                }
            }
        }

        private void CargarEmpleado(int idEmpleado)
        {
            EmpleadoNegocio negocio = new EmpleadoNegocio();
            Empleado empleado = negocio.ObtenerEmpleado(idEmpleado);
            if (empleado != null)
            {
                txtDNI.Text = empleado.DNI;
                txtNombre.Text = empleado.Nombre;
                txtApellido.Text = empleado.Apellido;
                txtEmail.Text = empleado.Email;
                txtFechaNacimiento.Text = empleado.FechaNacimiento.ToString("yyyy-MM-dd");
                ddlCargo.SelectedValue = empleado.cargoEmpleado.ID.ToString();
                ddlRol.SelectedValue = empleado.rol.ID.ToString();
                chkEstadoActivo.Checked = empleado.EstadoActivo;
                txtNombreUsuario.Text = empleado.usuario.NombreUsuario;
            }
            else
            {
                lblMensaje.Text = "Empleado no encontrado.";
                lblMensaje.CssClass = "text-danger";
            }
        }

        private void CargarCargos()
        {
            CargoEmpleadoNegocio negocio = new CargoEmpleadoNegocio();
            ddlCargo.DataSource = negocio.ListarCargos();
            ddlCargo.DataTextField = "Descripcion";
            ddlCargo.DataValueField = "ID";
            ddlCargo.DataBind();
        }

        private void CargarRoles()
        {
            RolNegocio negocio = new RolNegocio();
            ddlRol.DataSource = negocio.ListarRoles();
            ddlRol.DataTextField = "Descripcion";
            ddlRol.DataValueField = "ID";
            ddlRol.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    EmpleadoNegocio negocio = new EmpleadoNegocio();
                    UsuarioNegocio usuarioNegocio = new UsuarioNegocio();

                    int idEmpleado = Convert.ToInt32(Request.QueryString["id"]);
                    Empleado empleadoActual = negocio.ObtenerEmpleado(idEmpleado);

                    Empleado empleado = new Empleado
                    {
                        ID = idEmpleado,
                        DNI = txtDNI.Text,
                        Nombre = txtNombre.Text,
                        Apellido = txtApellido.Text,
                        Email = txtEmail.Text,
                        FechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text),
                        cargoEmpleado = new CargoEmpleado { ID = Convert.ToInt32(ddlCargo.SelectedValue) },
                        rol = new Rol { ID = Convert.ToInt32(ddlRol.SelectedValue) },
                        EstadoActivo = chkEstadoActivo.Checked,
                        usuario = new Usuario
                        {
                            ID = empleadoActual.usuario.ID,
                            NombreUsuario = txtNombreUsuario.Text
                        }
                    };

                    negocio.ModificarEmpleado(empleado);

                    // Modificar el usuario
                    string errorMessage;
                    Usuario usuarioActualizado = new Usuario
                    {
                        ID = empleado.usuario.ID,
                        NombreUsuario = txtNombreUsuario.Text,
                        Clave = string.IsNullOrEmpty(txtClave.Text) ? null : txtClave.Text
                    };

                    if (usuarioNegocio.ModificarUsuario(usuarioActualizado, out errorMessage))
                    {
                        lblMensaje.Text = "Empleado y usuario modificados con éxito.";
                        lblMensaje.CssClass = "text-success";
                    }
                    else
                    {
                        lblMensaje.Text = "Empleado modificado, pero hubo un problema al actualizar el usuario: " + errorMessage;
                        lblMensaje.CssClass = "text-warning";
                    }
                }
                catch (Exception ex)
                {
                    lblMensaje.Text = "Error al modificar el empleado: " + ex.Message;
                    lblMensaje.CssClass = "text-danger";
                }
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListarEmpleados.aspx");
        }
    }
}