<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleCobro.aspx.cs" Inherits="Gimn_Asp.DetalleCobro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Detalle de Cobro - <asp:Label ID="lblFecha" runat="server"></asp:Label></h1>
    <asp:GridView ID="gvDetalleCobro" runat="server" AutoGenerateColumns="false" CssClass="table">
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID Cobro" />
            <asp:BoundField DataField="IDPersona" HeaderText="ID Persona" />
            <asp:BoundField DataField="IDTipoMembresia" HeaderText="ID Tipo Membresía" />
            <asp:BoundField DataField="FechaCobro" HeaderText="Fecha Cobro" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField DataField="Precio" HeaderText="Monto" DataFormatString="{0:C}" />
        </Columns>
    </asp:GridView>
</asp:Content>
