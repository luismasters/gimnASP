<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarEmpleados.aspx.cs" Inherits="Gimn_Asp.AgregarEmpleados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">





        <div class="container">
            <div class="row bg-c mt-3" style="height: 900px">
                <div class="col-12">
                    <!-- Listado de Cargos de Empleados -->
                    <h3>Cargos de Empleados</h3>
                    <asp:GridView ID="gvCargosEmpleados" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered" DataKeyNames="ID" OnRowDeleting="gvCargosEmpleados_RowDeleting">
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="ID" />
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
                </div>
            </div>
        </div>
  

</asp:Content>
