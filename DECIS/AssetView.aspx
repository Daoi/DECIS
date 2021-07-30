﻿<%@ Page Title="" Language="C#" MasterPageFile="~/DECIS.Master" AutoEventWireup="true" CodeBehind="AssetView.aspx.cs" Inherits="DECIS.AssetView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid homepage">
        <div class="row modal-header offwhiteBackground p-0" style="height: 50px; padding-left: 0!important; padding-right: 0!important; font-size: large;">
        </div>
        <div class="container-fluid mt-2">
            <%-- Start Asset Card --%>
            <div class="card my-auto mx-auto h-75 w-90">
                <img id="crdAssetImage" class="card-img-top h-25 w-25 mx-auto my-auto" src="..." alt="Image" runat="server" />
                <div class="card-body">
                    <%-- Content Start --%>
                    <h5>
                        <asp:Label ID="lblSerialNumber" CssClass="card-title" runat="server" Text="">
                        </asp:Label>
                    </h5>
                    <asp:Panel ID="pnlControls" CssClass="row form-group h-100" runat="server">
                        <div class="col-md">
                            <asp:Label ID="lblAssetType" runat="server" Text="Asset Type:">
                            </asp:Label>
                            <asp:Label ID="lblAssetTypeText" CssClass="form-control bg-muted" runat="server"></asp:Label>
                            <asp:Label ID="lblAssetStatus" runat="server" Text="Asset Status:">
                            </asp:Label>
                            <asp:DropDownList ID="ddlAssetStatus" CssClass="form-control" runat="server"></asp:DropDownList>
                            <asp:UpdatePanel ID="upMakeModel" runat="server" UpdateMode="Conditional">
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlAssetMake" EventName="SelectedIndexChanged" />
                                </Triggers>
                                <ContentTemplate>
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
                            <asp:Label ID="lblAssetDescription" runat="server" Text="Asset Description:">
                            </asp:Label><asp:TextBox ID="tbAssetDescription" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:Label ID="lblLocation" runat="server" Text="Location:"></asp:Label>
                            <asp:DropDownList ID="ddlLocation" CssClass="form-control" runat="server"></asp:DropDownList>
                            <asp:Label ID="lblLocationDescription" runat="server" Text="Location Description:"></asp:Label>
                            <asp:Label ID="lblLocationDescriptionText" CssClass="bg-muted form-control" runat="server"></asp:Label>
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
                            <a href="#" class="btn btn-primary">View Intake</a>
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
</asp:Content>
