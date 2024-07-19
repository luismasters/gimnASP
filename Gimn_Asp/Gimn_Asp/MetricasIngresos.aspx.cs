﻿using Negocio;
using System;

namespace Gimn_Asp
{
    public partial class MetricasIngresos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarResumenDiario();
                CargarResumenMensual();
            }
        }

        private void CargarResumenDiario()
        {
            CobroNegocio cobroNegocio = new CobroNegocio();
            decimal ingresosDiarios = cobroNegocio.ObtenerIngresosTotales(DateTime.Today);
            lblIngresosDiarios.Text = $"Ingresos Totales del Día: {ingresosDiarios:C}";
        }

        private void CargarResumenMensual()
        {
            CobroNegocio cobroNegocio = new CobroNegocio();
            DateTime inicioMes = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            decimal ingresosMensuales = cobroNegocio.ObtenerIngresosTotalesPorRango(inicioMes, DateTime.Today);
            string nombreMes = DateTime.Today.ToString("MMMM");
            lblIngresosMensuales.Text = $"Ingresos durante el mes de {nombreMes}: {ingresosMensuales:C}";
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
