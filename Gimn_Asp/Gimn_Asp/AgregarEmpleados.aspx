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
                    <h3>Agregar Nuevo Empleado</h3>
                    <asp:Label ID="lblMensaje" runat="server" Text="" ForeColor="Red"></asp:Label>
                    
                    <!-- Campos de empleado -->
                    <div class="form-group">
                        <label for="txtDNI">DNI:</label>
                        <asp:TextBox ID="txtDNI" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="txtNombre">Nombre:</label>
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="txtApellido">Apellido:</label>
                        <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="txtEmail">Email:</label>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="txtFechaNacimiento">Fecha de Nacimiento:</label>
                        <asp:TextBox ID="txtFechaNacimiento" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                    </div>
                    
                    <!-- Selección de cargo -->
                    <div class="form-group">
                        <label for="ddlCargos">Cargo:</label>
                        <asp:DropDownList ID="ddlCargos" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>

                    <!-- Campos de usuario -->
                    <div class="form-group">
                        <label for="txtNombreUsuario">Nombre de Usuario:</label>
                        <asp:TextBox ID="txtNombreUsuario" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="txtClave">Clave:</label>
                        <asp:TextBox ID="txtClave" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="ddlRoles">Rol:</label>
                        <asp:DropDownList ID="ddlRoles" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>

                    <!-- Carga de imagen -->
                    <div class="form-group">
                        <h2>Subir Imagen</h2>
                        <asp:FileUpload ID="fileUploadImagen" runat="server" OnChange="previewImage(this)" />
                        <br />
                        <asp:Image ID="imgPreview" runat="server" Width="200px" Height="200px" />
                        <br />
                        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                    </div>

                    <asp:Button ID="btnAgregarEmpleado" runat="server" Text="Agregar Empleado" CssClass="btn btn-primary mt-2" OnClick="btnAgregarEmpleado_Click" />
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
