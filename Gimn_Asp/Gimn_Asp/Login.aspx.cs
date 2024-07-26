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
            bool esEmpleado = chkEmpleado.Checked;
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            Usuario usuario;

            if (esEmpleado)
            {
                usuario = usuarioNegocio.AutenticarEmpleado(username, password);

                if (usuario != null)
                {
                    Session["Username"] = username;
                    Session["TipoUsuario"] = "Empleado";

                    EmpleadoNegocio empleadoNegocio = new EmpleadoNegocio();
                    Empleado empleado = empleadoNegocio.BuscarEmpleadoPorUsuario(username);

                    if (empleado != null)
                    {
                        Session["EmpleadoID"] = empleado.ID;
                        Session["IDPersona"] = empleado.IDPersona;
                        Session["CargoEmpleado"] = empleado.cargoEmpleado.Descripcion;
                        Session["DNI"] = empleado.DNI;
                        Session["Nombre"] = empleado.Nombre;
                        Session["Apellido"] = empleado.Apellido;
                        Session["Rol"] = empleado.rol.ID;

                        switch (empleado.rol.ID)
                        {
                            case 1: // Administrador
                                Response.Redirect("MetricasIngresos.aspx");
                                break;
                            case 2: // Empleado Recepcion
                                Response.Redirect("Acceso.aspx");
                                break;
                            case 3: // Instructor Salon
                            case 4: // Instructor Musculacion
                                Response.Redirect("HorarioInstructor.aspx");
                                break;
                            default:
                                Response.Redirect("Default.aspx");
                                break;
                        }
                    }
                    else
                    {
                        lblMessage.Text = "No se encontró la información del empleado.";
                    }
                }
                else
                {
                    lblMessage.Text = "Usuario o contraseña incorrectos.";
                }
            }
            else
            {
                usuario = usuarioNegocio.AutenticarMiembro(username, password);

                if (usuario != null)
                {
                    Session["Username"] = username;
                    Session["TipoUsuario"] = "Miembro";

                    MiembroNegocio miembroNegocio = new MiembroNegocio();
                    Miembro miembro = miembroNegocio.BuscarUltimoRegMiembroPorUsername(username);

                    if (miembro != null)
                    {
                        Session["MiembroID"] = miembro.IDMiembro;
                        Session["IDPersona"] = miembro.IDPersona;
                        Session["TipoMembresia"] = miembro.TipoMembresiaDescripcion;
                        Session["FechaInicio"] = miembro.FechaInicio;
                        Session["FechaFin"] = miembro.FechaFin;
                        Session["DNI"] = miembro.DNI;
                        Session["Nombre"] = miembro.Nombre;
                        Session["Apellido"] = miembro.Apellido;
                        Session["Rol"] = miembro.rol.ID;

                        switch (miembro.rol.ID)
                        {
                            case 5:
                            case 6:
                            case 7:
                                Response.Redirect("UserDashboar.aspx");
                                break;
                            default:
                                Response.Redirect("Default.aspx");
                                break;
                        }
                    }
                    else
                    {
                        lblMessage.Text = "No se encontró la información del miembro.";
                    }
                }
                else
                {
                    lblMessage.Text = "Usuario o contraseña incorrectos.";
                }
            }
        }
    }
}
