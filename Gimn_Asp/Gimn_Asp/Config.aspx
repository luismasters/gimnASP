<%@ Page Title="Configuración" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Config.aspx.cs" Inherits="Gimn_Asp.Config" %>
<%@ Register Src="~/NavigationMenuAdmin.ascx" TagPrefix="uc" TagName="NavigationMenuAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <div class="container">
            <div class="row bg-c mt-3">
                <div class="col-3 border-L d-flex flex-column flex-shrink-0 p-3 bg-c">
                    <uc:NavigationMenuAdmin ID="NavigationMenuAdmin1" runat="server" />
                </div>
                <div class="col-9">
                    <!-- Listado de Cargos de Empleados -->
                    <h3>Cargos de Empleados</h3>
                    <asp:GridView ID="gvCargosEmpleados" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered" DataKeyNames="ID" OnRowDeleting="gvCargosEmpleados_RowDeleting" style="color:aliceblue">
                        <Columns>
                            <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button ID="btnEliminarCargoEmpleado" runat="server" CommandName="Delete" CommandArgument='<%# Eval("ID") %>' Text="Eliminar" CssClass="btn btn-danger" OnClientClick="return confirm('¿Estás seguro de que deseas eliminar este cargo de empleado?');" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                    <!-- Formulario para Agregar Cargos de Empleados -->
                    <div class="mt-4">
                        <h4>Agregar Nuevo Cargo de Empleado</h4>
                        <asp:Label ID="lblMensajeCargoEmpleado" runat="server" Text="" ForeColor="Red"></asp:Label>
                        <div class="form-group">
                            <label for="txtDescripcionCargoEmpleado">Descripción:</label>
                            <asp:TextBox ID="txtDescripcionCargoEmpleado" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <asp:Button ID="btnAgregarCargoEmpleado" runat="server" Text="Agregar Cargo de Empleado" CssClass="btn btn-primary mt-2" OnClick="btnAgregarCargoEmpleado_Click" />
                    </div>

                    <!-- Listado de Salones -->
                    <h3>Salones</h3>
                    <asp:GridView ID="gvSalones" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered" DataKeyNames="ID" OnRowDeleting="gvSalones_RowDeleting" style="color: aliceblue">
                        <Columns>
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="Capacidad" HeaderText="Capacidad" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button ID="btnEliminar" runat="server" CommandName="Delete" CommandArgument='<%# Eval("ID") %>' Text="Eliminar" CssClass="btn btn-danger" OnClientClick="return confirm('¿Estás seguro de que deseas eliminar este salón?');" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                    <!-- Formulario para Agregar Salones -->
                    <div class="mt-4">
                        <h4>Agregar Nuevo Salón</h4>
                        <asp:Label ID="lblMensajeSalon" runat="server" Text="" ForeColor="Red"></asp:Label>
                        <div class="form-group">
                            <label for="txtNombreSalon">Nombre:</label>
                            <asp:TextBox ID="txtNombreSalon" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="txtCapacidad">Capacidad:</label>
                            <asp:TextBox ID="txtCapacidad" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <asp:Button ID="btnAgregarSalon" runat="server" Text="Agregar Salón" CssClass="btn btn-primary mt-2" OnClick="btnAgregarSalon_Click" />
                    </div>
                </div>
            </div>
        </div>
    </main>
</asp:Content>
