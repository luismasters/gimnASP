<%@ Page Title="Modificar Empleado" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificarEmpleado.aspx.cs" Inherits="Gimn_Asp.ModificarEmpleado" %>
<%@ Register Src="~/NavigationMenuAdmin.ascx" TagPrefix="uc" TagName="NavigationMenuAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <div class="container">
            <div class="row bg-c mt-3">
                <div class="col-3 border-L d-flex flex-column flex-shrink-0 p-3 bg-c">
                    <uc:NavigationMenuAdmin ID="NavigationMenuAdmin1" runat="server" />
                </div>
                <div class="col-9">
                    <h2 class="mb-4">Modificar Empleado</h2>
                    
                    <asp:Label ID="lblMensaje" runat="server" CssClass="text-info"></asp:Label>
                    
                    <div class="row">
                        <div class="col-md-6 mb-3">
                            <label for="txtDNI" class="form-label">DNI:</label>
                            <asp:TextBox ID="txtDNI" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="col-md-6 mb-3">
                            <label for="txtNombre" class="form-label">Nombre:</label>
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvNombre" runat="server" 
                                ControlToValidate="txtNombre" ErrorMessage="El nombre es requerido." 
                                CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-6 mb-3">
                            <label for="txtApellido" class="form-label">Apellido:</label>
                            <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvApellido" runat="server" 
                                ControlToValidate="txtApellido" ErrorMessage="El apellido es requerido." 
                                CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-6 mb-3">
                            <label for="txtEmail" class="form-label">Email:</label>
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" 
                                ControlToValidate="txtEmail" ErrorMessage="El email es requerido." 
                                CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revEmail" runat="server" 
                                ControlToValidate="txtEmail" ErrorMessage="Email inválido." 
                                CssClass="text-danger" Display="Dynamic" 
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-6 mb-3">
                            <label for="txtFechaNacimiento" class="form-label">Fecha de Nacimiento:</label>
                            <asp:TextBox ID="txtFechaNacimiento" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvFechaNacimiento" runat="server" 
                                ControlToValidate="txtFechaNacimiento" ErrorMessage="La fecha de nacimiento es requerida." 
                                CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-6 mb-3">
                            <label for="ddlCargo" class="form-label">Cargo:</label>
                            <asp:DropDownList ID="ddlCargo" runat="server" CssClass="form-select"></asp:DropDownList>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-6 mb-3">
                            <label for="ddlRol" class="form-label">Rol:</label>
                            <asp:DropDownList ID="ddlRol" runat="server" CssClass="form-select"></asp:DropDownList>
                        </div>
                        <div class="col-md-6 mb-3">
                            <div class="form-check mt-4">
                                <asp:CheckBox ID="chkEstadoActivo" runat="server" Text="Activo" CssClass="form-check-input" />
                                <label class="form-check-label" for="chkEstadoActivo">Estado Activo</label>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-6 mb-3">
                            <label for="txtNombreUsuario" class="form-label">Nombre de Usuario:</label>
                            <asp:TextBox ID="txtNombreUsuario" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvNombreUsuario" runat="server" 
                                ControlToValidate="txtNombreUsuario" ErrorMessage="El nombre de usuario es requerido." 
                                CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-6 mb-3">
                            <label for="txtClave" class="form-label">Nueva Contraseña (dejar en blanco si no cambia):</label>
                            <asp:TextBox ID="txtClave" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                        </div>
                    </div>

                    <div class="mt-4">
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar Cambios" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary ms-2" OnClick="btnCancelar_Click" CausesValidation="false" />
                    </div>
                </div>
            </div>
        </div>
    </main>
</asp:Content>