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
        <p class="custom-font-text" style="margin-left: 25px">
            Podes escribirnos por correo electrónico a ejemplo@outlook.com, o escribirnos por whatsapp haciendo click en el siguiente link

            <br />
            O dejanos un mensaje completando los siguientes campos, Te responderemos a la brevedad.
        </p>
    </div>

  <%--  Tabla para enviar mensaje directo --%>
    <div style="margin-left: 25px; margin-top:25px;">
        <div class="row">
            <div class="col-sm-2 mb-3">
                <label for="txtName" class="form-label custom-font-text">Nombre</label>
            </div>
            <div class="col-sm-4 mb-3" style="text-align: right">
                <asp:TextBox runat="server" ID="txtName" CssClass="form-control" />
            </div>

        </div>
        <div class="row">
            <div class="col-sm-2 mb-3">
                <label for="txtLastName" class="form-label custom-font-text">Apellido</label>
            </div>
            <div class="col-sm-4 mb-3" style="text-align: right">
                <asp:TextBox runat="server" ID="txtLastName" CssClass="form-control" />
            </div>
        </div>

        <div class="row">
            <div class="col-sm-2 mb-3">
                <label for="txtID" class="form-label custom-font-text">ID Empresa</label>
            </div>
            <div class="col-sm-4 mb-3" style="text-align: right">
                <asp:TextBox runat="server" ID="txtID" CssClass="form-control" />
            </div>
        </div>

        <div class="row">
            <div class="col-sm-2 mb-3">
                <label for="txtMail" class="form-label custom-font-text">Mail</label>
            </div>
            <div class="col-sm-4 mb-3" style="text-align: right">
                <asp:TextBox runat="server"  ID="txtMail" CssClass="form-control" TextMode="Email" />
            </div>
        </div>

        <div class="row">
            <div class="col-sm-2 mb-3">
                <label for="txtPhone" class="form-label custom-font-text">Teléfono de contacto</label>
            </div>
            <div class="col-sm-4 mb-3" style="text-align: right">
                <asp:TextBox runat="server" ID="txtPhone" CssClass="form-control" TextMode="Phone" />
            </div>
        </div>

        <div class="row">

            <div class="col-sm-2 mb-3">
                <label for="txtMsj" class="form-label custom-font-text">Dejanos tu mensaje</label>
            </div>
            <div class="col-sm-6 mb-3">
                <asp:TextBox runat="server" TextMode="MultiLine" ID="txtMsj" CssClass="form-control" ValidateRequestMode="Inherit" Height="200" Wrap="False" />
                <br />
                <asp:Button Text="Enviar" ID="btnSend" CssClass="btn btn-outline-light custom-btns rounding" BackColor="navy" runat="server" Width="100" Height="50" />
            </div>
            </div>
            
        </div>
</asp:Content>
