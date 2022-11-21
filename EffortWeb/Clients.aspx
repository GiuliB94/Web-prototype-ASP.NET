<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Clients.aspx.cs" Inherits="EffortWeb.Clients" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Stylesheets" runat="server">
    <link rel="stylesheet" href="CustomStyles1.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin-left: 25px">
        <p class="custom-font-red" style="font-size: 30px;">Lista de clientes</p>
    </div>
    <div class="row">
        <div class="col-6">
            <asp:GridView ID="dgvClients" OnSelectedIndexChanged="dgvClients_SelectedIndexChanged" CssClass="table table-light table-bordered" AutoGenerateColumns="false" runat="server">
                <Columns>
                    <asp:BoundField HeaderText="Empresa" DataField="idCompany" />
                    <asp:BoundField HeaderText="Nombre" DataField="name" />
                    <asp:BoundField HeaderText="Apellido" DataField="lastName" />
                    <asp:BoundField HeaderText="Categoría" DataField="category" />
                    <asp:CheckBoxField HeaderText="Alta" DataField="active" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
