<%@ Page Title="" Language="C#" MasterPageFile="~/DECIS.Master" AutoEventWireup="true" CodeBehind="Homepage.aspx.cs" Inherits="DECIS.Homepage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid mainbg">
        <div class="row modal-header p-0" style="height: 50px;">
        </div>
        <div class="jumbotron vertical-center linen h-75">
            <div class="container-fluid plaster">
                <div class="row homepageCol">
                    <div id="divCreateCHW" class="col m-3 homepageCol" runat="server">
                        <!-- Button 1 Start -->
                        <div class="card text-center homepageCard">
                            <div class="card-body shadow">
                                <label class="card-title font-weight-bold h5">Create CHW Account</label>
                                <p class="text-dark">Create a new Community Health Worker Account</p>
                                <a class="stretched-link" href="CreateCHW.aspx"></a>
                            </div>
                        </div>
                        <%-- Button 1 End --%>
                    </div>
                    <div id="divViewAll" class="col m-3 homepageCol" runat="server">
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
                    <div id="divCreateEvent" class="col m-3 homepageCol" runat="server">
                        <%-- Button 3 Start --%>
                        <div class="card text-center homepageCard">
                            <div class="card-body shadow">
                                <label class="card-title font-weight-bold h5">Create Event</label>
                                <p class="text-dark">Create a new community health event</p>
                                <a class="stretched-link" href="EventCreator.aspx"></a>
                            </div>
                        </div>
                        <%-- Button 3 End --%>
                    </div>
                </div>
                <div class="row">
                    <div id="divInteractionList" class="col m-3 homepageCol" runat="server">
                        <%-- Button 4 Start --%>
                        <div class="card text-center homepageCard">
                            <div class="card-body shadow">
                                <label class="card-title font-weight-bold h5">Review Interactions</label>
                                <p class="text-dark">View a list of all interactions available to you</p>
                                <a class="stretched-link" href="InteractionList.aspx"></a>
                            </div>
                        </div>
                        <%-- Button 4 End --%>
                    </div>
                    <div id="divResidentList" class="col m-3 homepageCol" runat="server">
                        <%-- Button 5 Start --%>
                        <div class="card text-center homepageCard">
                            <div class="card-body shadow">
                                <label class="card-title font-weight-bold h5">Resident Look Up</label>
                                <p class="text-dark">Search for a specific resident's profile</p>
                                <a class="stretched-link" href="ResidentLookUp.aspx"></a>
                            </div>
                        </div>
                        <%-- Button 5 End --%>
                    </div>
                    <div id="divEventList" class="col m-3 homepageCol" runat="server">
                        <%-- Button 6 Start --%>
                        <div class="card text-center homepageCard">
                            <div class="card-body shadow">
                                <label class="card-title font-weight-bold h5">View Events</label>
                                <p class="text-dark">View a list of all community health events </p>
                                <a class="stretched-link" href="EventList.aspx"></a>
                            </div>
                        </div>
                        <%-- Button 6 End --%>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
