<%@ Page Title="" Language="C#" MasterPageFile="~/DECIS.Master" AutoEventWireup="true" CodeBehind="RequestView.aspx.cs" Inherits="DECIS.RequestView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class="container-fluid homepage">
        <div class="container-fluid mt-2">
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
                            <h5>Shared Request Info</h5>
                            <asp:Label ID="lblOrgName" runat="server" Text="Organization:"></asp:Label>
                            <asp:Label ID="lblOrgNameText" runat="server" CssClass="form-control bg-muted"></asp:Label>
                            <asp:Label ID="lblRequesterName" runat="server" Text="Requester:"></asp:Label>
                            <asp:TextBox ID="tbRequesterName" MaxLength="100" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:Label ID="lblRequesterPhone" runat="server" Text="Phone:"></asp:Label>
                            <asp:TextBox ID="tbRequesterPhone" MaxLength="100" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:Label ID="lblRequesterEmail" runat="server" Text="Email:"></asp:Label>
                            <asp:TextBox ID="tbRequesterEmail" MaxLength="100" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:Label ID="lblDateSubmitted" runat="server" Text="Submitted:"></asp:Label>
                            <asp:TextBox ID="tbDateSubmitted" MaxLength="20" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:Label ID="lblRequestStatus" runat="server" Text="Request Status:"></asp:Label>
                            <asp:DropDownList ID="ddlRequestStatus" CssClass="form-control" runat="server">                                        
                            </asp:DropDownList>
                        </div>
                        <div class="col-md">
                            <h5><asp:Label runat="server" ID="lblRequestTypeInfo" Text=""></asp:Label></h5>
                            <asp:Label ID="lblOne" runat="server" Text=""></asp:Label>
                            <asp:TextBox ID="tbOne" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:Label ID="lblTwo" runat="server" Text=""></asp:Label>
                            <asp:TextBox ID="tbTwo" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:Label ID="lblThree" runat="server" Text=""></asp:Label>
                            <asp:TextBox ID="tbThree" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:Label ID="lblFour" runat="server" Text=""></asp:Label>
                            <asp:TextBox ID="tbFour" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:Label ID="lblFive" runat="server" Text=""></asp:Label>
                            <asp:TextBox ID="tbFive" MaxLength="100" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:Label ID="lblSix" runat="server" Text=""></asp:Label>
                            <asp:TextBox ID="tbSix" MaxLength="400" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="row mt-3">
                            <div class="col-md-3"></div>
                            <div class="col-md-6">
                            <asp:Label ID="lblRequestNotes" runat="server" Text="Notes:"></asp:Label>
                            <asp:TextBox ID="tbRequestNotes" TextMode="MultiLine" MaxLength="400" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:Label ID="lblRequestPurpose" runat="server" CssClass="mt-2" Text="Purpose"></asp:Label>
                            <asp:TextBox ID="tbRequestPurpose" TextMode="MultiLine" MaxLength="400" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:Label ID="lblDate" runat="server" CssClass="mt-2" Text="Date Scheduled:"></asp:Label>
                            <asp:TextBox ID="tbDate" TextMode="Date" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-3"></div>
                            </div>
                        <div class="row mt-3">
                        <div class="col-md-3">
                            <asp:Label ID="lblKeyboard" runat="server" Text="Keyboard:"></asp:Label>
                            <asp:TextBox ID="tbKeyboard" TextMode="Number" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <asp:Label ID="lblMice" runat="server" Text="Mice:"></asp:Label>
                            <asp:TextBox ID="tbMice" TextMode="Number" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <asp:Label ID="lblWebcam" runat="server" Text="Webcam:"></asp:Label>
                            <asp:TextBox ID="tbWebcam" TextMode="Number" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <asp:Label ID="lblWifi" runat="server" Text="Wifi Device:"></asp:Label>
                            <asp:TextBox ID="tbWifi" TextMode="Number" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
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
                            <asp:Button ID="btnViewOrg" runat="server" CssClass="btn-primary btn" Text="View Org" OnClick="btnViewOrg_Click" OnClientClick="target ='_blank';" />
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
                                        <a class="nav-link active" href="#Computers" role="tab" aria-controls="Computers" aria-selected="true">Computers</a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" href="#Monitors" role="tab" aria-controls="Monitors" aria-selected="false">Monitors</a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" href="#Other" role="tab" aria-controls="Other" aria-selected="false">Other</a>
                                    </li>
                                </ul>
                            </div>
                        </div>
                        <div class="card-body text-dark">
                            <h4 id="headerTabCard" class="card-title">Requests from Org</h4>
                            <div class="tab-content mt-3">
                                <div class="tab-pane active" id="Computers" role="tabpanel">
                                    <asp:Label ID="lblComputerMsg" runat="server" Text=""></asp:Label>
                                    <asp:GridView ID="gvComputers" CssClass="table table-striped table-bordered thead-dark gvBtn" runat="server" AutoGenerateColumns="False">
                                        <HeaderStyle CssClass="cherryBackground" />
                                        <Columns>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <div class="tab-pane" id="Monitors" role="tabpanel">
                                    <asp:Label ID="lblMonitorsMsg" runat="server" Text=""></asp:Label>
                                    <asp:GridView ID="gvMonitors" CssClass="table table-striped table-bordered thead-dark gvBtn" runat="server" AutoGenerateColumns="False">
                                        <HeaderStyle CssClass="cherryBackground" />
                                        <Columns>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <div class="tab-pane" id="Other" role="tabpanel">
                                    <asp:Label ID="lblOtherMsg" runat="server" Text=""></asp:Label>
                                    <asp:GridView ID="gvOther" CssClass="table table-striped table-bordered thead-dark gvBtn" runat="server" AutoGenerateColumns="True">
                                        <HeaderStyle CssClass="cherryBackground" />
                                        <Columns>
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
            if ($(this).text() == 'Computers') {
                $('#headerTabCard').text('Computers');
                $('#hfActiveTab').text('Computers');
            }
            else if ($(this).text() == 'Monitors') {
                $('#headerTabCard').text('Monitors');
                $('#hfActiveTab').text('Monitors');
            }
            else if ($(this).text() == 'Other') {
                $('#headerTabCard').text('Misc Assets');
                $('#hfActiveTab').text('Other');
            }
        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#MainContent_gvAssetList').DataTable();
        });
    </script>
</asp:Content>
