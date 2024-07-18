using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gimn_Asp
{
    public partial class Pago : System.Web.UI.Page
    {
        private PersonaNegocio personaNegocio = new PersonaNegocio();
        private MiembroNegocio miembroNegocio = new MiembroNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPersonas();
                CargarTiposMembresias();
            }
        }

        protected void LoadPersonas()
        {
            List<Miembro> miembros = miembroNegocio.ListarMiembrosVencidos();
            Session["Personas"] = miembros; // Guardar la lista completa en sesión para filtrar
            BindListBox(miembros);
        }

        protected void BindListBox(List<Miembro> miembros)
        {
            lstPersonas.DataSource = miembros;
            lstPersonas.DataTextField = "NombreCompleto"; // Usar una propiedad combinada para mostrar nombre completo
            lstPersonas.DataValueField = "DNI";
            lstPersonas.DataBind();
        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string filter = txtDNI.Text.ToLower();
            List<Miembro> miembros = Session["Personas"] as List<Miembro>;

            if (!string.IsNullOrWhiteSpace(filter))
            {
                miembros = miembros.Where(p =>
                    p.DNI.ToLower().Contains(filter) ||
                    p.Nombre.ToLower().Contains(filter) ||
                    p.Apellido.ToLower().Contains(filter)).ToList();
            }

            BindListBox(miembros);
        }

        protected void lstPersonas_SelectedIndexChanged(object sender, EventArgs e)
        {
            string dni = lstPersonas.SelectedValue;
            Persona persona = personaNegocio.BuscarPersona(dni);
            if (persona != null)
            {
                Miembro miembro = miembroNegocio.BuscarUltimoRegMiembro(persona.IDPersona);

                if (miembro != null)
                {
                    TipoMembresia tipoMembresia = new TipoMembresia();
                    TipoMembresiaNegocio tipoMembresiaNegocio = new TipoMembresiaNegocio();
                    tipoMembresia = tipoMembresiaNegocio.BuscarMembresia(miembro.TipoMembresia);

                    lblNombre.Text = $"{miembro.Nombre} {miembro.Apellido}";
                    lblTipoMembresia.Text = tipoMembresia.Descripcion;
                    lblFechaInicio.Text = miembro.FechaInicio.ToString("dd/MMMM/yyyy");
                    lblFechaVencimiento.Text = miembro.FechaFin.ToString("dd/MMMM/yyyy");

                    Dominio.Imagen imagen = new Imagen();
                    ImagenNegocio imagenNegocio = new ImagenNegocio();
                    imagen = imagenNegocio.CargarImagenPorIDPersona(miembro.IDPersona);
                    imgFoto.ImageUrl = imagenNegocio.UrlPerfilImagen(imagen);

                    DateTime nuevafechafin = DateTime.Today.AddDays(30);
                    DateTime fechahoy = DateTime.Today;
                    txtFechaActual.Text = fechahoy.ToString("dd/MMMM/yyyy");
                    txtfinNuevoPeriodo.Text = nuevafechafin.ToString("dd/MMMM/yyyy");

                    if (miembro.FechaFin >= DateTime.Now)
                    {
                        lblAcceso.Text = "Acceso permitido";
                        lblAcceso.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        lblAcceso.Text = "Membresía vencida";
                        lblAcceso.ForeColor = System.Drawing.Color.Red;
                    }

                    pnlCard.Visible = true;
                }
                else
                {
                    pnlCard.Visible = false;
                }
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
            string DNI = lstPersonas.SelectedValue;
            Persona persona = new Persona();
            PersonaNegocio personaNegocio = new PersonaNegocio();

            Miembro miembro, miembroNuevo = new Miembro();
            MiembroNegocio miembroNegocio = new MiembroNegocio();

            TipoMembresia tipoMembresia = new TipoMembresia();
            TipoMembresiaNegocio tipoMembresiaNegocio = new TipoMembresiaNegocio();

            persona = personaNegocio.BuscarPersona(DNI);

            if (persona != null)
            {
                miembro = miembroNegocio.BuscarUltimoRegMiembro(persona.IDPersona);
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
                        txtfinNuevoPeriodo.Text = nuevafechafin.ToString("dd/MMMM/yyyy");
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
                string DNI = lstPersonas.SelectedValue;
                persona = personaNegocio.BuscarPersona(DNI);

                if (persona != null)
                {
                    int idTipoMembresiaSeleccionado = Convert.ToInt32(DropDownListMembresia.SelectedValue);
                    DateTime fechahoy = DateTime.Today;

                    miembro.IDPersona = persona.IDPersona;
                    miembro.TipoMembresia = idTipoMembresiaSeleccionado;

                    bool miembroAgregado = miembroNegocio.AgregarMiembro(miembro);
                    if (miembroAgregado)
                    {
                        // Recuperar el ID del empleado de la sesión
                        int empleadoID = (int)Session["EmpleadoID"];

                        cobro.IDPersona = persona.IDPersona;
                        cobro.IDTipoMembresia = miembro.TipoMembresia;
                        cobro.FechaCobro = fechahoy;
                        cobro.Empleado = new Empleado { ID = empleadoID }; // Asignar el ID del empleado

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
