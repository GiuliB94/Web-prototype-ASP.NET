<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="EffortWeb.Products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Stylesheets" runat="server">
    <link rel="stylesheet" href="CustomStyles1.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .oculto {
            display: none;
        }
    </style>
    <div style="margin-left: 25px">
        <p class="custom-font-red" style="font-size: 30px;">Productos</p>
    </div>
    <div class="row">
        <div class="col-6">
            <asp:GridView ID="dgvProducts" OnSelectedIndexChanged="dgvProducts_SelectedIndexChanged" DataKeyNames="Id" CssClass="table table-light table-bordered" AutoGenerateColumns="false" runat="server">
                <Columns>
                    <asp:BoundField HeaderText="Producto" DataField="name" />
                    <asp:BoundField HeaderText="Descripción" DataField="description" />
                    <asp:BoundField HeaderText="Talle" DataField="size" />
                    <asp:BoundField HeaderText="Color" DataField="color" HeaderStyle-CssClass="oculto" ItemStyle-CssClass="oculto" />
                    <asp:BoundField HeaderText="Precio" DataField="price" />
                    <asp:CommandField ShowSelectButton="true" SelectText="Ver" />
                </Columns>
            </asp:GridView>
        </div>
        <div class="row">
            <div class="col-sm-6 mb-3">
                <%--DEBERIA SER VISIBLE SOLO PARA LOS USUARIOS ADMIN--%>
                <asp:Button Text="Agregar producto" ID="btnAddProduct" OnClick="btnAddProduct_Click" CssClass="btn btn-outline-light custom-btns rounding" BackColor="navy" runat="server" Width="170" Height="50" />
            </div>
        </div>
    </div>
</asp:Content>
