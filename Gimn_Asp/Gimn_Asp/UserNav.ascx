<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserNav.ascx.cs" Inherits="Gimn_Asp.UserNav" %>

<div class="col-3 border-L d-flex flex-column flex-shrink-0 p-3 bg-c" style="width: 280px;">
    <a href="/" class="d-flex align-items-center mb-3 mb-md-0 me-md-auto text-decoration-none">
        <span class="fs-4" style="color: aliceblue;">Sidebar</span>
    </a>
    <hr style="border-color: rgb(146, 146, 146);">
    <ul class="nav nav-pills flex-column mb-auto">
        <li class="nav-item">
            <a href="UserDashboar.aspx" class="nav-link" style="color: aliceblue;">
                <i class="bi bi-house-door"></i>
                Panel Usuario
            </a>
        </li>

        <li>
            <a href="#" class="nav-link dropdown-toggle" data-bs-toggle="dropdown" aria-expanded="false" style="color: aliceblue;">
                <i class="bi bi-people"></i>
                Reservas Clases de Salon
            </a>
            <ul class="dropdown-menu bg-c" style="background-color: rgba(30, 30, 30, 255);">
                <li>
                    <a class="dropdown-item" href="ReservarClases.aspx" style="color: aliceblue;"
                        onmouseover="this.style.backgroundColor='aliceblue';this.style.color='rgba(30, 30, 30, 255)';"
                        onmouseout="this.style.backgroundColor='rgba(30, 30, 30, 255)';this.style.color='aliceblue';">Realiza Tu Reserva
                    </a>
                </li>
                <li>
                    <a class="dropdown-item" href="VerReservas.aspx" style="color: aliceblue;"
                        onmouseover="this.style.backgroundColor='aliceblue';this.style.color='rgba(30, 30, 30, 255)';"
                        onmouseout="this.style.backgroundColor='rgba(30, 30, 30, 255)';this.style.color='aliceblue';">Ver tus Reservas
                    </a>
                </li>
            </ul>
        </li>
        <li>
            <asp:Button ID="btnCerrarSesion" runat="server" CssClass="btn btn-link nav-link" Text="Cerrar Sesión" OnClick="btnCerrarSesion_Click" style="color: aliceblue; text-align: left;" />
        </li>
    </ul>
    <hr style="border-color: rgb(146, 146, 146);">
</div>
