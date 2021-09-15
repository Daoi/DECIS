<%@ Page Title="" Language="C#" MasterPageFile="~/DECIS.Master" Async="true" AutoEventWireup="true" CodeBehind="CreateAccount.aspx.cs" Inherits="DECIS.CreateAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid p-0">
        <div class="container-fluid homepage">
            <div class="row modal-header offwhiteBackground p-0" style="height: 50px; padding-left: 0!important; padding-right: 0!important; font-size: large">
                <nav aria-label="breadcrumb">
                    <ol class="breadcrumb bg-transparent">
                        <li class="breadcrumb-item" style="color: deepskyblue">
                            <asp:linkbutton id="lnkHome" navigateurl="~/Homepage.aspx" runat="server">Dashboard</asp:linkbutton>
                        </li>
                        <li class="breadcrumb-item active" aria-current="page">Create Account</li>
                    </ol>
                </nav>
                <asp:label id="lblPageInfo" runat="server" enabled="true" visible="true" cssclass="h3 my-2 px-0" style="width: 70%"></asp:label>
            </div>
            <div class="container-fluid mt-5 w-75">
                <div class="row">
                    <h5>Personal Information:</h5>
                </div>
                <div class="row m-3">
                    <div class="col">
                        <label class="required">First Name: </label>
                    </div>
                    <div class="col-7">
                        <asp:textbox id="tbFirstName" cssclass="form-control" runat="server"></asp:textbox>
                    </div>
                </div>
                <div class="row m-3">
                    <div class="col">
                        <label class="required">Last Name: </label>
                    </div>

                    <div class="col-7">
                        <asp:textbox id="tbLastName" cssclass="form-control" runat="server"></asp:textbox>
                    </div>
                </div>
                <div class="row m-3">
                    <div class="col">
                        <label class="required">Email: </label>
                    </div>
                    <div class="col-7">
                        <div class="input-group">
                            <asp:textbox id="tbEmail" cssclass="form-control" runat="server" textmode="Email"></asp:textbox>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <h5>Account Information:</h5>
                    </div>
                </div>
                <div class="row m-3">
                    <div class="col">
                        <label class="required">Account Type: </label>
                    </div>
                    <div class="col-7">
                        <asp:dropdownlist id="ddlRole" cssclass="form-control" runat="server">
                        </asp:dropdownlist>
                    </div>
                </div>
                <div class="row m-3">
                    <div class="col">
                        <asp:label id="lblError" cssclass="errorLabel" runat="server"></asp:label>
                    </div>
                </div>
                <div class="row m-3">
                    <asp:button id="btnSubmit" cssclass="btn btn-primary" onClick="btnSubmit_Click" text="Create Account" runat="server" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
