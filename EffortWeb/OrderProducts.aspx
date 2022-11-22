<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="OrderProducts.aspx.cs" Inherits="effort_ver1.OrderProducts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Stylesheets" runat="server">
    <link rel="stylesheet" href="CustomStyles1.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style >
        .oculto {
            display:none;
        }
    </style>
    <div style="margin-left: 25px">
        <asp:Label Text="" ID="lblOrderN" runat="server" class="custom-font-red" style="font-size: 30px;"/> 
    </div>
     <asp:GridView ID="dgvOrderProducts" OnSelectedIndexChanged="dgvOrderProducts_SelectedIndexChanged" DataKeyNames="lineItem" CssClass="table table-light table-bordered" AutoGenerateColumns="false" runat="server">
        <Columns>
            <asp:BoundField HeaderText="Número de pedido" DataField="idOrder" HeaderStyle-CssClass="oculto" ItemStyle-CssClass="oculto" />
            <asp:BoundField HeaderText="Número de línea" DataField="lineItem" />
            <asp:BoundField HeaderText="Importe" DataField="quantity" />
            <asp:BoundField HeaderText="Producto" DataField="idProduct" />
            <asp:CommandField ShowSelectButton="true" SelectText="Ver producto" /> 
        </Columns>
    </asp:GridView>
</asp:Content>
