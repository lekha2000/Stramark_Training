<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainSheet.Master" AutoEventWireup="true" CodeBehind="InputPage.aspx.cs" Inherits="ProductWebApp.MasterPages.InputPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" runat="server">

<h2>Input the User Information</h2>
    <hr />
    <div>
        Enter the Name: 
        <div >
            <asp:TextBox runat="server" ID="txtName" CssClass="form-control" Height="27px" Width="221px"></asp:TextBox>
        </div>
    </div>
    <div>
        Enter the Email:
        <div ><asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" Height="27px" Width="221px"></asp:TextBox>
        </div>
    </div>
    <div >
        Enter the Contact No:
        <div >
            <asp:TextBox runat="server" ID="txtContact" CssClass="form-control" Height="27px" Width="221px"></asp:TextBox>
        
            
