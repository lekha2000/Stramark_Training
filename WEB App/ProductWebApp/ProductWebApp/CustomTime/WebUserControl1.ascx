<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebUserControl1.ascx.cs" Inherits="ProductWebApp.CustomTime.WebUserControl1" %>
<%@ OutputCache Duration="60" VaryByParam="none" %>


<div style="border: 2px solid purple">
    Time:
    <asp:Label Text="" ID="lblSysTime" Width="300px" Height="50px" runat="server"></asp:Label>
</div>
