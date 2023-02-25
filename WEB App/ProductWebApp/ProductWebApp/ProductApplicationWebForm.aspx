
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
<div class="col-md-4">
                            <p>Product Id: <asp:TextBox runat="server" CssClass="form-control" ID="txtId"/></p>
                            <p>Name: <asp:TextBox CssClass="form-control" runat="server" ID="txtName"></asp:TextBox></p>
                            <p>Price: <asp:TextBox CssClass="form-control" runat="server" ID="txtPrice"></asp:TextBox></p>
<p>Quantity: 
                                <asp:DropDownList CssClass="form-control" runat="server" ID="dpQuantity">
                                    <asp:ListItem> 1 </asp:ListItem> 
                                    <asp:ListItem>2</asp:ListItem>
                                    <asp:ListItem>3</asp:ListItem>
                                    <asp:ListItem>4</asp:ListItem>
</asp:DropDownList>
                            </p>
                        </div>
                        <div class="col-md-1 align-items-center">
                            <button  class="btn btn-info m-2" onserverclick="btnEdit_click"  runat="server" >
                                <i class="fa fa-pencil"></i>
                            </button>
                            <button  class="btn btn-danger m-2" onserverclick="btnDelete_click"  runat="server" >
                            <i class="fa fa-trash-o"></i>
                            </button>
                            <button  class="btn btn-danger m-2" onserverclick="btnAdd_click"  runat="server" >
                            <i class="fa fa-plus-circle"></i>
                            </button>
                            <%--<asp:Button Text="Edit" runat="server" CssClass="btn btn-danger my-3" />
                            <i class="fa fa-trash-o"></i>
                            <asp:Button Text="Delete" runat="server" CssClass="btn btn-danger my-3" />
                            <i class="fa fa-trash-o"></i>
                            <asp:Button Text="Add" runat="server" CssClass="btn btn-danger my-3" />
                            <i class="fa fa-plus-circle"></i>--%>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

