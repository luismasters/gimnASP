<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarSocio.aspx.cs" Inherits="Gimn_Asp.AgregarSocio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">




    <main>
       <div class="container ">
     <div class="row bg-c mt-3" style="height: 900px">
         <div class="col-3 border-L">
             <ul class="nav flex-column">
                 <li class="nav-item">
                     <a class="nav-link active" aria-current="page" href="acceso.aspx">Acceso</a>
                 </li>
                 <li class="nav-item">
                     <a class="nav-link" href="Pago.aspx">Cobro</a>
                 </li>
                 <li class="nav-item">
                     <a class="nav-link" href="Socios.aspx">Socios</a>
                 </li>
                 <li class="nav-item">
                     <a class="nav-link" href="#">Actividades</a>
                 </li>
                 <li class="nav-item">
                     <a class="nav-link" href="#">Instructores</a>
                 </li>
             </ul>
         </div>
                <div class="col-9 bg-c">
                    <div class="mt-5 d-flex">
                        <div style="margin: auto">
                            <h4>Control de acceso</h4>
                            <asp:TextBox ID="txtDNI" runat="server" placeholder="Ingrese DNI del Usuario" CssClass="form-control" Width="800px"></asp:TextBox>
                        </div>
                    </div>

                    <div>
                        <h2>Subir Imagen</h2>
                        <asp:FileUpload ID="fileUploadImagen" runat="server" />
                        <br />
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar Imagen" OnClick="btnGuardar_Click" />
                        <br />
                        <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
                    </div>


                    <asp:Label ID="Label1" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
                </div>
            </div>
        </div>
    </main>

   <style>
       .bg-c {
           background-color: rgba(30,30,30,255);
           border-radius: 5px;
           border: solid;
           border-color: rgb(146, 146, 146);
           color: aliceblue;
       }

       .border-L {
           border-right: solid;
           border-color: rgb(146, 146, 146);
       }
   </style>

</asp:Content>
