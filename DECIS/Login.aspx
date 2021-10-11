<%@ Page Language="C#" AutoEventWireup="true" Async="true" CodeBehind="Login.aspx.cs" Inherits="DECIS.Login" %>

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
    <script src="Scripts/HTML5-Form-Validation-DjValidator/dist/DjValidator.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div class="d-flex loginContainer linen">
            <asp:Panel ID="pnlCard" runat="server" CssClass="card mx-auto my-auto text-center loginCard">
                <div class="card-header cherryBackground">
                    DEC Inventory System
                </div>
                <div>
                    <img src="" class="mt-5" />
                </div>
                <div class="card-body">
                    <!-- Login Panel -->
                    <asp:Panel ID="pnlLogin" runat="server">
                        <div class="row">
                            <asp:Label ID="lblInstructions" runat="server" CssClass="cherryFont mt-2" Text="Enter your username and password."></asp:Label>
                        </div>
                        <div class="row mt-2">
                            <asp:Label ID="lblError" runat="server" CssClass="cherryFont" Visible="false"></asp:Label>
                        </div>
                        <div class="form-group row justify-content-center">
                            <div class="col-md-8 mt-3">
                                <asp:TextBox ID="tbEmail" runat="server" CssClass="form-control" placeholder="Username"></asp:TextBox>
                            </div>
                        </div>
                        <br />
                        <div class="form-group row justify-content-center">
                            <div class="col-md-8">
                                <asp:TextBox ID="tbPassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="Password"></asp:TextBox>
                            </div>
                        </div>
                        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" CssClass="btn btn-primary mt-2" />
                        <br />
                        <asp:Button ID="btnForgotPassword" runat="server" OnClick="switchPanels" CssClass="btn btn-link font-weight-bold cherryFont" Text="Forgot Password?" />
                    </asp:Panel>
                    <!-- Password Reset Panel -->
                    <!-- Password Reset Panel -->
                    <asp:Panel ID="pnlPasswordReset" runat="server" Visible="false">
                        <asp:Label ID="lblPRInstructions" runat="server" CssClass="text-black-50" Text="Enter your email to receive a verification code."></asp:Label>
                        <div class="row">
                            <div class="col-sm-3 text-left my-auto">
                                <h5 class="text-body fw-bold">Password Requirements:</h5>
                                <h6 class="text-body fw-bold">Use at least 12 characters</h6>
                                <h6 class="text-body fw-bold">Include one uppercase letter</h6>
                                <h6 class="text-body fw-bold">Include one lowercase letter</h6>
                            </div>
                            <div class="col">
                                <br />
                                <asp:Label ID="lblPRError" runat="server" CssClass="cherryFont" Visible="false"></asp:Label>
                                <br />
                                <br />
                                <div class="form-group row justify-content-center">
                                    <div class="col-md-9">
                                        <asp:TextBox ID="txtPRUsername" runat="server" CssClass="form-control" placeholder="Email"></asp:TextBox>
                                    </div>
                                </div>

                                <br />
                                <div class="form-group row justify-content-center">
                                    <div class="col-md-9">
                                        <asp:TextBox ID="txtPRVerificationCode" runat="server" CssClass="form-control" placeholder="Verification Code" Enabled="false"></asp:TextBox>
                                    </div>
                                </div>

                                <br />
                                <div class="form-group row justify-content-center">
                                    <div class="col-md-9">
                                        <asp:TextBox ID="txtPRNewPassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="New Password" Enabled="false"></asp:TextBox>
                                    </div>
                                </div>

                                <br />
                                <div class="form-group row justify-content-center">
                                    <div class="col-md-9">
                                        <asp:TextBox ID="txtPRRetypePassword" runat="server" TextMode="Password" CssClass="form-control" placeholder=" Retype Password" Enabled="false"></asp:TextBox>
                                    </div>
                                </div>
                                <br />
                                <asp:Button ID="btnPRConfirm" runat="server" Text="Change Password" CssClass="btn btn-primary mt-2" OnClick="btnPRConfirm_Click" Enabled="false" />
                                <br />
                                <asp:Button ID="btnPRGoBack" runat="server" CssClass="btn btn-warning mt-2" Text="Back to Login" OnClick="switchPanels" />
                            </div>
                            <div class="col-sm-3 text-left">
                                <br />
                                <br />
                                <br />
                                <asp:Button ID="btnPRSendCode" runat="server" CssClass="buttonStyle" Text="Send Code" OnClick="btnPRSendCode_Click" />
                            </div>
                        </div>
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
