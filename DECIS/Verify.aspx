<%@ Page Language="C#" AutoEventWireup="true" Async="true" CodeBehind="Verify.aspx.cs" Inherits="DECIS.Verify" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DECIS Verify</title>
    <link rel="icon" href="" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" runat="server" />
    <script src="Scripts/jquery-3.0.0.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/popper.min.js"></script>
    <script src="../../Scripts/jquery-1.3.2.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-ui-1.7.1.custom.min.js" type="text/javascript"></script>
    <link href="style/style.css" rel="stylesheet" />
    <script src="Scripts/HTML5-Form-Validation-DjValidator/dist/DjValidator.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="d-flex ">
            <div class="card mt-5 text-center mx-auto verifyCard my-auto">
                <div class="card-header cherryBackground">
                    Digital Equity Center Inventory System
                </div>
                <br />
                <div class="my-3">
                    <img src="" class="" />
                </div>
                <div class="card-body row">
                    <div class="col-sm-3 text-left">
                        <h5 class="text-body fw-bold">Password Requirements:</h5>
                        <h6 class="text-body fw-bold">Use at least 12 characters</h6>
                        <h6 class="text-body fw-bold">Include at least one uppercase letter</h6>
                        <h6 class="text-body fw-bold">Include at least one lowercase letter</h6>
                    </div>
                    <div class="col">
                        <asp:Label ID="lblUsername" CssClass="text-black-50" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="lblInstructions" runat="server" CssClass="h6 text-dark" Text="Set your new password below."></asp:Label>
                        <br />
                        <asp:Label ID="lblError" runat="server" CssClass="errorLabel"></asp:Label>
                        <br />
                        <div class="form-group row justify-content-center">
                            <div class="col-md-9">
                                <asp:TextBox ID="txtNewPassword" data-dj-validator="pw" TextMode="Password" runat="server" CssClass="form-control mt-2" placeholder="New Password"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row justify-content-center">
                            <div class="col-md-9">
                                <asp:TextBox ID="txtRetypePassword" TextMode="Password" runat="server" CssClass="form-control mt-2" placeholder="Confirm New Password"></asp:TextBox>
                            </div>
                        </div>
                        <asp:Button ID="btnConfirm" runat="server" Text="Verify" OnClick="btnConfirm_Click" CssClass="btn btn-primary mt-3" />

                    </div>
                    <div class="col-sm-3"></div>
                </div>
                <div class="card-footer text-muted">
                    DECIS
                </div>
            </div>
        </div>
    </form>
</body>
<script>
     function pageLoad() {

    $('#form1').djValidator({});

    $.fn.djValidator.add('pw', 'Password should be a minimum of 12 characters and requires upper case and lower case characters. (Symbols/numbers optional)',
        function ($field, params) {
            var value = $field.val();
            const regex = /^(?=.*[a-z])(?=.*[A-Z])[a-zA-Z\d]{12,}$/;
            if (value.match(regex)) return true;
            else return false;
        });
    };
</script>
</html>
