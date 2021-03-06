<%@ Page Title="" Language="C#" MasterPageFile="~/DECIS.Master" AutoEventWireup="true" CodeBehind="RecycleView.aspx.cs" Inherits="DECIS.RecycleView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid homepage">
        <div class="container-fluid mt-2">
            <div class="row" style="height: 7%; font-size: large">
                <nav aria-label="breadcrumb" class="mb-n3 ml-2">
                    <ol class="breadcrumb bg-white">
                        <li class="breadcrumb-item" style="color: deepskyblue">
                            <asp:LinkButton ID="lnkHome" href="Homepage.aspx" runat="server">Dashboard</asp:LinkButton></li>
                        <li class="breadcrumb-item" style="color: deepskyblue">
                            <asp:LinkButton ID="lnkList" href="RecycleList.aspx" runat="server">Recycle List</asp:LinkButton></li>
                        <li class="breadcrumb-item active bg-white" aria-current="page">Recycle View</li>
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
                        <div class="col-md-2">
                        </div>
                        <div class="col-md-8" >
                            <h5>Recycle Info</h5>
                            <asp:Label ID="lblOrg" runat="server" Text="Recycle Organization:"></asp:Label>
                            <asp:DropDownList ID="ddlRecycleOrg"  CssClass="form-control" runat="server"></asp:DropDownList>
                            <asp:Label ID="lblRecycleDate" runat="server" Text="Recycle Date:"></asp:Label>
                            <asp:TextBox ID="tbRecycleDate" TextMode="Date" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:Label ID="lblRecycleStatus" runat="server" Text="Recycle Status:"></asp:Label>
                            <asp:DropDownList ID="ddlRecycleStatus" CssClass="form-control" runat="server">
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-2">
                        </div>
                    </asp:Panel>
                    <%-- Content End --%>
                    <%--Buttons Start--%>
                    <asp:Panel CssClass="row mt-3" ID="pnlButtons" runat="server">
                        <div class="col-md-3">
                            <asp:Button ID="btnEdit" CssClass="btn-primary btn w-25" runat="server" Text="Edit" OnClick="btnEdit_Click" />
                            <asp:Button ID="btnCancelEdit" Visible="false" CssClass="btn-warning btn w-25" runat="server" Text="Cancel" OnClick="btnEditCancel_Click" />
                        </div>
                        <div class="col-md-3">
                        </div>
                        <div class="col-md-3">
                            <asp:Button ID="btnAddAll" CssClass="btn btn-primary" runat="server" Text="Add All Selected Assets" OnClick="btnAddAll_Click" />
                        </div>
                        <div class="col-md-3">
                            <asp:Button ID="btnRemoveAll" CssClass="btn btn-warning" runat="server" Text="Remove Selected Assigned Assets" OnClick="btnRemoveAll_Click" />
                        </div>
                    </asp:Panel>
                    <%-- Buttons End --%>
                </div>
            </div>
            <%-- End Asset Card --%>
        </div>
        <%-- Requests Card Start --%>
        <div class="container-fluid mt-5">
            <asp:Panel ID="pnlGVs" runat="server">
                <div class="row">
                    <h5>Unassigned Bad Assets</h5>
                    <asp:Label ID="lblComputerMsg" runat="server" Text=""></asp:Label>
                    <asp:GridView ID="gvComputers" CssClass="table table-striped table-bordered thead-dark gvBtn" runat="server" AutoGenerateColumns="False">
                        <HeaderStyle CssClass="text-info" />
                        <Columns>
                            <asp:TemplateField HeaderText="Select">
                                <ItemTemplate>
                                    <asp:UpdatePanel ID="upCB" runat="server">
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="cbSelected" EventName="CheckedChanged" />
                                        </Triggers>
                                        <ContentTemplate>
                                            <asp:CheckBox ID="cbSelected" AutoPostBack="true" OnCheckedChanged="cbSelectedAdd_CheckedChanged" ViewStateMode="Enabled" runat="server" />
                                            <asp:HiddenField ID="hfAssetID" runat="server" Value='<%# Eval("AssetID").ToString() %>' />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="SerialNumber" HeaderText="Serial #" />
                            <asp:BoundField HeaderText="Status" />
                            <asp:BoundField DataField="Make" HeaderText="Make" />
                            <asp:BoundField DataField="Model" HeaderText="Model" />
                            <asp:BoundField DataField="AssetType" HeaderText="Type" />
                            <asp:BoundField DataField="Location" HeaderText="Location" />
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="row">
                    <h5>Assigned Assets</h5>
                    <asp:Label ID="lblAssignedMsg" runat="server" Text=""></asp:Label>
                    <asp:GridView ID="gvAssigned" CssClass="table table-striped table-bordered thead-dark gvBtn" runat="server" AutoGenerateColumns="false">
                        <HeaderStyle CssClass="text-info" />
                        <Columns>
                            <asp:TemplateField HeaderText="Select">
                                <ItemTemplate>
                                    <asp:UpdatePanel ID="upCB" runat="server">
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="cbSelectedR" EventName="CheckedChanged" />
                                        </Triggers>
                                        <ContentTemplate>
                                            <asp:CheckBox ID="cbSelectedR" AutoPostBack="true" OnCheckedChanged="cbSelectedRemove_CheckedChanged" ViewStateMode="Enabled" runat="server" />
                                            <asp:HiddenField ID="hfAssetIDR" runat="server" Value='<%# Eval("AssetID").ToString() %>' />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="SerialNumber" HeaderText="Serial #" />
                            <asp:BoundField HeaderText="Status" />
                            <asp:BoundField DataField="Make" HeaderText="Make" />
                            <asp:BoundField DataField="Model" HeaderText="Model" />
                            <asp:BoundField DataField="AssetType" HeaderText="Type" />
                            <asp:BoundField DataField="Location" HeaderText="Location" />
                        </Columns>
                    </asp:GridView>
                </div>
                <%-- Requests Card End --%>
            </asp:Panel>
        </div>
    </div>
    <script type="text/javascript">
        function pageLoad() {
            if (!$.fn.dataTable.isDataTable('#MainContent_gvComputers')) {
                var tables = ['#MainContent_gvComputers'];
                InitDT(tables);
            }
            if (!$.fn.dataTable.isDataTable('#MainContent_gvAssigned')) {
                var tables = ['#MainContent_gvAssigned'];
                InitDT(tables);
            }
        };
    </script>
</asp:Content>
