<%@ Page Title="" Language="C#" MasterPageFile="~/DECIS.Master" AutoEventWireup="true" CodeBehind="AssetView.aspx.cs" Inherits="DECIS.AssetView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid homepage">
        <div class="row modal-header offwhiteBackground p-0" style="height: 50px; padding-left: 0!important; padding-right: 0!important; font-size: large;">
        </div>
        <div class="container-fluid mt-2">
            <%-- Start Asset Card --%>
            <div class="card w-50 my-auto mx-auto">
                <img id="crdAssetImage" class="card-img-top h-25 w-auto" src="..." alt="Image" runat="server" />
                <div class="card-body text-center">
                    <%-- Content Start --%>
                    <div class="row">
                        <h5>
                            <asp:Label ID="lblSerialNumber" CssClass="card-title" runat="server" Text="">
                            </asp:Label>
                        </h5>
                        <p class="card-text">
                            <asp:Label ID="lblAssetDescription" runat="server" Text="">
                            </asp:Label>
                        </p>
                    </div>
                    <%-- Content End --%>
                    <%--Buttons Start--%>
                    <div class="row mt-3">
                        <div class="col-md-3">
                            <a href="#" class="btn btn-primary">Go somewhere</a>
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
    </div>
    <div style="margin-top: 2%; height: 2%; width: auto;"></div>
</asp:Content>
