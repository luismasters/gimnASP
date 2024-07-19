<%@ Page Title="Detalle de Cobro" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleCobro.aspx.cs" Inherits="Gimn_Asp.DetalleCobro" %>
<%@ Register Src="~/NavigationMenuAdmin.ascx" TagPrefix="uc" TagName="NavigationMenuAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <div class="container">
            <div class="row bg-c mt-3">
                <div class="col-3 border-L d-flex flex-column flex-shrink-0 p-3 bg-c">
                    <uc:NavigationMenuAdmin ID="NavigationMenuAdmin1" runat="server" />
                </div>
                <div class="col-9">
                    <h1>Detalle de Cobro - <asp:Label ID="lblFecha" runat="server"></asp:Label></h1>
                    <asp:GridView ID="gvDetalleCobro" runat="server" AutoGenerateColumns="false" CssClass="table" style="color:aliceblue">
                        <Columns>
                            <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="Membresia" HeaderText="Tipo Membresía" />
                            <asp:BoundField DataField="FechaCobro" HeaderText="Fecha Cobro" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="Precio" HeaderText="Monto" DataFormatString="{0:C}" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </main>
</asp:Content>
