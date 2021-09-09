<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DECIS.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DECIS</title>
    <link rel="icon" href="" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" runat="server" />
    <script src="Scripts/jquery-3.0.0.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/popper.min.js"></script>
    <script src="../../Scripts/jquery-1.3.2.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-ui-1.7.1.custom.min.js" type="text/javascript"></script>
    <link href="style/loginStyle.css" rel="stylesheet" />
    <link href="style/style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="d-flex">
            <asp:Panel ID="pnlCard" runat="server" CssClass="card mb-3 text-center mx-auto loginCard my-auto">
                <div class="card-header cherryBackground">
                    DEC Inventory System
                </div>
                <div>
                    <img src="" class="mt-5" />
                </div>
                <div class="card-body">
                    <!-- Login Panel -->
                    <asp:Panel ID="pnlLogin" runat="server">
                        <asp:Label ID="lblInstructions" runat="server" CssClass="text-black-50" Text="Enter your username and password."></asp:Label>
                        <br />
                        <asp:Label ID="lblError" runat="server" CssClass="errorLabel" Visible="false"></asp:Label>
                        <br />
                        <br />
                        <div class="form-group row justify-content-center">
                            <div class="col-md-6">
                                <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" placeholder="Username"></asp:TextBox>
                            </div>
                        </div>
                        <br />
                        <div class="form-group row justify-content-center">
                            <div class="col-md-6">
                                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="Password"></asp:TextBox>
                            </div>
                        </div>
                        <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="buttonStyle" />
                        <br />
                        <asp:Button ID="btnForgotPassword" runat="server" CssClass="btn btn-link font-weight-bold cherryFont" Text="Forgot Password?" />
                    </asp:Panel>
                    <!-- Password Reset Panel -->
                    <asp:Panel ID="pnlPasswordReset" runat="server" Visible="false">
                        
                    </asp:Panel>
                </div>
                <div class="card-footer text-muted">
                    DEC Inventory System
                </div>
            </asp:Panel>
        </div>
    </form>
</body>
</html>