<%@ Page Title="Horario del Instructor" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HorarioInstructor.aspx.cs" Inherits="Gimn_Asp.HorarioInstructor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <div class="container">
            <h2>Mi Horario de Clases</h2>
            
            <div class="form-group">
                <label for="txtFechaInicio">Fecha Inicio:</label>
                <asp:TextBox ID="txtFechaInicio" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtFechaFin">Fecha Fin:</label>
                <asp:TextBox ID="txtFechaFin" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
            </div>
            <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" CssClass="btn btn-primary mt-2" OnClick="btnFiltrar_Click" />

            <asp:GridView ID="gvHorarioInstructor" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered mt-3">
                <Columns>
                    <asp:BoundField DataField="claseSalon.NombreClase" HeaderText="Clase" />
                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:d}" />
                    <asp:BoundField DataField="HoraInicio" HeaderText="Hora Inicio" />
                    <asp:BoundField DataField="HoraFin" HeaderText="Hora Fin" />
                    <asp:BoundField DataField="salon.Nombre" HeaderText="Salón" />
                </Columns>
            </asp:GridView>
        </div>
    </main>
</asp:Content>