<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ClientForm.aspx.cs" Inherits="effort_ver1.ClientForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Stylesheets" runat="server">
    <link rel="stylesheet" href="CustomStyles1.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin-left: 25px">
        <p class="custom-font-red" style="font-size: 30px;">Ingrese sus datos</p>
    </div>
    <div class="row">
        <div class="col-6">
            <div>
                <p class="custom-font-text" style="margin-left: 25px">
                    Envia tu solicitud de alta de cliente.
                </p>
            </div>
            <%--  Formulario para completar los datos de los clientes // Esto viaja a clientes, pero con el active en false y despues se le da de alta.--%>
            <div style="margin-left: 25px; margin-top: 25px;">
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
                        <label for="txtIdCompany" class="form-label custom-font-text">Empresa</label>
                    </div>
                    <div class="col-sm-4 mb-3" style="text-align: right">
                        <asp:TextBox runat="server" ID="txtIdCompany" CssClass="form-control" />
                    </div>
                </div>

                <div class="row">
                    <div class="col-sm-2 mb-3">
                        <label for="txtEmail" class="form-label custom-font-text">Email</label>
                    </div>
                    <div class="col-sm-4 mb-3" style="text-align: right">
                        <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" TextMode="Email" />
                    </div>
                </div>

                <div class="row">
                    <div class="col-sm-2 mb-3">
                        <label for="txtPhone" class="form-label custom-font-text">Teléfono</label>
                    </div>
                    <div class="col-sm-4 mb-3" style="text-align: right">
                        <asp:TextBox runat="server" ID="txtPhone" CssClass="form-control" TextMode="Phone" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-6 mb-3">
                        <asp:Button Text="Enviar solicitud" ID="btnSendClientForm" OnClick="btnSendClientForm_Click" CssClass="btn btn-outline-light custom-btns rounding" BackColor="navy" runat="server" Width="170" Height="50" />
                        <asp:Button Text="Dar de alta" ID="btnSignUp" OnClick="btnSignUp_Click" Visible="false" CssClass="btn btn-outline-light custom-btns rounding" BackColor="navy" runat="server" Width="170" Height="50" />                    
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

