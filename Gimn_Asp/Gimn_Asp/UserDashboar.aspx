<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserDashboar.aspx.cs" Inherits="Gimn_Asp.UserDashboar" %>

<%@ Register Src="~/UserNav.ascx" TagName="UserNav" TagPrefix="uc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <main>


        <div class="container ">
            <div class="row bg-c mt-3" style="height: 900px">
                <uc:UserNav ID="UserNav1" runat="server" />

                <div class="col-9">

             <h3 class="text-center">Datos del Miembro</h3>
        <div class="row">
            <div class="col-md-4 text-center">
                <asp:Image ID="imgPerfil" runat="server" CssClass="img-thumbnail" Width="200px" Height="200px" />
            </div>
            <div class="col-md-8 p-4 rounded">
                <p><strong>DNI:</strong> <asp:Label ID="lblDNI" runat="server" /></p>
                <p><strong>Nombre:</strong> <asp:Label ID="lblNombre" runat="server" /></p>
                <p><strong>Apellido:</strong> <asp:Label ID="lblApellido" runat="server" /></p>
                <p><strong>Tipo Membresía:</strong> <asp:Label ID="lblTipoMembresia" runat="server" /></p>
                <p><strong>Último Período:</strong> <asp:Label ID="lblUltimoPeriodo" runat="server" /></p>
                <asp:Panel runat="server" ID="panelVencimiento"  >
                <p><strong>Próximo Vencimiento:</strong> <asp:Label ID="lblFechaProximoVencimiento" runat="server" /></p></asp:Panel>
                <p><strong>Estado Membresía:</strong> <asp:Label ID="lblEstadoMembresia" runat="server" /></p>
            </div>
        </div>
                </div>
            </div>
        </div>

    </main>
</asp:Content>
