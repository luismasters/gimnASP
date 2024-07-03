<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NavigationMenu.ascx.cs" Inherits="Gimn_Asp.NavigationMenu" %>
<div class="col-3 border-L d-flex flex-column flex-shrink-0 p-3 bg-c" style="width: 280px;">
    <a href="/" class="d-flex align-items-center mb-3 mb-md-0 me-md-auto text-decoration-none">
        <span class="fs-4" style="color: aliceblue;">Sidebar</span>
    </a>
    <hr style="border-color: rgb(146, 146, 146);">
    <ul class="nav nav-pills flex-column mb-auto">
        <li class="nav-item">
            <a href="acceso.aspx" class="nav-link" style="color: aliceblue;">
                <i class="bi bi-house-door"></i>
                Acceso
            </a>
        </li>
        <li>
            <a href="Pago.aspx" class="nav-link" style="color: aliceblue;">
                <i class="bi bi-credit-card"></i>
                Cobro
            </a>
        </li>
        <li>
            <a href="#" class="nav-link dropdown-toggle" data-bs-toggle="dropdown" aria-expanded="false" style="color: aliceblue;">
                <i class="bi bi-people"></i>
                Socios
            </a>
            <ul class="dropdown-menu bg-c" style="background-color: rgba(30, 30, 30, 255);">
                <li>
                    <a class="dropdown-item" href="Socios.aspx" style="color: aliceblue;" 
                       onmouseover="this.style.backgroundColor='aliceblue';this.style.color='rgba(30, 30, 30, 255)';" 
                       onmouseout="this.style.backgroundColor='rgba(30, 30, 30, 255)';this.style.color='aliceblue';">
                        Estatus/Buscar Socio
                    </a>
                </li>
                <li>
                    <a class="dropdown-item" href="AgregarSocio.aspx" style="color: aliceblue;" 
                       onmouseover="this.style.backgroundColor='aliceblue';this.style.color='rgba(30, 30, 30, 255)';" 
                       onmouseout="this.style.backgroundColor='rgba(30, 30, 30, 255)';this.style.color='aliceblue';">
                        Agregar Socio
                    </a>
                </li>
            </ul>
        </li>
        <li>
            <a href="#" class="nav-link dropdown-toggle" data-bs-toggle="dropdown" aria-expanded="false" style="color: aliceblue;">
                <i class="bi bi-briefcase"></i>
                Empleados
            </a>
            <ul class="dropdown-menu bg-c" style="background-color: rgba(30, 30, 30, 255);">
                <li>
                    <a class="dropdown-item" href="AgregarEmpleados.aspx" style="color: aliceblue;" 
                       onmouseover="this.style.backgroundColor='aliceblue';this.style.color='rgba(30, 30, 30, 255)';" 
                       onmouseout="this.style.backgroundColor='rgba(30, 30, 30, 255)';this.style.color='aliceblue';">
                        Agregar Empleado
                    </a>
                </li>
                <li>
                    <a class="dropdown-item" href="BMEmpleados.aspx" style="color: aliceblue;" 
                       onmouseover="this.style.backgroundColor='aliceblue';this.style.color='rgba(30, 30, 30, 255)';" 
                       onmouseout="this.style.backgroundColor='rgba(30, 30, 30, 255)';this.style.color='aliceblue';">
                        Gestionar Registros de Empleados
                    </a>
                </li>
            </ul>
        </li>
        <li>
            <a href="#" class="nav-link dropdown-toggle" data-bs-toggle="dropdown" aria-expanded="false" style="color: aliceblue;">
                <i class="bi bi-calendar-event"></i>
                Actividades de Salon
            </a>
            <ul class="dropdown-menu bg-c" style="background-color: rgba(30, 30, 30, 255);">
                <li>
                    <a class="dropdown-item" href="AgragarActividades.aspx" style="color: aliceblue;" 
                       onmouseover="this.style.backgroundColor='aliceblue';this.style.color='rgba(30, 30, 30, 255)';" 
                       onmouseout="this.style.backgroundColor='rgba(30, 30, 30, 255)';this.style.color='aliceblue';">
                        Agregar/ver Actividades de salon
                    </a>
                </li>
                <li>
                    <a class="dropdown-item" href="CargarHorarioSalon.aspx" style="color: aliceblue;" 
                       onmouseover="this.style.backgroundColor='aliceblue';this.style.color='rgba(30, 30, 30, 255)';" 
                       onmouseout="this.style.backgroundColor='rgba(30, 30, 30, 255)';this.style.color='aliceblue';">
                        Horario de las Actividades de Salon
                    </a>
                </li>
                <li>
                    <a class="dropdown-item" href="AgregarEmpleados.aspx" style="color: aliceblue;" 
                       onmouseover="this.style.backgroundColor='aliceblue';this.style.color='rgba(30, 30, 30, 255)';" 
                       onmouseout="this.style.backgroundColor='rgba(30, 30, 30, 255)';this.style.color='aliceblue';">
                        Agregar Empleado
                    </a>
                </li>
            </ul>
        </li>
        <li>
            <a href="#" class="nav-link" style="color: aliceblue;">
                <i class="bi bi-person"></i>
                Instructores
            </a>
        </li>
    </ul>
    <hr style="border-color: rgb(146, 146, 146);">
</div>
