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

            string DNI = txtDNI.Text;


            PersonaNegocio personaNegocio = new PersonaNegocio();
            Persona persona = new Persona();

            persona.DNI = txtDNIUser.Text;
            persona.Nombre = txtNombre.Text;
            persona.Apellido= txtApellido.Text;
            persona.Email = txtEmail.Text;
            DateTime FN;
            DateTime.TryParse(txtFechaNacimiento.Text, out FN);
            persona.FechaNacimiento = FN;
            string errorMessage;



            if (personaNegocio.AgregarPersona(persona, out errorMessage))
            {



                Miembro miembro = new Miembro();
                MiembroNegocio miembroNegocio = new MiembroNegocio();

                int idTipoMembresiaSeleccionado = Convert.ToInt32(DropDownListMembresia.SelectedValue);
                DateTime fechahoy = DateTime.Today;

                Persona PN = new Persona();

                PN=personaNegocio.BuscarPersona(DNI);

                miembro.IDPersona = PN.IDPersona;
                miembro.TipoMembresia = idTipoMembresiaSeleccionado;

               bool miembroAgregado= miembroNegocio.AgregarMiembro(miembro);

                if (miembroAgregado)
                {

                    Usuario usuario= new Usuario();
                    UsuarioNegocio usuarioNegocio = new UsuarioNegocio();

                    usuario.NombreUsuario = PN.Email;
                    usuario.Clave = PN.DNI;
                    usuario.IDRol = 3;
                    usuario.IDPersona = PN.IDPersona;

                    usuarioNegocio.AgregarUsuario(usuario,out errorMessage) ;

                    Cobro cobro = new Cobro();
                    CobroNegocio cobroNegocio = new CobroNegocio();
                    cobro.IDPersona = PN.IDPersona;
                    cobro.IDTipoMembresia = miembro.TipoMembresia;
                    cobro.FechaCobro = fechahoy;
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


                }
                else
                {


                }

            }
            else
            {

                string script = "alert('El mail ya esa regisrado');";
                ClientScript.RegisterStartupScript(this.GetType(), "AlertaMembresiaActiva", script, true);
            }



            persona = personaNegocio.BuscarPersona(DNI);

            if (persona != null)
            {
                // Verificar si se seleccionó un archivo
                if (fileUploadImagen.HasFile)
                {
                    // Obtener los datos binarios de la imagen
                    byte[] datosImagen = fileUploadImagen.FileBytes;

                    // Obtener el ID de la persona desde algún lugar, por ejemplo, un control TextBox





                    int idPersona = persona.IDPersona;

                    // Instanciar la clase ImagenNegocio
                    ImagenNegocio negocioImagen = new ImagenNegocio();

                    try
                    {
                        // Insertar la imagen en la base de datos
                        negocioImagen.InsertarImagen(idPersona, datosImagen);
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
                    // Mostrar un mensaje de error si no se seleccionó un archivo
                    lblMensaje.Text = "Por favor seleccione un archivo.";
                }





            }
            else
            {

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

           string DNI= txtDNI.Text;
           
            PersonaNegocio personaNegocio = new PersonaNegocio();


          if(personaNegocio.DNIRegistrado(DNI))
            {
                string script = "alert('Usuario ya es Socio.');";
                ClientScript.RegisterStartupScript(this.GetType(), "AlertaMembresiaActiva", script, true);

            }else 
            {
                panel.Visible = true;

                txtDNIUser.Text = DNI;

                DateTime nuevafechafin = DateTime.Today.AddDays(30);
                DateTime fechahoy = DateTime.Today;
                txtFechaActual.Text = fechahoy.ToString("dd/MMMM/yyyy");
                txtfinNuevoPeriodo.Text = nuevafechafin.ToString("dd/MMMM/yyyy");



            }
          


        }
    }
}