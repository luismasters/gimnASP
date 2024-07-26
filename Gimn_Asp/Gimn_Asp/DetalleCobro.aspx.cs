using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Negocio.CobroNegocio;

namespace Gimn_Asp
{
    public partial class DetalleCobro : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {


            if (Convert.ToInt32(Session["Rol"]) != 1)
            {
                Response.Redirect("Login.aspx");


            }



            if (!IsPostBack)
            {
                DateTime fecha = DateTime.Parse(Request.QueryString["fecha"]);
                lblFecha.Text = fecha.ToString("dd/MM/yyyy");
                int idEmpleado = int.Parse(Request.QueryString["idEmpleado"]);
                CargarDetalleCobro(idEmpleado, fecha);
            }
        }

        private void CargarDetalleCobro(int idEmpleado, DateTime fecha)
        {
            CobroNegocio cobroNegocio = new CobroNegocio();
            List<CobroDetalle> detalleCobros = cobroNegocio.ObtenerDetalleCobros(idEmpleado, fecha);

            gvDetalleCobro.DataSource = detalleCobros;
            gvDetalleCobro.DataBind();
        }
    }
}