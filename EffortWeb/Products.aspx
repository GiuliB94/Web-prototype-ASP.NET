<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="effort_ver1.Products" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Stylesheets" runat="server">
    <link rel="stylesheet" href="CustomStyles1.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin-left: 25px">
        <p class="custom-font-red" style="font-size: 30px;">Productos</p>
    </div>
    <div class="row">
        <div class="col-6">

        </div>
    </div>
    <asp:GridView ID="dgvProducts" CssClass="table table-light table-bordered" AutoGenerateColumns="false" runat="server">
        <Columns>
            <asp:BoundField HeaderText="Producto" DataField="name" />
            <asp:BoundField HeaderText="Precio" DataField="price" />
        </Columns>

    </asp:GridView>
</asp:Content>
