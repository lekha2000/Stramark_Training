
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainSheet.Master" AutoEventWireup="true" CodeBehind="Caching.aspx.cs" Inherits="ProductWebApp.MasterPages.Caching" %>

<%--<%@ OutputCache Duration="60" VaryByParam="City" %>--%>
<%@Register TagPrefix="url1" TagName="ServerTime" Src="~/CustomTime/WebUserControl1.ascx"%>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" runat="server">
    <h1>Time at the server:</h1>
    <hr />
    <asp:Label Text="" ID="lblTime" runat="server"></asp:Label>
    <div style="border: 2px solid green">
        <h2>Time at various places</h2>
        <hr />
        <p>
            Select Ur City:
            <asp:dropdownlist runat="server" ID="dpCities">
                <asp:listitem text="New Delhi"></asp:listitem>
                <asp:listitem text="London" />
                <asp:listitem text="New York" />
                <asp:listitem text="Tokyo" />
            </asp:dropdownlist>
            <asp:Button Text="GetTime" runat="server" ID="btnTime" OnClick="btnTime_Click" />
            <asp:Label Text="" Id="lblClock" runat="server"></asp:Label>
        </p>
    </div>
    <div>
        <url1:ServerTime runat="server"> </url1:ServerTime>
    </div>

</asp:Content>
