<%@ Page Title="Create account" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="TimeTracks.Account.Create" %>

<asp:Content ID="MainContentArea" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="createAccount" runat="server">
        <asp:Label ID="Label1" runat="server" Text="Account Settings" Font-Bold="True" Font-Size="20pt"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Account Name"></asp:Label><br />
        <asp:TextBox ID="AccountNameTextBox" runat="server" MaxLength="50"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Week Start Day"></asp:Label><br />
        <asp:DropDownList ID="WeekStartDropDown" runat="server"></asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Administrator Account" Font-Bold="True" Font-Size="20pt"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label5" runat="server" Text="Username"></asp:Label><br />
        <asp:TextBox ID="UserNameTextBox" runat="server" MaxLength="15"></asp:TextBox>
        <br />
        <asp:Label ID="Label6" runat="server" Text="First Name"></asp:Label><br />
        <asp:TextBox ID="FirstNameTextBox" runat="server" MaxLength="50"></asp:TextBox>
        <br />
        <asp:Label ID="Label7" runat="server" Text="Last Name"></asp:Label><br />
        <asp:TextBox ID="LastNameTextBox" runat="server" MaxLength="50"></asp:TextBox>
        <br />
        <asp:Label ID="Label8" runat="server" Text="Email"></asp:Label><br />
        <asp:TextBox ID="EmailTextBox" runat="server" MaxLength="50"></asp:TextBox>
        <br />
        <asp:Label ID="Label21" runat="server" Text="Password"></asp:Label><br />
        <asp:TextBox ID="PasswordTextBox1" runat="server" MaxLength="50" TextMode="Password"></asp:TextBox>
        <br />
        <asp:Label ID="Label22" runat="server" Text="Re-enter Password"></asp:Label><br />
        <asp:TextBox ID="PasswordTextBox2" runat="server" MaxLength="50" TextMode="Password"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label9" runat="server" Text="Company Info" Font-Bold="True" Font-Size="20pt"></asp:Label><br />
        <asp:Label ID="Label10" runat="server" Text="(you can create additional companies later on)"></asp:Label><br />
        <br />
        <br />
        <asp:Label ID="Label11" runat="server" Text="Company Name (leave blank to use account name)"></asp:Label><br />
        <asp:TextBox ID="CompanyNameTextBox" runat="server" MaxLength="50"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label12" runat="server" Text="Location Info" Font-Bold="True" Font-Size="20pt"></asp:Label><br />
        <asp:Label ID="Label13" runat="server" Text="(you can create additional locations later on)"></asp:Label><br />
        <br />
        <br />
        <asp:Label ID="Label14" runat="server" Text="Name (leave blank to use account name)"></asp:Label><br />
        <asp:TextBox ID="LocationNameTextBox" runat="server" MaxLength="50"></asp:TextBox>
        <br />
        <asp:Label ID="Label15" runat="server" Text="Street Adderess"></asp:Label><br />
        <asp:TextBox ID="StreetAdderessTextBox" runat="server" MaxLength="100"></asp:TextBox>
        <br />
        <asp:Label ID="Label16" runat="server" Text="Suite (leave blank for none)"></asp:Label><br />
        <asp:TextBox ID="SuiteTextBox" runat="server" MaxLength="50"></asp:TextBox>
        <br />
        <asp:Label ID="Label17" runat="server" Text="City"></asp:Label><br />
        <asp:TextBox ID="CityTextBox" runat="server" MaxLength="50"></asp:TextBox>
        <br />
        <asp:Label ID="Label18" runat="server" Text="State"></asp:Label><br />
        <asp:TextBox ID="StateTextBox" runat="server" MaxLength="50"></asp:TextBox>
        <br />
        <asp:Label ID="Label19" runat="server" Text="ZipCode"></asp:Label><br />
        <asp:TextBox ID="ZipCodeTextBox" runat="server" MaxLength="50" TextMode="Number"></asp:TextBox>
        <br />
        <asp:Label ID="Label20" runat="server" Text="Country"></asp:Label><br />
        <asp:TextBox ID="CountryTextBox" runat="server" MaxLength="50"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="SaveButton" runat="server" Text="Create Account" OnClick="SaveButton_Click" />
    </asp:Panel>
</asp:Content>
