<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="Clients.aspx.cs" Inherits="EffortWeb.MenuAdmin.Clients" %>

<asp:Content ID="ClientsBodyContent" ContentPlaceHolderID="MainBodyPlaceHolder" runat="server">
    <link rel="stylesheet" href="../CSS/CustomStyles.css" type="text/css" />
    <style>
        .oculto {
            display: none;
        }
    </style>
    <div style="margin-left: 25px">
        <asp:Label Text="" ID="lblClients" runat="server" class="custom-font-red" Style="font-size: 30px;" />
        <div class="col-sm-9 mb-5">
            <asp:Button Text="Ver solicitudes pendientes" ID="btnPendings" OnClick="btnPendings_Click" class="btn btn-outline-primary" runat="server" Width="200" Height="40" />
        </div>
           <div class="row">
        <div class="col-3">
            <div class="mb-3">
                <asp:Label CssClass="form-label custom-font-text" Text="Filtrar por" runat="server" />
                <asp:DropDownList CssClass="form-control" runat="server" ID="FilterDDown" AutoPostBack="true">
                    <asp:ListItem Text="Nombre" />
                    <asp:ListItem Text="Apellido" />
                    <asp:ListItem Text="DNI" />
                </asp:DropDownList>
            </div>
        </div>
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
    </div>
    </div>
    <div class="row">
        <div class="col-6">
            <asp:GridView ID="dgvClients" OnSelectedIndexChanged="dgvClients_SelectedIndexChanged" DataKeyNames="id" CssClass="table table-light table-bordered" AutoGenerateColumns="false" runat="server">
                <Columns>
                    <asp:BoundField HeaderText="IdUser" DataField="idUser" HeaderStyle-CssClass="oculto" ItemStyle-CssClass="oculto" />
                    <asp:BoundField HeaderText="Nombre" DataField="name" />
                    <asp:BoundField HeaderText="Apellido" DataField="lastName" />
                    <asp:BoundField HeaderText="Teléfono" DataField="phone" />
                    <asp:BoundField HeaderText="DNI" DataField="dni" />
                    <asp:CheckBoxField HeaderText="Alta" DataField="state" HeaderStyle-CssClass="oculto" ItemStyle-CssClass="oculto" />
                    <asp:CommandField ShowSelectButton="true" SelectText="Ver" />
                </Columns>
            </asp:GridView>
            <asp:GridView ID="dgvPendingClients" DataKeyNames="Id" OnSelectedIndexChanged="dgvPendingClients_SelectedIndexChanged" CssClass="table table-light table-bordered" AutoGenerateColumns="false" runat="server">
                <Columns>
                    <asp:BoundField HeaderText="IdUser" DataField="idUser" HeaderStyle-CssClass="oculto" ItemStyle-CssClass="oculto" />
                    <asp:BoundField HeaderText="Nombre" DataField="name" />
                    <asp:BoundField HeaderText="Apellido" DataField="lastName" />
                    <asp:BoundField HeaderText="Teléfono" DataField="phone" />
                    <asp:BoundField HeaderText="DNI" DataField="dni" />
                    <asp:CheckBoxField HeaderText="Alta" DataField="state" HeaderStyle-CssClass="oculto" ItemStyle-CssClass="oculto" />
                    <asp:CommandField ShowSelectButton="true" SelectText="Ver" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
