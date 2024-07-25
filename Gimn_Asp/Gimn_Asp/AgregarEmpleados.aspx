<%@ Page Title="Agregar Empleados" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarEmpleados.aspx.cs" Inherits="Gimn_Asp.AgregarEmpleados" %>
<%@ Register Src="~/NavigationMenuAdmin.ascx" TagPrefix="uc" TagName="NavigationMenuAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <div class="container">
            <div class="row bg-c mt-3">
                <div class="col-3 border-L d-flex flex-column flex-shrink-0 p-3 bg-c">
                    <uc:NavigationMenuAdmin ID="NavigationMenuAdmin1" runat="server" />
                </div>
                <div class="col-9">
                    <h2 class="mb-4">Agregar Nuevo Empleado</h2>
                    <asp:Label ID="lblMensaje" runat="server" Text="" CssClass="d-block mt-2"></asp:Label>
                    
                    <div class="row">
                        <div class="col-md-6 mb-3">
                            <label for="txtDNI" class="form-label">DNI:</label>
                            <asp:TextBox ID="txtDNI" runat="server" CssClass="form-control" required="required" MaxLength="8" />
                            <asp:RegularExpressionValidator ID="revDNI" runat="server" 
                                ControlToValidate="txtDNI" 
                                ErrorMessage="El DNI debe contener solo números" 
                                ValidationExpression="^\d+$" 
                                Display="Dynamic" 
                                CssClass="text-danger" />
                        </div>
                        <div class="col-md-6 mb-3">
                            <label for="txtNombre" class="form-label">Nombre:</label>
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" required="required" />
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-6 mb-3">
                            <label for="txtApellido" class="form-label">Apellido:</label>
                            <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" required="required" />
                        </div>
                        <div class="col-md-6 mb-3">
                            <label for="txtEmail" class="form-label">Email:</label>
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" required="required" TextMode="Email" />
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-6 mb-3">
                            <label for="txtFechaNacimiento" class="form-label">Fecha de Nacimiento:</label>
                            <asp:TextBox ID="txtFechaNacimiento" runat="server" CssClass="form-control" required="required" TextMode="Date" />
                        </div>
                        <div class="col-md-6 mb-3">
                            <label for="ddlCargos" class="form-label">Cargo:</label>
                            <asp:DropDownList ID="ddlCargos" runat="server" CssClass="form-select" required="required"></asp:DropDownList>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-6 mb-3">
                            <label for="txtNombreUsuario" class="form-label">Nombre de Usuario:</label>
                            <asp:TextBox ID="txtNombreUsuario" runat="server" CssClass="form-control" required="required" />
                        </div>
                        <div class="col-md-6 mb-3">
                            <label for="txtClave" class="form-label">Clave:</label>
                            <asp:TextBox ID="txtClave" runat="server" CssClass="form-control" required="required" TextMode="Password" />
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-6 mb-3">
                            <label for="ddlRoles" class="form-label">Rol:</label>
                            <asp:DropDownList ID="ddlRoles" runat="server" CssClass="form-select" required="required"></asp:DropDownList>
                        </div>
                    </div>

                    <div class="mb-4">
                        <h4>Subir Imagen</h4>
                        <asp:FileUpload ID="fileUploadImagen" runat="server" OnChange="previewImage(this)" CssClass="form-control" />
                        <asp:Image ID="imgPreview" runat="server" Width="200px" Height="200px" CssClass="mt-3 mb-3" />
                    </div>

                    <asp:Button ID="btnAgregarEmpleado" runat="server" Text="Agregar Empleado" CssClass="btn btn-primary" OnClick="btnAgregarEmpleado_Click" />
                </div>
            </div>
        </div>
        <script type="text/javascript">
            function previewImage(input) {
                if (input.files && input.files[0]) {
                    var reader = new FileReader();
                    reader.onload = function (e) {
                        document.getElementById('<%= imgPreview.ClientID %>').src = e.target.result;
                    };
                    reader.readAsDataURL(input.files[0]);
                }
            }
        </script>
    </main>
</asp:Content>