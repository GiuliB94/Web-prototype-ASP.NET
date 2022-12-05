<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="PriceList.aspx.cs" Inherits="EffortWeb.MenuAdmin.PriceList" %>

<asp:Content ID="PriceListBodyContent" ContentPlaceHolderID="MainBodyPlaceHolder" runat="server">
    <style>
        .oculto {
            display: none;
        }
    </style>
    <div style="margin-left: 25px">
        <p class="custom-font-red" style="font-size: 30px;">Productos</p>
    </div>
    <div class="row">
        <div class="col-3">
            <div class="mb-3">
                <asp:Label CssClass="form-label custom-font-text" Text="Filtrar por" runat="server" />
                <asp:DropDownList CssClass="form-control" runat="server" ID="FilterDDown" AutoPostBack="true" OnSelectedIndexChanged="FilterDDown_SelectedIndexChanged">
                    <asp:ListItem Text="Nombre" />
                    <asp:ListItem Text="Precio" />
                    <asp:ListItem Text="Talle" />
                    <asp:ListItem Text="Color" />
                </asp:DropDownList>
            </div>
        </div>

        <% if (FilteredPrice)
            { %>
        <div class="col-3">
            <div class="mb-3">
                <asp:Label CssClass="form-label custom-font-text" Text="Criterio" runat="server" />
                <asp:DropDownList runat="server" ID="FilterPrice" CssClass="form-control">
                    <asp:ListItem Text="Mayor o igual que" />
                    <asp:ListItem Text="Menor o igual que" />
                </asp:DropDownList>
            </div>
        </div>
        <% }%>
        <div class="col-3">
            <div class="mb-3">
                <asp:Label CssClass="form-label custom-font-text" Text="Criterio" runat="server" />
                <asp:DropDownList runat="server" ID="StateDDL" CssClass="form-control">
                    <asp:ListItem Text="Activo" />
                    <asp:ListItem Text="Inactivo" />
                    <asp:ListItem Text="Todos" />
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-3">

            <div class="mb-3">
                <asp:Label CssClass="form-label custom-font-text" Text="Filtrar" runat="server" />
                <asp:TextBox runat="server" ID="filter" CssClass="form-control" />
            </div>
        </div>

        <div class="col-3">
            <div class="mb-3"></div>
            <div class="mb-3">
                <asp:Button Text="Buscar" CssClass="btn btn-outline-light custom-btns rounding" BackColor="navy" Width="90" Height="50" runat="server" ID="BtnSearch" OnClick="BtnSearch_Click" />
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-8">
            <asp:GridView ID="dgvProducts" OnSelectedIndexChanged="dgvProducts_SelectedIndexChanged" DataKeyNames="id" CssClass="table table-light table-bordered" AutoGenerateColumns="False" runat="server">
                <Columns>
                    <asp:BoundField HeaderText="Id" DataField="id" HeaderStyle-CssClass="oculto" ItemStyle-CssClass="oculto" />
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
                <asp:Button Text="Agregar producto" ID="btnAddProduct" OnClick="btnAddProduct_Click" CssClass="btn btn-outline-light custom-btns rounding" BackColor="navy" runat="server" Width="170" Height="50" />
            </div>
        </div>
    </div>
</asp:Content>
