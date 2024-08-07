﻿<%@ Page Title="Cargar Horario de Salón" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CargarHorarioSalon.aspx.cs" Inherits="Gimn_Asp.CargarHorarioSalon" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%@ Register Src="~/NavigationMenu.ascx" TagPrefix="uc" TagName="NavigationMenu" %>




    <main>
        <div class="container">
       
      <div class="row bg-c mt-3" >
         
<div class="col-3 border-L d-flex flex-column flex-shrink-0 p-3 bg-c">

  <uc:NavigationMenu ID="NavigationMenu1" runat="server" />


                              </div>



                <div class="col-9">
                    <h3>Horarios de Clases de Salón</h3>

                    <div class="form-group">
                        <label for="txtFechaInicio">Fecha Inicio:</label>
                        <asp:TextBox ID="txtFechaInicio" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="txtFechaFin">Fecha Fin:</label>
                        <asp:TextBox ID="txtFechaFin" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                    </div>
                    <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" CssClass="btn btn-primary mt-2" OnClick="btnFiltrar_Click" />

                    <asp:GridView ID="gvHorariosClases" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered" DataKeyNames="ID" OnRowDeleting="gvHorariosClases_RowDeleting" Style="color: aliceblue">
    <Columns>
        <asp:BoundField DataField="claseSalon.NombreClase" HeaderText="Clase" />
        <asp:TemplateField HeaderText="Fecha">
            <ItemTemplate>
                <%# FormatearFecha(Eval("Fecha")) %>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="HoraInicio" HeaderText="Hora Inicio" DataFormatString="{0:hh\\:mm}" />
        <asp:BoundField DataField="HoraFin" HeaderText="Hora Fin" DataFormatString="{0:hh\\:mm}" />
        <asp:BoundField DataField="salon.Nombre" HeaderText="Salón" />
        <asp:BoundField DataField="Instructor.NombreCompleto" HeaderText="Instructor" />
        <asp:TemplateField>
            <ItemTemplate>
                <asp:Button ID="btnEliminarHorarioClase" runat="server" CommandName="Delete" CommandArgument='<%# Eval("ID") %>' Text="Eliminar" CssClass="btn btn-danger" OnClientClick="return confirm('¿Estás seguro de que deseas eliminar este horario de clase?');" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>


                    <div class="mt-4">
                        <h4>Agregar Nuevo Horario de Clase</h4>
                        <asp:Label ID="lblMensajeHorarioClase" runat="server" Text="" ForeColor="Red"></asp:Label>
                        <div class="form-group">
                            <label for="ddlClaseSalon">Clase:</label>
                            <asp:DropDownList ID="ddlClaseSalon" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label for="ddlSalon">Salón:</label>
                            <asp:DropDownList ID="ddlSalon" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label for="txtFecha">Fecha:</label>
                            <asp:TextBox ID="txtFecha" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="txtHoraInicio">Hora Inicio:</label>
                            <asp:TextBox ID="txtHoraInicio" runat="server" CssClass="form-control" TextMode="Time"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="txtHoraFin">Hora Fin:</label>
                            <asp:TextBox ID="txtHoraFin" runat="server" CssClass="form-control" TextMode="Time"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <label for="ddlInstructor">Instructor:</label>
                            <asp:DropDownList ID="ddlInstructor" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>


                        <asp:Button ID="btnAgregarHorarioClase" runat="server" Text="Agregar Horario de Clase" CssClass="btn btn-primary mt-2" OnClick="btnAgregarHorarioClase_Click" />
                    </div>
                </div>
            </div>
        </div>
    </main>
</asp:Content>
