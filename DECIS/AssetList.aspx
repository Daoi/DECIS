<%@ Page Title="" Language="C#" MasterPageFile="~/DECIS.Master" AutoEventWireup="true" CodeBehind="AssetList.aspx.cs" Inherits="DECIS.AssetList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid homepage">
        <div class="row modal-header offwhiteBackground p-0" style="height: 50px; padding-left: 0!important; padding-right: 0!important; font-size: large;">
        </div>
        <div class="table-responsive tableContainer">
            <div class="container-fluid mt-2">
                <div runat="server" id="divNoRows" visible="false" class="row w-auto justify-content-center" style="height: 10vh;">
                    <asp:label id="lblNoRows" runat="server" text=""></asp:label>
                </div>
                <asp:updatepanel id="upLocationDDL" runat="server" updatemode="Conditional">
                    <ContentTemplate>
                        <div class="row">
                            <div class="col-md-1">
                                <asp:Panel ID="pnlFilters" Style="white-space: pre-line" runat="server">
                                    <asp:LinkButton runat="server" ID="lbAllAssets" CssClass="form-control-sm" Text="View All" OnClick="lbAllAssets_Click"></asp:LinkButton>
                                    <asp:LinkButton runat="server" ID="lbGoodStatus" CssClass="form-control-sm" Text="Good" OnClick="lb_Click"></asp:LinkButton>
                                    <asp:LinkButton runat="server" ID="lbTestingStatus" CssClass="form-control-sm" Text="Testing" OnClick="lb_Click"></asp:LinkButton>
                                    <asp:LinkButton runat="server" ID="lbNewItems" CssClass="form-control-sm" Text="New Item" OnClick="lb_Click"></asp:LinkButton>
                                    <asp:LinkButton runat="server" ID="lbBad" CssClass="form-control-sm" Text="Bad" OnClick="lb_Click"></asp:LinkButton>
                                    <asp:LinkButton runat="server" ID="lbDonated" CssClass="form-control-sm" Text="Donated" OnClick="lb_Click"></asp:LinkButton>
                                    <asp:LinkButton runat="server" ID="lbRecycled" CssClass="form-control-sm" Text="Recycled" OnClick="lb_Click"></asp:LinkButton>
                                    <asp:LinkButton runat="server" ID="lbStorage" CssClass="form-control-sm" Text="Storage" OnClick="lb_Click"></asp:LinkButton>
                                    <asp:LinkButton runat="server" ID="lbInUse" CssClass="form-control-sm" Text="In Use" OnClick="lb_Click"></asp:LinkButton>
                                </asp:Panel>
                            </div>
                            <div class="col-md-11">
                                <asp:Label ID="lblGVMessage" runat="server" Visible="False"></asp:Label>
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
                    </ContentTemplate>
                </asp:updatepanel>
            </div>
        </div>
    </div>
    <div style="margin-top: 2%; height: 2%; width: auto;"></div>
    <script type="text/javascript">
        function pageLoad() {
            var tables = ['#MainContent_gvAssetList'];
            InitDT(tables);
        };
    </script>
</asp:Content>