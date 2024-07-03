﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Socios.aspx.cs" Inherits="Gimn_Asp.Socios" %>
<%@ Register Src="~/NavigationMenu.ascx" TagPrefix="uc" TagName="NavigationMenu" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <div class="container ">
            <div class="row bg-c mt-3" style="height: 900px">
                                      <uc:NavigationMenu ID="NavigationMenu1" runat="server" />


             
                <div class="col-9 bg-c">
                    <div class="mt-1 d-flex">
                        <div style="margin: auto">
                            <h4>Buscar Socio</h4>
                            <asp:TextBox ID="txtBuscar" runat="server" placeholder="Buscar por DNI, Nombre o Apellido" CssClass="form-control" Width="800px" AutoPostBack="true" OnTextChanged="txtBuscar_TextChanged"></asp:TextBox>
                        </div>
                    </div>
                    <div class="mt-3">
                        <asp:ListBox ID="lstPersonas" runat="server" CssClass="form-control" Height="200px" OnSelectedIndexChanged="lstPersonas_SelectedIndexChanged" AutoPostBack="true"></asp:ListBox>
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

                </div>
            </div>
        </div>
    </main>

</asp:Content>
