<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarSocio.aspx.cs" Inherits="Gimn_Asp.AgregarSocio" %>
    <%@ Register Src="~/NavigationMenu.ascx" TagPrefix="uc" TagName="NavigationMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">




    <main>
        <div class="container ">
            <div class="row bg-c mt-3" style="height: 900px">
                                                      <uc:NavigationMenu ID="NavigationMenu1" runat="server" />

                <div class="col-9 bg-c">




                    <div>
                        <h2>Agregar Nuevo Socio</h2>

                        <div class="mt-5 d-flex">
                            <div style="margin: auto">
                                <h4>Control de acceso</h4>
                                <asp:TextBox ID="txtDNI" runat="server" placeholder="Ingrese DNI del Usuario" CssClass="form-control" Width="800px"></asp:TextBox>
                                <asp:Button Text="Enviar" runat="server" OnClick="BuscarUsuario_Click" />
                            </div>
                        </div>

                        <asp:Panel runat="server" ID="panel" Visible="false">
                            <table>
                                <tr>
                                    <td>Nombre:</td>
                                    <td>
                                        <asp:TextBox ID="txtNombre" runat="server" /></td>
                                </tr>
                                <tr>
                                    <td>Apellido:</td>
                                    <td>
                                        <asp:TextBox ID="txtApellido" runat="server" /></td>
                                </tr>
                                <tr>
                                    <td>Fecha de Nacimiento:</td>
                                    <td>
                                        <asp:TextBox ID="txtFechaNacimiento" runat="server" TextMode="Date" /></td>
                                </tr>
                                <tr>
                                    <td>Email:</td>
                                    <td>
                                        <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" /></td>
                                </tr>
                                <tr>
                                    <td>DNI:</td>
                                    <td>
                                        <asp:TextBox ID="txtDNIUser" runat="server" /></td>
                                </tr>
                                <tr>
                                    <td>Inicio Nuevo Periodo</td>
                                    <td>     <asp:TextBox runat="server" CssClass="form-control" ID="txtFechaActual" />

                                       </td>
                                </tr>
                                <tr>
                                    <td>Inicio Nuevo Periodo</td>
                                    <td>
                                             <asp:TextBox runat="server" CssClass="form-control" ID="txtfinNuevoPeriodo" /></td>

                                </tr>


                            </table>

                     <div class="col-md-6">
     <label for="inputMembershipType" class="form-label">Tipo de membresía</label>
     <asp:DropDownList ID="DropDownListMembresia" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownListMembresia_SelectedIndexChanged">
     </asp:DropDownList>
 </div>

 <div class="col-md-6">
     <label for="inputPrice" class="form-label">Precio</label>
     <asp:Label runat="server" ID="lblPrecio" />
 </div>
                  







                    <script type="text/javascript">
                        function previewImage(input) {
                            var preview = document.getElementById('<%= imgPreview.ClientID %>');
                            var file = input.files[0];
                            var reader = new FileReader();

                            reader.onload = function (e) {
                                preview.src = e.target.result;
                            };

                            if (file) {
                                reader.readAsDataURL(file);
                            }
                        }
    </script>



                    <div>
                        <h2>Subir Imagen</h2>
                        <asp:FileUpload ID="fileUploadImagen" runat="server" OnChange="previewImage(this)" />
                        <br />
                        <asp:Image ID="imgPreview" runat="server" Width="200px" Height="200px" />
                        <br />
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar Imagen" OnClick="btnGuardar_Click" />
                        <br />
                        <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
                    </div>


    </asp:Panel>

                </div>
            </div>
  </div>
        
</asp:Content>
