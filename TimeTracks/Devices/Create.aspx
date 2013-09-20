<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="TimeTracks.Devices.Create" %>

<asp:Content ID="MainContentArea" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="editDevice" runat="server">
        <asp:Label ID="Label12" runat="server" Text="Create Device" Font-Bold="True" Font-Size="20pt"></asp:Label><br />
        <br />
        <asp:Label ID="Label14" runat="server" Text="Device Name"></asp:Label><br />
        <asp:TextBox ID="DeviceNameTextBox" runat="server" MaxLength="50"></asp:TextBox>
        <%--<br />
        <asp:Label ID="Label15" runat="server" Text="Serial Number"></asp:Label><br />
        <asp:TextBox ID="SerialNumberTextBox" runat="server" MaxLength="100"></asp:TextBox>--%>
        <br />
        <asp:Label ID="Label16" runat="server" Text="Device ID"></asp:Label>&nbsp;
        <%--<asp:LinkButton ID="EditIdButton" runat="server" OnClick="EditIdButton_Click">(edit)</asp:LinkButton>--%>
        <br />
        <asp:TextBox ID="DeviceIdTextBox" runat="server" Enabled="false" MaxLength="50"></asp:TextBox>
        <br />
        <asp:Label ID="Label20" runat="server" Text="Owner"></asp:Label><br />
        <asp:DropDownList ID="OwnerDropDown" runat="server"></asp:DropDownList>
        <br />
        <asp:Label ID="Label1" runat="server" Text="User"></asp:Label><br />
        <asp:DropDownList ID="UserDropDown" runat="server"></asp:DropDownList>
        <br />
        <br />
        <asp:Button ID="SaveButton" runat="server" Text="Create Device" OnClick="SaveButton_Click" />
    </asp:Panel>
</asp:Content>
