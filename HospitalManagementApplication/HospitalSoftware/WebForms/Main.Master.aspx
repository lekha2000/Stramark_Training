<%@ Master Language="C#" AutoEventWireup="true" CodeBehind="Main.master.cs" Inherits="HostitalSoftware.WebForms.Main" %>
<!DOCTYPE html>
<html>

<head runat="server">
    <title>Hospital Management System</title>
    <link href="../Contents/bootstrap.min.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            color: #000066;
        }
    </style>
</head>

<body style="background-color: #CCCCFF">
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <h1 style="text-align: center; background-color: #CCCCFF; font-family: Cambria;" class="auto-style1">Hospital Management System</h1>
            </div>
            <div class="row" >
                <div class="col-md-3">
                    <asp:Menu runat="server" style="background-color: #CCCCFF" BorderColor="#9966FF" Font-Bold="False">
                    <Items>
                        <asp:MenuItem Text="Home" NavigateUrl="~/WebForms/Home.aspx"></asp:MenuItem>
                        <asp:MenuItem Text="Patient" NavigateUrl="~/WebForms/RegPatient.aspx"></asp:MenuItem>
                        <asp:MenuItem Text="Doctor" NavigateUrl="~/WebForms/DoctorView.aspx"></asp:MenuItem>
                        <asp:MenuItem Text="Billing" NavigateUrl="~/WebForms/Billing.aspx"></asp:MenuItem>
                        <asp:MenuItem Text="Caching" NavigateUrl="~/WebForms/Caching.aspx"></asp:MenuItem>
                        <asp:MenuItem Text="LoginPage" NavigateUrl="~/WebForms/LoginPage.aspx"></asp:MenuItem>
                    </Items>
                        <StaticMenuStyle Height="500px" Width="100px" />
                </asp:Menu>
                </div>
                <div class="col-md-9">
                    <asp:ContentPlaceHolder ID="mainContent" runat="server">
                        <%--<h1>Home Page</h1>
                        <p>
                            Our Hospital has the best doctors of the Field to treat you with .........<br />
                        </p>--%>
