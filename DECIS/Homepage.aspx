<%@ Page Title="" Language="C#" MasterPageFile="~/DECIS.Master" AutoEventWireup="true" CodeBehind="Homepage.aspx.cs" Inherits="DECIS.Homepage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid mainbg">
        <div class="row p-0" style="height: 50px;">
        </div>
        <div class="jumbotron vertical-center linen h-75">
            <div class="container-fluid plaster">
                <div class="row homepageCol">
                    <div id="divViewOrgs" class="col m-3 homepageCol" runat="server">
                        <!-- Button 1 Start -->
                        <div class="card text-center homepageCard">
                            <div class="card-body shadow">
                                <label class="card-title font-weight-bold h5">View Orgs</label>
                                <p class="text-dark">View a list of all Organizations</p>
                                <a class="stretched-link" href="OrgList.aspx"></a>
                            </div>
                        </div>
                        <%-- Button 1 End --%>
                    </div>
                    <div id="divViewAllAsset" class="col m-3 homepageCol" runat="server">
                        <%-- Button 2 Start --%>
                        <div class="card text-center homepageCard">
                            <div class="card-body shadow">
                                <label class="card-title font-weight-bold h5">View All Items</label>
                                <p class="text-dark">View and search all assets in the database</p>
                                <a class="stretched-link" href="AssetList.aspx"></a>
                            </div>
                        </div>
                        <%-- Button 2 End --%>
                    </div>
                    <div id="divIntakeList" class="col m-3 homepageCol" runat="server">
                        <%-- Button 3 Start --%>
                        <div class="card text-center homepageCard">
                            <div class="card-body shadow">
                                <label class="card-title font-weight-bold h5">View Intakes</label>
                                <p class="text-dark">View a list of all intakes</p>
                                <a class="stretched-link" href="IntakeList.aspx"></a>
                            </div>
                        </div>
                        <%-- Button 3 End --%>
                    </div>
                    <div id="divRequestList" class="col m-3 homepageCol" runat="server">
                        <%-- Button 4 Start --%>
                        <div class="card text-center homepageCard">
                            <div class="card-body shadow">
                                <label class="card-title font-weight-bold h5">View Requests</label>
                                <p class="text-dark">View a list of all requests</p>
                                <a class="stretched-link" href="RequestList.aspx"></a>
                            </div>
                        </div>
                        <%-- Button 4 End --%>
                    </div>
                </div>
                <div class="row">
                    <div id="divRecycleList" class="col m-3 homepageCol" runat="server">
                        <%-- Button 5 Start --%>
                        <div class="card text-center homepageCard">
                            <div class="card-body shadow">
                                <label class="card-title font-weight-bold h5">Recycle List</label>
                                <p class="text-dark">View and Create new Recycle Events</p>
                                <a class="stretched-link" href="RecycleList.aspx"></a>
                            </div>
                        </div>
                        <%-- Button 5 End --%>
                    </div>
                    <div id="divAssetUpload" class="col m-3 homepageCol" runat="server">
                        <%-- Button 6 Start --%>
                        <div class="card text-center homepageCard">
                            <div class="card-body shadow">
                                <label class="card-title font-weight-bold h5">Upload Intakes</label>
                                <p class="text-dark">Upload spreadsheets to enter multiple assets at once.</p>
                                <a class="stretched-link" href="AssetUpload.aspx"></a>
                            </div>
                        </div>
                        <%-- Button 6 End --%>
                    </div>
                    <div id="divSettings" class="col m-3 homepageCol" runat="server">
                        <%-- Button 7 Start --%>
                        <div class="card text-center homepageCard">
                            <div class="card-body shadow">
                                <label class="card-title font-weight-bold h5">Settings</label>
                                <p class="text-dark">Modify the values for Locations, Make and Model. Export Database tables to excel.</p>
                                <a class="stretched-link" href="Settings.aspx"></a>
                            </div>
                        </div>
                        <%-- Button 7 End --%>
                    </div>
                    <div id="div1" class="col m-3 homepageCol" runat="server">
                        <%-- Button 8 Start --%>
                        <div class="card text-center homepageCard">
                            <div class="card-body shadow">
                                <label class="card-title font-weight-bold h5">Person List</label>
                                <p class="text-dark">View a list of all people</p>
                                <a class="stretched-link" href="PersonList.aspx"></a>
                            </div>
                        </div>
                        <%-- Button 8 End --%>
                    </div>
                </div>
            </div>
            <%-- End Button Container --%>
            <div class="container-fluid mt-5">
                <div class="row">
                    <div class="col m-3">
                        <%-- Upcoming Tracker Start --%>
                        <div class="card-body border text-dark offwhiteBackground">
                            <h4 class="card-title">
                                <asp:Label ID="lblUpcoming" runat="server" Text="   "></asp:Label></h4>
                            <div class="card mt-5">
                                <div class="card-body UCEventsCard">
                                    <asp:Label ID="lblEventMsg" runat="server" Text=""></asp:Label>
                                    <asp:GridView ID="gvUpcoming" CssClass="table table-striped table-bordered thead-dark gvBtn" runat="server" AutoGenerateColumns="False">
                                        <HeaderStyle CssClass="cherryBackground" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="View Request"></asp:TemplateField>
                                            <asp:BoundField DataField="DateScheduled" HeaderText="Date Scheduled" />
                                            <asp:BoundField DataField="Name" HeaderText="Name" />
                                            <asp:BoundField DataField="Email" HeaderText="Email" />
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
