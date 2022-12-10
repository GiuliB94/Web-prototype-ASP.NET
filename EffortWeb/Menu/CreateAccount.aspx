<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Master.Master" AutoEventWireup="true" CodeBehind="CreateAccount.aspx.cs" Inherits="EffortWeb.Menu.CreateAccount" %>

<asp:Content ID="CreateAccountBodyContent" ContentPlaceHolderID="MainBodyPlaceHolder" runat="server">
    <script type="text/javascript" src="js/JScript.js"></script>
    <div style="margin-left: 25px; margin-top: 10px;">
        <p class="custom-font-red" style="font-size: 30px;">Ingrese sus datos</p>
        <asp:Panel ID="Panel_ClientInfo" runat="server" GroupingText="Datos Personales">
            <table>
                <tr>
                    <td>
                        <label for="TxtFirstName" class="form-label">Nombre Completo</label></td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox runat="server" ID="TxtFirstName" CssClass="form-control" Style="width: 250px;" type="text" MaxLength="150" /></td>
                </tr>
                <tr>
                    <td>
                        <label for="TxtPhone" class="form-label">Telefono</label></td>
                    <td>
                        <label for="TxtCUIT" class="form-label">CUIT</label></td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox runat="server" ID="TxtPhone" CssClass="form-control" Style="width: 150px;" MaxLength="20" /></td>
                    <asp:RegularExpressionValidator ID="revPhone" runat="server" ErrorMessage="Telefono no valido, ingresar solo números" ControlToValidate="TxtPhone" ValidationExpression="\d{0,20}"></asp:RegularExpressionValidator>
                    <td>
                        <asp:TextBox runat="server" ID="TxtCUIT" CssClass="form-control" Style="width: 100px;" MaxLength="11" /></td>
                    <asp:RegularExpressionValidator ID="revCUIT" runat="server" ErrorMessage="CUIT/CUIL no valido, ingresar solo números" ControlToValidate="TxtCUIT" ValidationExpression="\d{0,11}"></asp:RegularExpressionValidator>

                </tr>
            </table>
        </asp:Panel>
    </div>
    <div style="margin-left: 25px; margin-top: 10px;">
        <asp:Panel ID="Panel_AdressInfo" runat="server" GroupingText="Direccion">
            <table>
                <tr>
                    <td>
                        <label for="TxtAddress" class="form-label">Calle y numero</label></td>
                    <td>
                        <label for="TxtAddressExtra" class="form-label">Piso y departamento</label></td>
                    <td>
                        <label for="TxtPostalCode" class="form-label">Codigo Postal</label></td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox runat="server" ID="TxtAddress" CssClass="form-control" Style="width: 250px;" type="text" MaxLength="150" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="TxtAddressExtra" CssClass="form-control" Style="width: 250px;" type="text" MaxLength="150" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="TxtPostalCode" CssClass="form-control" Style="width: 90px;" MaxLength="6" /></td>
                    <asp:RegularExpressionValidator ID="revCP" runat="server" ErrorMessage="Código postal no valido, ingresar solo números" ControlToValidate="TxtPostalCode" ValidationExpression="\d{0,6}"></asp:RegularExpressionValidator>
                </tr>
                <tr>
                    <td>
                        <label for="TxtCity" class="form-label">Ciudad</label></td>
                    <td>
                        <label for="TxtProvince" class="form-label">Provincia</label></td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox runat="server" ID="TxtCity" CssClass="form-control" Style="width: 250px;" type="text" MaxLength="50" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="TxtProvince" CssClass="form-control" Style="width: 250px;" type="text" MaxLength="50" /></td>
                </tr>
            </table>
        </asp:Panel>
    </div>
    <div style="margin-left: 25px; margin-top: 10px;">
        <asp:Panel ID="PanelUserInfo" runat="server" GroupingText="Usuario">
            <table>
                <tr>
                    <td>
                        <label for="TxtEmail" class="form-label">Email address</label></td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox runat="server" ID="TxtEmail" CssClass="form-control" Style="width: 300px;" type="email" MaxLength="255" /></td>
                </tr>
                <tr>
                    <td>
                        <label for="TxtPass" class="form-label">Password</label></td>
                    <td>
                        <label for="TxtRetryPass" class="form-label">Repetir Password</label></td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox runat="server" ID="TxtPass" CssClass="form-control" Style="width: 200px;" type="password" MaxLength="32" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="TxtRetryPass" CssClass="form-control" Style="width: 200px;" type="password" MaxLength="32" /></td>
                </tr>
            </table>
        </asp:Panel>
    </div>
    <div style="margin-left: 25px; margin-top: 60px;">
        <asp:Panel ID="Panel_Buttons" runat="server">
            <table>
                <tr>
                    <asp:Label Text="" runat="server" Visible="false" Style="font-weight: lighter" ID="lblErrorMSG" />
                    <td>
                        <asp:Button Text="Crear Usuario" ID="btnCreateUser" CssClass="btn btn-primary" runat="server" OnClick="btnCreateUser_Click" /></td>
                    <td>
                        <asp:Button Text="Cancelar" ID="btnBack" CssClass="btn btn-primary" runat="server" /></td>
                </tr>
            </table>
        </asp:Panel>
    </div>
</asp:Content>
