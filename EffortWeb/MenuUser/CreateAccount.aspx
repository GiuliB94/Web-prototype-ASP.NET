<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterUser.Master" AutoEventWireup="true" CodeBehind="CreateAccount.aspx.cs" Inherits="effort_ver1.MenuUser.CreateAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Stylesheets" runat="server">
    <link rel="stylesheet" href="../CSS/CustomStyles1.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin-left: 25px; margin-top: 10px;">
        <p class="custom-font-red" style="font-size: 30px;">Ingrese sus datos</p>
            <asp:Panel ID="Panel_ClientInfo" runat="server" GroupingText="Datos Personales">
                <table>
                    <tr>
                        <td><label for="TxtFirstName" class="form-label">Nombre</label></td>
                        <td><label for="TxtLastName" class="form-label">Apellido</label></td>
                    </tr>
                    <tr>
                        <td><asp:TextBox runat="server" ID="TxtFirstName" CssClass="form-control" style="width:250px;" type="text"/></td>
                        <td><asp:TextBox runat="server" ID="TxtLastName" CssClass="form-control" style="width:200px;" type="text"/></td>
                    </tr>
                    <tr>
                        <td><label for="TxtPhone" class="form-label">Telefono</label></td>
                        <td><label for="TxtDNI" class="form-label">DNI</label></td>
                    </tr>
                    <tr>
                        <td><asp:TextBox runat="server" ID="TxtPhone" CssClass="form-control" style="width:150px;" type="text"/></td>
                        <td><asp:TextBox runat="server" ID="TxtDNI" CssClass="form-control" style="width:100px;" type="text"/></td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
        <div style="margin-left: 25px; margin-top: 10px;">
            <asp:Panel ID="Panel_AdressInfo" runat="server" GroupingText="Direccion">
                <table>
                    <tr>
                        <td><label for="TxtAdress" class="form-label">Calle y numero</label></td>
                        <td><label for="TxtPostalCode" class="form-label">Codigo Postal</label></td>
                    </tr>
                    <tr>
                        <td><asp:TextBox runat="server" ID="TxtAdress" CssClass="form-control" style="width:250px;" type="text"/></td>
                        <td><asp:TextBox runat="server" ID="TxtPostalCode" CssClass="form-control" style="width:90px;" type="text"/></td>
                    </tr>
                    <tr>
                        <td><label for="TxtCity" class="form-label">Ciudad</label></td>
                        <td><label for="TxtProvince" class="form-label">Provincia</label></td>
                    </tr>
                    <tr>
                        <td><asp:TextBox runat="server" ID="TxtCity" CssClass="form-control" style="width:250px;" type="text"/></td>
                        <td><asp:TextBox runat="server" ID="TxtProvince" CssClass="form-control" style="width:250px;" type="text"/></td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
        <div style="margin-left: 25px; margin-top: 10px;">
            <asp:Panel ID="PanelUserInfo" runat="server" GroupingText="Usuario">
                <table>
                    <tr>
                        <td><label for="TxtEmail" class="form-label">Email address</label></td>
                    </tr>
                    <tr>
                        <td><asp:TextBox runat="server" ID="TxtEmail" CssClass="form-control" style="width:300px;" type="email"/></td>
                    </tr>
                    <tr>
                        <td><label for="TxtPass" class="form-label">Password</label></td>
                        <td><label for="TxtRetryPass" class="form-label">Repetir Password</label></td>
                    </tr>
                    <tr>
                        <td><asp:TextBox runat="server" ID="TxtPass" CssClass="form-control" style="width:200px;" type="password"/></td>
                        <td><asp:TextBox runat="server" ID="TxtRetryPass" CssClass="form-control" style="width:200px;" type="password"/></td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
        <div style="margin-left: 25px; margin-top: 60px;">
            <asp:Panel ID="Panel_Buttons" runat="server">
                <table>
                    <tr>
                        <td><asp:Button Text="Crear Usuario" ID="btnCreateUser" CssClass="btn btn-primary" runat="server" OnClick="btnCreateUser_Click" /></td>
                        <td><asp:Button Text="Cancelar" ID="btnBack" CssClass="btn btn-primary" runat="server" /></td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
</asp:Content>