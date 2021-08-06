<%@ Page Title="" Language="C#" MasterPageFile="~/DECIS.Master" AutoEventWireup="true" CodeBehind="Settings.aspx.cs" Inherits="DECIS.Settings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid homepage">
        <div class="container-fluid p-0">
            <div class="container my-5">
                <h3>Add Model</h3>
                <div class="row border-bottom mb-5 pb-5">
                    <div class="col-8">
                        <asp:UpdatePanel ID="upModel" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:GridView ID="gvModels" runat="server" AutoGenerateColumns="False" CssClass="table table-light table-striped table-bordered thead-dark">
                                    <HeaderStyle CssClass="freshwater" />
                                    <Columns>
                                    </Columns>
                                </asp:GridView>
                                </div>
                    <div class="col pt-5">
                        <div class="card mt-4">
                            <div class="card-body">
                                <p class="card-text">Enter the text for the new option you'd like to add and then click the Add New Option button.</p>
                                <asp:Label ID="lblModelError" runat="server" Text="" CssClass="errorLabel" Visible="false"></asp:Label><br />
                                <asp:TextBox ID="tbModelName" runat="server" Placeholder="Model Name" CssClass="form-control"></asp:TextBox>
                                <asp:DropDownList ID="ddlAssetMake" CssClass="form-control mt-1" runat="server"></asp:DropDownList>
                                <asp:DropDownList ID="ddlAssetType" CssClass="form-control mt-1" runat="server"></asp:DropDownList>
                                <asp:FileUpload ID="fuModelImage" CssClass="form-control mt-1" runat="server" />
                                <asp:Button ID="btnAddModel" runat="server" Text="Add New Model" CssClass="btn btn-primary mt-3" OnClick="btnAddModel_Click" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
        <%-- Start --%>
        <h3>Export Database to Excel</h3>
        <div class="row mb-5 pb-5">
            <div class="col-md-6">
                <asp:Label ID="lbExport" runat="server" Text="Export Table"></asp:Label><br />
                <asp:DropDownList ID="ddlTables" runat="server" CssClass="form-control w-50" AppendDataBoundItems="True">
                </asp:DropDownList>
                <asp:Button ID="btnExportTable" runat="server" Text="Export Selected Table" CssClass="btn btn-primary mt-3" />
            </div>
        </div>
        <%-- End --%>
    </div>
</asp:Content>
