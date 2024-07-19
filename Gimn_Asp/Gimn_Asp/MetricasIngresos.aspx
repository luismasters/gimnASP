<%@ Page Title="Métricas de Ingresos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MetricasIngresos.aspx.cs" Inherits="Gimn_Asp.MetricasIngresos" %>
<%@ Register Src="~/NavigationMenuAdmin.ascx" TagPrefix="uc" TagName="NavigationMenuAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <div class="container">
            <div class="row bg-c mt-3">
                <div class="col-3 border-L d-flex flex-column flex-shrink-0 p-3 bg-c">
                    <uc:NavigationMenuAdmin ID="NavigationMenuAdmin1" runat="server" />
                </div>
                <div class="col-9">
                    <h3>Métricas de Ingresos</h3>

                    <h4>Resumen Diario</h4>
                    <asp:Label ID="lblIngresosDiarios" runat="server" CssClass="form-control"></asp:Label>

                    <h4>Resumen Mensual</h4>
                    <asp:Label ID="lblIngresosMensuales" runat="server" CssClass="form-control"></asp:Label>

                    <h4>Resumen Filtrado por Fechas</h4>
                    <div class="form-group">
                        <label for="txtFechaInicio">Fecha Inicio:</label>
                        <asp:TextBox ID="txtFechaInicio" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="txtFechaFin">Fecha Fin:</label>
                        <asp:TextBox ID="txtFechaFin" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                    </div>
                    <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" CssClass="btn btn-primary mt-2" OnClick="btnFiltrar_Click" />

                    <asp:Label ID="lblIngresosFiltrados" runat="server" CssClass="form-control mt-3"></asp:Label>
                </div>
            </div>
        </div>
    </main>
</asp:Content>
