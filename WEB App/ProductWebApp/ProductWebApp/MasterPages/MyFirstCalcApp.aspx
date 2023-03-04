<%@ Page Language="C#" MasterPageFile="~/MasterPages/MainSheet.Master" AutoEventWireup="true" CodeBehind="MyFirstCalcApp.aspx.cs" Inherits="ProductWebApp.MasterPages.MyFirstCalcApp" %>

<asp:Content runat="server" ContentPlaceHolderID="mainContent">
        <div>
            <h1 style="text-align: left; color: #000000; background-color: #CCCCFF; font-family: 'Comic Sans MS';">
                Calcuator Application
            </h1>
            <div style="color: #000000; text-align: center; background-color: #CCCCFF;">
<p style="font-family: 'Comic Sans MS'; font-size: large; text-align: left;">
                Enter First Number: 
<asp:TextBox runat="server" ID ="txtFirstNo"/>
            </p>
               <p style="font-size: large; font-family: 'Comic Sans MS'; text-align: left;">
                Select Options:
                <asp:DropDownList runat ="server" ID ="dpList">
                    <asp:ListItem Text="Add"/>
                    <asp:ListItem Text="Subtract" />
                    <asp:ListItem Text="Multiply" />
                    <asp:ListItem Text="Divide" />
                    </asp:DropDownList>
            </p>
            <p style="font-family: 'Comic Sans MS'; font-size: large; text-align: left;">
                <span class="auto-style1">Enter Second Number: 
                </span> 
                <asp:TextBox runat="server" ID ="txtSecondNo" CssClass="auto-style1"/>
            </p>   
            </div>
