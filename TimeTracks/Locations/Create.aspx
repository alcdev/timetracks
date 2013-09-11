<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="TimeTracks.Locations.Create" %>

<asp:Content ID="MainContentArea" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="editLocation" runat="server">
        <asp:Label ID="Label12" runat="server" Text="Create Location" Font-Bold="True" Font-Size="20pt"></asp:Label><br />
        <br />
        <asp:Label ID="Label14" runat="server" Text="Location Name"></asp:Label><br />
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
        <asp:Label ID="Label1" runat="server" Text="Company"></asp:Label><br />
        <asp:DropDownList ID="CompanyDropDown" runat="server"></asp:DropDownList>
        <br />
        <br />
        <asp:Button ID="SaveButton" runat="server" Text="Create Location" OnClick="SaveButton_Click" />
    </asp:Panel>
</asp:Content>
