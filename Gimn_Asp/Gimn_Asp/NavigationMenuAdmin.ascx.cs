using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gimn_Asp
{
    public partial class NavigationMenuAdmin : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Asume que el nombre y cargo del usuario están almacenados en la sesión
                string nombreCompleto = Session["NombreCompleto"]?.ToString() ?? "Administrador";
                string cargo = Session["Cargo"]?.ToString() ?? "Admin";

                // Configura el título del sidebar
                sidebarTitle.InnerText = $"{nombreCompleto} - {cargo}";
            }
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