using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gimn_Asp
{
    public partial class Error401 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMensaje.Text = Session["Mensaje"].ToString();
            btnAceptar.PostBackUrl = Session["URl"].ToString();

            if (Session["URL"].ToString() == "Login.aspx")
            {
                // Limpiar la sesión
                Session.Clear();
                Session.Abandon();


            }

            







        }
    }







}