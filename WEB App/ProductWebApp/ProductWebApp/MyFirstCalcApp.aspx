<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyFirstCalcApp.aspx.cs" Inherits="ASPDotNetExample.MyFirstCalcApp" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Calculator App</title>
    <style type="text/css">
        .auto-style1 {
        }
    </style>
</head>
    <body>
    <form id="form1" runat="server">
        <div>
            <h1 style="text-align: center; color: #000000; background-color: #CCCCFF; font-family: 'Comic Sans MS';">
                Calcuator Application
            </h1>
            <div style="color: #000000; text-align: center; background-color: #CCCCFF;">

            <p style="font-family: 'Comic Sans MS'; font-size: large">
                Enter First Number: 
                <asp:TextBox runat="server" ID ="textFirstNo"/>
            </p>
            <p style="font-size: large; font-family: 'Comic Sans MS';">
                Select Options:
                <asp:DropDownList runat ="server" ID ="dpList">
                    <asp:ListItem Text="Add"/>
                    <asp:ListItem Text="Subtract" />
                    <asp:ListItem Text="Multiply" />
                    <asp:ListItem Text="Divide" />
                    </asp:DropDownList>
            </p>
            <p style="font-family: 'Comic Sans MS'; font-size: large;">
                <span class="auto-style1">Enter Second Number: 
                </span> 
                <asp:TextBox runat="server" ID ="textSecondNo" CssClass="auto-style1"/>
            </p>
            </div>
            <p style="text-align: center; background-color: #CCCCFF; font-family: 'Comic Sans MS';">
                <asp:Button Text="Click Me" runat ="server" BorderStyle="Double" OnClick="Unnamed1_Click" style="background-color: #FFFFFF" />
            </p>
