<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Acceso.aspx.cs" Inherits="Gimn_Asp.Acceso" %>
             <%@ Register Src="~/NavigationMenu.ascx" TagPrefix="uc" TagName="NavigationMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main>

  
      <div class="container ">


      <div class="row bg-c mt-3" >
         
<div class="col-3 border-L d-flex flex-column flex-shrink-0 p-3 bg-c">

  <uc:NavigationMenu ID="NavigationMenu1" runat="server" />


                              </div>



                <div class="col-9">
                    <div class="mt-5 d-flex">
                        <div style="margin: auto">
                            <h4>Control de acceso</h4>
                            <asp:TextBox ID="txtDNI" runat="server" placeholder="Ingrese DNI del Usuario" CssClass="form-control" Width="800px"></asp:TextBox>
                            <asp:Button ID="btnBuscar" Text="Buscar" runat="server" OnClick="Acceso_Click" CssClass="btn-success" />
                        </div>
                    </div>

                    <asp:Panel ID="pnlCard" runat="server" Visible="false">
                        <div id="card" class="mt-5 d-flex">
                            <div style="margin: auto">
                                <div class="card mb-3 bg-c" style="width: 640px; height: 300px">
                                    <div class="row g-0">
                                        <div class="col-md-4 border-L">
                                            <asp:Image ID="imgFoto" runat="server" CssClass="img-fluid rounded-start" Style="height: 290px; width: 300px" />
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

                    <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
                </div>
            </div>
        </div>
    </main>

    
</asp:Content>
