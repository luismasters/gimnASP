<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarSocio.aspx.cs" Inherits="Gimn_Asp.AgregarSocio" %>
<%@ Register Src="~/NavigationMenu.ascx" TagPrefix="uc" TagName="NavigationMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <div class="container">
            <div class="row bg-c mt-3">
                <div class="col-3 border-L d-flex flex-column flex-shrink-0 p-3 bg-c">
                    <uc:NavigationMenu ID="NavigationMenu1" runat="server" />
                </div>

                <div class="col-9">
                    <h2 class="mb-4">Agregar Nuevo Socio</h2>

                    <div class="mb-4">
                        <h4>Ingrese DNI</h4>
                        <div class="input-group">
                            <asp:TextBox ID="txtDNI" runat="server" placeholder="Ingrese DNI del Usuario" CssClass="form-control" MaxLength="8" />
                            <asp:Button Text="Buscar" runat="server" OnClick="BuscarUsuario_Click" CssClass="btn btn-primary" />
                        </div>
                        <asp:RegularExpressionValidator ID="revDNI" runat="server" 
                            ControlToValidate="txtDNI" 
                            ErrorMessage="El DNI debe contener solo números" 
                            ValidationExpression="^\d+$" 
                            Display="Dynamic" 
                            CssClass="text-danger" />
                    </div>

                    <asp:Panel runat="server" ID="panel" Visible="false">
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
                                <label for="txtFechaNacimiento" class="form-label">Fecha de Nacimiento:</label>
                                <asp:TextBox ID="txtFechaNacimiento" runat="server" TextMode="Date" CssClass="form-control" required="required" />
                            </div>
                            <div class="col-md-6 mb-3">
                                <label for="txtEmail" class="form-label">Email:</label>
                                <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" CssClass="form-control" required="required" />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6 mb-3">
                                <label for="txtDNIUser" class="form-label">DNI:</label>
                                <asp:TextBox ID="txtDNIUser" runat="server" CssClass="form-control" required="required" MaxLength="8" />
                                <asp:RegularExpressionValidator ID="revDNIUser" runat="server" 
                                    ControlToValidate="txtDNIUser" 
                                    ErrorMessage="El DNI debe contener solo números" 
                                    ValidationExpression="^\d+$" 
                                    Display="Dynamic" 
                                    CssClass="text-danger" />
                            </div>
                           
                        </div>

                        <div class="row">
                         
                            <div class="col-md-6 mb-3">
                                <label for="DropDownListMembresia" class="form-label">Tipo de membresía:</label>
                                <asp:DropDownList ID="DropDownListMembresia" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownListMembresia_SelectedIndexChanged" CssClass="form-select" required="required">
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6 mb-3">
                                <label for="lblPrecio" class="form-label" style="color:aliceblue">Precio:</label>
                                <asp:Label runat="server" ID="lblPrecio" CssClass="form-control-plaintext" style="color:aliceblue" />
                            </div>
                        </div>

                        <div class="mb-4">
                            <h4>Subir Imagen</h4>
                            <asp:FileUpload ID="fileUploadImagen" runat="server" OnChange="previewImage(this)" CssClass="form-control" />
                            <asp:Image ID="imgPreview" runat="server" Width="200px" Height="200px" CssClass="mt-3 mb-3" />
                            <asp:Button ID="btnGuardar" runat="server" Text="Guardar Socio" OnClick="btnGuardar_Click" CssClass="btn btn-primary" />
                            <asp:Label ID="lblMensaje" runat="server" Text="" CssClass="d-block mt-2"></asp:Label>
                        </div>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </main>

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
</asp:Content>