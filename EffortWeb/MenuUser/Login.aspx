<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterUser.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="effort_ver1.MenuUser.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Stylesheets" runat="server">
    <link rel="stylesheet" href="../CSS/CustomStyles1.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-2"></div>
        <div class="col">
            <div class="mb-3">
                <label for="TxtEmail" class="form-label">Email</label>
                <asp:TextBox runat="server" ID="TxtEmail" placeholder="ejemplo@ejemplo.com" CssClass="form-control" Style="width: 300px;" type="email" />
            </div>
            <div class="mb-3">
                <label for="TxtPass" class="form-label">Contraseña</label>
                <asp:TextBox placeholder="contraseña" runat="server" ID="TxtPass" CssClass="form-control" Style="width: 300px;" type="password" />
            </div>
            <div>
                <asp:Label ID="ValidationText" Text="Usuario o contraseña incorrecta" CssClass="alert alert-warning" role="alert" runat="server" />
                <asp:Timer ID="ValidationTimer"  runat="server" OnTick="ValidationTimer_Tick" Interval="3000" >
    </asp:Timer>
            </div>
            <br/>
            <div>
                <asp:Button Text="Ingresar" ID="btnLogIn" CssClass="btn btn-primary" runat="server" OnClick="btnLogIn_Click" />
                <asp:Button Text="Crear cuenta" ID="btnCreateAccount" CssClass="btn btn-primary" runat="server" OnClick="btnCreateAccount_Click"/>
            </div>
        </div>
        <div class="col-2"></div>
    </div>
</asp:Content>
