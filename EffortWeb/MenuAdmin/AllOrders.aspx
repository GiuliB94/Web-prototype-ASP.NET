<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="AllOrders.aspx.cs" Inherits="EffortWeb.MenuAdmin.AllOrders" %>

<asp:Content ID="AllOrdersBodyContent" ContentPlaceHolderID="MainBodyPlaceHolder" runat="server">
    <div style="margin-left: 25px">
        <p class="custom-font-red" style="font-size: 30px;">Pedidos</p>
    </div>
    <asp:GridView ID="dgvAllOrders" DataKeyNames="ID" OnSelectedIndexChanged="dgvAllOrders_SelectedIndexChanged" CssClass="table table-light table-bordered" AutoGenerateColumns="false" runat="server">
        <Columns>
            <asp:BoundField HeaderText="Número de pedido" DataField="ID" />
            <asp:BoundField HeaderText="Fecha de pedido" DataField="OrderDate" />
            <asp:BoundField HeaderText="Importe" DataField="TotalAmount" />
            <asp:BoundField HeaderText="Estado" DataField="StatusDescription" />
            <asp:BoundField HeaderText="Cliente" DataField="CompanyName" />
            <asp:BoundField HeaderText="Costo de fabricación" DataField="TotalCost" />
            <asp:CommandField ShowSelectButton="true" SelectText="Ver" />
        </Columns>
    </asp:GridView>
    <asp:GridView ID="dgvOrderElements" DataKeyNames="IdProduct" CssClass="table table-light table-bordered" OnSelectedIndexChanged="dgvOrderElements_SelectedIndexChanged" AutoGenerateColumns="false" runat="server">
        <Columns>
            <asp:BoundField HeaderText="Número de línea" DataField="LineItem" />
            <asp:BoundField HeaderText="Producto" DataField="ProductName" />
            <asp:BoundField HeaderText="Talle" DataField="Size" />
            <asp:BoundField HeaderText="Color" DataField="Color" />
            <asp:BoundField HeaderText="Precio unitario" DataField="UnitPrice" />
            <asp:BoundField HeaderText="Cantidad" DataField="Quantity" />
            <asp:BoundField HeaderText="Total" DataField="TotalAmount" />
            <asp:CommandField ShowSelectButton="true" SelectText="Ver detalle del costo" />
        </Columns>
    </asp:GridView>
    <asp:GridView ID="dgvCostDetails" DataKeyNames="IdProduct" CssClass="table table-light table-bordered" AutoGenerateColumns="false" runat="server">
        <Columns>
            <asp:BoundField HeaderText="Material" DataField="Material" />
            <asp:BoundField HeaderText="Box" DataField="Box" />
            <asp:BoundField HeaderText="Color" DataField="Color" />
            <asp:BoundField HeaderText="Bag" DataField="Bag" />
            <asp:BoundField HeaderText="Mano de obra" DataField="Handwork" />
            <asp:BoundField HeaderText="Costo por producto" DataField="TotalCostxProduct" />
        </Columns>
    </asp:GridView>
</asp:Content>
