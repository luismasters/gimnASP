<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Acceso.aspx.cs" Inherits="Gimn_Asp.Acceso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <div class="container ">
            <div class="row" style="height: 900px">
                <div class="col-3 bg-c">
                    <ul class="nav flex-column">
                        <li class="nav-item">
                                     <a class="nav-link active" aria-current="page" href="acceso.aspx">Acceso</a>
            </li>
            <li class="nav-item">
                <a class="nav-link" href="Pago.aspx">Cobro</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#">Socios</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#">Actividades</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#">Instructores</a>
                        </li>
                    </ul>
                </div>
                <div class="col-9 bg-c">
                    <div class="mt-5 d-flex">
                        <div style="margin: auto">
                            <h4>Control de acceso</h4>
                            <asp:TextBox ID="txtDNI" runat="server" placeholder="Ingrese DNI del Usuario" CssClass="form-control" Width="800px"></asp:TextBox>
                            <asp:Button ID="btnBuscar" Text="Buscar" runat="server" onclick="Acceso_Click" CssClass="btn-success" />
                        </div>
                    </div>
                    
                    <asp:Panel ID="pnlCard" runat="server" Visible="false">
                        <div id="card" class="mt-5 d-flex">
                            <div style="margin: auto">
                                <div class="card mb-3 bg-c" style="width: 640px;height:300px">
                                    <div class="row g-0">
                                        <div class="col-md-4 bg-c">
                                            <img src="Content/Imagen/gymn.jpg" class="img-fluid rounded-start" alt="..." style="height:300px;width:300px">
                                        </div>
                                        <div class="col-md-8 bg-c">
                                            <div class="card-body">
                                                <h5 class="card-title">Nombre:
                                                    <asp:Label ID="lblNombre" runat="server" /></h5>
                                                <p class="card-text">Tipo de Membresia:
                                                    <asp:Label ID="lblTipoMembresia" runat="server" /></p>

                                                <p class="card-text">Fecha de Inicio:
                                                    <asp:Label ID="lblFechaInicio" runat="server" /></p>
                                                <p class="card-text">Fecha de Vencimiento:
                                                    <asp:Label ID="lblFechaVencimiento" runat="server" /></p>
                                                
                                                <p class="card-text">
                                                    <asp:Label ID="lblAcceso" runat="server" />
                                                </p>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>

                    <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
                </div>
            </div>
        </div>
    </main>

    <style>
        .bg-c {
            background-color: rgb(60, 60, 60);
            border-radius: 5px;
            border: solid;
            border-color: red;
            color: aliceblue;
        }
    </style>
</asp:Content>
