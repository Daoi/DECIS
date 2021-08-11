<%@ Page Title="" Language="C#" MasterPageFile="~/DECIS.Master" AutoEventWireup="true" CodeBehind="Homepage.aspx.cs" Inherits="DECIS.Homepage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid mainbg">
        <div class="row p-0" style="height: 50px;">
        </div>
        <div class="jumbotron vertical-center linen h-75">
            <div class="container-fluid plaster">
                <div class="row homepageCol">
                    <div id="divCreateCHW" class="col m-3 homepageCol" runat="server">
                        <!-- Button 1 Start -->
                        <div class="card text-center homepageCard">
                            <div class="card-body shadow">
                                <label class="card-title font-weight-bold h5">Add New Asset</label>
                                <p class="text-dark">Add assets one at a time manually</p>
                                <a class="stretched-link" href="AssetForm.aspx"></a>
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
                                <label class="card-title font-weight-bold h5">Upload Assets</label>
                                <p class="text-dark">Upload a spreadsheet to add multiple assests at once</p>
                                <a class="stretched-link" href="AssetUpload.aspx"></a>
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
                                <label class="card-title font-weight-bold h5">View Orders</label>
                                <p class="text-dark">Place holder text</p>
                                <a class="stretched-link" href="InteractionList.aspx"></a>
                            </div>
                        </div>
                        <%-- Button 4 End --%>
                    </div>
                    <div id="divResidentList" class="col m-3 homepageCol" runat="server">
                        <%-- Button 5 Start --%>
                        <div class="card text-center homepageCard">
                            <div class="card-body shadow">
                                <label class="card-title font-weight-bold h5">Settings</label>
                                <p class="text-dark">Modify the values for Locations, Make and Model. Export Database tables to excel.</p>
                                <a class="stretched-link" href="Settings.aspx"></a>
                            </div>
                        </div>
                        <%-- Button 5 End --%>
                    </div>
                    <div id="divEventList" class="col m-3 homepageCol" runat="server">
                        <%-- Button 6 Start --%>
                        <div class="card text-center homepageCard">
                            <div class="card-body shadow">
                                <label class="card-title font-weight-bold h5">View Intakes</label>
                                <p class="text-dark">Add new locations, images, makes/models, etc </p>
                                <a class="stretched-link" href="IntakeList.aspx"></a>
                            </div>
                        </div>
                        <%-- Button 6 End --%>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
