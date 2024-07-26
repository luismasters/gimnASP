using Negocio;
using System;

namespace Gimn_Asp
{
    public partial class MetricasIngresos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Convert.ToInt32(Session["Rol"]) != 1)
            {
                Response.Redirect("Login.aspx");


            }
            if (!IsPostBack)
            {
                CargarResumenDiario();
                CargarResumenMensual();
                CargarMembresiasActivas();
                CargarMembresiasVencidas();
            }
        }


        private void CargarMembresiasActivas()
        {
            MiembroNegocio membresiaNegocio = new MiembroNegocio();
            int membresiasActivas = membresiaNegocio.ObtenerCantidadMembresiasActivas();
            lblMembresiasActivas.Text = $"Total: {membresiasActivas}";
        }

        private void CargarMembresiasVencidas()
        {
            MiembroNegocio membresiaNegocio = new MiembroNegocio();
            int membresiasVencidas = membresiaNegocio.ObtenerCantidadMembresiasVencidas();
            lblMembresiasVencidas.Text = $"Total: {membresiasVencidas}";
        }
    


    private void CargarResumenDiario()
        {
            CobroNegocio cobroNegocio = new CobroNegocio();
            decimal ingresosDiarios = cobroNegocio.ObtenerIngresosTotales(DateTime.Today);
            lblIngresosDiarios.Text = $"Total: {ingresosDiarios:C}";
        }

        private void CargarResumenMensual()
        {
            CobroNegocio cobroNegocio = new CobroNegocio();
            DateTime inicioMes = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            decimal ingresosMensuales = cobroNegocio.ObtenerIngresosTotalesPorRango(inicioMes, DateTime.Today);
            string nombreMes = DateTime.Today.ToString("MMMM");
            lblIngresosMensuales.Text = $"Total mes de {nombreMes}: {ingresosMensuales:C}";
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            DateTime fechaInicio;
            DateTime fechaFin;

            if (DateTime.TryParse(txtFechaInicio.Text, out fechaInicio) && DateTime.TryParse(txtFechaFin.Text, out fechaFin))
            {
                CobroNegocio cobroNegocio = new CobroNegocio();
                decimal ingresosFiltrados = cobroNegocio.ObtenerIngresosTotalesPorRango(fechaInicio, fechaFin);
                lblIngresosFiltrados.Text = $"Ingresos Totales desde {fechaInicio:dd/MM/yyyy} hasta {fechaFin:dd/MM/yyyy}: {ingresosFiltrados:C}";
            }
            else
            {
                // Mostrar un mensaje de error si las fechas no son válidas
                lblIngresosFiltrados.Text = "Por favor, ingrese fechas válidas.";
            }
        }
    }
}
