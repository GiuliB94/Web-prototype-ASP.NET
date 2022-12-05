<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="AllOrders.aspx.cs" Inherits="EffortWeb.MenuAdmin.AllOrders" %>

<asp:Content ID="AllOrdersBodyContent" ContentPlaceHolderID="MainBodyPlaceHolder" runat="server">
    <div style="margin-left: 25px">
        <p class="custom-font-red" style="font-size: 30px;">Mis Pedidos</p>
    </div>
    <asp:GridView ID="dgvAllOrders" DataKeyNames="id" OnSelectedIndexChanged="dgvAllOrders_SelectedIndexChanged" CssClass="table table-light table-bordered" AutoGenerateColumns="false" runat="server">
        <Columns>
            <asp:BoundField HeaderText="Número de pedido" DataField="id" />
            <asp:BoundField HeaderText="Fecha de pedido" DataField="orderDate" />
            <asp:BoundField HeaderText="Importe" DataField="amount" />
            <asp:BoundField HeaderText="Fecha de entrega" DataField="deliveryDate" />
            <asp:BoundField HeaderText="Estado" DataField="status" />
            <asp:BoundField HeaderText="Cliente" DataField="idClient" />
            <asp:CommandField ShowSelectButton="true" SelectText="Ver productos" />
        </Columns>
    </asp:GridView>
</asp:Content>