<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReservarClases.aspx.cs" Inherits="Gimn_Asp.ReservarClases" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-3">
        <div class="row">
            <div class="col-12 bg-c p-4 rounded">
                <h3 class="text-center">Reservar Clase</h3>

                <asp:GridView ID="gvHorariosDisponibles" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered text-light" DataKeyNames="ID,IDClaseSalon,IDSalon" OnRowCommand="gvHorariosDisponibles_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="claseSalon.NombreClase" HeaderText="Clase" />
                        <asp:BoundField DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField DataField="HoraInicio" HeaderText="Hora Inicio" />
                        <asp:BoundField DataField="HoraFin" HeaderText="Hora Fin" />
                        <asp:BoundField DataField="salon.Nombre" HeaderText="Salón" />
                        <asp:BoundField DataField="CapacidadRestante" HeaderText="Capacidad Restante" />
                        <asp:BoundField DataField="Instructor.Nombre" HeaderText="Instructor" />
                        <asp:BoundField DataField="Instructor.Apellido" HeaderText=" " />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnReservar" runat="server" CommandName="Reservar" CommandArgument='<%# Container.DataItemIndex %>' Text="Reservar" CssClass="btn btn-primary" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
            </div>
        </div>
    </div>

</asp:Content>
