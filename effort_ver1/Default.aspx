<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="effort_ver1.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Stylesheets" runat="server">
    <link rel="stylesheet" href="CustomStyles1.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="default-banner-left">
        <div class="row">
            <div class="col-md-6">
                    <p class="custom-font-blue" style="text-align: center; margin-top: 100px">
                        Fabricación y venta de
                        <span class="custom-font-red">productos deportivos</span>
            </div>
            <div class="col-md-6" style="height: 200px;">
                <a href="Map.aspx">
                    <img class="banner-img" src="https://www.shutterstock.com/image-photo/perak-malaysia-canada-team-when-600w-1815012776.jpg">
                </a>
            </div>

        </div>
    </div>

    <div class="default-banner-right">
        <a href="Map.aspx" >
            <div class="row">
                <div class="col-md-6" style="height: 200px;">

                    <img class="banner-img" src="https://www.shutterstock.com/image-photo/low-angle-view-two-young-600w-1486328387.jpg">
                </div>
                <div class="col-md-6" style="height: 200px;">
                    <p class="custom-font-red" style="text-align: center; margin-top: 100px">
                        Amplia
                        <span class="custom-font-blue">zona de entrega</span>
                    </p>
                </div>
            </div>
        </a>
    </div>


    <div class="default-banner-bottom">
        <a href="AboutUs.aspx">
            <h2 class="custom-font-white" style="text-align: center; margin-top:100px">Registrate como usuario y accede a precios especiales</h2>
        </a>
    </div>


</asp:Content>

