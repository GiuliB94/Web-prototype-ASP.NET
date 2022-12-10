<%@ Page Title="" Language="C#" MasterPageFile="../MasterPages/MasterUser.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="EffortWeb.MenuUser.Contact" %>

<asp:Content ID="ContactBodyContent" ContentPlaceHolderID="MainBodyPlaceHolder" runat="server">
    <div style="margin-left: 25px">
        <p class="custom-font-red" style="font-size: 30px;">
            Contactate
            <span class="custom-font-blue" style="font-size: 30px;">con nosotros</span>
        </p>
    </div>
    <div>
        <p class="custom-font-text" style="margin-left: 25px">
            Dejanos tu mensaje, no olvides completar todos tus campos para que podamos ponernos en contacto con vos.
            <br />
        </p>
    </div>

    <%--  Tabla para enviar mensaje directo --%>
    <div style="margin-left: 25px; margin-top: 25px;">
        <div class="row">
            <div class="col-sm-2 mb-3">
                <label for="tbName" class="form-label custom-font-text">Nombre</label>
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
                <asp:TextBox runat="server" ID="txtMail" CssClass="form-control" TextMode="Email" />
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
                <asp:Label runat="server" Style="font-weight: lighter" ID="lblError" Visible="false"> Ups! Por favor complete toda su información para que el mensaje pueda ser enviado. Si no posee ID de empresa puede omitirlo.</asp:Label>
                <br />
                <br />
                <asp:Button Text="Enviar" ID="btnSend" CssClass="btn btn-outline-light custom-btns rounding" BackColor="navy" runat="server" Width="100" Height="50" OnClick="btnSend_Click" />
            </div>
        </div>
        <div>
        </div>
        <br />
        <p class="custom-font-text" style="font-style:italic; color:lightgrey">
            No tenés correo electrónico? También podes contactarnos por whatsapp haciendo click en el siguiente enlace
            <a href="https://wa.me/1111111111">
                <img src="../Extras/Images/WhatsAppButtonGreenSmall.png" alt="whatsapp" style="height: 30px; width:100px" />
            </a>
        </p>
    </div>
</asp:Content>
