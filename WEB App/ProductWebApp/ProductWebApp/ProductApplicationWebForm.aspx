
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductAppWebForm.aspx.cs" Inherits="ProductWebApp.ProductAppWebForm" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ProductApplication</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/font-awesome.min.css" rel="stylesheet" />
</head>
<body>
    <h1 class="h1 text-danger">Product Database</h1>
    <hr />

    <form id="form1" runat="server">
        <div class="container">
            <div class="row d-flex">
                <div class="col-md-4">
                    <asp:ListBox ID="lstProduct" runat="server" Height="386px" Width="213px"  AutoPostBack="True" OnSelectedIndexChanged="lstProduct_SelectedIndexChanged" >                      
                    </asp:ListBox>
                </div>
<div class =" col-md-7">
                    <h2>Display of the Products</h2>
                    <div class="row">
                        <div class="col-md-6">
                            <asp:Image ID="imgPic" runat="server" Height="208px" Width="266px"/>
                            <asp:FileUpload runat="server" ID="fileUploader" />
                        </div>
