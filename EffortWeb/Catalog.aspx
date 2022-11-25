<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Catalog.aspx.cs" Inherits="effort_ver1.Catalog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Stylesheets" runat="server">
    <link rel="stylesheet" href="CustomStyles1.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row row-cols1 row-cols-md-3 g-4">
        <%
            foreach (Domain.Product item in ListaProductos )
            {%>
        <div class="col">
            <div class="card" style="width: 18rem;">
                <img src="..." class="card-img-top" alt="...">
                <div class="card-body">
                    <h5 class="card-title"><%:item.name%></h5>
                    <p class="card-text"><%:item.description%></p>
                    <p class="card-text">$ <%:item.price%></p>
                    <a href="#" class="btn btn-primary" id="AddProduct" >Agregar</a>
                </div>
            </div>
        </div>
        <%}%>

    </div>
</asp:Content>
