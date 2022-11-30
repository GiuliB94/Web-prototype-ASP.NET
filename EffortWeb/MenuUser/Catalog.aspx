<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterUser.Master" AutoEventWireup="true" CodeBehind="Catalog.aspx.cs" Inherits="effort_ver1.MenuUser.Catalog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Stylesheets" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <div align="center">
            <asp:ListView ID="ListView1" runat="server" GroupItemCount="5" Style="margin-right: 0px">
                <ItemTemplate>
                    <td>
                        <div class="card" style="width: 18rem; top: 0px; left: 0px;">
                            <h5 class="card-title"><%#Eval("name")%></h5>
                            <div class="card-body">
                                <asp:ImageButton ID="ImageButton" runat="server" Height="235px" BackColor="Blue" ImageUrl="~/Productos/NoImage" Width="138px" />
                                <p class="card-text"><%#Eval("description")%></p>
                                <p class="card-text">$<%#Eval("price")%></p>
                                <asp:TextBox Text="1" ID="quantity" runat="server" AutoPostBack="True" Width="30%"></asp:TextBox>
                                <asp:Button ID="btn_AddProduct" CommandArgument="Agregar" CommandName="ProductId" OnClick="btn_AddProduct_Click" runat="server" CssClass="btn btn-primary" Text="Agregar" />
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
