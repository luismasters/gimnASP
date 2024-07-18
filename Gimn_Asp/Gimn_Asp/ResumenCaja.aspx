<%@ Page Title="Resumen de Caja" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ResumenCaja.aspx.cs" Inherits="Gimn_Asp.ResumenCaja" %>
<%@ Register Src="~/NavigationMenuAdmin.ascx" TagPrefix="uc" TagName="NavigationMenuAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <div class="container">
            <div class="row bg-c mt-3">
                <div class="col-3 border-L d-flex flex-column flex-shrink-0 p-3 bg-c">
                    <uc:NavigationMenuAdmin ID="NavigationMenuAdmin1" runat="server" />
                </div>
                <div class="col-9">
                    <h1>Resumen de Caja - <asp:Label ID="lblFecha" runat="server"></asp:Label></h1>
                    <asp:GridView ID="gvResumenCaja" runat="server" AutoGenerateColumns="false" CssClass="table" style="color:aliceblue">
                        <Columns>
                            <asp:BoundField DataField="NombreCompleto" HeaderText="Empleado" />
                            <asp:BoundField DataField="MontoTotal" HeaderText="Monto Total" DataFormatString="{0:C}" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button ID="btnVerDetalle" runat="server" Text="Ver Detalle" CommandArgument='<%# Eval("IDEmpleado") %>' OnClick="btnVerDetalle_Click" CssClass="btn btn-primary" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </main>
</asp:Content>
