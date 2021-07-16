<%@ Page Title="" Language="C#" MasterPageFile="~/DECIS.Master" AutoEventWireup="true" CodeBehind="AssetList.aspx.cs" Inherits="DECIS.AssetList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class="container-fluid homepage">
        <div class="row modal-header offwhiteBackground p-0" style="height: 50px; padding-left: 0!important; padding-right: 0!important; font-size: large;">
        </div>
        <div class="table-responsive tableContainer">
            <div class="container-fluid mt-2">
                <div runat="server" id="divNoRows" visible="false" class="row w-auto justify-content-center" style="height: 10vh;">
                    <asp:Label ID="lblNoRows" runat="server" Text=""></asp:Label>
                </div>
                <asp:GridView ID="gvAssetList" Width="100%" runat="server" AutoGenerateColumns="True" CssClass="table table-light table-striped table-bordered thead-dark">
                    <HeaderStyle CssClass="cherryBackground" />
                    <Columns>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
    <div style="margin-top: 2%; height: 2%; width: auto;"></div>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#MainContent_gvAssetList').DataTable();
        });
    </script>
</asp:Content>
