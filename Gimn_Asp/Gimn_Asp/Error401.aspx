<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Error401.aspx.cs" Inherits="Gimn_Asp.Error401" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        body {
            background-image: url('Content/Imagen/Captura de pantalla 2024-07-26 134724.png');
            background-size: cover;
            background-position: center;
            height: 100vh;
            margin: 0;
            display: flex;
            justify-content: center;
            align-items: center;
        }
        .contenido {
            text-align: center;
            
        }
    </style>

    <div class="contenido">
        <asp:Label ID="lblMensaje" runat="server" Text="" Font-Size="50px" ForeColor  ="black"></asp:Label>
        <br />
        <asp:Button ID="btnAceptar" runat="server" Text="Aceptar"  />
    </div>

</asp:Content>
