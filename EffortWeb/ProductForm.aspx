<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ProductForm.aspx.cs" Inherits="effort_ver1.ProductForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Stylesheets" runat="server">
    <link rel="stylesheet" href="CustomStyles1.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label Text="Nuevo producto" ID="lblProducto" runat="server" class="custom-font-red" Style="font-size: 30px;" />
    <br />
    <asp:Label Text="Ingrese los detalles" ID="lblDetails" runat="server" class="custom-font-red" Style="font-size: 20px;" />
    <%--  Formulario para agregar un producto (VISIBLE SOLO PARA LOS ADMIN)--%>
    <div style="margin-left: 25px; margin-top: 25px;">
        <div class="row">
            <div class="col-sm-2 mb-3">
                <label for="txtId" class="form-label custom-font-text">ID</label>
            </div>
            <div class="col-sm-4 mb-3" style="text-align: right">
                <asp:TextBox runat="server" ID="txtId" CssClass="form-control" />
            </div>
        </div>
        <div class="row">
            <div class="col-sm-2 mb-3">
                <label for="txtName" class="form-label custom-font-text">Artículo</label>
            </div>
            <div class="col-sm-4 mb-3" style="text-align: right">
                <asp:TextBox runat="server" ID="txtName" CssClass="form-control" />
            </div>
        </div>

        <div class="row">
            <div class="col-sm-2 mb-3">
                <label for="txtDescription" class="form-label custom-font-text">Descripción</label>
            </div>
            <div class="col-sm-4 mb-3" style="text-align: right">
                <asp:TextBox runat="server" ID="txtDescription" CssClass="form-control" />
            </div>
        </div>

        <div class="row">
            <div class="col-sm-2 mb-3">
                <label for="txtSize" class="form-label custom-font-text">Talle</label>
            </div>
            <div class="col-sm-4 mb-3" style="text-align: right">
                <asp:TextBox runat="server" ID="txtSize" CssClass="form-control" />
            </div>
        </div>

        <div class="row">
            <div class="col-sm-2 mb-3">
                <label for="txtColor" class="form-label custom-font-text">Color</label>
            </div>
            <div class="col-sm-4 mb-3" style="text-align: right">
                <asp:TextBox runat="server" ID="txtColor" CssClass="form-control" />
            </div>
        </div>

        <div class="row">
            <div class="col-sm-2 mb-3">
                <label for="txtPrice" class="form-label custom-font-text">Precio</label>
            </div>
            <div class="col-sm-4 mb-3" style="text-align: right">
                <asp:TextBox runat="server" ID="txtPrice" CssClass="form-control" />
            </div>
        </div>
        <div class="row">
            <div class="col-sm-6 mb-3">
                <asp:Button Text="Agregar" ID="btnAddProduct" OnClick="btnAddProduct_Click" CssClass="btn btn-outline-light custom-btns rounding" BackColor="navy" runat="server" Width="170" Height="50" />
            </div>
        </div>
        <div class="row">
            <div class="col-sm-2 mb-3">
                <asp:Button Text="Modificar" ID="btnModProduct" OnClick="btnModProduct_Click" CssClass="btn btn-outline-light custom-btns rounding" BackColor="navy" runat="server" Width="170" Height="50" />
                <asp:Button Text="Eliminar" ID="btnDeleteProduct" OnClick="btnDeleteProduct_Click" CssClass="btn btn-outline-light custom-btns rounding" BackColor="navy" runat="server" Width="170" Height="50" />
            </div>
            <div class="col-sm-2 mb-3">
                <asp:Button Text="Aceptar" ID="BtnAccept" CssClass="btn btn-outline-light custom-btns rounding" BackColor="navy" Width="170" Height="50" OnClick="BtnAccept_Click" runat="server" />
            </div>
        </div>
    </div>
    </div>
    </div>
</asp:Content>
