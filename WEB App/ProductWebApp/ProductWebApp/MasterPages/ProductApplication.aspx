<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductApplication.aspx.cs" Inherits="ProductWebApp.MasterPages.ProductApplication" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Product Application</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/font-awesome.min.css" rel="stylesheet" />
    <style type="text/css">
        .col-md-4 {
            height: 381px;
            width: 211px;
        }
        .align-items-center {
            width: 141px;
        }
    </style>
    </head>
<body>
    <h1 class="h1 text-danger">Product Database</h1>
    <hr />

    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-md-4">
                    <asp:ListBox ID="lstProduct" runat="server" Height="386px" Width="213px"  AutoPostBack="True" OnSelectedIndexChanged="lstProduct_SelectedIndexChanged">                      
                    </asp:ListBox>
                </div>
                <div class ="col-md-7">
                    <h2>Display of the Products</h2>
                    <div >
                        <div style="width: 318px" >
                            <asp:Image ID="imgPic" runat="server" Height="208px" Width="266px"/>
                        </div>
                        <div >
                        <p style="width: 290px">Product Id: <asp:TextBox runat="server" CssClass="form-control" ID="txtId"/></p>
                            <p style="width: 288px">Name: <asp:TextBox CssClass="form-control" runat="server" ID="txtName"></asp:TextBox></p>
                            <p style="width: 182px">Price: <asp:TextBox CssClass="form-control" runat="server" ID="txtPrice"></asp:TextBox></p>
                            <p>Quantity: 
                                <asp:DropDownList CssClass="form-control" runat="server" ID="dpQuantity">
                                    <asp:ListItem> 1 </asp:ListItem> 
                                    <asp:ListItem>2</asp:ListItem>
                                    <asp:ListItem>3</asp:ListItem>
                                    <asp:ListItem>4</asp:ListItem>
                                    </asp:DropDownList>
                            </p>
                        </div>

