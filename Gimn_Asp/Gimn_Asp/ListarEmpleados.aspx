<%@ Page Title="Listar Empleados" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListarEmpleados.aspx.cs" Inherits="Gimn_Asp.ListarEmpleados" %>
<%@ Register Src="~/NavigationMenuAdmin.ascx" TagPrefix="uc" TagName="NavigationMenuAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main style="color: white;">
        <div class="container">
            <div class="row bg-c mt-3">
                <div class="col-3 border-L d-flex flex-column flex-shrink-0 p-3 bg-c">
                    <uc:NavigationMenuAdmin ID="NavigationMenuAdmin1" runat="server" />
                </div>
                <div class="col-9">
                    <h2 class="mb-4" style="color: white;">Listado de Empleados</h2>
                    
                    <asp:GridView ID="gvEmpleados" runat="server" AutoGenerateColumns="False" 
                                  CssClass="table table" OnRowCommand="gvEmpleados_RowCommand" style="color: white;">
                        <Columns >
                            <asp:BoundField DataField="DNI" HeaderText="DNI" />
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                            <asp:BoundField DataField="Email" HeaderText="Email" />
                            <asp:BoundField DataField="cargoEmpleado.Descripcion" HeaderText="Cargo" />
                            <asp:CheckBoxField DataField="EstadoActivo" HeaderText="Activo" />
                            <asp:TemplateField HeaderText="Acciones">
                                <ItemTemplate>
                                    <asp:Button ID="btnModificar" runat="server" Text="Modificar" 
                                                CommandName="Modificar" CommandArgument='<%# Eval("ID") %>'
                                                CssClass="btn btn-primary btn-sm" style="color: white;" />
                                    <asp:Button ID="btnDarBaja" runat="server" Text='<%# (bool)Eval("EstadoActivo") ? "Dar de Baja" : "Activar" %>'
                                                CommandName="CambiarEstado" CommandArgument='<%# Eval("ID") %>'
                                                CssClass='<%# (bool)Eval("EstadoActivo") ? "btn btn-danger btn-sm" : "btn btn-success btn-sm" %>' style="color: white;" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    
                    <asp:Label ID="lblMensaje" runat="server" CssClass="text-info" style="color: white;"></asp:Label>
                </div>
            </div>
        </div>
    </main>
</asp:Content>