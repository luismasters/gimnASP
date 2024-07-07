using System;
using System.Web;
using System.Web.UI;

namespace Gimn_Asp
{
    public partial class UserNav : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            // Limpiar la sesión
            Session.Clear();
            Session.Abandon();

            // Redirigir al login
            Response.Redirect("Login.aspx");
        }
    }
}
