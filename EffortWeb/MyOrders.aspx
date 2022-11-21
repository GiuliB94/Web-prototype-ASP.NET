<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MyOrders.aspx.cs" Inherits="EffortWeb.MyOrders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Stylesheets" runat="server">
    <link rel="stylesheet" href="CustomStyles1.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin-left: 25px">
        <p class="custom-font-red" style="font-size: 30px;">Mis Pedidos</p>
    </div>
    <asp:GridView ID="dgvMyOrders" OnSelectedIndexChanged="dgvMyOrders_SelectedIndexChanged" CssClass="table table-light table-bordered" AutoGenerateColumns="false" runat="server">
        <Columns>
            <asp:CheckBoxField HeaderText="Seleccionar" />
            <asp:BoundField HeaderText="Número de pedido" DataField="id" />
            <asp:BoundField HeaderText="Fecha de pedido" DataField="orderDate" />
            <asp:BoundField HeaderText="Importe" DataField="amount" />
            <asp:BoundField HeaderText="Fecha de entrega" DataField="deliveryDate" />
            <asp:BoundField HeaderText="Estado" DataField="status" />
            <asp:CommandField ShowSelectButton="true" SelectText="Ver productos"  />
        </Columns>
    </asp:GridView>
</asp:Content>
