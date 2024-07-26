<%@ Page Title="Métricas de Ingresos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MetricasIngresos.aspx.cs" Inherits="Gimn_Asp.MetricasIngresos" %>
<%@ Register Src="~/NavigationMenuAdmin.ascx" TagPrefix="uc" TagName="NavigationMenuAdmin" %>

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
                <div class="col-3 border-L d-flex flex-column flex-shrink-0 p-3 bg-c">
                    <uc:NavigationMenuAdmin ID="NavigationMenuAdmin1" runat="server" />
                </div>
                <div class="col-9">
                    <h3 class="mb-4">Métricas de Ingresos</h3>
                    
                    <div class="row">
                        <div class="col-md-4 mb-4">
                            <div class="card metric-card">
                                <div class="card-body">
                                    <h5 class="card-title">
                                        <i class="fas fa-calendar-day me-2"></i>Ingresos Diarios
                                    </h5>
                                    <p class="card-text">
                                        <asp:Label ID="lblIngresosDiarios" runat="server"></asp:Label>
                                    </p>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4 mb-4">
                            <div class="card metric-card">
                                <div class="card-body">
                                    <h5 class="card-title">
                                        <i class="fas fa-calendar-alt me-2"></i>Ingresos en el mes
                                    </h5>
                                    <p class="card-text">
                                        <asp:Label ID="lblIngresosMensuales" runat="server"></asp:Label>
                                    </p>
                                </div>
                            </div>
                        </div>
                     <div class="col-md-4 mb-4">
    <div class="card metric-card">
        <div class="card-body">
            <h5 class="card-title">
                <i class="fas fa-user-check me-2"></i>Membresías Activas
            </h5>
            <p class="card-text">
                <asp:Label ID="lblMembresiasActivas" runat="server"></asp:Label>
            </p>
        </div>
    </div>
</div>
<div class="col-md-4 mb-4">
    <div class="card metric-card">
        <div class="card-body">
            <h5 class="card-title">
                <i class="fas fa-user-times me-2"></i>Membresías Vencidas
            </h5>
            <p class="card-text">
                <asp:Label ID="lblMembresiasVencidas" runat="server"></asp:Label>
            </p>
        </div>
    </div>
</div>
                    </div>

                    <h4 class="mt-4">Resumen Filtrado por Fechas</h4>
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
                    <asp:Label ID="lblIngresosFiltrados" runat="server" CssClass="form-control mt-3"></asp:Label>
                </div>
            </div>
        </div>
    </main>
</asp:Content>