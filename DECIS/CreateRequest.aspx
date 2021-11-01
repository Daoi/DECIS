<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateRequest.aspx.cs" Inherits="DECIS.CreateRequest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DEC Inventory System</title>
    <link rel="icon" href=".ico" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" runat="server" />
    <script src="https://code.jquery.com/jquery-3.6.0.min.js" integrity="sha256-/xUj+3OJU5yExlq6GSYGSHk7tPXikynS7ogEvDej/m4=" crossorigin="anonymous"></script>    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/popper.min.js"></script>
    <link href="style/style.css" rel="stylesheet" />
    <script src="js/prefixfree.min.js" type="application/javascript"></script>
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.15.1/css/all.css" integrity="sha384-vp86vTRFVJgpjF9jiIGPEEqYqlDwgyBgEF109VFjmqGmIY/Y4HV4d3Gp2irVfcrp" crossorigin="anonymous" />
    <link href="https://cdn.jsdelivr.net/npm/select2@4.1.0-rc.0/dist/css/select2.min.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/select2@4.1.0-rc.0/dist/js/select2.min.js"></script>
    <script src="https://sdk.amazonaws.com/js/aws-sdk-2.962.0.min.js"></script>
    <script src="Scripts/HTML5-Form-Validation-DjValidator/dist/DjValidator.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="container-fluid w-auto h-100 createRequestBG pt-5">
            <div class="container-fluid w-50 h-100 shadow bg-white">
                <div class="row h-25 my-auto text-left cherryRedText">
                    <div class="col-3">
                        <asp:Image ID="imgLogo" ImageUrl="Images/CRC.png" runat="server" CssClass="img-fluid" />
                    </div>
                    <div class="col-9">
                        <h1 class="mt-3">Temple Tech for Philly Computer Request Form</h1>
                        <h6 class="mb-3">Non-profit and community requests for refurbished computer equipment</h6>
                    </div>
                </div>
                <%-- Main Form Start--%>
                <asp:UpdatePanel ID="upForm" UpdateMode="Conditional" runat="server">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlRequestType" EventName="SelectedIndexChanged" />
                        <asp:PostBackTrigger ControlID="btnSubmit" />
                    </Triggers>
                    <ContentTemplate>
                        <div id="divMsg" class="row mt-5 text-center" visible="true" runat="server">
                            <h4>
                                <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label></h4>
                        </div>
                        <div class="row mt-5">
                            <div class="col-2"></div>
                            <div class="col-8 mb-5" style="color: black">
                                <asp:Label ID="lblRequestType" runat="server" Text="Select Request Type:" CssClass=""></asp:Label>
                                <asp:DropDownList ID="ddlRequestType" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_SelectedIndexChanged">
                                    <asp:ListItem Selected="True" Value="-1">Select Request Type</asp:ListItem>
                                    <asp:ListItem Value="Personal">Personal (Equipment for an individual/home)</asp:ListItem>
                                    <asp:ListItem Value="Organization">Organization</asp:ListItem>
                                </asp:DropDownList>
                                <%--Shared Request Form Start--%>
                                <asp:Panel ID="pnlShared" runat="server">
                                    <asp:Label ID="lblOrganization" Visible="false" runat="server" Text="Select Affiliated Organization:" CssClass=""></asp:Label>
                                    <asp:DropDownList ID="ddlOrganization" data-dj-validator="org" Visible="false" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>
                                    <asp:Label ID="lblOrgName" runat="server" Text="Org name: "></asp:Label>
                                    <asp:TextBox ID="tbOrgName" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:Label ID="lblName" runat="server" Text="Name: "></asp:Label>
                                    <asp:TextBox ID="tbName" required="true" data-dj-validator="name" Placeholder="First and Last Name" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:Label ID="lblEmail" runat="server" Text="Email Address: " CssClass="mt-2"></asp:Label>
                                    <asp:TextBox ID="tbEmail" required="true" placeholder="Type none if you do not have one" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:Label ID="lblPhone" runat="server" Text="Phone: " CssClass="mt-2"></asp:Label>
                                    <asp:TextBox ID="tbPhone" required="true" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:Label ID="lblAddress" runat="server" Text="Organization Address: " CssClass="mt-2"></asp:Label>
                                    <asp:TextBox ID="tbAddress" required="true" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:Label ID="lblZipcode" runat="server" Text="Zip Code: " CssClass="mt-2"></asp:Label>
                                    <asp:TextBox ID="tbZipcode" required="true" runat="server" CssClass="form-control"></asp:TextBox>
                                </asp:Panel>
                                <%--Shared Request Form End--%>
                                <%--Personal Request Form Start--%>
                                <asp:Panel ID="pnlPersonal" CssClass="mb-5" runat="server" Visible="false">
                                    <asp:Label ID="lblGender" runat="server" Text="Gender: "></asp:Label>
                                    <asp:DropDownList ID="ddlGender" CssClass="form-control mt-2" runat="server"></asp:DropDownList>
                                    <asp:Label ID="lblRace" runat="server" Text="Race: "></asp:Label>
                                    <asp:DropDownList ID="ddlRace" CssClass="form-control mt-2" runat="server"></asp:DropDownList>
                                    <asp:Label ID="lblAgeRange" runat="server" Text="Age Range: "></asp:Label>
                                    <asp:DropDownList ID="ddlAgeRange" CssClass="form-control mt-2" runat="server"></asp:DropDownList>
                                    <asp:Label ID="lblEthnicity" runat="server" Text="Ethnicity: "></asp:Label>
                                    <asp:DropDownList ID="ddlEthnicity" CssClass="form-control mt-2" runat="server"></asp:DropDownList>
                                    <asp:Label ID="lblNumOfAdults" runat="server" Text="# Of Adults in Household:" CssClass="mt-2"></asp:Label>
                                    <asp:TextBox ID="tbNumOfAdults" required="true" TextMode="Number" min="0" data-dj-validator="int,0,10" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:Label ID="lblNumOfHS" runat="server" Text="# Of High School Students:" CssClass="mt-2"></asp:Label>
                                    <asp:TextBox ID="tbNumOfHS" required="true" TextMode="Number" min="0" data-dj-validator="int,0,10" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:Label ID="lblYoungKids" runat="server" Text="# of Kindergarten to Grade 8 Students:" CssClass="mt-2"></asp:Label>
                                    <asp:TextBox ID="tbYoungKids" required="true" TextMode="Number" min="0" data-dj-validator="int,0,10" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:Label ID="lblPreSchool" runat="server" Text="# of Preschool Children (not in Kindergarten)" CssClass="mt-2"></asp:Label>
                                    <asp:TextBox ID="tbPreSchool" required="true" TextMode="Number" min="0" data-dj-validator="int,0,10" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:Label ID="lblInternet" CssClass="mt-2" runat="server" Text="Please indicate if you would like a six month voucher for Comcast Internet Essentials: "></asp:Label>
                                    <asp:DropDownList ID="ddlInternet" CssClass="form-control mt-2" runat="server">
                                        <asp:ListItem Value="-1" Selected="True">Select Answer</asp:ListItem>
                                        <asp:ListItem Value="0">I currently have internet access at my home, and do not need an Internet Essential voucher.</asp:ListItem>
                                        <asp:ListItem Value="1">I currently do not have any internet access at my home, and would like an Internet Essential voucher.</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:Label ID="lblPersonalReasons" CssClass="mt-2" runat="server" Text="Please indicate the reasons why you are requesting a desktop computer, Check all that apply: "></asp:Label>
                                    <asp:CheckBoxList ID="cblReasons" CssClass="cbl" runat="server"></asp:CheckBoxList>
                                </asp:Panel>
                                <%--Personal Request Form End--%>
                                <%--Org Request Form Start--%>
                                <asp:Panel ID="pnlOrg" CssClass="mt-2" runat="server" Visible="false">
                                    <asp:Label ID="lblSameAsRequester" runat="server" Text="Is the contact for the request the same as the requester?"></asp:Label>
                                    <asp:CheckBox ID="cbSameAsRequester" Checked="false" runat="server" OnCheckedChanged="cbSameAsRequester_CheckedChanged" AutoPostBack="True" />
                                    <br />
                                    <asp:Label ID="lblContactName" runat="server" Text="Contact Name: "></asp:Label>
                                    <asp:TextBox ID="tbContactName" required="true" Placeholder="Full Name" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:Label ID="lblContactEmail" runat="server" Text="Contact Email Address: " CssClass="mt-2"></asp:Label>
                                    <asp:TextBox ID="tbContactEmail" required="true" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:Label ID="lblContactPhone" runat="server" Text="Contact Phone: " CssClass="mt-2"></asp:Label>
                                    <asp:TextBox ID="tbContactPhone" required="true" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:Label ID="lblOrgPurpose" runat="server" Text="Describe the organization and its purpose:" CssClass="mt-2"></asp:Label><asp:Label ID="lblOrgPurposeCharCount" for="tbOrgPurpose" runat="server" CssClass="charCountLabel m-1"></asp:Label>
                                    <asp:TextBox ID="tbOrgPurpose" onkeyup="countChar(this)" required="true" MaxLength="750" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:Label ID="lblPurpose" runat="server" Text="Intended purpose and targeted users of the computer equipment: " CssClass="mt-2"></asp:Label><asp:Label ID="lblPurposeCharCount" for="tbPurpose" runat="server" CssClass="charCountLabel"></asp:Label>
                                    <asp:TextBox ID="tbPurpose" onkeyup="countChar(this)" required="true" MaxLength="750" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:Label ID="lblSpecs" runat="server" Text="Number of and type of computer equipment desired (Include minimal specs required): " CssClass="mt-2"></asp:Label>
                                    <asp:TextBox ID="tbSpecs" required="true" MaxLength="400" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:Label ID="lblReferer" runat="server" Text="How did you hear about Temple Tech for Philly: " CssClass="mt-2"></asp:Label>
                                    <asp:TextBox ID="tbReferer" MaxLength="150" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:Label ID="lblTimeline" runat="server" Text="Briefly include a possible timeline of when you would need the items:" CssClass="mt-2"></asp:Label>
                                    <asp:TextBox ID="tbTimeline" required="true" MaxLength="200" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:Label ID="lblRecievedEquipment" runat="server" Text="Has your organization recieved equipment from us before?" CssClass="mt-2"></asp:Label>
                                    <asp:DropDownList ID="ddlReceivedEquipment" CssClass="form-control" runat="server">
                                        <asp:ListItem Value="0">No</asp:ListItem>
                                        <asp:ListItem Value="1">Yes</asp:ListItem>
                                    </asp:DropDownList>
                                </asp:Panel>
                                <%--Org Request Form End--%>
                            </div>
                            <div class="col-2"></div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div class="row mt-3 pb-3">
                    <div class="col-md-2"></div>
                    <div class="col-md-8">
                        <asp:Label ID="lblFU" runat="server" Text="Please upload a PDF file containing documents verifying non-profit status. Please also include pictures of the space the computers will be used in." CssClass="mt-2"></asp:Label>
                        <asp:FileUpload ID="fuDocuments" CssClass="form-control" runat="server" />
                    </div>
                    <div class="col-md-2"></div>
                </div>
                <div class="row mt-3 pb-3">
                    <div class="col-md-2"></div>
                    <div class="col-md-8">
                        <div runat="server" id="divButtons" class="row mb-3" visible="true">
                            <div class="col-4"></div>
                            <div class="col-4 text-center">
                                <asp:Button ID="btnSubmit" CssClass="btn btn-primary mt-3" runat="server" Text="Submit Request" OnClick="btnSubmit_Click" />
                                <br />
                                <asp:Label ID="lblSubmitError" runat="server" CssClass="text-danger" Text=""></asp:Label>
                            </div>
                            <div class="col-4"></div>
                        </div>
                    </div>
                    <div class="col-md-2"></div>
                </div>
                <%-- Main Form End--%>
            </div>
            <div class="pb-5" style="margin-top: 2%; height: 2%; width: auto;"></div>
        </div>
    </form>
</body>
<script>
    function pageLoad() {
        $("#ddlOrg").select2({
            placeholder: "Select Organization",
            allowClear: true,
            selectOnClose: true
        });

        $('#form1').djValidator({

        });

        $.fn.djValidator.add('name', 'Please include only first and last name, if its still not working email reuse@temple.edu',
            function ($field, params) {
                var value = $field.val();
                const regex = /^[^\s]+( [^\s]+)+$/;
                if (value.match(regex)) return true;
                else return false;
            });

        if ($("#ddlRequestType").prop('selectedIndex') === 2) {
            $("#lblFU").show();
            $("#fuDocuments").show();
        }
        else {
            $("#lblFU").hide();
            $("#fuDocuments").hide();
        }
    };
</script>
<script>
    //Change file label to file uploaded
    $(".custom-file-input").on("change", function () {
        var fileName = $(this).val().split("\\").pop();
        $(this).siblings(".custom-file-label").addClass("selected").html(fileName);
    });
</script>
<script>
    function countChar(val) {
        var len = val.value.length;
        if (len >= 750) {
            val.value = val.value.substring(0, 750);
        } else {
            $(`.charCountLabel[for=${val.id}]`).text(750 - len + ' / 750 characters');
        }
    };
</script>

</html>
