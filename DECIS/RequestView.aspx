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
                            <asp:TextBox ID="tbDateSubmitted" TextMode="Date" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:Label ID="lblDateFinished" runat="server" Text="Finished:"></asp:Label>
                            <asp:TextBox ID="tbDateFinished" TextMode="Date" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:Label ID="lblRequestStatus" runat="server" Text="Request Status:"></asp:Label>
                            <asp:DropDownList ID="ddlRequestStatus" CssClass="form-control" runat="server">
                            </asp:DropDownList>
                        </div>
                        <div class="col-md">
                            <h5><asp:Label runat="server" ID="lblRequestTypeInfo" Text=""></asp:Label></h5>
                            <asp:Panel ID="pnlDDLs" Visible="false" CssClass="" runat="server">
                                <asp:Label ID="lblRace" runat="server" Text="Race: "></asp:Label>
                                <asp:DropDownList ID="ddlRace" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                                <asp:Label ID="lblGender" runat="server" Text="Gender: "></asp:Label>
                                <asp:DropDownList ID="ddlGender" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                                <asp:Label ID="lblEthnicity" runat="server" Text="Ethnicity: "></asp:Label>
                                <asp:DropDownList ID="ddlEthnicity" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                                <asp:Label ID="lblInternet" runat="server" Text="Does user have internet: "></asp:Label>
                                <asp:DropDownList ID="ddlInternet" CssClass="form-control mt-2" runat="server">
                                <asp:ListItem Value="0">User has internet, does not need an Internet Essential Voucher</asp:ListItem>
                                <asp:ListItem Value="1">User does not have internet, requires an Internet Essential Voucher</asp:ListItem>
                            </asp:DropDownList>
                            </asp:Panel>
                            <asp:Label ID="lblOne" runat="server" Text=""></asp:Label>
                            <asp:TextBox ID="tbOne" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:Label ID="lblTwo" runat="server" Text=""></asp:Label>
                            <asp:TextBox ID="tbTwo" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:Label ID="lblThree" runat="server" Text=""></asp:Label>
                            <asp:TextBox ID="tbThree" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:Label ID="lblFour" runat="server" Text=""></asp:Label>
                            <asp:TextBox ID="tbFour" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:Label ID="lblFive" runat="server" Text=""></asp:Label>
                            <asp:TextBox ID="tbFive" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
                            <asp:Label ID="lblSix" runat="server" Text=""></asp:Label>
                            <asp:TextBox ID="tbSix" runat="server" CssClass="form-control" MaxLength="400"></asp:TextBox>
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
                        <asp:Panel CssClass="row mt-3" ID="pnlPeripheral" runat="server">
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
                        </asp:Panel>
                    </asp:Panel>
                    <%-- Content End --%>
                    <%--Buttons Start--%>
                    <asp:Panel CssClass="row mt-3" ID="pnlButtons" runat="server">
                        <div class="col-md-3">
                            <asp:Button ID="btnEdit" CssClass="btn-primary btn w-25" runat="server" Text="Edit" OnClick="btnEdit_Click" />
                            <asp:Button ID="btnCancelEdit" Visible="false" CssClass="btn-warning btn w-25" runat="server" Text="Cancel" OnClick="btnEditCancel_Click" />
                        </div>
                        <div class="col-md-3">
                            <asp:Button ID="btnViewOrg" runat="server" CssClass="btn-primary btn" Text="View Org" OnClick="btnViewOrg_Click" OnClientClick="target ='_blank';" />
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
                    <h5>Unassigned Good Assets</h5>
                    <asp:Label ID="lblComputerMsg" runat="server" Text=""></asp:Label>
                    <asp:GridView ID="gvComputers" CssClass="table table-striped table-bordered thead-dark gvBtn" runat="server" AutoGenerateColumns="False">
                        <HeaderStyle CssClass="cherryBackground" />
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
                            <asp:TemplateField HeaderText="View">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbView" OnClick="lnkBtnView_Click" runat="server"><i class="fas fa-eye"></i></asp:LinkButton>
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
                        <HeaderStyle CssClass="cherryBackground" />
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
                            <asp:TemplateField HeaderText="View">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbView" OnClick="lnkBtnView_Click" runat="server"><i class="fas fa-eye"></i></asp:LinkButton>
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
        $(document).ready(function () {
            $('#MainContent_gvComputers').DataTable({ "lengthMenu": [5, 10, 25, 50, "All"] });
            $('#MainContent_gvAssigned').DataTable({ "lengthMenu": [5, 10, 25, 50, "All"] });
        });
    </script>
</asp:Content>
