<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterUser.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="EffortWeb.MenuUser.Cart" %>

<asp:Content ID="CartBodyContent" ContentPlaceHolderID="MainBodyPlaceHolder" runat="server">
    <asp:GridView ID="gdr_Cart" runat="server" BorderStyle="Double" BorderWidth="5px" Height="195px" Width="672px" BackColor="White" BorderColor="White" CellPadding="4" GridLines="Horizontal" OnRowCommand="gdr_Cart_OnRowCommand" ShowHeaderWhenEmpty="True" EmptyDataText="No hay datos">
        <Columns>
            <asp:ButtonField ButtonType="Button" CommandName="DeleteElement" InsertVisible="False" Text="X" />
            <asp:ButtonField ButtonType="Button" CommandName="DeleteIndividualElement" InsertVisible="False" Text="Eliminar unidad" />
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#333333" />
        <HeaderStyle BackColor="#1D056E" BorderStyle="Solid" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
        <PagerStyle BackColor="#1D056E" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="White" ForeColor="#333333" HorizontalAlign="Center" VerticalAlign="Middle" />
        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F7F7F7" />
        <SortedAscendingHeaderStyle BackColor="#487575" />
        <SortedDescendingCellStyle BackColor="#E5E5E5" />
        <SortedDescendingHeaderStyle BackColor="#275353" />
    </asp:GridView>
    <asp:GridView ID="gdr_AuxCart" runat="server" BorderStyle="Double" BorderWidth="3px" Height="195px" Width="563px" BorderColor="#336666" CellPadding="0" GridLines="Horizontal" Visible="True">
        <FooterStyle BackColor="White" ForeColor="#333333" />
        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="White" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F7F7F7" />
        <SortedAscendingHeaderStyle BackColor="#487575" />
        <SortedDescendingCellStyle BackColor="#E5E5E5" />
        <SortedDescendingHeaderStyle BackColor="#275353" />
    </asp:GridView>
</asp:Content>
