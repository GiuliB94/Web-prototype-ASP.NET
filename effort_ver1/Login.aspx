<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="effort_ver1.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Stylesheets" runat="server">
    <link rel="stylesheet" href="CustomStyles.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-2"></div>
        <div class="col">
            <div class="mb-3">
                <label for="TxtMail" class="form-label">Email address</label>
                <asp:TextBox runat="server" ID="TxtMail" CssClass="form-control" style="width:300px;" type="email"/>
            </div>
            <div class="mb-3">
                <label for="TxtPass" class="form-label">Password</label>
                <asp:TextBox runat="server" ID="TxtPass" CssClass="form-control" style="width:300px;" CssClass="password"/>
            </div>
            <asp:Button Text="Aceptar" ID="btnAceptar" CssClass="btn btn-primary" runat="server" />
        </div>
        <div class="col-2"></div>
    </div>


</asp:Content>

