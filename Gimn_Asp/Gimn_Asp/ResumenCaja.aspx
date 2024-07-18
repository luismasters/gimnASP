<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ResumenCaja.aspx.cs" Inherits="Gimn_Asp.ResumenCaja" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Resumen de Caja - <asp:Label ID="lblFecha" runat="server"></asp:Label></h1>
    <asp:GridView ID="gvResumenCaja" runat="server" AutoGenerateColumns="false" CssClass="table">
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
</asp:Content>
