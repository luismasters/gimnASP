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
        private TipoMembresiaNegocio tipoMembresiaNegocio = new TipoMembresiaNegocio();
        private RolNegocio rolNegocio = new RolNegocio();
        private CobroNegocio cobroNegocio = new CobroNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {



            if (Convert.ToInt32(Session["Rol"]) != 2)
            {
                Response.Redirect("Login.aspx");


            }


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
                    TipoMembresia tipoMembresia = tipoMembresiaNegocio.BuscarMembresia(miembro.TipoMembresia);

                    lblNombre.Text = $"{miembro.Nombre} {miembro.Apellido}";
                    lblTipoMembresia.Text = tipoMembresia.Descripcion;
                    lblFechaInicio.Text = miembro.FechaInicio.ToString("dd/MMMM/yyyy");
                    lblFechaVencimiento.Text = miembro.FechaFin.ToString("dd/MMMM/yyyy");

                    DateTime nuevafechafin = DateTime.Today.AddDays(30);
                    DateTime fechahoy = DateTime.Today;

                    if (miembro.FechaFin >= DateTime.Today)
                    {
                        lblAcceso.Text = "Acceso permitido";
                        lblAcceso.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        lblAcceso.Text = "Membresía vencida";
                        lblAcceso.ForeColor = System.Drawing.Color.Red;
                    }

                    Dominio.Imagen imagen = new Imagen();
                    ImagenNegocio imagenNegocio = new ImagenNegocio();

                    imagen = imagenNegocio.CargarImagenPorIDPersona(miembro.IDPersona);

                    imgFoto.ImageUrl = imagenNegocio.UrlPerfilImagen(imagen);

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
            List<TipoMembresia> tipoMembresias = tipoMembresiaNegocio.ListarTiposMembresias();

            DropDownListMembresia.DataSource = tipoMembresias;
            DropDownListMembresia.DataTextField = "Descripcion"; // Muestra la descripción
            DropDownListMembresia.DataValueField = "ID"; // Almacena el ID como valor
            DropDownListMembresia.DataBind();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string DNI = lstPersonas.SelectedValue;
            Persona persona = personaNegocio.BuscarPersona(DNI);

            if (persona != null)
            {
                Miembro miembro = miembroNegocio.BuscarUltimoRegMiembro(persona.IDPersona);
                if (miembro != null)
                {
                    if (miembro.FechaFin < DateTime.Today)
                    {
                        lblNombre.Text = persona.Nombre + " " + persona.Apellido;
                        lblFechaInicio.Text = miembro.FechaInicio.ToString("dd/MMMM/yyyy");
                        lblFechaVencimiento.Text = miembro.FechaFin.ToString("dd/MMMM/yyyy");

                        TipoMembresia tipoMembresia = tipoMembresiaNegocio.BuscarMembresia(miembro.TipoMembresia);
                        lblTipoMembresia.Text = tipoMembresia.Descripcion;

                        DateTime nuevafechafin = DateTime.Today.AddDays(30);
                        DateTime fechahoy = DateTime.Today;
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
                string DNI = lstPersonas.SelectedValue;
                Persona persona = personaNegocio.BuscarPersona(DNI);

                if (persona != null)
                {
                    Miembro miembro = miembroNegocio.BuscarUltimoRegMiembro(persona.IDPersona);
                 

                    if (miembro != null && miembro.FechaFin < DateTime.Today)
                    {
                        miembro.TipoMembresia = Convert.ToInt32(DropDownListMembresia.SelectedValue);
                        miembro.FechaInicio = DateTime.Today;
                        miembro.FechaFin = DateTime.Today.AddMonths(1);
                        miembro.rol = ObtenerIDRolSegunMembresia(Convert.ToInt32(DropDownListMembresia.SelectedValue));
                        miembro.EstadoActivo = true;
                        miembro.usuario.ID = miembro.usuario.ID;





                        bool miembroActualizado = miembroNegocio.AgregarMiembroExistente(miembro);
                        if (miembroActualizado)
                        {
                            int empleadoID = (int)Session["EmpleadoID"];
                            Cobro cobro = new Cobro
                            {
                                IDPersona = miembro.IDPersona,
                                IDTipoMembresia = miembro.TipoMembresia,
                                Empleado = new Empleado { ID = empleadoID },
                                FechaCobro = DateTime.Today
                            };

                            bool cobroAgregado = cobroNegocio.AgregarCobro(cobro);
                            if (cobroAgregado)
                            {
                                string script = "alert('Pago registrado correctamente.');";
                                ClientScript.RegisterStartupScript(this.GetType(), "RegistroExitoso", script, true);
                            }
                            else
                            {
                                string script = "alert('Error al registrar el cobro.');";
                                ClientScript.RegisterStartupScript(this.GetType(), "ErrorRegistroCobro", script, true);
                            }
                        }
                        else
                        {
                            string script = "alert('Error al actualizar el miembro.');";
                            ClientScript.RegisterStartupScript(this.GetType(), "ErrorActualizarMiembro", script, true);
                        }
                    }
                    else
                    {
                        string script = "alert('Membresía activa o no encontrada.');";
                        ClientScript.RegisterStartupScript(this.GetType(), "ErrorMembresiaActiva", script, true);
                    }
                }
                else
                {
                    string script = "alert('No se encontró la persona.');";
                    ClientScript.RegisterStartupScript(this.GetType(), "ErrorPersonaNoEncontrada", script, true);
                }
            }
            catch (Exception ex)
            {
                string script = "alert('Ocurrió un error: " + ex.Message + "');";
                ClientScript.RegisterStartupScript(this.GetType(), "ErrorGeneral", script, true);
            }

         LoadPersonas();

        }

        private Rol ObtenerIDRolSegunMembresia(int tipoMembresia)
        {
               Rol rol = new Rol();
            switch (tipoMembresia)
            {
                case 1: // Musculación
                    rol.ID = 6;
                    break;
                case 2: // Clases de Salón
                    rol.ID = 5;
                    break;
                case 3: // Pase Dorado
                    rol.ID = 7;
                    break;
            }
            return rol;
        }
    }
}
