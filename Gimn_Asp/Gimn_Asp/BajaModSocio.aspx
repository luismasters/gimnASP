<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BajaModSocio.aspx.cs" Inherits="Gimn_Asp.BajaModSocio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Baja/Modificación de Socio</h2>
    <div>
        <asp:Label ID="lblDNI" runat="server" Text="DNI:"></asp:Label>
        <asp:TextBox ID="txtDNI" runat="server"></asp:TextBox>
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
        <br /><br />

        <asp:Label ID="lblNombre" runat="server" Text="Nombre:"></asp:Label>
        <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblApellido" runat="server" Text="Apellido:"></asp:Label>
        <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" />
        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
        <br /><br />
        <asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label>
    </div>
</asp:Content>
