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
                        Click browse to select a file to upload. The file must be a .csv file.
                        After you choose the file, select the development this file relates to
                        from the dropdown box.
                    </p>
                </div>
                <div class="row justify-content-center text-secondary mt-3">
                    <div class="custom-file align-items-center">
                        <asp:FileUpload CssClass="fileUpload custom-file-input" ID="fileUpload" runat="server"></asp:FileUpload>
                        <label class="custom-file-label fileUpload" for="MainContent_fileUpload">Choose file</label>
                    </div>
                </div>
                <div class="row justify-content-center mt-3">
                    <asp:DropDownList ID="ddl" CssClass="" runat="server"></asp:DropDownList>
                </div>
                <div class="row justify-content-center mt-5">
                    <div class="col-md-6">
                        <asp:Button ID="btnSubmitImport" runat="server" Text="Import Resident List" CssClass="buttonStyle" OnClick="btnSubmitImport_Click" />
                    </div>
                    <div class="col-md-6">
                        <asp:Button ID="btnDownloadTemplate" runat="server" Text="Download Template" CssClass="buttonStyle" />
                    </div>
                </div>
                <asp:Label ID="lblInsertCount" CssClass="mt-1" runat="server" Text=""></asp:Label>
                <div runat="server" visible="false" id="divUploadErrors" class="row justify-content-center mt-3 fileUploadErrors">
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <div class="card-footer text-muted">
                Digital Equity Center
            </div>
        </div>
    </div>
    <script>
        $(document).ready(function () {
            $("#MainContent_ddlDevelopments").select2({
                placeholder: "Select Development",
                allowClear: true,
                selectOnClose: true
            });
        });
    </script>

    <script>
        //Change file label to file uploaded
        $(".custom-file-input").on("change", function () {
            var fileName = $(this).val().split("\\").pop();
            $(this).siblings(".custom-file-label").addClass("selected").html(fileName);
        });
    </script>
</asp:Content>
