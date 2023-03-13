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
                <p style="font-family: Cambria">
                    Date of Birth :
                    <asp:TextBox TextMode="Date" runat="server" Width="300px" ID="txtDob" CssClass="form-control"></asp:TextBox>
                </p>
                <p style="font-family: Cambria">
                    Doctor Name :
                    <asp:DropDownList runat="server" Width="300px" ID="dpDoctors" CssClass="form-control"></asp:DropDownList>
                </p>
                <p>
                    <asp:Button Text="Register" Width="300px" runat="server" CssClass="btn btn-danger" OnClick="Unnamed1_Click"  />
                </p>
                <p>
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                </p>
            </div>
        </div>
    </div>
</asp:Content>

