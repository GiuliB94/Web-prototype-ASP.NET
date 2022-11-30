﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="PriceList.aspx.cs" Inherits="effort_ver1.MenuAdmin.PriceList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Stylesheets" runat="server">
    <link rel="stylesheet" href="../CSS/CustomStyles1.css" type="text/css" />
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
        <div class="col-8">
            <asp:GridView ID="dgvProducts" OnSelectedIndexChanged="dgvProducts_SelectedIndexChanged" DataKeyNames="id" CssClass="table table-light table-bordered" AutoGenerateColumns="False" runat="server" >
                <Columns>
                    <asp:BoundField HeaderText="Id" DataField="id" HeaderStyle-CssClass="oculto" ItemStyle-CssClass="oculto" />
                    <asp:BoundField HeaderText="Producto" DataField="name" />
                    <asp:BoundField HeaderText="Descripción" DataField="description" />
                    <asp:BoundField HeaderText="Talle" DataField="size" />
                    <asp:BoundField HeaderText="Color" DataField="color" HeaderStyle-CssClass="oculto" ItemStyle-CssClass="oculto" />
                    <asp:BoundField HeaderText="Precio" DataField="price" />
                    <asp:CommandField ShowSelectButton="true" SelectText="Ver"/>
                </Columns>
            </asp:GridView>
        </div>
        <div class="row">
            <div class="col-sm-6 mb-3">
                <asp:Button Text="Agregar producto" ID="btnAddProduct" OnClick="btnAddProduct_Click" CssClass="btn btn-outline-light custom-btns rounding" BackColor="navy" runat="server" Width="170" Height="50" />
            </div>
        </div>
    </div>
</asp:Content>
