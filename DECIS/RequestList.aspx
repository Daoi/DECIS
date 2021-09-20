<%@ Page Title="" Language="C#" MasterPageFile="~/DECIS.Master" AutoEventWireup="true" CodeBehind="RequestList.aspx.cs" Inherits="DECIS.RequestList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid homepage">
        <div class="row modal-header offwhiteBackground p-0" style="height: 50px; padding-left: 0!important; padding-right: 0!important; font-size: large;">
        </div>
        <div class="table-responsive tableContainer">
            <div class="container-fluid mt-2">
                <div runat="server" id="divNoRows" visible="false" class="row w-auto justify-content-center" style="height: 10vh;">
                    <asp:Label ID="lblNoRows" runat="server" Text=""></asp:Label>
                </div>
                <div class="row">
                    <div class="col-md-1">
                        <asp:Panel ID="pnlFilters" Style="white-space: pre-line" runat="server">
                            <asp:LinkButton runat="server" ID="lbAll" CssClass="form-control-sm" Text="All" OnClick="lb_Click"></asp:LinkButton>
                            <asp:LinkButton runat="server" ID="lbNew" CssClass="form-control-sm" Text="New" OnClick="lb_Click"></asp:LinkButton>
                            <asp:LinkButton runat="server" ID="lbPending" CssClass="form-control-sm" Text="Pending" OnClick="lb_Click"></asp:LinkButton>
                            <asp:LinkButton runat="server" ID="lbScheduled" CssClass="form-control-sm" Text="Scheduled" OnClick="lb_Click"></asp:LinkButton>
                            <asp:LinkButton runat="server" ID="lbFinished" CssClass="form-control-sm" Text="Finished" OnClick="lb_Click"></asp:LinkButton>
                            <asp:LinkButton runat="server" ID="lbCancelled" CssClass="form-control-sm" Text="Canceled" OnClick="lb_Click"></asp:LinkButton>
                        </asp:Panel>
                    </div>
                    <div class="col-md-11">
                        <asp:Label ID="lblGVMessage" runat="server" Visible="False"></asp:Label>
                        <asp:GridView ID="gvRequestList" Width="100%" runat="server" CssClass="table table-light table-striped table-bordered thead-dark" AutoGenerateColumns="False">
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
                                <asp:TemplateField HeaderText="Type">
                                    <ItemTemplate>
                                        <asp:Label ID="lblType" runat="server" Text='<%# Eval("Type").ToString() == "0" ? "Organization" : "Personal" %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="RequestID" HeaderText="ID" />
                                <asp:BoundField DataField="OrgName" HeaderText="Org" />
                                <asp:BoundField DataField="Name" HeaderText="Requester" />
                                <asp:BoundField DataField="RequestStatus" HeaderText="Status" />
                                <asp:BoundField DataField="DateSubmitted" DataFormatString="{0:MM-dd-yyyy}" HeaderText="Date Submitted" />
                                <asp:BoundField DataField="DateFinished" DataFormatString="{0:MM-dd-yyyy}" HeaderText="Finished" />
                                <asp:BoundField DataField="DateScheduled" DataFormatString="{0:MM-dd-yyyy}" HeaderText="Scheduled" />
                            </Columns>
                            <RowStyle HorizontalAlign="Center" />
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div style="margin-top: 2%; height: 2%; width: auto;"></div>
    
    <script type="text/javascript">
        function pageLoad() {
            var tables = ['#MainContent_gvRequestList'];
            InitDT(tables);
        };
    </script>
</asp:Content>
