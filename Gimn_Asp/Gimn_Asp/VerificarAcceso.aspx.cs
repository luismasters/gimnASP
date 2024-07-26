﻿using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gimn_Asp
{
    public partial class VerificarAcceso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Acceso_Click(object sender, EventArgs e)
        {
            string DNI = txtDNI.Text;

            Persona persona = new Persona();
            PersonaNegocio personaNegocio = new PersonaNegocio();

            persona = personaNegocio.BuscarPersona(DNI);

            if (persona != null)
            {
                Miembro miembro = new Miembro();
                MiembroNegocio miembroNegocio = new MiembroNegocio();

                miembro = miembroNegocio.BuscarUltimoRegMiembro(persona.IDPersona);

                if (miembro != null)
                {
                    TipoMembresia tipoMembresia = new TipoMembresia();
                    TipoMembresiaNegocio tipoMembresiaNegocio = new TipoMembresiaNegocio();
                    tipoMembresia = tipoMembresiaNegocio.BuscarMembresia(miembro.TipoMembresia);

                    lblNombre.Text = $"{persona.Nombre} {persona.Apellido}";
                    lblTipoMembresia.Text = tipoMembresia.Descripcion;
                    lblFechaInicio.Text = miembro.FechaInicio.ToString("dd/MMMM/yyyy");
                    lblFechaVencimiento.Text = miembro.FechaFin.ToString("dd/MMMM/yyyy");


                    ImagenNegocio imagenNegocio = new ImagenNegocio();
                    Imagen imagen = new Imagen();

                    imagen = imagenNegocio.CargarImagenPorIDPersona(miembro.IDPersona);

                    imgFoto.ImageUrl = imagenNegocio.UrlPerfilImagen(imagen);

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
                    lblMensaje.Visible = false;
                }
                else
                {
                    lblMensaje.Text = "La persona no es un socio.";
                    lblMensaje.Visible = true;
                    pnlCard.Visible = false;
                }
            }
            else
            {
                lblMensaje.Text = "Socio no registrado.";
                lblMensaje.Visible = true;
                pnlCard.Visible = false;
            }
        }
    }
}