<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VerReservas.aspx.cs" Inherits="Gimn_Asp.VerReservas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-3">
        <div class="row">
            <div class="col-12 bg-c p-4 rounded">
                <h3 class="text-center">Mis Reservas</h3>
                <asp:GridView ID="gvReservas" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered text-light">
                    <Columns>
                        <asp:BoundField DataField="claseSalon.NombreClase" HeaderText="Clase" />
                        <asp:BoundField DataField="horarioClase.Fecha" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField DataField="horarioClase.HoraInicio" HeaderText="Hora Inicio" />
                        <asp:BoundField DataField="horarioClase.HoraFin" HeaderText="Hora Fin" />
                        <asp:BoundField DataField="salon.Nombre" HeaderText="Salón" />
                    </Columns>
                </asp:GridView>
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
