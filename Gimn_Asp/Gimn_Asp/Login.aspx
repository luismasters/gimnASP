<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Gimn_Asp.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="login-container">
        <div class="login-card">
            <h2>Ingresa a tu Cuenta</h2>
            <div class="form-group">
                <asp:Label ID="lblUsername" runat="server" Text="Usuario:" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="lblPassword" runat="server" Text="Contraseña:" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:CheckBox ID="chkEmpleado" runat="server" Text="Soy Empleado" CssClass="form-check-input" style="background-color: rgba(30,30,30,255)"/>
            </div>
            <div class="form-group">
                <asp:Button ID="btnLogin" runat="server" Text="Sign in" CssClass="btn btn-primary" OnClick="btnLogin_Click" />
            </div>
            <div class="form-group text-center">
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
            </div>
            <div class="text-center" style="margin-top: 20px;">
                <p>&copy; gymnApp2024</p>
            </div>
        </div>
    </div>

    <style>
        .login-container {
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            background-color: rgba(30,30,30,255);
        }

        .login-card {
            background-color: rgba(30,30,30,255);
            color: aliceblue !important;
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
            max-width: 400px;
            width: 100%;
        }

        .login-card h2 {
            text-align: center;
            margin-bottom: 20px;
        }

        .login-card .form-control {
            margin-bottom: 15px;
        }

        .login-card .btn-primary {
            width: 100%;
        }

        .login-card .form-check-input {
            margin-bottom: 15px;
        }
    </style>
</asp:Content>
