<%@ Page Title="Detalle de Reservas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleReservas.aspx.cs" Inherits="Gimn_Asp.DetalleReservas" %>
             <%@ Register Src="~/NavigationMenu.ascx" TagPrefix="uc" TagName="NavigationMenu" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">





    <div class="row bg-c mt-3">

        <div class="col-3 border-L d-flex flex-column flex-shrink-0 p-3 bg-c">

            <uc:navigationmenu id="NavigationMenu1" runat="server" />


        </div>



        <div class="col-9">

            <h3 class="text-center">Detalle de Reservas</h3>

            <asp:GridView ID="gvReservas" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered text-light">
                <Columns>
                    <asp:BoundField DataField="miembro.Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="miembro.Apellido" HeaderText="Apellido" />
                  
                </Columns>
            </asp:GridView>
        </div>
    </div>
                     

</asp:Content>
