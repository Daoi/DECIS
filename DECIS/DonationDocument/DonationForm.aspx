<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DonationForm.aspx.cs" Inherits="DECIS.DonationDocument.DonationForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../Style/style.css" media="all" rel="stylesheet" />
    <script src="../Scripts/jquery-3.6.0.min.js"></script>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.1/dist/css/bootstrap.min.css" integrity="sha384-F3w7mX95PdgyTmZZMECAngseQB83DfGTowi0iMjiWaeVhAn4FJkqJByhZMI3AhiU" crossorigin="anonymous" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.1/dist/js/bootstrap.min.js" integrity="sha384-skAcpIdS7UcVUC05LJ9Dxay8AXcDYfBJqt1CJ85S/CFujBsIzCIv+l9liuYLaMQ/" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.1/dist/js/bootstrap.bundle.min.js" integrity="sha384-/bQdsTh/da6pkI1MST/rWKFNjaCP5gBSY4sEBT38Q/9RBh9AH40zEOg7Hlq2THRZ" crossorigin="anonymous"></script>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js" integrity="sha256-/xUj+3OJU5yExlq6GSYGSHk7tPXikynS7ogEvDej/m4=" crossorigin="anonymous"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="row text-center">
            <div class="container-fluid cherryBackground">
                <p style="font-size: 2rem;" class="display-4 pb-2">Digital Equity Center Donation Release Form</p>
            </div>
        </div>
        <div class="container-fluid ">
            <%-- Heading Info --%>
            <%-- Row 1 --%>
            <div class="row text-center">
                <div class="col-sm-3">
                    <asp:Label ID="lblSubmissionDate" CssClass="documentHeader" runat="server" Text="Submitted "></asp:Label>
                    <br />
                    <asp:Label ID="lblSubmissionDateText" runat="server" Text="12/12/2020"></asp:Label>
                </div>
                <div class="col-sm-3 p-sm-1">
                    <asp:Label ID="lblRequestID" CssClass="documentHeader" runat="server" Text="Request ID "></asp:Label>
                    <br />
                    <asp:Label ID="lblRequestIDText" runat="server" Text="23"></asp:Label>
                </div>
                <div class="col-sm-3 p-sm-0">
                    <asp:Label ID="lblOrganization" CssClass="documentHeader" runat="server" Text="Organization "></asp:Label>
                    <br />
                    <asp:Label ID="lblOrganizationText" CssClass="text-wrap" runat="server" Text="Personal"></asp:Label>
                </div>
                <div class="col-sm-3 p-sm-1">
                    <asp:Label ID="lblEmail" CssClass="documentHeader" runat="server" Text="Email "></asp:Label>
                    <br />
                    <asp:Label ID="lblEmailText" runat="server" Text="123@123.com"></asp:Label>
                </div>
            </div>
            <%-- Row 2 --%>
            <div class="row mt-5 text-center">
                <div class="col-sm-3">
                    <asp:Label ID="lblContactPerson" CssClass="documentHeader" runat="server" Text="Contact "></asp:Label>
                    <br />
                    <asp:Label ID="lblContactPersonText" runat="server" ></asp:Label>
                </div>
                <div class="col-sm-3">
                    <asp:Label ID="lblAddress" CssClass="documentHeader" runat="server" Text="Address "></asp:Label>
                    <br />
                    <asp:Label ID="lblAddressText" runat="server" ></asp:Label>
                </div>
                <div class="col-sm-3">
                    <asp:Label ID="lblZipCode" CssClass="documentHeader" runat="server" Text="Zip Code "></asp:Label>
                    <br />
                    <asp:Label ID="lblZipCodeText" runat="server"></asp:Label>
                </div>
                <div class="col-sm-3">
                    <asp:Label ID="lblPhoneNumber" CssClass="documentHeader" runat="server" Text="Phone"></asp:Label>
                    <br />
                    <asp:Label ID="lblPhoneNumberText" runat="server"></asp:Label>
                </div>
            </div>
            <%-- Heading Info End --%>
            <%-- Insurance Waiver --%>
            <div class="row mt-5">
                <h5 class="fw-bolder">Insurance Waiver and Assumption of Risk</h5>
                <p class="text-break waiverText">
                    In consideration for <asp:Label ID="lblWaiverName" CssClass="text-info" runat="server" Text=""></asp:Label> being permitted to take part in the Temple Tech for Philly
                    surplus equipment program and understanding that there are some health and bodily risks in connection with said program, I hereby indemnify, defend, and save
                    harmless Temple University of the Commonwealth System of Higher Education and its officers and employees and agents from any and all claims whatsoever arising
                    out of in any way related to the undersigned participating in the above referenced activity.
                </p>
            </div>
            <%-- Insurance End --%>
            <%-- Equipment Start --%>
            <div class="row mt-3">
                <h4>Equipment Information</h4>
                <asp:GridView ID="gvEquipment" CssClass="table" runat="server" AutoGenerateColumns="false">
                    <HeaderStyle CssClass="documentHeader" />
                    <Columns>
                        <asp:BoundField DataField="AssetType" HeaderText="Equipment Type" />
                        <asp:BoundField DataField="SerialNumber" HeaderText="Serial Number" />
                        <asp:BoundField DataField="Make" HeaderText="Make" />
                        <asp:BoundField DataField="Model" HeaderText="Model" />
                    </Columns>
                </asp:GridView>
            </div>
            <%-- Equipment End --%>
            <%-- Signature Start --%>
            <div class="row mt-3">
                <div class="row">
                    <p class="text-break waiverText">
                        Acquisition of equipment is "as is", with no warranty of any kind, expressed or implied. <asp:Label ID="lblAcquName" CssClass="text-info" runat="server" Text=""></asp:Label> agrees to
                        dispose of all equipment in such a manner as to abide by any applicable laws, as well as abide by any current environmental standards.
                    </p>
                </div>
                <div class="row mt-3">
                    <div class="col-sm-6 fw-bold">Temple University, as Administrator</div>
                    <div class="col-sm-6">Signature: __________________________________________________</div>
                </div>
                <div class="row mt-3">
                    <div class="col-sm-6 fw-bold">Personal</div>
                    <div class="col-sm-6">Signature: __________________________________________________</div>
                </div>
            </div>
            <%-- Signature End --%>
        </div>
    </form>
</body>
</html>
