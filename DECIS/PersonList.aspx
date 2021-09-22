<%@ Page Title="" Language="C#" MasterPageFile="~/DECIS.Master" AutoEventWireup="true" CodeBehind="PersonList.aspx.cs" Inherits="DECIS.PersonList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid homepage">
        <div class="row modal-header offwhiteBackground p-0" style="height: 50px; padding-left: 0!important; padding-right: 0!important; font-size: large;">
        </div>
        <div class="table-responsive tableContainer">
            <div class="container-fluid mt-2">
                <div runat="server" id="divNoRows" visible="false" class="row w-auto justify-content-center" style="height: 10vh;">
                    <asp:Label ID="lblNoRows" runat="server" Text=""></asp:Label>
                </div>
                <div class="row">
                    <asp:Label ID="lblGVMessage" runat="server" Visible="False"></asp:Label>
                    <asp:GridView ID="gvPersonList" Width="100%" runat="server" CssClass="table table-light table-striped table-bordered thead-dark" AutoGenerateColumns="False">
                        <HeaderStyle CssClass=" text-info" />
                        <Columns>
                            <asp:TemplateField HeaderText="View" ItemStyle-CssClass="align-items-center">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkBtnView" runat="server" OnClick="lnkBtnView_Click">
                                    <i class="fas fa-eye"></i>
                                    </asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle CssClass="align-items-center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                            <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                            <asp:BoundField DataField="Email" HeaderText="Email" />
                            <asp:BoundField DataField="Phone" HeaderText="Phone" />
                            <asp:BoundField DataField="Zipcode" HeaderText="Zip Code" />
                            <asp:BoundField DataField="HouseholdSize" HeaderText="Household Size" />
                        </Columns>
                        <RowStyle HorizontalAlign="Center" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
    <div style="margin-top: 2%; height: 2%; width: auto;"></div>
    <script type="text/javascript">
        function pageLoad() {
            var tables = ['#MainContent_gvPersonList'];
            InitDT(tables);
        };
    </script>
</asp:Content>
