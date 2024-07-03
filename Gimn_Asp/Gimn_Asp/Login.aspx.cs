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

                // Redirige según el rol del usuario
                if (usuario.IDRol == 1) // Asumiendo que el rol de Administrador tiene ID 1
                {
                    Response.Redirect("Acceso.aspx");
                }
                else
                {
                }
            }
            else
            {
                // Error de autenticación
                lblMessage.Text = "Usuario o contraseña incorrectos.";
            }
        }

        protected void btnLogin_Click1(object sender, EventArgs e)
        {

        }
    }
}
