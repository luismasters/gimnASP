<%@ Page Title="Horario del Instructor" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HorarioInstructor.aspx.cs" Inherits="Gimn_Asp.HorarioInstructor" %>
<%@ Register Src="~/InstructorNav.ascx" TagPrefix="uc" TagName="InstructorNav" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .metric-card {
            background-color: rgba(30,30,30,255);
            color: aliceblue !important;
        }
    </style>
    <main>
        <div class="container">
            <div class="row bg-c mt-3">
                    <uc:InstructorNav ID="InstructorNav1" runat="server" />
                <div class="col-9">
                    <h2 class="mb-4">Mi Horario de Clases</h2>
                    
                    <div class="row">
                        <div class="col-md-4 mb-3">
                            <label for="txtFechaInicio">Fecha Inicio:</label>
                            <asp:TextBox ID="txtFechaInicio" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                        </div>
                        <div class="col-md-4 mb-3">
                            <label for="txtFechaFin">Fecha Fin:</label>
                            <asp:TextBox ID="txtFechaFin" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                        </div>
                        <div class="col-md-4 mb-3 d-flex align-items-end">
                            <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" CssClass="btn btn-primary" OnClick="btnFiltrar_Click" />
                        </div>
                    </div>
                    
                    <div class="card metric-card mt-3">
                        <div class="card-body">
                            <asp:GridView ID="gvHorarioInstructor" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered text-white">
                                <Columns>
                                    <asp:BoundField DataField="claseSalon.NombreClase" HeaderText="Clase" />
                                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:d}" />
                                    <asp:BoundField DataField="HoraInicio" HeaderText="Hora Inicio" />
                                    <asp:BoundField DataField="HoraFin" HeaderText="Hora Fin" />
                                    <asp:BoundField DataField="salon.Nombre" HeaderText="Salón" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    
                    <asp:Label ID="lblError" runat="server" CssClass="text-danger mt-3" Visible="false"></asp:Label>
                </div>
            </div>
        </div>
    </main>
</asp:Content>