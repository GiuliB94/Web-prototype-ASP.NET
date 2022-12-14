<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="AllOrders.aspx.cs" Inherits="EffortWeb.MenuAdmin.AllOrders" %>

<asp:Content ID="AllOrdersBodyContent" ContentPlaceHolderID="MainBodyPlaceHolder" runat="server">
    <div style="margin-left: 25px">
        <p class="custom-font-red" style="font-size: 30px;">Pedidos</p>
        <div class="row" Visible="false">
            <div class="col-2" width="200">
                <asp:Label Text="Actualizar estado" runat="server" CssClass="form-label" ID="lblChangeStatus" For="DDLChangeStatus"/>
            </div>
            <div class="col-3">
                <asp:DropDownList runat="server" ID="DDLChangeStatus" CssClass="form-control" Width="300">
                    <asp:ListItem Text="En espera de aprobación" />
                    <asp:ListItem Text="Aprobado" />
                    <asp:ListItem Text="En proceso de fabricación" />
                    <asp:ListItem Text="Listo para entrega" />
                    <asp:ListItem Text="Entregado" />
                    <asp:ListItem Text="Rechazado" />
                </asp:DropDownList>
            </div>
            <div class="col-3">
                <asp:Button Text="Enviar cambios" CssClass="btn btn-outline-light custom-btns rounding" ID="BtnChangeStatus" BackColor="navy" Width="200" Height="40" runat="server" OnClick="BtnChangeStatus_Click"/>
            </div>
        </div>
    </div>
    <asp:GridView ID="dgvAllOrders" DataKeyNames="ID" OnSelectedIndexChanged="dgvAllOrders_SelectedIndexChanged" CssClass="table table-light table-bordered" AutoGenerateColumns="false" runat="server">
        <Columns>
            <asp:BoundField HeaderText="Número de pedido" DataField="ID" />
            <asp:BoundField HeaderText="Fecha de pedido" DataField="OrderDate" />
            <asp:BoundField HeaderText="Importe" DataField="TotalAmount" />
            <asp:BoundField HeaderText="Estado" DataField="StatusDescription" />
            <asp:BoundField HeaderText="Cliente" DataField="CompanyName" />
            <asp:BoundField HeaderText="Costo de fabricación" DataField="TotalCost" />
            <asp:CommandField ShowSelectButton="true" SelectText="Ver" />
        </Columns>

    </asp:GridView>

    <asp:GridView ID="dgvOrderElements" DataKeyNames="IdProduct" CssClass="table table-light table-bordered" OnSelectedIndexChanged="dgvOrderElements_SelectedIndexChanged" AutoGenerateColumns="false" runat="server">
        <Columns>
            <asp:BoundField HeaderText="Número de línea" DataField="LineItem" />
            <asp:BoundField HeaderText="Producto" DataField="ProductName" />
            <asp:BoundField HeaderText="Talle" DataField="Size" />
            <asp:BoundField HeaderText="Color" DataField="Color" />
            <asp:BoundField HeaderText="Precio unitario" DataField="UnitPrice" />
            <asp:BoundField HeaderText="Cantidad" DataField="Quantity" />
            <asp:BoundField HeaderText="Total" DataField="TotalAmount" />
            <asp:CommandField ShowSelectButton="true" SelectText="Ver detalle del costo" />
        </Columns>

    </asp:GridView>
    <asp:GridView ID="dgvCostDetails" DataKeyNames="IdProduct" CssClass="table table-light table-bordered" AutoGenerateColumns="false" runat="server">
        <Columns>
            <asp:BoundField HeaderText="Material" DataField="Material" />
            <asp:BoundField HeaderText="Box" DataField="Box" />
            <asp:BoundField HeaderText="Color" DataField="Color" />
            <asp:BoundField HeaderText="Bag" DataField="Bag" />
            <asp:BoundField HeaderText="Mano de obra" DataField="Handwork" />


        </Columns>
    </asp:GridView>
</asp:Content>
