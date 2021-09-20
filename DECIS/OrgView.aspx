<%@ Page Title="" Language="C#" MasterPageFile="~/DECIS.Master" AutoEventWireup="true" CodeBehind="OrgView.aspx.cs" Inherits="DECIS.OrgView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid homepage">
        <div class="container-fluid mt-2">
            <div class="row" style="height: 7%; font-size: large">
                <nav aria-label="breadcrumb" class="mb-n3 ml-2">
                    <ol class="breadcrumb bg-white">
                        <li class="breadcrumb-item" style="color: deepskyblue">
                            <asp:LinkButton ID="lnkHome" href="Homepage.aspx" runat="server">Dashboard</asp:LinkButton></li>
                        <li class="breadcrumb-item" style="color: deepskyblue">
                            <asp:LinkButton ID="lnkList" href="OrgList.aspx" runat="server">Org List</asp:LinkButton></li>
                        <li class="breadcrumb-item active bg-white" aria-current="page">Org View</li>
                    </ol>
                </nav>
            </div>
            <div class="card my-auto mx-auto h-75 w-90 mb-3">
                <div class="card-body">
                    <%-- Content Start --%>
                    <h4>
                        <asp:Label ID="lblCardTitle" CssClass="card-title" runat="server" Text="">
                        </asp:Label>
                    </h4>
                    <div class="row modal-header offwhiteBackground p-0 mb-1" style="padding-left: 0!important; padding-right: 0!important; font-size: large;"></div>
                    <asp:Panel ID="pnlControls" CssClass="row form-group h-100" runat="server">
                        <div class="col-md">
                            <h5>Org Info</h5>
                            <asp:Label ID="lblOrgName" runat="server" Text="Name:"></asp:Label>
                            <asp:TextBox ID="tbOrgName" MaxLength="100" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:Label ID="lblOrgAddress" runat="server" Text="Address:"></asp:Label>
                            <asp:TextBox ID="tbOrgAddress" MaxLength="200" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:Label ID="lblOrgEmail" runat="server" Text="Org Email:"></asp:Label>
                            <asp:TextBox ID="tbOrgEmail" MaxLength="100" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:Label ID="lblOrgPhone" runat="server" Text="Org Phone:"></asp:Label>
                            <asp:TextBox ID="tbOrgPhone" MaxLength="14" Placeholder="###-###-####" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:Label ID="lblOrgZipcode" runat="server" Text="Zipcode:">
                            </asp:Label>
                            <asp:TextBox ID="tbOrgZipcode" MaxLength="20" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:Label ID="lblRecievedEquipment" runat="server" Text="Has Recieved Equipment Before: "></asp:Label>
                            <asp:DropDownList ID="ddlReceivedEquipment" CssClass="form-control" runat="server">                                        
                                <asp:ListItem Value="0">Hasn't Recieved Equipment</asp:ListItem>
                                <asp:ListItem Value="1">Has Recieved Equipment</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-md">
                            <h5>Contact Info</h5>
                            <asp:Label ID="lblPrimaryContact" runat="server" Text="Primary Contact:"></asp:Label>
                            <asp:TextBox ID="tbPrimaryContact" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:Label ID="lblPrimaryPhone" runat="server" Text="Primary Phone:"></asp:Label>
                            <asp:TextBox ID="tbPrimaryPhone" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:Label ID="lblPrimaryEmail" runat="server" Text="Primary Email:"></asp:Label>
                            <asp:TextBox ID="tbPrimaryEmail" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:Label ID="lblSecondaryContact" runat="server" Text="Secondary Contact:"></asp:Label>
                            <asp:TextBox ID="tbSecondaryContact" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:Label ID="lblSecondaryPhone" runat="server" Text="Secondary Phone:"></asp:Label>
                            <asp:TextBox ID="tbSecondaryPhone" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:Label ID="lblSecondaryEmail" runat="server" Text="Secondary Email:"></asp:Label>
                            <asp:TextBox ID="tbSecondaryEmail" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="row mt-3">
                            <div class="col-md-3"></div>
                            <div class="col-md-6">
                            <asp:Label ID="lblOrgPurpose" runat="server" Text="Purpose:"></asp:Label>
                            <asp:TextBox ID="tbOrgPurpose" TextMode="MultiLine" MaxLength="500" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:Label ID="lblReferer" runat="server" CssClass="mt-2" Text="Refered By:"></asp:Label>
                            <asp:TextBox ID="tbOrgReferer" TextMode="MultiLine" MaxLength="150" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-3"></div>
                        </div>
                    </asp:Panel>
                    <%-- Content End --%>
                    <%--Buttons Start--%>
                    <div class="row mt-3">
                        <div class="col-md-3">
                            <asp:Button ID="btnEdit" CssClass="btn-primary btn w-25" runat="server" Text="Edit" OnClick="btnEdit_Click" />
                            <asp:Button ID="btnCancelEdit" Visible="false" CssClass="btn-warning btn w-25" runat="server" Text="Cancel" OnClick="btnEditCancel_Click" />
                        </div>
                        <div class="col-md-3">
                            <asp:Button ID="btnDownload" CssClass="btn-primary btn" runat="server" Text="View Documents" OnClick="btnDownload_Click" OnClientClick="target ='_blank';"/>
                        </div>
                        <div class="col-md-3">
                            <a href="#" class="btn btn-primary">Go somewhere</a>
                        </div>
                        <div class="col-md-3">
                            <a href="#" class="btn btn-primary">Go somewhere</a>
                        </div>
                    </div>
                    <%-- Buttons End --%>
                </div>
            </div>
            <%-- End Asset Card --%>
        </div>
        <%-- Requests Card Start --%>
        <div class="container-fluid mt-5">
            <div class="row">
                <div class="col m-3">
                    <div class="card w-100">
                        <div class="card-header offwhiteBackground">
                            <div class="row pl-1">
                                <ul class="nav nav-tabs card-header-tabs" id="tab-card" role="tablist">
                                    <li class="nav-item cherryFont">
                                        <a class="nav-link active" href="#Requests" role="tab" aria-controls="Requests" aria-selected="true">Requests</a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" href="#CompletedRequests" role="tab" aria-controls="CompletedRequests" aria-selected="false">Completed Requests</a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" href="#People" role="tab" aria-controls="People" aria-selected="false">People</a>
                                    </li>
                                </ul>
                            </div>
                        </div>
                        <div class="card-body text-dark">
                            <h4 id="headerTabCard" class="card-title">Requests from Org</h4>
                            <div class="tab-content mt-3">
                                <div class="tab-pane active" id="Requests" role="tabpanel">
                                    <asp:Label ID="lblOutstandingMsg" runat="server" Text=""></asp:Label>
                                    <asp:GridView ID="gvRequests" CssClass="table table-striped table-bordered thead-dark gvBtn" runat="server" AutoGenerateColumns="False">
                                        <HeaderStyle CssClass="cherryBackground" />
                                        <Columns>
                                            <asp:BoundField DataField="RequestID" HeaderText="Request ID" />
                                            <asp:BoundField DataField="ContactName" HeaderText="Contact" />
                                            <asp:BoundField DataField="ContactPhone" HeaderText="Phone" />
                                            <asp:BoundField DataField="ContactEmail" HeaderText="Email" />
                                            <asp:BoundField DataField="Timeline" DataFormatString="{0:d}" HeaderText="Timeline" />
                                            <asp:BoundField DataField="DateSubmitted" HeaderText="Submitted" />
                                            <asp:BoundField DataField="RequestStatus" HeaderText="Status" />
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <div class="tab-pane" id="CompletedRequests" role="tabpanel">
                                    <asp:Label ID="lblCompletedMsg" runat="server" Text=""></asp:Label>
                                    <asp:GridView ID="gvCompletedRequests" CssClass="table table-striped table-bordered thead-dark gvBtn" runat="server" AutoGenerateColumns="False">
                                        <HeaderStyle CssClass="cherryBackground" />
                                        <Columns>
                                            <asp:BoundField DataField="RequestID" HeaderText="Request ID" />
                                            <asp:BoundField DataField="DateSubmitted" HeaderText="Submitted" />
                                            <asp:BoundField DataField="DateFinished" HeaderText="Finished" />
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <div class="tab-pane" id="People" role="tabpanel">
                                    <asp:Label ID="lblPeopleMsg" runat="server" Text=""></asp:Label>
                                    <asp:GridView ID="gvPeople" CssClass="table table-striped table-bordered thead-dark gvBtn" runat="server" AutoGenerateColumns="True">
                                        <HeaderStyle CssClass="cherryBackground" />
                                        <Columns>
                                            <asp:BoundField DataField="RequestID" HeaderText="Request ID" />
                                            <asp:BoundField DataField="Name" HeaderText="Contact" />
                                            <asp:BoundField DataField="Phone" HeaderText="Phone" />
                                            <asp:BoundField DataField="Email" HeaderText="Email" />
                                            <asp:BoundField DataField="DateSubmitted" HeaderText="Submitted" />
                                            <asp:BoundField DataField="RequestStatus" HeaderText="Status" />
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%-- Requests Card End --%>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hfActiveTab" runat="server" />
    <%-- Switch tabs on tab card --%>
    <script>
        $('#tab-card a').on('click', function (e) {
            e.preventDefault();
            console.log($(this).text());
            $(this).tab('show');
            if ($(this).text() == 'Requests') {
                $('#headerTabCard').text('Requests from Org');
                $('#hfActiveTab').text('Requests');
            }
            else if ($(this).text() == 'Completed Requests') {
                $('#headerTabCard').text('Completed Requests');
                $('#hfActiveTab').text('CompletedRequest');
            }
            else if ($(this).text() == 'People') {
                $('#headerTabCard').text('Associated Individuals');
                $('#hfActiveTab').text('People');
            }
        });
    </script>
    <script type="text/javascript">
        function pageLoad() {
            $('#MainContent_gvAssetList').prepend($("<thead></thead>").append($("#MainContent_gvAssetList").find("tr:first"))).DataTable({
                stateSave: true,
            });
        };
    </script>
</asp:Content>
