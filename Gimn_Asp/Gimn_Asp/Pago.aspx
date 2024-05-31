<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pago.aspx.cs" Inherits="Gimn_Asp.Pago" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <div class="container ">
            <div class="row" style="height: 700px">
                <div class="col-3 bg-c">
                    <ul class="nav flex-column">
                        <li class="nav-item">
                            <a class="nav-link active" aria-current="page" href="acceso.aspx">Acceso</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="Pago.aspx">Cobro</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="Socios.aspx">Socios</a>
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
                    <div class="mt-1 d-flex">
                        <div style="margin: auto">
                            <h4>Cobrar Mensualidad</h4>
                            <asp:TextBox ID="txtDNI" runat="server" placeholder="Ingrese DNI del Usuario" CssClass="form-control" Width="800px"></asp:TextBox>
                            <asp:Button ID="btnBuscar" Text="Buscar" runat="server" CssClass="btn-success" OnClick="btnBuscar_Click" />
                        </div>
                    </div>

                    <div class="mt-2 d-flex">
                        <div style="margin: auto">
                            <div class="row g-3">
                                <asp:Panel ID="pnlCard" runat="server">
                                    <div id="card" class="mt-5 d-flex">
                                        <div style="margin: auto">
                                            <div class="card mb-3 bg-c" style="width: 640px; height: 300px">
                                                <div class="row g-0">
                                                    <div class="col-md-4 bg-c">
                                                        <img src="Content/Imagen/gymn.jpg" class="img-fluid rounded-start" alt="..." style="height: 300px; width: 300px">
                                                    </div>
                                                    <div class="col-md-8 bg-c">
                                                        <div class="card-body">
                                                            <h5 class="card-title">Nombre:
                                                                <asp:Label ID="lblNombre" runat="server" />
                                                            </h5>
                                                            <p class="card-text">Membresia:
                                                                <asp:Label ID="lblTipoMembresia" runat="server" />
                                                            </p>
                                                            <p class="card-text">Ultimo Pago:
                                                                <asp:Label ID="lblFechaInicio" runat="server" />
                                                            </p>
                                                            <p class="card-text">Vencimiento:
                                                                <asp:Label ID="lblFechaVencimiento" runat="server" />
                                                            </p>
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

                                <div class="col-md-6">
                                    <label for="inputEndDate" class="form-label">Inicio Nuevo Periodo</label>
                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtFechaActual" />
                                </div>

                                <div class="col-md-6">
                                    <label for="inputEndDate" class="form-label">Proximo Vencimiento</label>
                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtfinNuevoPeriodo" />
                                </div>

                                <div class="col-md-6">
                                    <label for="inputMembershipType" class="form-label">Tipo de membresía</label>
                                    <asp:DropDownList ID="DropDownListMembresia" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownListMembresia_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>

                                <div class="col-md-6">
                                    <label for="inputPrice" class="form-label">Precio</label>
                                    <asp:Label runat="server" ID="lblPrecio" />
                                </div>

                                <div class="col-12 mb-2">
                            <asp:Button ID="txtBotonReg" Text="Registrar Pago" runat="server" CssClass="btn-success" onclick="RegistrarPago_Click" />
                                </div>
                            </div>
                        </div>
                    </div>

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
