<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EffortWeb.Menu.Login" %>
<asp:Content ID="HomeBodyContent" ContentPlaceHolderID="MainBodyPlaceHolder" runat="server">
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

            <br/>
            <div>
                <asp:Button Text="Ingresar" ID="btnLogIn" CssClass="btn btn-primary" runat="server" OnClick="btnLogIn_Click" />
                <asp:Button Text="Crear cuenta" ID="btnCreateAccount" CssClass="btn btn-primary" runat="server" OnClick="btnCreateAccount_Click"/>
            </div>
        </div>
        <div class="col-2"></div>
    </div>
</asp:Content>
