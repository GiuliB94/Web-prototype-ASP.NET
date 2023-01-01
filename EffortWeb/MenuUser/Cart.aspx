<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterUser.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="EffortWeb.MenuUser.Cart" %>

<asp:Content ID="CartBodyContent" ContentPlaceHolderID="MainBodyPlaceHolder" runat="server">
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
     <div style="display:none"> <asp:Button ID="hiddenButton" runat="server"/></div>
    <center style="margin-top: 5%;">
        <style>
            .oculto {
                display: none;
            }
        </style>
        <asp:GridView ID="dgvCart" CssClass="table table-light table-bordered" AutoGenerateColumns="False" runat="server">
            <Columns>
                <asp:BoundField HeaderText="IdProduct" DataField="IdProduct" HeaderStyle-CssClass="oculto" ItemStyle-CssClass="oculto" />
                <asp:BoundField HeaderText="Producto" DataField="ProductName" />
                <asp:BoundField HeaderText="Precio unitario" DataField="UnitPrice" />
                <asp:BoundField HeaderText="Cantidad" DataField="Quantity" />
                <asp:BoundField HeaderText="Total" DataField="TotalAmount" />
            </Columns>
        </asp:GridView>
        <asp:Button Text="Finalizar pedido" ID="BtnToOrder" OnClick="BtnToOrder_Click" CssClass="btn btn-outline-light custom-btns rounding" BackColor="navy" Width="160" Height="50" runat="server" />
    </center>

            <asp:Panel ID="MSGPanel" Style="display: none; background-color: var(--bg-color-effort-blue);" runat="server" valign="top" >
            <div class="popup-margin" style="margin-top: 50px">
                <div style="margin-top: 30px; margin-left: 30px; margin-right: 30px">
                    <table>
                        <tr><td></td></tr>
                        <tr>
                            <td>
                                <asp:Label ID="LabelMSG" Style="font-family: var(--mdb-body-font-family); color: white; margin-top: 10px" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Button Text="Aceptar" ID="Okbtn" class="btn btn-outline-light" Style="margin-top: 10px; font-size: smaller;" runat="server" OnClick="Okbtn_Click"/></td>
                        </tr>
                        <tr><td></td></tr>
                    </table>
                </div>
            </div>
    </div>
    </div>
    </asp:Panel>
        <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="hiddenButton" PopupControlID="MSGPanel" valign="top" DropShadow="true"></ajaxToolkit:ModalPopupExtender>

</asp:Content>
