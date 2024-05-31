using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gimn_Asp
{
    public partial class Pago : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTiposMembresias();
            }
        }

        private void CargarTiposMembresias()
        {
            TipoMembresiaNegocio tipoMembresiaNegocio = new TipoMembresiaNegocio();
            List<TipoMembresia> tipoMembresias = tipoMembresiaNegocio.ListarTiposMembresias();

            DropDownListMembresia.DataSource = tipoMembresias;
            DropDownListMembresia.DataTextField = "Descripcion"; // Muestra la descripción
            DropDownListMembresia.DataValueField = "ID"; // Almacena el ID como valor
            DropDownListMembresia.DataBind();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string DNI = txtDNI.Text;
            Persona persona = new Persona();
            PersonaNegocio personaNegocio = new PersonaNegocio();

            Miembro miembro, miembroNuevo = new Miembro();
            MiembroNegocio miembroNegocio = new MiembroNegocio();

            TipoMembresia tipoMembresia = new TipoMembresia();
            TipoMembresiaNegocio tipoMembresiaNegocio = new TipoMembresiaNegocio();

            persona = personaNegocio.BuscarPersona(DNI);

            if (persona != null)
            {
                miembro = miembroNegocio.BuscarUltimoRegMiembro(persona.ID);
                if (miembro != null)
                {
                    if (miembro.FechaFin < DateTime.Today)
                    {
                        lblNombre.Text = persona.Nombre + " " + persona.Apellido;
                        lblFechaInicio.Text = miembro.FechaInicio.ToString("dd/MMMM/yyyy");
                        lblFechaVencimiento.Text = miembro.FechaFin.ToString("dd/MMMM/yyyy");

                        tipoMembresia = tipoMembresiaNegocio.BuscarMembresia(miembro.TipoMembresia);
                        lblTipoMembresia.Text = tipoMembresia.Descripcion;

                        DateTime nuevafechafin = DateTime.Today.AddDays(30);
                        DateTime fechahoy = DateTime.Today;
                        txtFechaActual.Text = fechahoy.ToString("dd/MMMM/yyyy");
                        txtfinNuevoPeriodo.Text = nuevafechafin.ToString("dd +de+ MMMM del yyyy");
                    }
                    else
                    {
                        string script = "alert('Usuario con membresía activa.');";
                        ClientScript.RegisterStartupScript(this.GetType(), "AlertaMembresiaActiva", script, true);
                    }




                }
            }
        }

        protected void DropDownListMembresia_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idTipoMembresiaSeleccionado = Convert.ToInt32(DropDownListMembresia.SelectedValue);
            TipoMembresiaNegocio tipoMembresiaNegocio = new TipoMembresiaNegocio();
            TipoMembresia tipoMembresiaSeleccionado = tipoMembresiaNegocio.BuscarMembresia(idTipoMembresiaSeleccionado);

            if (tipoMembresiaSeleccionado != null)
            {
                lblPrecio.Text = tipoMembresiaSeleccionado.Precio.ToString("C");
            }
        }

       protected void RegistrarPago_Click(object sender, EventArgs e)
{
    try
    {
        Cobro cobro = new Cobro();
        CobroNegocio cobroNegocio = new CobroNegocio();

        Miembro miembro = new Miembro();
        MiembroNegocio miembroNegocio = new MiembroNegocio();

        Persona persona = new Persona();
        PersonaNegocio personaNegocio = new PersonaNegocio();
        string DNI = txtDNI.Text;
        persona = personaNegocio.BuscarPersona(DNI);

        if (persona != null)
        {
            int idTipoMembresiaSeleccionado = Convert.ToInt32(DropDownListMembresia.SelectedValue);
            DateTime fechahoy = DateTime.Today;

            miembro.IDPersona = persona.ID;
            miembro.TipoMembresia = idTipoMembresiaSeleccionado;

            bool miembroAgregado = miembroNegocio.AgregarMiembro(miembro);
            if (miembroAgregado)
            {
                cobro.IDPersona = persona.ID;
                cobro.IDTipoMembresia = miembro.TipoMembresia;
                cobro.FechaCobro = fechahoy;
                bool cobroAgregado = cobroNegocio.AgregarCobro(cobro);

                if (cobroAgregado)
                {
                    // Éxito: mostrar un mensaje de éxito
                    string script = "alert('Miembro y cobro registrados correctamente.');";
                    ClientScript.RegisterStartupScript(this.GetType(), "RegistroExitoso", script, true);
                }
                else
                {
                    // Error al agregar el cobro
                    string script = "alert('Error al registrar el cobro.');";
                    ClientScript.RegisterStartupScript(this.GetType(), "ErrorRegistroCobro", script, true);
                }
            }
            else
            {
                // Error al agregar el miembro
                string script = "alert('Error al registrar el miembro.');";
                ClientScript.RegisterStartupScript(this.GetType(), "ErrorRegistroMiembro", script, true);
            }
        }
        else
        {
            // Error: persona no encontrada
            string script = "alert('Persona no encontrada.');";
            ClientScript.RegisterStartupScript(this.GetType(), "PersonaNoEncontrada", script, true);
        }
    }
    catch (Exception ex)
    {
        // Mostrar el error
        string script = $"alert('Ocurrió un error: {ex.Message}');";
        ClientScript.RegisterStartupScript(this.GetType(), "ErrorGeneral", script, true);
    }
}

    }
    }
