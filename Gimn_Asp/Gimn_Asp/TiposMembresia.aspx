<%@ Page Title="Configuración de Tipos de Membresía" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TiposMembresia.aspx.cs" Inherits="Gimn_Asp.TiposMembresia" %>
<%@ Register Src="~/NavigationMenuAdmin.ascx" TagPrefix="uc" TagName="NavigationMenuAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <div class="container">
            <div class="row bg-c mt-3">
                <div class="col-3 border-L d-flex flex-column flex-shrink-0 p-3 bg-c">
                    <uc:NavigationMenuAdmin ID="NavigationMenuAdmin1" runat="server" />
                </div>
                <div class="col-9">
                    <h3>Tipos de Membresía</h3>
                   <asp:GridView ID="gvTiposMembresia" runat="server" AutoGenerateColumns="False" 
    CssClass="table table-bordered" DataKeyNames="ID" 
    OnRowDeleting="gvTiposMembresia_RowDeleting" 
    OnRowEditing="gvTiposMembresia_RowEditing"
    OnRowUpdating="gvTiposMembresia_RowUpdating"
    OnRowCancelingEdit="gvTiposMembresia_RowCancelingEdit"
    style="color: aliceblue">
    <Columns>
        <asp:TemplateField HeaderText="Descripción">
            <ItemTemplate>
                <%# Eval("Descripcion") %>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtDescripcion" runat="server" Text='<%# Bind("Descripcion") %>'></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Precio">
            <ItemTemplate>
                <%# Eval("Precio", "{0:C}") %>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtPrecio" runat="server" Text='<%# Bind("Precio") %>'></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:CommandField ShowEditButton="True" ButtonType="Button" EditText="Modificar" UpdateText="Guardar" CancelText="Cancelar" />
        <asp:TemplateField>
            <ItemTemplate>
                <asp:Button ID="btnEliminar" runat="server" CommandName="Delete" Text="Eliminar" CssClass="btn btn-danger" OnClientClick="return confirm('¿Estás seguro de que deseas eliminar este tipo de membresía?');" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>

                    <div class="mt-4">
                        <h4>Agregar Nuevo Tipo de Membresía</h4>
                        <asp:Label ID="lblMensaje" runat="server" Text="" ForeColor="Red"></asp:Label>
                        <div class="form-group">
                            <label for="txtDescripcion">Descripción:</label>
                            <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="txtPrecio">Precio:</label>
                            <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <asp:Button ID="btnAgregar" runat="server" Text="Agregar Tipo de Membresía" CssClass="btn btn-primary mt-2" OnClick="btnAgregar_Click" />
                    </div>
                </div>
            </div>
        </div>
    </main>
</asp:Content>