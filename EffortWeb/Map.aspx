<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Map.aspx.cs" Inherits="EffortWeb.Map" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Stylesheets" runat="server">
    <link rel="stylesheet" href="CustomStyles1.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin-left: 25px">
        <p class="custom-font-red" style="font-size: 30px;">
            Zonas
            <span class="custom-font-blue" style="font-size: 30px;">de entrega</span>
        </p>
        <img src="https://www.shutterstock.com/image-vector/urban-vector-city-map-buenos-600w-1585420666.jpg" alt="Alternate Text" />

    </div>
    <div style="margin-top: 15px; margin-left: 25px">
        <p class="custom-font-text" style="font-size:15px">
            <span class="custom-font-blue" style="font-size:17px">Zona A:</span>
            Zona 1 - Zona 2 - Zona 3
            <br />

            <span class="custom-font-blue" style="font-size:17px">Zona B:</span>
            Zona 1 - Zona 2 - Zona 3
        <br />
            <span class="custom-font-blue" style="font-size:17px">Zona C:</span>
            Zona 1 - Zona 2 - Zona 3
        </p>

    </div>
    <div>
         <h5 class="custom-font-text" style="font-size: 15px; color: lightgrey; margin-left: 25px">¿No encontras tu zona? Contactate con nosotros para consultar cobertura.</h5>
    </div>
    <%--    <div style="margin-left: 25px">
        <p>
            <span class="custom-font-blue">Zona B:</span>
            Zona 1 - Zona 2 - Zona 3
        </p>
    </div>
    <div style="margin-left: 25px">
        <p>
            <span class="custom-font-blue">Zona B:</span>
            Zona 1 - Zona 2 - Zona 3
        </p>
    </div>--%>
</asp:Content>
