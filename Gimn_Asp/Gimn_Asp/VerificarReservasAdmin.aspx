<%@ Page Title="Verificar Reservas Admin" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VerificarReservasAdmin.aspx.cs" Inherits="Gimn_Asp.VerificarReservasAdmin" %>

<%@ Register Src="~/NavigationMenu.ascx" TagPrefix="uc" TagName="NavigationMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  
    
    
    
    
    
    


                <div class="row bg-c mt-3">

                    <div class="col-3 border-L d-flex flex-column flex-shrink-0 p-3 bg-c">

                        <uc:NavigationMenu ID="NavigationMenu1" runat="server" />


                    </div>



                    <div class="col-9">

                <h3 class="text-center">Verificar Reservas</h3>



                        <asp:GridView ID="gvHorariosClases" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered text-light" DataKeyNames="ID" OnRowCommand="gvHorariosClases_RowCommand">
                            <Columns>
                                <asp:BoundField DataField="claseSalon.NombreClase" HeaderText="Clase" />
                                <asp:BoundField DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}" />
                                <asp:BoundField DataField="HoraInicio" HeaderText="Hora Inicio" />
                                <asp:BoundField DataField="HoraFin" HeaderText="Hora Fin" />
                                <asp:BoundField DataField="salon.Nombre" HeaderText="Salón" />
                                <asp:BoundField DataField="CapacidadRestante" HeaderText="Capacidad Restante" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Button ID="btnVerReservas" runat="server" CommandName="VerReservas" CommandArgument='<%# Container.DataItemIndex %>' Text="Ver Reservas" CssClass="btn btn-primary" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>

</asp:Content>
