<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateRequest.aspx.cs" Inherits="DECIS.CreateRequest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DEC Inventory System</title>
    <link rel="icon" href=".ico" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" runat="server" />
    <script src="Scripts/jquery-3.0.0.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/popper.min.js"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/v/bs4/dt-1.10.22/b-1.6.5/r-2.2.6/datatables.min.css" />
    <script type="text/javascript" src="https://cdn.datatables.net/v/bs4/dt-1.10.22/b-1.6.5/r-2.2.6/datatables.min.js"></script>
    <link href="style/style.css" rel="stylesheet" />
    <script src="js/prefixfree.min.js" type="application/javascript"></script>
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.15.1/css/all.css" integrity="sha384-vp86vTRFVJgpjF9jiIGPEEqYqlDwgyBgEF109VFjmqGmIY/Y4HV4d3Gp2irVfcrp" crossorigin="anonymous" />
    <link href="https://cdn.jsdelivr.net/npm/select2@4.1.0-rc.0/dist/css/select2.min.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/select2@4.1.0-rc.0/dist/js/select2.min.js"></script>
    <script src="https://sdk.amazonaws.com/js/aws-sdk-2.962.0.min.js"></script>
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
                    </Triggers>
                    <ContentTemplate>
                        <div class="row mt-5">
                            <div class="col-2"></div>
                            <div class="col-8 mb-5" style="color: black">
                                <asp:Label ID="lblRequestType" runat="server" Text="Select Request Type:" CssClass=""></asp:Label>
                                <asp:DropDownList ID="ddlRequestType" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_SelectedIndexChanged">
                                    <asp:ListItem Selected="True" Value="-1">Select Request Type</asp:ListItem>
                                    <asp:ListItem>Personal</asp:ListItem>
                                    <asp:ListItem>Organization</asp:ListItem>
                                </asp:DropDownList>
                                <%--Shared Request Form Start--%>
                                <asp:Panel ID="pnlShared" runat="server">
                                    <asp:Label ID="lblOrganization" Visible="false" runat="server" Text="Select Affiliated Organization:" CssClass=""></asp:Label>
                                    <asp:DropDownList ID="ddlOrg" Visible="false" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>
                                    <asp:Label ID="lblOrgName" runat="server" Text="Org name: "></asp:Label>
                                    <asp:TextBox ID="tbOrgName" Placeholder="Full Name" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:Label ID="lblName" runat="server" Text="Name: "></asp:Label>
                                    <asp:TextBox ID="tbName" Placeholder="Full Name" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:Label ID="lblEmail" runat="server" Text="Email Address: " CssClass="mt-2"></asp:Label>
                                    <asp:TextBox ID="tbEmail" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:Label ID="lblPhone" runat="server" Text="Phone: " CssClass="mt-2"></asp:Label>
                                    <asp:TextBox ID="tbPhone" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:Label ID="lblZipcode" runat="server" Text="Zip Code: " CssClass="mt-2"></asp:Label>
                                    <asp:TextBox ID="tbZipcode" runat="server" CssClass="form-control"></asp:TextBox>
                                </asp:Panel>
                                <%--Shared Request Form End--%>
                                <%--Personal Request Form Start--%>
                                <asp:Panel ID="pnlPersonal" CssClass="mb-5" runat="server" Visible="false">
                                    <asp:Label ID="lblGender" runat="server" Text="Gender: "></asp:Label>
                                    <asp:DropDownList ID="ddlGender" CssClass="form-control mt-2" runat="server"></asp:DropDownList>
                                    <asp:Label ID="lblRace" runat="server" Text="Race: "></asp:Label>
                                    <asp:DropDownList ID="ddlRace" CssClass="form-control mt-2" runat="server"></asp:DropDownList>
                                    <asp:Label ID="lblEthnicity" runat="server" Text="Ethnicity: "></asp:Label>
                                    <asp:DropDownList ID="ddlEthnicity" CssClass="form-control mt-2" runat="server"></asp:DropDownList>
                                    <asp:Label ID="lblInternet" runat="server" Text="Please indicate if you would like a six month voucher for Comcast Internet Essentials: "></asp:Label>
                                    <asp:DropDownList ID="ddlInternet" CssClass="form-control mt-2" runat="server">
                                        <asp:ListItem Selected="True">Select Answer</asp:ListItem>
                                        <asp:ListItem Value="0">I currently have internet access at my home, and do not need an Internet Essential voucher.</asp:ListItem>
                                        <asp:ListItem Value="1">I currently do not have any internet access at my home, and would like an Internet Essential voucher.</asp:ListItem>
                                    </asp:DropDownList>
                                </asp:Panel>
                                <%--Personal Request Form End--%>
                                <%--Org Request Form Start--%>
                                <asp:Panel ID="pnlOrg" CssClass="mt-2" runat="server" Visible="false">
                                    <asp:Label ID="lblSameAsRequester" runat="server"  Text="Is the contact for the request the same as the requester?"></asp:Label>
                                    <asp:CheckBox ID="cbSameAsRequester" Checked="false" runat="server" OnCheckedChanged="cbSameAsRequester_CheckedChanged" AutoPostBack="True" />
                                    <br />
                                    <asp:Label ID="lblContactName" runat="server" Text="Contact Name: "></asp:Label>
                                    <asp:TextBox ID="tbContactName" Placeholder="Full Name" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:Label ID="lblContactEmail" runat="server" Text="Contact Email Address: " CssClass="mt-2"></asp:Label>
                                    <asp:TextBox ID="tbContactEmail" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:Label ID="lblContactPhone" runat="server" Text="Contact Phone: " CssClass="mt-2"></asp:Label>
                                    <asp:TextBox ID="tbContactPhone" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:Label ID="lblOrgPurpose" runat="server" Text="Describe the organization and its purpose:" CssClass="mt-2"></asp:Label>
                                    <asp:TextBox ID="tbOrgPurpose" MaxLength="500" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:Label ID="lblPurpose" runat="server" Text="Intended purpose and targeted users of the computer equipment: " CssClass="mt-2"></asp:Label>
                                    <asp:TextBox ID="tbPurpose" MaxLength="500" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:Label ID="lblSpecs" runat="server" Text="Number of and type of computer equipment desired (Include minimal specs required): " CssClass="mt-2"></asp:Label>
                                    <asp:TextBox ID="tbSpecs" MaxLength="400" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:Label ID="lblReferer" runat="server" Text="How did you hear about Temple Tech for Philly: " CssClass="mt-2"></asp:Label>
                                    <asp:TextBox ID="tbReferer" MaxLength="150" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:Label ID="lblTimeline" runat="server" Text="Please include a possible timeline of when you would need the items:" CssClass="mt-2"></asp:Label>
                                    <asp:TextBox ID="tbTimeline" MaxLength="200" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:Label ID="lblRecievedEquipment" Visible="false" runat="server" Text="Has your organization recieved equipment from us before?"></asp:Label>
                                    <asp:DropDownList ID="ddlRecievedEquipment" Visible="true" CssClass="form-control" runat="server">
                                        <asp:ListItem Value="0">No</asp:ListItem>
                                        <asp:ListItem Value="1">Yes</asp:ListItem>
                                    </asp:DropDownList>
                                </asp:Panel>
                                <%--Org Request Form End--%>
                            </div>
                            <div class="col-2"></div>
                            <div runat="server" id="divButtons" class="row mb-3" visible="true">
                            <div class="col-4"></div>
                            <div class="col-4">
                                <asp:Button ID="btnSubmit" CssClass="btn btn-primary" runat="server" Text="Submit Request" OnClick="btnSubmit_Click" /></div>
                            <div class="col-4"></div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <%-- Main Form End--%>
            </div>
            <div class="pb-5" style="margin-top: 2%; height: 2%; width: auto;"></div>
        </div>
    </form>
</body>
<script>
    function pageLoad() {
        $("#MainContent_ddlOrg").select2({
            placeholder: "Select Organization",
            allowClear: true,
            selectOnClose: true
        });
    };
</script>
</html>
