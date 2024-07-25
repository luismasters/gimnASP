<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NavigationMenuAdmin.ascx.cs" Inherits="Gimn_Asp.NavigationMenuAdmin" %>
<a href="/" class="d-flex align-items-center mb-3 mb-md-0 me-md-auto text-decoration-none">
    <span class="fs-4" id="sidebarTitle" runat="server" style="color: aliceblue;"></span>
</a>
<hr style="border-color: rgb(146, 146, 146);">
<ul class="nav nav-pills flex-column mb-auto">
    <li class="nav-item">
        <asp:HyperLink ID="linkAgregarEmpleados" runat="server" CssClass="nav-link" NavigateUrl="AgregarEmpleados.aspx" Style="color: aliceblue;">
            <i class="bi bi-person-plus"></i> Agregar Empleados
        </asp:HyperLink>
    </li>
    <li class="nav-item">
        <asp:HyperLink ID="linkCargosEmpleados" runat="server" CssClass="nav-link" NavigateUrl="CargosEmpleados.aspx" Style="color: aliceblue;">
            <i class="bi bi-person-badge"></i> Generar Cargos Empleados
        </asp:HyperLink>
    </li>
    <li class="nav-item">
        <asp:HyperLink ID="linkSalones" runat="server" CssClass="nav-link" NavigateUrl="Salones.aspx" Style="color: aliceblue;">
            <i class="bi bi-door-open"></i> Cargar Salones 
        </asp:HyperLink>
    </li>
    <li class="nav-item">
        <asp:HyperLink ID="linkTiposMembresia" runat="server" CssClass="nav-link" NavigateUrl="TiposMembresia.aspx" Style="color: aliceblue;">
            <i class="bi bi-card-checklist"></i> Cargar/editar Membresias 
        </asp:HyperLink>
    </li>
    <li class="nav-item">
        <asp:HyperLink ID="linkResumenCaja" runat="server" CssClass="nav-link" NavigateUrl="ResumenCaja.aspx" Style="color: aliceblue;">
            <i class="bi bi-cash-stack"></i> Resumen de Caja
        </asp:HyperLink>
    </li>
    <li class="nav-item">
        <asp:HyperLink ID="linkMetricasIngreso" runat="server" CssClass="nav-link" NavigateUrl="MetricasIngresos.aspx" Style="color: aliceblue;">
            <i class="bi bi-graph-up-arrow"></i> Métricas de Ingreso
        </asp:HyperLink>
    </li>
    <li>
    <asp:Button ID="btnCerrarSesion" runat="server" CssClass="btn btn-link nav-link" Text="Cerrar Sesión" OnClick="btnCerrarSesion_Click" Style="color: aliceblue; text-align: left;" />
</li>
</ul>
<hr style="border-color: rgb(146, 146, 146);">