<%@ Page Title="Log in" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TimeTracks.Account.Login" %>
<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <section id="loginForm">


                <p class="validation-summary-errors">
                    <asp:Literal runat="server" ID="FailureText" />
                </p>
                <fieldset>
                    <legend>Log in Form</legend>
                    <ol>
                        <li>
                            <asp:Label ID="Label1" runat="server" AssociatedControlID="AccountTextBox">Account</asp:Label>
                            <asp:TextBox runat="server" ID="AccountTextBox" TextMode="Number" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="AccountTextBox" CssClass="field-validation-error" ErrorMessage="The account name field is required." />
                        </li>
                        <li>
                            <asp:Label runat="server" AssociatedControlID="UsernameTextBox">User name</asp:Label>
                            <asp:TextBox runat="server" ID="UsernameTextBox" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="UsernameTextBox" CssClass="field-validation-error" ErrorMessage="The user name field is required." />
                        </li>
                        <li>
                            <asp:Label runat="server" AssociatedControlID="PasswordTextBox">Password</asp:Label>
                            <asp:TextBox runat="server" ID="PasswordTextBox" TextMode="Password" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="PasswordTextBox" CssClass="field-validation-error" ErrorMessage="The password field is required." />
                        </li>
                        <li>
                            <asp:CheckBox runat="server" ID="RememberCheckBox"/>
                            <asp:Label runat="server" AssociatedControlID="RememberCheckBox" CssClass="checkbox">Remember me?</asp:Label>
                        </li>
                    </ol>
                    <asp:Button runat="server" CommandName="Login" Text="Log in" ID="LoginButton" OnClick="LoginButton_Click" />
                </fieldset>

        <p>
            <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled">Register</asp:HyperLink>
            if you don't have an account.
        </p>
    </section>

    </asp:Content>
