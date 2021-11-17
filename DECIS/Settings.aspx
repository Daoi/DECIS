<%@ Page Title="" Language="C#" MasterPageFile="~/DECIS.Master" AutoEventWireup="true" CodeBehind="Settings.aspx.cs" Inherits="DECIS.Settings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid homepage">
        <div class="container-fluid p-0">
            <%--Add Models Start--%>
            <div class="container my-5">
                <h3>Add Model</h3>
                <div class="row">
                    <div class="col-8 mb-4">
                        <asp:UpdatePanel ID="upModel" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:GridView ID="gvModels" runat="server" AutoGenerateColumns="False" CssClass="table table-light table-striped table-bordered thead-dark">
                                    <HeaderStyle CssClass="freshwater" />
                                    <Columns>
                                        <asp:BoundField DataField="ModelID" HeaderText="ID" />
                                        <asp:BoundField DataField="Model" HeaderText="Name" />
                                        <asp:BoundField DataField="AssetTypeT" HeaderText="Type" />
                                        <asp:BoundField DataField="MakeT" HeaderText="Make" />
                                    </Columns>
                                </asp:GridView>
                                </div>
                    <div class="col pt-2">
                        <div class="card mt-4">
                            <div class="card-body mb-2">
                                <p class="card-text">
                                    Adding New Models: Enter just the model name(no id), select the Make and Asset Type and then click Add New Model<br /><br />
                                    Editing Models: Enter the name of the model followed by the ID of the model. Example: Optiplex 990,5 <br />
                                    You must also select the values for Make and Asset Type you want the model to have. <br />
                                    If Image is left blank when editing it will continue to use the same Image. Uploading a new image will delete the old image.
                                </p>
                                <asp:Label ID="lblModelMsg" runat="server" Text=""></asp:Label>
                                <br />
                                <asp:TextBox ID="tbModelName" runat="server" placeholder="Model Name,ID" CssClass="form-control"></asp:TextBox>
                                <asp:DropDownList ID="ddlAssetMake" CssClass="form-control mt-1" runat="server"></asp:DropDownList>
                                <asp:DropDownList ID="ddlAssetType" CssClass="form-control mt-1" runat="server"></asp:DropDownList>
                                <asp:FileUpload ID="fuModelImage" CssClass="form-control mt-1" runat="server" />
                                <asp:Button ID="btnAddModel" runat="server" Text="Add New Model" CssClass="btn-sm btn-primary mt-3" OnClick="btnAdd_Click" />
                                <asp:Button ID="btnEditModel" runat="server" Text="Edit Model" CssClass="btn-sm btn-secondary mt-3" OnClick="btnAdd_Click" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
            <%--Add Models End--%>
            <%--Add Make Start--%>
            <div class="container my-5">
                <h3>Add Make</h3>
                <div class="row">
                    <div class="col-8 mb-4">
                        <asp:UpdatePanel ID="upMake" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:GridView ID="gvMake" runat="server" AutoGenerateColumns="False" CssClass="table table-light table-striped table-bordered thead-dark">
                                    <HeaderStyle CssClass="freshwater" />
                                    <Columns>
                                    </Columns>
                                </asp:GridView>
                                </div>
                    <div class="col pt-2">
                        <div class="card mt-4">
                            <div class="card-body mb-2">
                                <p class="card-text">Enter the text for the new option you'd like to add and then click the Add New Option button.</p>
                                <asp:Label ID="lblMakeMsg" runat="server" Text=""></asp:Label>
                                <br />
                                <asp:TextBox ID="tbMake" runat="server" placeholder="Make Name" CssClass="form-control"></asp:TextBox>
                                <asp:Button ID="btnAddMake" runat="server" Text="Add New Option" CssClass="btn btn-primary mt-3" OnClick="btnAdd_Click" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
            <%-- Make End --%>
            <%--Locations--%>
            <div class="container my-5">
                <h3>Add Location</h3>
                <div class="row">
                    <div class="col-8 mb-4">
                        <asp:UpdatePanel ID="upLocation" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:GridView ID="gvLocations" runat="server" AutoGenerateColumns="False" CssClass="table table-light table-striped table-bordered thead-dark">
                                    <HeaderStyle CssClass="freshwater" />
                                    <Columns>
                                    </Columns>
                                </asp:GridView>
                                </div>
                    <div class="col pt-2">
                        <div class="card mt-4">
                            <div class="card-body mb-2">
                                <p class="card-text">Enter a Location Name, Description and select a Status then click Add New Option to create a new location.</p>
                                <asp:Label ID="lblLocMsg" runat="server" Text=""></asp:Label>
                                <br />
                                <asp:TextBox ID="tbLocationName" runat="server" placeholder="Location Name (100 ch)" CssClass="form-control mt-1"></asp:TextBox>
                                <asp:TextBox ID="tbLocationDesc" runat="server" placeholder="Location Description(250 ch)" CssClass="form-control mt-1" TextMode="MultiLine"></asp:TextBox>
                                <asp:DropDownList ID="ddlAssetStatus" CssClass="form-control mt-1" runat="server"></asp:DropDownList>
                                <asp:Button ID="btnAddLocation" runat="server" Text="Add New Option" CssClass="btn btn-primary mt-3" OnClick="btnAdd_Click" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
            <%-- Locations--%>
        </div>
        <%-- Start --%>
        <div>
            <h3>Export Database to Excel</h3>
            <div class="row mb-5 pb-5">
                <div class="col-md-6">
                    <asp:Label ID="lbExport" runat="server" Text="Export Table"></asp:Label>
                    <br />
                    <asp:Label ID="lblStartDate" runat="server" Text="Start Date"></asp:Label>
                    <asp:TextBox ID="tbStartDate" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:Label ID="lblEndDate" runat="server" Text="End Date"></asp:Label>
                    <asp:TextBox ID="tbEndDate" CssClass="form-control" runat="server"></asp:TextBox>
                    <br />
                    <asp:Button ID="btnReport" runat="server" Text="View Report Tables" CssClass="btn btn-primary mt-3" />
                </div>
                <asp:GridView ID="gvPersonalReport" runat="server">

                </asp:GridView>
                <br />
                <asp:GridView ID="gvOrganizationReport" runat="server">

                </asp:GridView>
            </div>
            <%-- End --%>
        </div>
    </div>
        <script type="text/javascript">
        function pageLoad() {
            var tables = ['#MainContent_gvModels'];
            InitDT(tables);
        };
    </script>
</asp:Content>
