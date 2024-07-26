<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BajaModSocio.aspx.cs" Inherits="Gimn_Asp.BajaModSocio" %>
<%@ Register Src="~/NavigationMenu.ascx" TagPrefix="uc" TagName="NavigationMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <div class="container">
            <div class="row bg-c mt-3">
                <div class="col-3 border-L d-flex flex-column flex-shrink-0 p-3 bg-c">
                    <uc:NavigationMenu ID="NavigationMenu1" runat="server" />
                </div>

                <div class="col-9">
                    <h2 class="mb-4">Modificación de Socio</h2>

                    <div class="mb-4">
                        <h4>Ingrese DNI</h4>
                        <div class="input-group">
                            <asp:TextBox ID="txtDNI" runat="server" placeholder="Ingrese DNI del Usuario" CssClass="form-control" MaxLength="8" />
                            <asp:Button Text="Buscar" runat="server" OnClick="btnBuscar_Click" CssClass="btn btn-primary" />
                        </div>
                        <asp:RegularExpressionValidator ID="revDNI" runat="server" 
                            ControlToValidate="txtDNI" 
                            ErrorMessage="El DNI debe contener solo números" 
                            ValidationExpression="^\d+$" 
                            Display="Dynamic" 
                            CssClass="text-danger" />
                    </div>

                    <asp:Panel runat="server" ID="panel" Visible="true">
                        <div class="row">
                            <div class="col-md-6 mb-3">
                                <label for="txtNombre" class="form-label">Nombre:</label>
                                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" required="required" />
                            </div>
                            <div class="col-md-6 mb-3">
                                <label for="txtApellido" class="form-label">Apellido:</label>
                                <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" required="required" />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6 mb-3">
                                <label for="txtEmail" class="form-label">Email:</label>
                                <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" CssClass="form-control" required="required" />
                            </div>
                        </div>

                        <div class="mb-4">
                            <h4>Imagen de Perfil</h4>
                            <asp:Image ID="imgPerfil" runat="server" Width="200px" Height="200px" CssClass="mb-3" />
                            <asp:FileUpload ID="fileUploadImagen" runat="server" OnChange="previewImage(this)" CssClass="form-control" />
                        </div>

                        <div class="mb-3">
                            <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" CssClass="btn btn-primary" />
                        </div>

                        <asp:Label ID="lblMensaje" runat="server" CssClass="d-block mt-2"></asp:Label>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </main>

    <script type="text/javascript">
        function previewImage(input) {
            var preview = document.getElementById('<%= imgPerfil.ClientID %>');
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
</asp:Content>