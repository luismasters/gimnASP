using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gimn_Asp
{
    public partial class DashboardEmpleado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDatosEmpleado();
            }
        }

        private void CargarDatosEmpleado()
        {
            if (Session["EmpleadoID"] != null)
            {
                int empleadoID = Convert.ToInt32(Session["EmpleadoID"]);
                EmpleadoNegocio empleadoNegocio = new EmpleadoNegocio();
                Empleado empleado = empleadoNegocio.ObtenerEmpleado(empleadoID);







                if (empleado != null)
                {
                    lblNombre.Text = empleado.Nombre + " " + empleado.Apellido;
                    lblDNI.Text = empleado.DNI;
                    lblEmail.Text = empleado.Email;
                    lblCargo.Text = empleado.cargoEmpleado.Descripcion;
                    lblFechaNacimiento.Text = empleado.FechaNacimiento.ToShortDateString();


                    Persona p = new Persona();
                    PersonaNegocio pn=new PersonaNegocio();
                    p = pn.BuscarPersona(empleado.DNI);


                    // Cargar imagen de perfil
                    ImagenNegocio imagenNegocio = new ImagenNegocio();
                    Imagen imagen = imagenNegocio.CargarImagenPorIDPersona(p.IDPersona);
                    imgPerfil.ImageUrl = imagenNegocio.UrlPerfilImagen(imagen);
                }
            }
            else
            {
                // Redirigir al login si no hay sesión de empleado
                Response.Redirect("Login.aspx");
            }
        }
    }
}