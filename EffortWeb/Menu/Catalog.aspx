<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Master.Master" AutoEventWireup="true" CodeBehind="Catalog.aspx.cs" Inherits="EffortWeb.Menu.Catalog" %>

<asp:Content ID="CatalogBodyContent" ContentPlaceHolderID="MainBodyPlaceHolder" runat="server">
    <h1 class="custom-font-red" style="font-size: 30px;">Productos</h1>
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
    <br />
    <asp:Button Text="Realizar pedido" CssClass="btn btn-outline-light custom-btns rounding" BackColor="navy" Width="160" Height="50" runat="server" ID="Btn_Order" OnClick="Btn_Order_Click" />
    <center>
        <div align="center">
            <asp:ListView ID="ListView" OnItemCommand="Events" runat="server" GroupItemCount="5" Style="margin-right: 0px">
                <ItemTemplate>
                    <td>
                        <div class="card" style="width: 25rem; top: 13px; left: 13px; text-align: left;">
                            <div class="card-body">
                                <center>
                                    <asp:ImageButton ID="ImageButton" style="margin-top: 3%;" ImageUrl='<%#Eval("ImageUrl")%>' backColor="Blue" height="80%" width="80%" runat="server" />
                                    <h5 class="card-title" style="text-align: center; margin-top: 2%;"><%#Eval("Name")%></h5>
                                    <h5 class="card-title" style="text-align: center;">$<%#Eval("Price")%></h5>
                                    <table runat="server">
                                        <tr runat="server">
                                            <td>
                                                <asp:TextBox ID="txtQuantity" runat="server" TextMode="Number" max='<%#Eval("Stock")%>' min="1" Width="50px">1</asp:TextBox></td>
                                            <td>
                                                <asp:Button ID="btn_AddProduct" CommandArgument='<%#Eval("Id")%>' CommandName="AddProduct" runat="server" CssClass="btn btn-primary" Text="Agregar al carrito" /></td>
                                        </tr>
                                    </table>
                                </center>
                            </div>
                        </div>
                    </td>
                </ItemTemplate>
                <LayoutTemplate>
                    <table runat="server">
                        <tr runat="server">
                            <td id="groupPlaceHolder"></td>
                        </tr>
                    </table>
                </LayoutTemplate>
                <GroupTemplate>
                    <tr runat="server">
                        <td id="itemPlaceHolder"></td>
                    </tr>
                </GroupTemplate>
            </asp:ListView>
            <br />
            <br />
        </div>
    </center>
</asp:Content>
