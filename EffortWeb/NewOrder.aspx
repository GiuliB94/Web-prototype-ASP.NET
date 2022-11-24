<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="NewOrder.aspx.cs" Inherits="effort_ver1.NewOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Stylesheets" runat="server">
    <link rel="stylesheet" href="CustomStyles1.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin-left: 25px">
        <asp:Label Text="Nuevo pedido" ID="lblNewOrder" runat="server" class="custom-font-red" Style="font-size: 30px;" />
    </div>
    <style>
        .oculto {
            display: none;
        }
    </style>
    <div style="margin-left: 25px">
        <asp:Label Text="" ID="lblOrderN" runat="server" class="custom-font-red" Style="font-size: 30px;" />
    </div>
    <asp:GridView ID="dgvOrderElementList" DataKeyNames="id" CssClass="table table-light table-bordered" AutoGenerateColumns="False" runat="server">
        <Columns>
            <asp:BoundField HeaderText="Id" DataField="id" HeaderStyle-CssClass="oculto" ItemStyle-CssClass="oculto" />
            <asp:BoundField HeaderText="Producto" DataField="name" />
            <asp:BoundField HeaderText="Descripción" DataField="description" />
            <asp:BoundField HeaderText="Talle" DataField="size" />
            <asp:BoundField HeaderText="Color" DataField="color" HeaderStyle-CssClass="oculto" ItemStyle-CssClass="oculto" />
            <asp:BoundField HeaderText="Precio" DataField="price" />
        </Columns>
    </asp:GridView>
    <asp:Button Text="Agregar producto" OnClick="btnAddProduct_Click" ID="btnAddProduct" CssClass="btn btn-outline-light custom-btns rounding" BackColor="navy" runat="server" Width="170" Height="50" />
</asp:Content>
