<%@ Page Title="Dashboard Empleado" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DashboardEmpleado.aspx.cs" Inherits="Gimn_Asp.DashboardEmpleado" %>
<%@ Register Src="~/InstructorNav.ascx" TagPrefix="uc" TagName="InstructorNav" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .dashboard-card {
            background-color: rgba(30,30,30,255);
            color: aliceblue !important;
        }
    </style>
    <main>
        <div class="container">
            <div class="row bg-c mt-3">
                    <uc:InstructorNav ID="InstructorNav1" runat="server" />
                <div class="col-9">
                    <h3 class="mb-4">Dashboard Empleado</h3>
                    
                    <div class="row">
                        <div class="col-md-4 mb-4">
                            <div class="card dashboard-card">
                                <div class="card-body text-center">
                                    <asp:Image ID="imgPerfil" runat="server" CssClass="rounded-circle img-fluid mb-3" Style="max-width: 150px;" />
                                    <h5 class="card-title">
                                        <asp:Label ID="lblNombre" runat="server"></asp:Label>
                                    </h5>
                                    <p class="card-text">
                                        <asp:Label ID="lblCargo" runat="server"></asp:Label>
                                    </p>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-8">
                            <div class="card dashboard-card">
                                <div class="card-body">
                                    <h5 class="card-title">Información Personal</h5>
                                    <p class="card-text">
                                        <strong>DNI:</strong> <asp:Label ID="lblDNI" runat="server"></asp:Label><br />
                                        <strong>Email:</strong> <asp:Label ID="lblEmail" runat="server"></asp:Label><br />
                                        <strong>Fecha de Nacimiento:</strong> <asp:Label ID="lblFechaNacimiento" runat="server"></asp:Label>
                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>

                    <!-- Aquí puedes agregar más secciones según sea necesario -->

                </div>
            </div>
        </div>
    </main>
</asp:Content>