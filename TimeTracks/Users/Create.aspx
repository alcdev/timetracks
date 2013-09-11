<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="True" CodeBehind="Create.aspx.cs" Inherits="TimeTracks.Users.Create" %>

<asp:Content ID="MainContentArea" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Panel ID="editUser" runat="server">
        <asp:Label ID="Label4" runat="server" Text="Create New User Account" Font-Bold="True" Font-Size="20pt"></asp:Label>
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
        <asp:Label ID="Label1" runat="server" Text="Payrate"></asp:Label><br />
        <asp:TextBox ID="PayrateTextBox" runat="server" MaxLength="50" TextMode="Number"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Pay Interval"></asp:Label><br />
        <asp:DropDownList ID="PayIntervalDropDown" runat="server"></asp:DropDownList>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Role"></asp:Label><br />
        <asp:DropDownList ID="RoleDropDown" runat="server"></asp:DropDownList>
        <br />
        <br />
        <asp:Button ID="SaveButton" runat="server" Text="Create User" OnClick="SaveButton_Click" />
    </asp:Panel>

</asp:Content>
