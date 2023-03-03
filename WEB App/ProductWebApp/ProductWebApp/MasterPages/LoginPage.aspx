<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainSheet.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="ProductWebApp.MasterPages.LoginPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" runat="server">
    <div style="height: 296px; width: 398px">
        <h2>User Login</h2>
        <hr />
        <p class="text-left">
            User Name:
            <asp:TextBox runat="server" ID="txtName" Height="25px" Width="140px"></asp:TextBox>
        </p>
        <p>
            Password:
            <asp:TextBox runat="server" ID="txtpass" Height="24px" Width="151px"></asp:TextBox>
        </p>
        <p>            
            <asp:Button Text="Login" runat="server" ID="btnLogin" OnClick="btnLogin_Click"></asp:Button>
        </p>
