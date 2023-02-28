<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainSheet.Master" AutoEventWireup="true" CodeBehind="StateManagement.aspx.cs" Inherits="ProductWebApp.MasterPages.StateManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" runat="server">
    <style>
        .item{
            border:2px solid blue;
        }
    </style>
    <h1 class="h1">
    Server Side State Management using session and Application State
    </h1>
    <div class="container">
        <div class="row">
            <div class="col-md-6">
                <asp:Repeater runat="server" ID="rpProducts">
                    <HeaderTemplate>
                        <div>
                            <h2>List of items with Us !!</h2>
                            <hr />
                        </div>
                    </HeaderTemplate>
                    <ItemTemplate>
            <div class="row item">
                <div class="col-md-8">

