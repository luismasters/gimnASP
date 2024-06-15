<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgragarActividades.aspx.cs" Inherits="Gimn_Asp.AgragarActividades" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">





      <div class="container ">
      <div class="row bg-c mt-3" style="height: 900px">
          <div class="col-3 border-L">
              <ul class="nav flex-column">
                  <li class="nav-item">
                      <a class="nav-link active" aria-current="page" href="acceso.aspx">Acceso</a>
                  </li>
                  <li class="nav-item">
                      <a class="nav-link" href="Pago.aspx">Cobro</a>
                  </li>

                  <div class="dropdown">
                      <a class="nav-item" href="#" data-bs-toggle="dropdown" aria-expanded="false">Socios</a>
                      <ul class="dropdown-menu">
                          <li><a class="dropdown-item" href="Socios.aspx">Estatus/Buscar Socio</a></li>
                          <li><a class="dropdown-item" href="AgregarSocio.aspx">Agregar Socio</a></li>
                          <li><a class="dropdown-item" href="#">Something else here</a></li>
                      </ul>
                  </div>

                  <div class="dropdown">
                      <a class="nav-item" href="#" data-bs-toggle="dropdown" aria-expanded="false">Actividades</a>

                      <ul class="dropdown-menu">
                          <li><a class="dropdown-item" href="AgregarActividades.aspx">Agregar/ver Actividades de salon</a></li>
                          <li><a class="dropdown-item" href="AgregarSocio.aspx">Agregar Socio</a></li>
                          <li><a class="dropdown-item" href="#">Something else here</a></li>
                      </ul>
                  </div>

                  <li class="nav-item">
                      <a class="nav-link" href="#">Instructores</a>
                  </li>
              </ul>
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
