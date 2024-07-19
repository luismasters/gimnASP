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
    public partial class AgregarSocio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {






            if (!IsPostBack)
            {
                CargarTiposMembresias();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string errorMessage = string.Empty;
            PersonaNegocio personaNegocio = new PersonaNegocio();
            MiembroNegocio miembroNegocio = new MiembroNegocio();
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            CobroNegocio cobroNegocio = new CobroNegocio();
            ImagenNegocio negocioImagen = new ImagenNegocio();
            DateTime FN;
            DateTime.TryParse(txtFechaNacimiento.Text, out FN);

            // Crear el objeto Miembro con los datos del formulario
            Miembro miembro = new Miembro
            {
                DNI = txtDNIUser.Text,
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Email = txtEmail.Text,
                FechaNacimiento =FN,
                TipoMembresia = Convert.ToInt32(DropDownListMembresia.SelectedValue)
            };

            // Verificar si la persona ya existe
            Persona personaExistente = personaNegocio.BuscarPersona(miembro.DNI);
            if (personaExistente == null)
            {
                // Si no existe, crear un objeto Persona con los datos de Miembro
                Persona nuevaPersona = new Persona
                {
                    DNI = miembro.DNI,
                    Nombre = miembro.Nombre,
                    Apellido = miembro.Apellido,
                    Email = miembro.Email,
                    FechaNacimiento = FN
                };

                // Agregar la persona
                bool personaAgregada = personaNegocio.AgregarPersona(nuevaPersona, out errorMessage);
                if (!personaAgregada)
                {
                    lblMensaje.Text = errorMessage;
                    return;
                }

                // Recuperar el IDPersona de la persona recién agregada
                personaExistente = personaNegocio.BuscarPersona(miembro.DNI);
                miembro.IDPersona = personaExistente.IDPersona;
            }
            else
            {
                // Si la persona ya existe, usar su ID
                miembro.IDPersona = personaExistente.IDPersona;
            }

            // Agregar el miembro
            bool miembroAgregado = miembroNegocio.AgregarMiembro(miembro);
            if (!miembroAgregado)
            {
                lblMensaje.Text = errorMessage;
                return;
            }

            // Crear y agregar el usuario
            Persona p2 = new Persona();
            p2 = personaNegocio.BuscarPersona(miembro.DNI);
 
            Usuario usuario = new Usuario
           

            {
                NombreUsuario = p2.Email,
                Clave = miembro.DNI,
                IDRol = 3,
                IDPersona = miembro.IDPersona
            };

            bool usuarioAgregado = usuarioNegocio.AgregarUsuario(usuario, out errorMessage);
            if (!usuarioAgregado)
            {
                lblMensaje.Text = errorMessage;
                return;
            }

            // Registro de cobro
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
                // Éxito: mostrar un mensaje de éxito
                string script1 = "alert('Miembro y cobro registrados correctamente.');";
                ClientScript.RegisterStartupScript(this.GetType(), "RegistroExitoso", script1, true);
            }
            else
            {
                // Error al agregar el cobro
                string script1 = "alert('Error al registrar el cobro.');";
                ClientScript.RegisterStartupScript(this.GetType(), "ErrorRegistroCobro", script1, true);
            }

            // Manejo de la imagen del miembro
            if (fileUploadImagen.HasFile)
            {
                byte[] datosImagen = fileUploadImagen.FileBytes;
                try
                {
                    negocioImagen.InsertarImagen(miembro.IDPersona, datosImagen);
                    lblMensaje.Text = "La imagen se guardó correctamente en la base de datos.";
                    Response.Redirect("Acceso.aspx");
                }
                catch (Exception ex)
                {
                    lblMensaje.Text = "Error al guardar la imagen: " + ex.Message;
                }
            }
            else
            {
                lblMensaje.Text = "Por favor seleccione un archivo.";
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

        private void CargarTiposMembresias()
        {
            TipoMembresiaNegocio tipoMembresiaNegocio = new TipoMembresiaNegocio();
            List<TipoMembresia> tipoMembresias = tipoMembresiaNegocio.ListarTiposMembresias();

            DropDownListMembresia.DataSource = tipoMembresias;
            DropDownListMembresia.DataTextField = "Descripcion"; // Muestra la descripción
            DropDownListMembresia.DataValueField = "ID"; // Almacena el ID como valor
            DropDownListMembresia.DataBind();
        }

        protected void BuscarUsuario_Click(object sender, EventArgs e)
        {
            string DNI = txtDNI.Text;
            PersonaNegocio personaNegocio = new PersonaNegocio();
            MiembroNegocio miembroNegocio1 = new MiembroNegocio();

            if (miembroNegocio1.BuscarUltimoRegMiembro(DNI) != null)
            {
                string script = "alert('Usuario ya es Socio.');";
                ClientScript.RegisterStartupScript(this.GetType(), "AlertaMembresiaActiva", script, true);
            }
            else
            {
                panel.Visible = true;
                txtDNIUser.Text = DNI;

                DateTime nuevafechafin = DateTime.Today.AddDays(30);
                DateTime fechahoy = DateTime.Today;
                txtFechaActual.Text = fechahoy.ToString("dd/MM/yyyy");
                txtfinNuevoPeriodo.Text = nuevafechafin.ToString("dd/MM/yyyy");
            }
        }
    }
}
