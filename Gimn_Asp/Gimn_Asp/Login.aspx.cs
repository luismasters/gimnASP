using Dominio;
using Negocio;
using System;
using System.Web.UI;

namespace Gimn_Asp
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            Usuario usuario = usuarioNegocio.AutenticarUsuario(username, password);

            if (usuario != null)
            {
                // Autenticación exitosa
                Session["Username"] = username;
                Session["Role"] = usuario.IDRol; // Guarda el ID del rol en la sesión

                if (usuario.IDRol == 3) // Asumiendo que el rol de Cliente tiene ID 3
                {
                    MiembroNegocio miembroNegocio = new MiembroNegocio();
                    Miembro miembro = miembroNegocio.BuscarUltimoRegMiembro(usuario.IDPersona);

                    if (miembro != null)
                    {
                        // Almacenar los datos del miembro en la sesión
                        Session["MiembroID"] = miembro.IDMiembro;
                        Session["IDPersona"] = miembro.IDPersona;
                        Session["TipoMembresia"] = miembro.TipoMembresiaDescripcion;
                        Session["FechaInicio"] = miembro.FechaInicio;
                        Session["FechaFin"] = miembro.FechaFin;
                        Session["DNI"] = miembro.DNI;
                        Session["Nombre"] = miembro.Nombre;
                        Session["Apellido"] = miembro.Apellido;
                    }

                    // Redirigir al panel de usuario
                    Response.Redirect("UserDashboard.aspx");
                }
                else if (usuario.IDRol == 1) // Asumiendo que el rol de Administrador tiene ID 1
                {
                    Response.Redirect("AgregarEmpleados.aspx");
                }
                else if (usuario.IDRol == 2) // Asumiendo que el rol de Empleado tiene ID 2
                {
                    EmpleadoNegocio empleadoNegocio = new EmpleadoNegocio();
                    Empleado empleado = empleadoNegocio.BuscarEmpleadoPorIDPersona(usuario.IDPersona);

                    if (empleado != null)
                    {
                        // Almacenar los datos del empleado en la sesión
                        Session["EmpleadoID"] = empleado.ID;
                        Session["IDPersona"] = empleado.IDPersona;
                        Session["CargoEmpleado"] = empleado.cargoEmpleado.Descripcion;
                        Session["DNI"] = empleado.DNI;
                        Session["Nombre"] = empleado.Nombre;
                        Session["Apellido"] = empleado.Apellido;
                    }

                    // Redirigir al panel de empleado
                    Response.Redirect("Acceso.aspx");
                }
                else
                {
                    // Redirigir a una página por defecto o mostrar un mensaje si el rol no está manejado
                    Response.Redirect("Default.aspx");
                }
            }
            else
            {
                // Error de autenticación
                lblMessage.Text = "Usuario o contraseña incorrectos.";
            }
        }
    }
}
