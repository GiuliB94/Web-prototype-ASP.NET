<%@ Page Title="" Language="C#" MasterPageFile="../MasterPages/MasterUser.Master" AutoEventWireup="true" CodeBehind="Catalog.aspx.cs" Inherits="effort_ver1.MenuUser.Catalog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Stylesheets" runat="server">
    <link rel="stylesheet" href="../CSS/CustomStyles1.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <div align="center">
            <asp:ListView ID="ListView" OnItemCommand="Events" runat="server" GroupItemCount="5" Style="margin-right: 0px">
                <ItemTemplate>
                    <td>
                        <div class="card" style="width: 25rem; top: 13px; left: 13px; text-align: left;">
                            <div class="card-body">
                                <center>
                                    <asp:ImageButton ID="ImageButton" runat="server" style="margin-top: 3%;" ImageUrl='<%#Eval("ImageUrl")%>' backColor="Blue" height="80%" width="80%" />
                                    <h5 class="card-title" style="text-align: center; margin-top: 2%;"><%#Eval("Name")%></h5>
                                    <h5 class="card-title" style="text-align: center;">$<%#Eval("Price")%></h5>
                                    <table runat="server">
                                        <tr runat="server">
                                            <td><asp:TextBox ID="txtQuantity" runat="server" TextMode="Number" max='<%#Eval("Stock")%>' min="1" Width="50px">1</asp:TextBox></td>
                                            <td><asp:Button ID="btn_AddProduct" CommandArgument='<%#Eval("Id")%>' CommandName="AddProduct" runat="server" CssClass="btn btn-primary" Text="Agregar al carrito" /></td>
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

