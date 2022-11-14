<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="EffortWeb.Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Stylesheets" runat="server">
        <link rel="stylesheet" href="CustomStyles1.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin-left: 25px">
        <p class="custom-font-red" style="font-size: 30px;">
            Contactate
            <span class="custom-font-blue" style="font-size: 30px;">con nosotros</span>
        </p>
    </div>
    <div>
        <p class="custom-font-text" style="margin-left: 25px">Podes escribirnos por correo electrónico a ejemplo@outlook.com, o escribirnos por whatsapp haciendo click en el siguiente link
            <br />
            O dejanos un mensaje completando los siguientes campos, Te responderemos a la brevedad.
        </p>
    </div>
</asp:Content>
