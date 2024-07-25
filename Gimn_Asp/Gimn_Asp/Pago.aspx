<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pago.aspx.cs" Inherits="Gimn_Asp.Pago" %>
<%@ Register Src="~/NavigationMenu.ascx" TagPrefix="uc" TagName="NavigationMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <div class="container">
            <div class="row bg-c mt-3">
                <div class="col-3 border-L d-flex flex-column flex-shrink-0 p-3 bg-c">
                    <uc:NavigationMenu ID="NavigationMenu1" runat="server" />
                </div>
                
                <div class="col-9">
                    <h2 class="text-center mb-4">Cobrar Mensualidad</h2>
                    
                    <div class="d-flex justify-content-center mb-3">
                        <div class="input-group" style="max-width: 500px;">
                            <asp:TextBox ID="txtDNI" runat="server" CssClass="form-control" placeholder="Ingrese DNI del Usuario"></asp:TextBox>
                            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="btnBuscar_Click" />
                        </div>
                    </div>
                    
                    <div class="d-flex justify-content-center mb-4">
                        <asp:ListBox ID="lstPersonas" runat="server" CssClass="form-select" Style="max-width: 500px;" Height="100px" OnSelectedIndexChanged="lstPersonas_SelectedIndexChanged" AutoPostBack="true"></asp:ListBox>
                    </div>
                          <asp:Panel ID="pnlCard" runat="server" Visible="false">
            <div id="card" class="mt-5 d-flex">
                <div style="margin: auto">
                    <div class="card mb-3 bg-c" style="width: 640px; height: 300px">
                        <div class="row g-0">
                            <div class="col-md-4 border-L">
                                <asp:Image ID="imgFoto" runat="server" CssClass="img-fluid rounded-start" Style="height: 300px; width: 300px" />
                            </div>
                            <div class="col-md-8">
                                <div class="card-body">
                                    <h5 class="card-title">Nombre:
                            <asp:Label ID="lblNombre" runat="server" /></h5>
                                    <p class="card-text">
                                        Tipo de Membresia:
                            <asp:Label ID="lblTipoMembresia" runat="server" />
                                    </p>

                                    <p class="card-text">
                                        Fecha de Inicio:
                            <asp:Label ID="lblFechaInicio" runat="server" />
                                    </p>
                                    <p class="card-text">
                                        Fecha de Vencimiento:
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
                    
                    <div class="row mb-3">
                        <div class="col-md-6">
                            <label for="txtFechaActual" class="form-label">Inicio Nuevo Periodo</label>
                            <asp:TextBox ID="txtFechaActual" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                        </div>
                        <div class="col-md-6">
                            <label for="txtfinNuevoPeriodo" class="form-label">Próximo Vencimiento</label>
                            <asp:TextBox ID="txtfinNuevoPeriodo" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                        </div>
                    </div>
                    
                    <div class="row mb-4">
                        <div class="col-md-6">
                            <label for="DropDownListMembresia" class="form-label">Tipo de membresía</label>
                            <asp:DropDownList ID="DropDownListMembresia" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="DropDownListMembresia_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-6">
                            <label for="lblPrecio" class="form-label">Precio</label>
                            <asp:Label ID="lblPrecio" runat="server" CssClass="form-control-plaintext"></asp:Label>
                        </div>
                    </div>
                    
                    <div class="d-flex justify-content-center">
                        <asp:Button ID="btnRegistrarPago" runat="server" Text="Registrar Pago" CssClass="btn btn-primary" Style="width: 200px;" OnClick="RegistrarPago_Click" />
                    </div>
                    
                    <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger mt-3" Visible="false"></asp:Label>
                </div>
            </div>
        </div>
    </main>
</asp:Content>