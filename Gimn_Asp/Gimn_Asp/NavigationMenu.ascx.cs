using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gimn_Asp
{
    public partial class NavigationMenu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Verificar si los datos del empleado están en la sesión
                if (Session["Nombre"] != null && Session["Apellido"] != null && Session["CargoEmpleado"] != null)
                {
                    string nombreCompleto = $"{Session["Nombre"]} {Session["Apellido"]}";
                    string cargoEmpleado = Session["CargoEmpleado"].ToString();
                    sidebarTitle.InnerText = $"{nombreCompleto} - {cargoEmpleado}";
                }
                else
                {
                    sidebarTitle.InnerText = "Sidebar";
                }
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