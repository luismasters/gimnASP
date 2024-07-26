<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InstructorNav.ascx.cs" Inherits="Gimn_Asp.InstructorNav" %>

<div class="col-3 border-L d-flex flex-column flex-shrink-0 p-3 bg-c" style="width: 280px;">
    <a href="/" class="d-flex align-items-center mb-3 mb-md-0 me-md-auto text-decoration-none">
        <span class="fs-4" style="color: aliceblue;">Sidebar</span>
    </a>
    <hr style="border-color: rgb(146, 146, 146);">
    <ul class="nav nav-pills flex-column mb-auto">

        <li>
            <a href="DashboardEmpleado.aspx" class="nav-link" style="color: aliceblue;">
                <i class="bi bi-speedometer2"></i>
                Panel Empleado
            </a>
        </li>
        <li>
            <a href="HorarioInstructor.aspx" class="nav-link" style="color: aliceblue;">
                <i class="bi bi-calendar"></i>
                Clases Asignadas
            </a>
        </li>
        <li>
            <a href="VerificarAcceso.aspx" class="nav-link" style="color: aliceblue;">
                <i class="bi bi-lock"></i>
                Verificar Acceso de Miembros
            </a>
        </li>
        <li>
            <asp:Button ID="btnCerrarSesion" runat="server" CssClass="btn btn-link nav-link" Text="Cerrar Sesión" OnClick="btnCerrarSesion_Click" style="color: aliceblue; text-align: left;" />
        </li>
    </ul>
    <hr style="border-color: rgb(146, 146, 146);">
</div>