using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace Gimn_Asp
{
    public partial class AgregarEmpleados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCargos();
            }
        }

        private void CargarCargos()
        {
            try
            {
                CargoEmpleadoNegocio cargoNegocio = new CargoEmpleadoNegocio();
                List<CargoEmpleado> cargos = cargoNegocio.ListarCargos();
                ddlCargos.DataSource = cargos;
                ddlCargos.DataTextField = "Descripcion";
                ddlCargos.DataValueField = "ID";
                ddlCargos.DataBind();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al cargar los cargos: " + ex.Message;
            }
        }

        protected void btnAgregarEmpleado_Click(object sender, EventArgs e)
        {
            try
            {
                Empleado empleado = new Empleado
                {
                    DNI = txtDNI.Text,
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Email = txtEmail.Text,
                    FechaNacimiento = DateTime.Parse(txtFechaNacimiento.Text),
                    cargoEmpleado = new CargoEmpleado { ID = int.Parse(ddlCargos.SelectedValue) }
                };

                EmpleadoNegocio empleadoNegocio = new EmpleadoNegocio();
                string errorMessage;
                bool exito = empleadoNegocio.AgregarEmpleado(empleado, out errorMessage);

                if (exito)
                {
                    // Asignar usuario y clave al empleado
                    string nombreUsuario = empleado.Email + ".Emp";
                    string clave = empleado.DNI;
                    Usuario usuario = new Usuario
                    {
                        IDPersona = empleado.IDPersona,
                        IDRol = 2, // Rol de Empleado
                        NombreUsuario = nombreUsuario,
                        Clave = clave
                    };

                    UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                    bool usuarioExito = usuarioNegocio.AgregarUsuario(usuario, out errorMessage);

                    if (!usuarioExito)
                    {
                        lblMensaje.ForeColor = System.Drawing.Color.Red;
                        lblMensaje.Text = "Empleado agregado, pero error al crear el usuario: " + errorMessage;
                        return;
                    }

                    if (fileUploadImagen.HasFile)
                    {
                        byte[] datosImagen = fileUploadImagen.FileBytes;
                        ImagenNegocio negocioImagen = new ImagenNegocio();
                        try
                        {
                            negocioImagen.InsertarImagen(empleado.IDPersona, datosImagen);
                            lblMensaje.Text = "Empleado, usuario e imagen agregados correctamente.";
                        }
                        catch (Exception ex)
                        {
                            lblMensaje.Text = "Empleado y usuario agregados, pero error al guardar la imagen: " + ex.Message;
                        }
                    }
                    else
                    {
                        lblMensaje.Text = "Empleado y usuario agregados correctamente, pero no se subió ninguna imagen.";
                    }
                    LimpiarFormulario();
                }
                else
                {
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    lblMensaje.Text = errorMessage;
                }
            }
            catch (Exception ex)
            {
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Text = "Error al agregar el empleado: " + ex.Message;
            }
        }

        private void LimpiarFormulario()
        {
            txtDNI.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtFechaNacimiento.Text = string.Empty;
            ddlCargos.SelectedIndex = 0;
            imgPreview.ImageUrl = string.Empty;
        }
    }
}