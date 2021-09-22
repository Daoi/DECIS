<%@ Page Title="" Language="C#" MasterPageFile="~/DECIS.Master" AutoEventWireup="true" CodeBehind="IntakeView.aspx.cs" Inherits="DECIS.IntakeView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid homepage">
        <div class="container-fluid mt-2">
            <div class="row" style="height: 7%; font-size: large">
                <nav aria-label="breadcrumb" class="mb-n3 ml-2">
                    <ol class="breadcrumb bg-white">
                        <li class="breadcrumb-item" style="color: deepskyblue">
                            <asp:LinkButton ID="lnkHome" href="Homepage.aspx" runat="server">Dashboard</asp:LinkButton></li>
                        <li class="breadcrumb-item" style="color: deepskyblue">
                            <asp:LinkButton ID="lnkList" href="IntakeList.aspx" runat="server">Intake List</asp:LinkButton></li>
                        <li class="breadcrumb-item active bg-white" aria-current="page">Intake View</li>
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
                            <asp:Label ID="lblOrgAddress" runat="server" Text="Address:"></asp:Label>
                            <asp:Label ID="lblOrgAddressText" CssClass="form-control bg-muted" runat="server"></asp:Label>
                            <asp:Label ID="lblOrgEmail" runat="server" Text="Org Email:"></asp:Label>
                            <asp:Label ID="lblOrgEmailText" CssClass="form-control bg-muted" runat="server"></asp:Label>
                            <asp:Label ID="lblOrgPhone" runat="server" Text="Org Phone:">
                            </asp:Label>
                            <asp:Label ID="lblOrgPhoneText" runat="server" CssClass="form-control bg-muted" Text=""></asp:Label>
                            <asp:Label ID="lblIntakeNotes" runat="server" Text="Intake Notes:">
                            </asp:Label>
                            <asp:TextBox ID="tbIntakeNotes" MaxLength="500" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md">
                            <h5>Contact Info</h5>
                            <asp:Label ID="lblPrimaryContact" runat="server" Text="Primary Contact:"></asp:Label>
                            <asp:Label ID="lblPrimaryContactText" CssClass="form-control bg-muted" runat="server"></asp:Label>
                            <asp:Label ID="lblPrimaryPhone" runat="server" Text="Primary Phone:"></asp:Label>
                            <asp:Label ID="lblPrimaryPhoneText" CssClass="form-control bg-muted" runat="server"></asp:Label>
                            <asp:Label ID="lblPrimaryEmail" runat="server" Text="Primary Email:"></asp:Label>
                            <asp:Label ID="lblPrimaryEmailText" CssClass="form-control bg-muted" runat="server"></asp:Label>
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
                            <a href="#" class="btn btn-primary">Go somewhere</a>
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
        <div class="row">
            <h5>All Assets in this Intake</h5>
            <asp:GridView ID="gvAssetList" Width="100%" runat="server" CssClass="table table-light table-striped table-bordered thead-dark" AutoGenerateColumns="false">
                <HeaderStyle CssClass="text-info" />
                <Columns>
                    <asp:TemplateField HeaderText="View" ItemStyle-CssClass="align-items-center">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkBtnView" runat="server" OnClick="lnkBtnView_Click">
                                    <i class="fas fa-eye"></i>
                            </asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle CssClass="align-items-center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:BoundField DataField="AssetID" HeaderText="Asset ID" />
                    <asp:BoundField DataField="SerialNumber" HeaderText="Serial #" />
                    <asp:BoundField DataField="AssetType" HeaderText="Asset Type" />
                    <asp:BoundField DataField="Make" HeaderText="Make" />
                    <asp:BoundField DataField="Model" HeaderText="Model" />
                    <asp:BoundField DataField="Status" HeaderText="Status" />
                    <asp:BoundField DataField="Location" HeaderText="Location" />
                    <asp:BoundField DataField="LocationDescription" HeaderText="Loc Description" />
                </Columns>
                <RowStyle HorizontalAlign="Center" />
            </asp:GridView>
        </div>
    </div>
    <script type="text/javascript">
        function pageLoad() {
            var tables = ['#MainContent_gvAssetList'];
            InitDT(tables);
        };
    </script>
</asp:Content>
