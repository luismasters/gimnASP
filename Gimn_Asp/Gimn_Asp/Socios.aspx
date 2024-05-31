<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Socios.aspx.cs" Inherits="Gimn_Asp.Socios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <div class="container">
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
                            <h4>Buscar Socio</h4>
                            <asp:TextBox ID="txtBuscar" runat="server" placeholder="Buscar por DNI, Nombre o Apellido" CssClass="form-control" Width="800px" AutoPostBack="true" OnTextChanged="txtBuscar_TextChanged"></asp:TextBox>
                        </div>
                    </div>
                    <div class="mt-3">
                        <asp:ListBox ID="lstPersonas" runat="server" CssClass="form-control" Height="200px" OnSelectedIndexChanged="lstPersonas_SelectedIndexChanged" AutoPostBack="true">
                        </asp:ListBox>
                    </div>
                    <div class="mt-3">
                        <asp:GridView ID="gvPersonas" runat="server" CssClass="table table-striped" AutoGenerateColumns="false">
                            <Columns>
                                <asp:BoundField DataField="ID" HeaderText="ID" />
                                <asp:BoundField DataField="DNI" HeaderText="DNI" />
                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                                <asp:BoundField DataField="Email" HeaderText="Email" />
                                <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha Nacimiento" DataFormatString="{0:dd/MM/yyyy}" />
                            </Columns>
                        </asp:GridView>
                    </div>
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
