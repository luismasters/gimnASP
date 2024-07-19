<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NavigationMenuAdmin.ascx.cs" Inherits="Gimn_Asp.NavigationMenuAdmin" %>

<a href="/" class="d-flex align-items-center mb-3 mb-md-0 me-md-auto text-decoration-none">
    <span class="fs-4" id="sidebarTitle" runat="server" style="color: aliceblue;"></span>
</a>
<hr style="border-color: rgb(146, 146, 146);">
<ul class="nav nav-pills flex-column mb-auto">
    <li class="nav-item">
        <asp:HyperLink ID="linkAgregarEmpleados" runat="server" CssClass="nav-link" NavigateUrl="AgregarEmpleados.aspx" Style="color: aliceblue;">
            <i class="bi bi-briefcase"></i> Agregar Empleados
        </asp:HyperLink>
    </li>
    <li class="nav-item">
        <asp:HyperLink ID="linkConfig" runat="server" CssClass="nav-link" NavigateUrl="Config.aspx" Style="color: aliceblue;">
            <i class="bi bi-gear"></i> Configuración
        </asp:HyperLink>
    </li>
    <li class="nav-item">
        <asp:HyperLink ID="linkResumenCaja" runat="server" CssClass="nav-link" NavigateUrl="ResumenCaja.aspx" Style="color: aliceblue;">
            <i class="bi bi-cash"></i> Resumen de Caja
        </asp:HyperLink>
    </li>
    <li class="nav-item">
        <asp:HyperLink ID="linkMetricasIngreso" runat="server" CssClass="nav-link" NavigateUrl="MetricasIngresos.aspx" Style="color: aliceblue;">
            <i class="bi bi-graph-up"></i> Métricas de Ingreso
        </asp:HyperLink>
    </li>
    <li>
        <asp:Button ID="btnCerrarSesion" runat="server" CssClass="btn btn-link nav-link" Text="Cerrar Sesión" OnClick="btnCerrarSesion_Click" Style="color: aliceblue; text-align: left;" />
    </li>
</ul>
<hr style="border-color: rgb(146, 146, 146);">
