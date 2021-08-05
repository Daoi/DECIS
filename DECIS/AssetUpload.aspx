<%@ Page Title="" Language="C#" MasterPageFile="~/DECIS.Master" AutoEventWireup="true" CodeBehind="AssetUpload.aspx.cs" Inherits="DECIS.AssetUpload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="justify-content-center d-flex py-5">
        <div class="card mb-3 text-center my-auto ">
            <div class="card-header" style="font-size: 18px">
                Import Data
            </div>
            <div class="card-body justify-content-center">
                <div class="row" style="height: 7%; font-size: large">
                    <nav aria-label="breadcrumb" class="mb-n3 ml-2">
                        <ol class="breadcrumb bg-white">
                            <li class="breadcrumb-item" style="color: deepskyblue">
                                <asp:LinkButton ID="lnkHome" NavigateUrl="./Homepage.aspx" runat="server">Dashboard</asp:LinkButton></li>
                            <li class="breadcrumb-item active bg-white" aria-current="page">Import Data</li>
                        </ol>
                    </nav>
                </div>
                <h4>Instructions</h4>
                <div class="row justify-content-center">
                    <p class="w-50">
                        Click browse to select the file to upload. Select the organization providing the donation from the drop down 
                        and then click submit. If the organization is not in the drop down list select New Organization. Make sure the Organizations
                        name is spelled correctly in the Workbook's Donor Info sheet. To download a template of the Intake Form click download template.
                    </p>
                </div>
                <div class="row justify-content-center text-secondary mt-3">
                    <div class="custom-file align-items-center">
                        <asp:FileUpload CssClass="fileUpload custom-file-input" ID="fileUpload" runat="server"></asp:FileUpload>
                        <label class="custom-file-label fileUpload" for="MainContent_fileUpload">Choose file</label>
                    </div>
                </div>
                <div class="row justify-content-center mt-3">
                    <asp:DropDownList ID="ddlOrgs" CssClass="form-control w-50" runat="server" AppendDataBoundItems="True">
                        <asp:ListItem Value="-1">New Organization</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="row justify-content-center mt-5">
                    <div class="col-md-4">
                        <asp:Button ID="btnSubmitImport" runat="server" Text="Submit Intake Form" CssClass="btn-primary btn" OnClick="btnSubmitImport_Click" />
                    </div>
                    <div class="col-md-4">
                        <asp:Button ID="btnRetryImports" runat="server" Text="Retry Failed Imports" Visible="false" CssClass="btn btn-primary" OnClick="btnRetryImports_Click" />
                    </div>
                    <div class="col-md-4">
                        <asp:Button ID="btnDownloadTemplate" runat="server" Text="Download Template" CssClass="btn btn-primary" />
                    </div>
                </div>
                <asp:UpdatePanel ID="upGV" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblInsertCount" CssClass="mt-1" runat="server" Text=""></asp:Label>
                        <div runat="server" visible="false" id="divUploadErrors" class="row justify-content-center mt-3 fileUploadErrors">
                            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                        </div>
                        <asp:GridView ID="gvDuplicates" Width="100%" runat="server" CssClass="table table-light table-striped table-bordered thead-dark" AutoGenerateColumns="False">
                            <HeaderStyle CssClass="cherryBackground" />
                            <Columns>
                                <asp:TemplateField HeaderText="Select" ItemStyle-CssClass="align-items-center">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="hfOriginalSerial" runat="server" Value='<%# Bind("SerialNumber")%>' />
                                        <asp:CheckBox runat="server" ID="cbSelectDupe"></asp:CheckBox>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="align-items-center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SerialNumber">
                                    <ItemTemplate>
                                        <asp:TextBox ID="tbSerialNumber" Text='<%#DECIS.ControlLogic.Gridview.BoundFieldFormatter.FormatGeneric(Eval("SerialNumber"))%>' runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Description">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDescription" runat="server" Text='<%# DECIS.ControlLogic.Gridview.BoundFieldFormatter.FormatGeneric(Eval("Description"))%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Status" HeaderText="Current Status" />
                                <asp:BoundField DataField="Location" HeaderText="Current Location" />
                            </Columns>
                            <RowStyle HorizontalAlign="Center" />
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="card-footer text-muted">
                Digital Equity Center
            </div>
        </div>
    </div>
    <script>
        function pageLoad() {
            $("#MainContent_ddlOrgs").select2({
                placeholder: "Select Organization",
                allowClear: true,
                selectOnClose: true
            });
            var table = $('#MainContent_gvDuplicates');

            if (table.is(":visible"))
                table.DataTable();
        };
    </script>
    <script>
        //Change file label to file uploaded
        $(".custom-file-input").on("change", function () {
            var fileName = $(this).val().split("\\").pop();
            $(this).siblings(".custom-file-label").addClass("selected").html(fileName);
        });
    </script>
</asp:Content>
