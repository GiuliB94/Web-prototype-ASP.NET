<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Master.Master" AutoEventWireup="true" CodeBehind="CreateAccount.aspx.cs" Inherits="EffortWeb.Menu.CreateAccount" %>

<asp:Content ID="CreateAccountBodyContent" ContentPlaceHolderID="MainBodyPlaceHolder" runat="server">
    <script type="text/javascript" src="js/JScript.js"></script>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
    <div style="display:none"> <asp:Button ID="hiddenButton" runat="server"/></div>
    <div style="margin-left: 25px; margin-top: 10px;">
        <p class="custom-font-red" style="font-size: 30px;">Ingrese sus datos</p>
        <asp:Panel ID="Panel_ClientInfo" runat="server" GroupingText="Datos Personales">
            <table>
                <tr>
                    <td>
                        <label for="TxtFirstName" class="form-label">Nombre Completo</label></td>
                    <td>
                        <asp:Label runat="server" for="TxtIdCompany" CssClass="form-label" Visible="false" ID="lblId">ID de la Empresa</asp:Label>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:TextBox runat="server" ID="TxtFirstName" CssClass="form-control" Style="width: 250px;" type="text" MaxLength="150" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="TxtIdCompany" CssClass="form-control" Style="width: 100px;" ReadOnly="True" Visible="false" /></td>
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
                <tr>
                    <td>
                        <asp:Label runat="server" for="TxtIdCompany" CssClass="form-label" Visible="false" ID="LblIdUser">ID de Usuario</asp:Label></td>
                    <td>
                        <asp:TextBox runat="server" ID="TxtIdUser" Visible="False" ReadOnly="True" CssClass="form-control" Style="width: 100px" /></td>

                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
    <div style="margin-left: 25px; margin-top: 60px;">
        <asp:Panel ID="Panel_Buttons" runat="server">
            <table>
                <tr>
                    <td>
                        <asp:Button Text="Crear Usuario" ID="btnCreateUser" CssClass="btn btn-primary" runat="server" OnClick="btnCreateUser_Click" data-bs-toggle="modal" data-bs-target="#PopupMSG" /></td>
                    <td>
                        <asp:Button Text="Cancelar" ID="btnBack" CssClass="btn btn-primary" runat="server" OnClick="btnBack_Click" /></td>
                    <td>
                        <asp:Button Text="Modificar" runat="server" ID="btnModify" CssClass="btn btn-primary" Visible="false" OnClick="btnModify_Click" /></td>
                    <td>
                        <asp:Button Text="Activar" runat="server" ID="BtnActive" CssClass="btn btn-primary" Visible="false" OnClick="BtnActive_Click" /></td>
                    <td>
                        <asp:Button Text="Rechazar" runat="server" ID="BtnReject" CssClass="btn btn-primary" Visible="false" OnClick="BtnReject_Click" />
                       
                    </td>

                </tr>
            </table>
            <div>
            </div>
        </asp:Panel>

        <asp:Panel ID="MSGPanel" Style="display: none; background-color: var(--bg-color-effort-blue); align-content: center;" runat="server">
            <div class="popup-margin" style="margin-top: 100px">
                <div style="margin-top: 30px; margin-left: 30px; margin-right: 30px">
                    <table>
                        <tr><td></td></tr>
                        <tr>
                            <td>
                                <asp:Label ID="LabelMSG" Style="font-family: var(--mdb-body-font-family); color: white; margin-top: 10px" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Button Text="Aceptar" ID="Okbtn" class="btn btn-outline-light" Style="margin-top: 10px; font-size: smaller;" runat="server" /></td>
                        </tr>
                        <tr><td></td></tr>
                    </table>
                </div>
            </div>
    </div>
    </div>
    </asp:Panel>
        <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="hiddenButton" PopupControlID="MSGPanel" DropShadow="true" OkControlID="Okbtn" CancelControlID="Okbtn"></ajaxToolkit:ModalPopupExtender>

</asp:Content>
