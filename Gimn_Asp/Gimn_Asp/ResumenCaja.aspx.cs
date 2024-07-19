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
    public partial class ResumenCaja : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblFecha.Text = DateTime.Today.ToString("dd/MM/yyyy");
                CargarResumenCaja();
            }
        }

        private void CargarResumenCaja()
        {
            CobroNegocio cobroNegocio = new CobroNegocio();
            List<ResumenCobro> resumenCobros = cobroNegocio.ObtenerResumenCobros(DateTime.Today);

            gvResumenCaja.DataSource = resumenCobros;
            gvResumenCaja.DataBind();
        }

        protected void btnVerDetalle_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int idEmpleado = Convert.ToInt32(btn.CommandArgument);
            Response.Redirect($"DetalleCobro.aspx?idEmpleado={idEmpleado}&fecha={DateTime.Today.ToString("yyyy-MM-dd")}");
        }
    }
}