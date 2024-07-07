<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgragarActividades.aspx.cs" Inherits="Gimn_Asp.AgragarActividades" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <%@ Register Src="~/NavigationMenu.ascx" TagPrefix="uc" TagName="NavigationMenu" %>


      <div class="row bg-c mt-3" >
         
<div class="col-3 border-L d-flex flex-column flex-shrink-0 p-3 bg-c">

  <uc:NavigationMenu ID="NavigationMenu1" runat="server" />


                              </div>



                <div class="col-9">

                    <!-- Listado de Clases de Salón -->
                    <h3>Clases de Salón</h3>
                    <asp:GridView ID="gvClasesSalon" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered" DataKeyNames="ID" OnRowDeleting="gvClasesSalon_RowDeleting" style="color:aliceblue">
                        <Columns>
                            <asp:BoundField DataField="NombreClase" HeaderText="Nombre de Clase" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button ID="btnEliminarClaseSalon" runat="server" CommandName="Delete" CommandArgument='<%# Eval("ID") %>' Text="Eliminar" CssClass="btn btn-danger" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                    <!-- Formulario para Agregar Clases de Salón -->
                    <div class="mt-4">
                        <h4>Agregar Nueva Clase de Salón</h4>
                        <asp:Label ID="lblMensajeClaseSalon" runat="server" Text="" ForeColor="Red"></asp:Label>
                        <div class="form-group">
                            <label for="txtNombreClaseSalon">Nombre de Clase:</label>
                            <asp:TextBox ID="txtNombreClaseSalon" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <asp:Button ID="btnAgregarClaseSalon" runat="server" Text="Agregar Clase de Salón" CssClass="btn btn-primary mt-2" OnClick="btnAgregarClaseSalon_Click" />
                    </div>
                </div>
            </div>
        </div>
 



</asp:Content>
