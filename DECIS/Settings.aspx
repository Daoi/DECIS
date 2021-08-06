<%@ Page Title="" Language="C#" MasterPageFile="~/DECIS.Master" AutoEventWireup="true" CodeBehind="Settings.aspx.cs" Inherits="DECIS.Settings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid homepage">
        <div class="container-fluid p-0">
            <div class="container my-5">
                <h3>Add Model</h3>
                <div class="row border-bottom mb-5 pb-5">
                    <div class="col-8">
                        <asp:updatepanel id="upModel" runat="server" updatemode="Conditional">
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
                                <asp:label id="lblModelError" runat="server" text="" cssclass="errorLabel" visible="false"></asp:label>
                                <br />
                                <asp:textbox id="tbModelName" runat="server" placeholder="Model Name" cssclass="form-control"></asp:textbox>
                                <asp:dropdownlist id="ddlAssetMake" cssclass="form-control mt-1" runat="server"></asp:dropdownlist>
                                <asp:dropdownlist id="ddlAssetType" cssclass="form-control mt-1" runat="server"></asp:dropdownlist>
                                <asp:fileupload id="fuModelImage" cssclass="form-control mt-1" runat="server" />
                                <asp:button id="btnAddModel" runat="server" text="Add New Model" cssclass="btn btn-primary mt-3" onclick="btnAddModel_Click" />
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
                        <asp:label id="lbExport" runat="server" text="Export Table"></asp:label>
                        <br />
                        <asp:dropdownlist id="ddlTables" runat="server" cssclass="form-control w-50" appenddatabounditems="True">
                </asp:dropdownlist>
                        <asp:button id="btnExportTable" runat="server" text="Export Selected Table" cssclass="btn btn-primary mt-3" />
                    </div>
                </div>
                <%-- End --%>
            </div>
</asp:Content>
