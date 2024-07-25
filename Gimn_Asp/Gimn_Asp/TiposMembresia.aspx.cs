using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace Gimn_Asp
{
    public partial class TiposMembresia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTiposMembresia();
            }
        }

        private void CargarTiposMembresia()
        {
            try
            {
                TipoMembresiaNegocio tipoMembresiaNegocio = new TipoMembresiaNegocio();
                List<TipoMembresia> tiposMembresia = tipoMembresiaNegocio.ListarTiposMembresias();
                gvTiposMembresia.DataSource = tiposMembresia;
                gvTiposMembresia.DataBind();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al cargar los tipos de membresía: " + ex.Message;
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                TipoMembresia tipoMembresia = new TipoMembresia
                {
                    Descripcion = txtDescripcion.Text,
                    Precio = decimal.Parse(txtPrecio.Text)
                };

                TipoMembresiaNegocio tipoMembresiaNegocio = new TipoMembresiaNegocio();
                bool exito = tipoMembresiaNegocio.AgregarTipoMembresia(tipoMembresia);

                if (exito)
                {
                    lblMensaje.ForeColor = System.Drawing.Color.Green;
                    lblMensaje.Text = "Tipo de membresía agregado con éxito.";
                    CargarTiposMembresia();
                    LimpiarCampos();
                }
                else
                {
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    lblMensaje.Text = "Error al agregar el tipo de membresía.";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Text = "Error al agregar el tipo de membresía: " + ex.Message;
            }
        }

        protected void gvTiposMembresia_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int idTipoMembresia = Convert.ToInt32(gvTiposMembresia.DataKeys[e.RowIndex].Value);
                TipoMembresiaNegocio tipoMembresiaNegocio = new TipoMembresiaNegocio();
                // Asumiendo que hay un método EliminarTipoMembresia en TipoMembresiaNegocio
                bool exito = tipoMembresiaNegocio.EliminarTipoMembresia(idTipoMembresia);

                if (exito)
                {
                    lblMensaje.ForeColor = System.Drawing.Color.Green;
                    lblMensaje.Text = "Tipo de membresía eliminado con éxito.";
                    CargarTiposMembresia();
                }
                else
                {
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    lblMensaje.Text = "Error al eliminar el tipo de membresía.";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Text = "Error al eliminar el tipo de membresía: " + ex.Message;
            }
        }

        protected void gvTiposMembresia_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvTiposMembresia.EditIndex = e.NewEditIndex;
            CargarTiposMembresia();
        }

        protected void gvTiposMembresia_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow row = gvTiposMembresia.Rows[e.RowIndex];
                int id = Convert.ToInt32(gvTiposMembresia.DataKeys[e.RowIndex].Value);

                TextBox txtDescripcion = (TextBox)row.FindControl("txtDescripcion");
                TextBox txtPrecio = (TextBox)row.FindControl("txtPrecio");

                if (txtDescripcion != null && txtPrecio != null)
                {
                    string descripcion = txtDescripcion.Text;
                    decimal precio;

                    if (decimal.TryParse(txtPrecio.Text, out precio))
                    {
                        TipoMembresia tipoMembresia = new TipoMembresia
                        {
                            ID = id,
                            Descripcion = descripcion,
                            Precio = precio
                        };

                        TipoMembresiaNegocio tipoMembresiaNegocio = new TipoMembresiaNegocio();
                        bool exito = tipoMembresiaNegocio.ModificarTipoMembresia(tipoMembresia);

                        if (exito)
                        {
                            lblMensaje.ForeColor = System.Drawing.Color.Green;
                            lblMensaje.Text = "Tipo de membresía modificado con éxito.";
                            gvTiposMembresia.EditIndex = -1;
                            CargarTiposMembresia();
                        }
                        else
                        {
                            lblMensaje.ForeColor = System.Drawing.Color.Red;
                            lblMensaje.Text = "Error al modificar el tipo de membresía.";
                        }
                    }
                    else
                    {
                        lblMensaje.ForeColor = System.Drawing.Color.Red;
                        lblMensaje.Text = "El precio ingresado no es válido.";
                    }
                }
                else
                {
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    lblMensaje.Text = "No se pudieron encontrar los controles de edición.";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Text = "Error al modificar el tipo de membresía: " + ex.Message;
            }
        }
        protected void gvTiposMembresia_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvTiposMembresia.EditIndex = -1;
            CargarTiposMembresia();
        }

        private void LimpiarCampos()
        {
            txtDescripcion.Text = string.Empty;
            txtPrecio.Text = string.Empty;
        }
    }
}