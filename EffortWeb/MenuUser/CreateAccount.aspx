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
                    <td>
                        <label for="TxtFirstName" class="form-label">Nombre</label></td>
                    <td>
                        <label for="TxtLastName" class="form-label">Apellido</label></td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox runat="server" ID="TxtFirstName" CssClass="form-control" Style="width: 250px;" type="text" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="TxtLastName" CssClass="form-control" Style="width: 200px;" type="text" /></td>
                </tr>
                <tr>
                    <td>
                        <label for="TxtPhone" class="form-label">Telefono</label></td>
                    <td>
                        <label for="TxtDNI" class="form-label">DNI</label></td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox runat="server" ID="TxtPhone" CssClass="form-control" Style="width: 150px;" type="text" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="TxtDNI" CssClass="form-control" Style="width: 100px;" type="text" /></td>
                </tr>
            </table>
        </asp:Panel>
    </div>
    <div style="margin-left: 25px; margin-top: 10px;">
        <asp:Panel ID="Panel_AdressInfo" runat="server" GroupingText="Direccion">
            <table>
                <tr>
                    <td>
                        <label for="TxtAdress" class="form-label">Calle y numero</label></td>
                    <td>
                        <label for="TxtPostalCode" class="form-label">Codigo Postal</label></td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox runat="server" ID="TxtAdress" CssClass="form-control" Style="width: 250px;" type="text" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="TxtPostalCode" CssClass="form-control" Style="width: 90px;" type="text" /></td>
                </tr>
                <tr>
                    <td>
                        <label for="TxtCity" class="form-label">Ciudad</label></td>
                    <td>
                        <label for="TxtProvince" class="form-label">Provincia</label></td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox runat="server" ID="TxtCity" CssClass="form-control" Style="width: 250px;" type="text" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="TxtProvince" CssClass="form-control" Style="width: 250px;" type="text" /></td>
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
                        <asp:TextBox runat="server" ID="TxtEmail" CssClass="form-control" Style="width: 300px;" type="email" /></td>
                </tr>
                <tr>
                    <td>
                        <label for="TxtPass" class="form-label">Password</label></td>
                    <td>
                        <label for="TxtRetryPass" class="form-label">Repetir Password</label></td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox runat="server" ID="TxtPass" CssClass="form-control" Style="width: 200px;" type="password" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="TxtRetryPass" CssClass="form-control" Style="width: 200px;" type="password" /></td>
                </tr>
            </table>
        </asp:Panel>
    </div>
    <div style="margin-left: 25px; margin-top: 60px;">
        <asp:Panel ID="Panel_Buttons" runat="server">
            <table>
                <tr>
                    <td>
                        <asp:Button Text="Crear Usuario" ID="btnCreateUser" CssClass="btn btn-primary" runat="server" OnClick="btnCreateUser_Click" /></td>
                    <td>
                        <asp:Button Text="Cancelar" ID="btnBack" CssClass="btn btn-primary" runat="server" /></td>
                </tr>
            </table>
        </asp:Panel>
    </div>
</asp:Content>



<!-- Navbar -->
<nav class="navbar navbar-expand-lg custom-navbar">
    <!-- Container wrapper -->
    <div class="container-fluid">
        <!-- Toggle button -->
        <button
            class="navbar-toggler"
            type="button"
            data-mdb-toggle="collapse"
            data-mdb-target="#navbarSupportedContent"
            aria-controls="navbarSupportedContent"
            aria-expanded="false"
            aria-label="Toggle navigation">
            <i class="fas fa-bars"></i>
        </button>

        <!-- Collapsible wrapper -->
        <div class="collapse navbar-collapse" id="navbarSupportedContent">
            <!-- Navbar brand -->
            <a class="navbar-brand mt-2 mt-lg-0" href="#">
                <img
                    src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTuUk0qvIxe0V2ZLDMaEmAeZWp6nPUYRFQdYnhOkvMdmHPJiRcBEuuIwUl9143L96X9CRk&usqp=CAU"
                    height="15"
                    alt="MDB Logo"
                    loading="lazy" />
            </a>
            <!-- Left links -->
            <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                <li class="nav-item">
                    <asp:LinkButton CssClass="nav-link custom-navar-txt" ID="LinkHome" PostBackUrl="~/MenuUser/Home.aspx" runat="server">Inicio</asp:LinkButton>
                </li>
                <li class="nav-item">
                    <asp:LinkButton CssClass="nav-link custom-navar-txt" ID="LinkCatalogue" PostBackUrl="~/MenuUser/Catalog.aspx" runat="server">Catálogo</asp:LinkButton>
                </li>
                <li class="nav-item">
                    <asp:LinkButton CssClass="nav-link custom-navar-txt" ID="LinkRegister" PostBackUrl="~/MenuUser/CreateAccount.aspx" runat="server">Quiero ser cliente</asp:LinkButton>
                </li>
                <li class="nav-item">
                    <asp:LinkButton CssClass="nav-link custom-navar-txt" ID="LinkAboutUs" PostBackUrl="~/MenuUser/AboutUs.aspx" runat="server">Sobre Effort</asp:LinkButton>
                </li>
            </ul>
            <!-- Left links -->
        </div>
        <!-- Collapsible wrapper -->

        <!-- Right elements -->
        <div class="d-flex align-items-center">
            <!-- Icon -->
            <a class="text-reset me-3" href="#">
                <i class="fas fa-shopping-cart"></i>
            </a>

            <!-- Notifications -->
            <div class="dropdown">
                <a
                    class="text-reset me-3 dropdown-toggle hidden-arrow"
                    href="#"
                    id="navbarDropdownMenuLink"
                    role="button"
                    data-mdb-toggle="dropdown"
                    aria-expanded="false">
                    <i class="fas fa-bell"></i>
                    <span class="badge rounded-pill badge-notification bg-danger">1</span>
                </a>
                <ul
                    class="dropdown-menu dropdown-menu-end"
                    aria-labelledby="navbarDropdownMenuLink">
                    <li>
                        <a class="dropdown-item" href="#">Some news</a>
                    </li>
                    <li>
                        <a class="dropdown-item" href="#">Another news</a>
                    </li>
                    <li>
                        <a class="dropdown-item" href="#">Something else here</a>
                    </li>
                </ul>
            </div>
            <!-- Avatar -->
            <nav class="navbar navbar-expand-lg custom-navbar">
                <ul class="navbar-nav" id="MenuCart">
                    <li>
                        <a class="nav-link custom-navar-txt">
                            <center>
                                <asp:ImageButton ID="CartButtom" runat="server" ImageUrl="../Extras/Images/Cart.png" Height="25%" Width="25%" ImageAlign="AbsMiddle" ForeColor="White" OnClick="CartButtom_Click" />
                                <asp:Label ID="CartProductsCount" runat="server" Text="0"></asp:Label>
                            </center>
                        </a>
                    </li>
                </ul>
                <ul class="navbar-nav" id="MenuLogIn">
                    <li>
                        <asp:LinkButton CssClass="nav-link custom-navar-txt" ID="LinkButton1" PostBackUrl="~/MenuUser/Login.aspx" runat="server">¿Ya sos cliente?</asp:LinkButton>
                    </li>
                </ul>
            </nav>
        </div>
        <!-- Right elements -->
    </div>
    <!-- Container wrapper -->
</nav>
<!-- Navbar -->
