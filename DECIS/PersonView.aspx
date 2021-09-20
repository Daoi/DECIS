<%@ Page Title="" Language="C#" MasterPageFile="~/DECIS.Master" AutoEventWireup="true" CodeBehind="PersonView.aspx.cs" Inherits="DECIS.PersonView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid homepage">
        <div class="row modal-header offwhiteBackground p-0" style="height: 50px; padding-left: 0!important; padding-right: 0!important; font-size: large;">
        </div>
        <div class="container-fluid mt-2">
            <%-- Start Asset Card --%>
            <div class="card my-auto mx-auto h-75 w-90">
                <div class="card-body">
                    <%-- Content Start --%>
                    <h4>
                        <asp:Label ID="lblTitle" CssClass="card-title" runat="server" Text="">
                        </asp:Label>
                    </h4>
                    <asp:Panel ID="pnlControls" CssClass="row form-group h-100" runat="server">
                        <div class="col-md">
                            <asp:Label ID="lblFirstName" runat="server" Text="First Name: "></asp:Label>
                            <asp:TextBox ID="tbFirstName" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:Label ID="lblLastName" runat="server" Text="Last Name: "></asp:Label>
                            <asp:TextBox ID="tbLastName" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:Label ID="lblRace" runat="server" Text="Race:"></asp:Label>
                            <asp:DropDownList ID="ddlRace" CssClass="form-control" runat="server"></asp:DropDownList>
                            <asp:Label ID="lblEthnicity" runat="server" Text="Ethnicity:"></asp:Label>
                            <asp:DropDownList ID="ddlEthnicity" CssClass="form-control" runat="server"></asp:DropDownList>
                            <asp:Label ID="lblGender" runat="server" Text="Race:"></asp:Label>
                            <asp:DropDownList ID="ddlGender" CssClass="form-control" runat="server"></asp:DropDownList>
                            <asp:Label ID="lblAgeRange" runat="server" Text="Age Range:"></asp:Label>
                            <asp:DropDownList ID="ddlAgeRange" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                        <div class="col-md">
                            <asp:Label ID="lblPhone" runat="server" Text="Phone: "></asp:Label>
                            <asp:TextBox ID="tbPhone" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:Label ID="lblEmail" runat="server" Text="Email: "></asp:Label>
                            <asp:TextBox ID="tbEmail" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:Label ID="lblZipcode" runat="server" Text="Zip Code: "></asp:Label>
                            <asp:TextBox ID="tbZipcode" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="row sumRow mt-2">
                            <div class="col-md-3">
                                <asp:Label ID="lblAdult" runat="server" Text="# of Adults:"></asp:Label>
                                <asp:TextBox ID="tbAdult" TextMode="Number" CssClass="form-control sum" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-3">
                                <asp:Label ID="lblHSStudent" runat="server" Text="# of HS:"></asp:Label>
                                <asp:TextBox ID="tbHSStudent" TextMode="Number" CssClass="form-control sum" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-3">
                                <asp:Label ID="lblK8" runat="server" Text="# of K8:"></asp:Label>
                                <asp:TextBox ID="tbK8" TextMode="Number" CssClass="form-control sum" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-3">
                                <asp:Label ID="lblPreschool" runat="server" Text="# of Preschool:"></asp:Label>
                                <asp:TextBox ID="tbPreschool" TextMode="Number" CssClass="form-control sum" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row text-center mt-1">
                            <h5><asp:Label ID="lblTotal" runat="server" Text=""></asp:Label></h5>
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

        $(document).ready(function () {
            calculateSum();
            $(".sum").on('keyup change', calculateSum);
        });

        function calculateSum() {
            var $row = $(".sumRow");
            var sum = 0;
            $row.find(".sum").each(function () {
                sum += parseFloat(this.value) || 0;
            });

            $("#MainContent_lblTotal").text("Total Household Size: " + sum.toFixed(0));
        }
    </script>
</asp:Content>
