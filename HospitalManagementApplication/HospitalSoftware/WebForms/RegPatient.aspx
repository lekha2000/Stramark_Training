<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/Main.Master" AutoEventWireup="true" CodeBehind="RegPatient.aspx.cs" Inherits="HostitalSoftware.WebForms.RegPatient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" runat="server">

<h1 class="auto-style1" style="font-family: Cambria">Patient Registration Form</h1>
    <hr />
<div class="container">
        <div class="row">
            <div class="col-md-9">
                <p style="font-family: Cambria">
                    Patient Id :
                    <asp:TextBox runat="server" Width="300px" ID="txtId" CssClass="form-control" PlaceHolder="Auto Generated" Enabled="false"></asp:TextBox>
                </p>
                <p style="font-family: Cambria">
                    Patient Name :
                    <asp:TextBox runat="server" Width="300px" ID="txtName" CssClass="form-control"></asp:TextBox>
                </p>
                <p style="font-family: Cambria">
                    Mobile No :
                    <asp:TextBox runat="server" Width="300px" ID="txtMobile" CssClass="form-control"></asp:TextBox>
                </p>
