<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterUser.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="EffortWeb.MenuUser.Cart" %>

<asp:Content ID="CartBodyContent" ContentPlaceHolderID="MainBodyPlaceHolder" runat="server">
    <center style="margin-top: 5%;">
        <style>
            .oculto {
                display: none;
            }
        </style>
        <asp:GridView ID="dgvCart" CssClass="table table-light table-bordered" AutoGenerateColumns="False" runat="server">
            <Columns>
                <asp:BoundField HeaderText="IdProduct" DataField="IdProduct" HeaderStyle-CssClass="oculto" ItemStyle-CssClass="oculto" />
                <asp:BoundField HeaderText="Producto" DataField="ProductName" />
                <asp:BoundField HeaderText="Precio unitario" DataField="UnitPrice" />
                <asp:BoundField HeaderText="Cantidad" DataField="Quantity" />
                <asp:BoundField HeaderText="Total" DataField="TotalAmount" />
            </Columns>
        </asp:GridView>
        <asp:Button Text="Realizar pedido" ID="BtnToOrder" OnClick="BtnToOrder_Click" CssClass="btn btn-outline-light custom-btns rounding" BackColor="navy" Width="160" Height="50" runat="server" />
    </center>
</asp:Content>
