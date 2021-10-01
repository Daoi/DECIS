<%@ Page Title="" Language="C#" MasterPageFile="~/DECIS.Master" AutoEventWireup="true" CodeBehind="AssetView.aspx.cs" Inherits="DECIS.AssetView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid homepage">
        <div class="container-fluid mt-2">
            <%-- Start Asset Card --%>
            <div class="row" style="height: 7%; font-size: large">
                <nav aria-label="breadcrumb" class="mb-n3 ml-2">
                    <ol class="breadcrumb bg-white">
                        <li class="breadcrumb-item" style="color: deepskyblue">
                            <asp:LinkButton ID="lnkHome" href="Homepage.aspx" runat="server">Dashboard</asp:LinkButton></li>
                        <li class="breadcrumb-item" style="color: deepskyblue">
                            <asp:LinkButton ID="lnkList" href="AssetList.aspx" runat="server">Asset List</asp:LinkButton></li>
                        <li class="breadcrumb-item active bg-white" aria-current="page">Asset View</li>
                    </ol>
                </nav>
            </div>
            <div class="card my-auto mx-auto h-75 w-90">
                <img id="crdAssetImage" class="card-img-top h-25 w-25 mx-auto my-auto" src="..." alt="Image" runat="server" />
                <div class="card-body">
                    <%-- Content Start --%>
                    <h4>
                        <asp:Label ID="lblSerialNumber" CssClass="card-title" runat="server" Text="">
                        </asp:Label>
                    </h4>
                    <asp:Panel ID="pnlControls" CssClass="row form-group h-100" runat="server">
                        <div class="col-md">
                            <asp:Label ID="lblAssetType" runat="server" Text="Asset Type:">
                            </asp:Label>
                            <asp:Label ID="lblAssetTypeText" CssClass="form-control bg-muted" runat="server"></asp:Label>

                            <asp:UpdatePanel ID="upMakeModel" runat="server" UpdateMode="Conditional">
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlAssetMake" EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="ddlAssetMake" EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="ddlAssetStatus" EventName="SelectedIndexChanged" />
                                </Triggers>
                                <ContentTemplate>
                                    <asp:Label ID="lblAssetStatus" runat="server" Text="Asset Status:"></asp:Label>
                                    <asp:DropDownList ID="ddlAssetStatus" data-dj-validator="index" CssClass="form-control" runat="server" OnSelectedIndexChanged="ddlAssetStatus_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                    <asp:Label ID="lblAssetMake" runat="server" Text="Asset Make:">
                                    </asp:Label>
                                    <asp:DropDownList ID="ddlAssetMake" CssClass="form-control" runat="server" OnSelectedIndexChanged="ddlAssetMake_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                    <asp:Label ID="lblAssetModel" runat="server" Text="Asset Model:">
                                    </asp:Label>
                                    <asp:DropDownList ID="ddlAssetModel" CssClass="form-control" runat="server"></asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="col-md">
                            <asp:UpdatePanel ID="upLocation" UpdateMode="Conditional" runat="server">
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlLocation" EventName="SelectedIndexChanged" />
                                </Triggers>
                                <ContentTemplate>
                                    <asp:Label ID="lblLocation" runat="server" Text="Location:"></asp:Label>
                                    <asp:DropDownList ID="ddlLocation" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlLocation_SelectedIndexChanged"></asp:DropDownList>
                                    <asp:Label ID="lblLocationDescription" runat="server" Text="Location Description:"></asp:Label>
                                    <asp:Label ID="lblLocationDescriptionText" CssClass="bg-muted form-control" runat="server"></asp:Label>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <asp:Label ID="lblAssetDescription" runat="server" Text="Asset Description:">
                            </asp:Label><asp:TextBox ID="tbAssetDescription" MaxLength="300" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </asp:Panel>
                    <%-- Content End --%>
                    <%--Buttons Start--%>
                    <div class="row mt-3">
                        <div class="col-md-3">
                            <asp:Button ID="btnEdit" OnClientClick="validateAll();" CssClass="btn-primary btn w-25" runat="server" Text="Edit" OnClick="btnEdit_Click" />
                            <asp:Button ID="btnCancelEdit" OnClientClick="clientCancel();" Visible="false" CssClass="btn-warning btn w-25" runat="server" Text="Cancel" OnClick="btnEditCancel_Click" />
                        </div>
                        <div class="col-md-3">
<<<<<<< Updated upstream
=======
                            <asp:Button ID="btnViewIntake" CssClass="btn btn-primary" runat="server" Text="View Intake" />
>>>>>>> Stashed changes
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
    </div>
    <div style="margin-top: 2%; height: 2%; width: auto;"></div>
    <script>

        $('#frmMain').djValidator({ blur: true });

        function validateAll() {
            resp = $('#frmMain').djValidator({ mode: "function" });
            if (resp == true) {
                sendForm($('#frmMain'));
            }
        };

        function pageLoad() {
            $.fn.djValidator.add('index', 'Cannot set donated or recycled status from here.',
                function ($field, params) {
                    var value = $("#MainContent_ddlAssetStatus").prop('selectedIndex');
                    if (value == 4 || value == 5) {
                        return false;
                    }
                    return true;
                });
        };
    </script>
</asp:Content>
