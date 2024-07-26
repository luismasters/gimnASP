<%@ Page Title="Configuración de Salones" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Salones.aspx.cs" Inherits="Gimn_Asp.Salones" %>
<%@ Register Src="~/NavigationMenuAdmin.ascx" TagPrefix="uc" TagName="NavigationMenuAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <div class="container">
            <div class="row bg-c mt-3">
                <div class="col-3 border-L d-flex flex-column flex-shrink-0 p-3 bg-c">
                    <uc:NavigationMenuAdmin ID="NavigationMenuAdmin1" runat="server" />
                </div>
                <div class="col-9">
                    <h3>Salones</h3>
                    <asp:GridView ID="gvSalones" runat="server" AutoGenerateColumns="False" 
                        CssClass="table table-bordered" DataKeyNames="ID" 
                        OnRowDeleting="gvSalones_RowDeleting" 
                        OnRowEditing="gvSalones_RowEditing"
                        OnRowUpdating="gvSalones_RowUpdating"
                        OnRowCancelingEdit="gvSalones_RowCancelingEdit"
                        style="color: aliceblue">
                        <Columns>
                            <asp:TemplateField HeaderText="Nombre">
                                <ItemTemplate>
                                    <%# Eval("Nombre") %>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtNombre" runat="server" Text='<%# Bind("Nombre") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Capacidad">
                                <ItemTemplate>
                                    <%# Eval("Capacidad") %>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtCapacidad" runat="server" Text='<%# Bind("Capacidad") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField ShowEditButton="True" ButtonType="Button" EditText="Modificar" UpdateText="Guardar" CancelText="Cancelar" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button ID="btnEliminar" runat="server" CommandName="Delete" Text="Eliminar" CssClass="btn btn-danger" OnClientClick="return confirm('¿Estás seguro de que deseas eliminar este salón?');" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <div class="mt-4">
                        <h4>Agregar Nuevo Salón</h4>
                        <asp:Label ID="lblMensaje" runat="server" Text="" ForeColor="Red"></asp:Label>
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