<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Clients.aspx.cs" Inherits="EffortWeb.Clients" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Stylesheets" runat="server">
    <link rel="stylesheet" href="CustomStyles1.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style >
        .oculto {
            display:none;
        }
    </style>
    <div style="margin-left: 25px">
        <asp:Label Text="" ID="lblClients" runat="server" class="custom-font-red" style="font-size: 30px;"/>
        <div class="col-sm-9 mb-5">
                <%--DEBERIA SER VISIBLE SOLO PARA LOS USUARIOS ADMIN--%>
                <asp:Button Text="Ver solicitudes pendientes" ID="btnPendings" onClick="btnPendings_Click" class="btn btn-outline-primary" runat="server" Width="200" Height="40" />
            </div>
    </div>
    <div class="row">
        <div class="col-6">
            <asp:GridView ID="dgvClients" OnSelectedIndexChanged="dgvClients_SelectedIndexChanged" DataKeyNames="Id" CssClass="table table-light table-bordered" AutoGenerateColumns="false" runat="server">
                <Columns>
                    <asp:BoundField HeaderText="Empresa" DataField="idCompany" />
                    <asp:BoundField HeaderText="Nombre" DataField="name" />
                    <asp:BoundField HeaderText="Apellido" DataField="lastName" />
                    <asp:BoundField HeaderText="Categoría" DataField="category" />
                    <asp:CheckBoxField HeaderText="Alta" DataField="active" HeaderStyle-CssClass="oculto" ItemStyle-CssClass="oculto" />
                    <asp:CommandField ShowSelectButton="true" SelectText="Ver" />
                </Columns>
            </asp:GridView>
            <asp:GridView ID="dgvPendingClients" DataKeyNames="Id" OnSelectedIndexChanged="dgvPendingClients_SelectedIndexChanged" CssClass="table table-light table-bordered" AutoGenerateColumns="false" runat="server">
                <Columns>
                    <asp:BoundField HeaderText="Empresa" DataField="idCompany" />
                    <asp:BoundField HeaderText="Nombre" DataField="name" />
                    <asp:BoundField HeaderText="Apellido" DataField="lastName" />
                    <asp:BoundField HeaderText="Categoría" DataField="category" />
                    <asp:CheckBoxField HeaderText="Alta" DataField="active" HeaderStyle-CssClass="oculto" ItemStyle-CssClass="oculto" />
                    <asp:CommandField ShowSelectButton="true" SelectText="Ver" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
