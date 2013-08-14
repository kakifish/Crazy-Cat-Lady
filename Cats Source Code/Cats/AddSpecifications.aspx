<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddSpecifications.aspx.cs" Inherits="Cats.AddSpecifications" %>
<asp:Content ID="head" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="header" ContentPlaceHolderID="HeaderText" runat="server">
</asp:Content>
<asp:Content ID="main" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <br />
        <asp:Label ID="ChooseBreedLabel" runat="server" Text="Choose Breed:" Font-Size="XX-Large" Font-Underline="True" ForeColor="#3333CC" style="margin-left: 30%"></asp:Label>
        <asp:DropDownList ID="ChooseBreedDownList" runat="server"></asp:DropDownList>
        <asp:Button ID="SearchButton" runat="server" Text="Search" OnClick="SearchButton_Click" />
        <div>
            <asp:Label ID="ErrorLabel" runat="server" Text="Please choose a breed" ForeColor="Red" style="margin-left: 42%" Font-Size="Medium"></asp:Label>
        </div>
        <br />
        <asp:Image ID="CatImage" runat="server" ImageAlign="Middle" style="margin-left: 42%"/>
        <br />
        <table id="LabelsTable" runat="server" class="specificationsLabelsTable">
            <tr>
                <td>
                    <asp:Label ID="SpecificationsLable" runat="server" Text="Specifications: " Font-Size="Large" Font-Bold="True" Font-Underline="True"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="CountryLabel" runat="server" Text="Country: " Font-Size="Large" Font-Bold="True" Font-Underline="True"></asp:Label>
                    <asp:TextBox ID="CountryTextBox" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="OriginLabel" runat="server" Text="Origin: " Font-Size="Large" Font-Bold="True" Font-Underline="True"></asp:Label>
                    <asp:TextBox ID="OriginTextBox" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="BodyTypeLabel" runat="server" Text="Body Type: " Font-Size="Large" Font-Bold="True" Font-Underline="True"></asp:Label>
                    <asp:TextBox ID="BodyTypeTextBox" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="CoatLabel" runat="server" Text="Coat: " Font-Size="Large" Font-Bold="True" Font-Underline="True"></asp:Label>
                    <asp:TextBox ID="CoatTextBox" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="PatternLabel" runat="server" Text="Pattern: " Font-Size="Large" Font-Bold="True" Font-Underline="True"></asp:Label>
                    <asp:TextBox ID="PatternTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
        <br />
    </div>
    <div>
        <br />
        <br />
        <table class="searchCatButtonTable">
            <tr>
                <td>
                    <asp:Button ID="SubmitButton" runat="server" Text="Submit Changes" OnClick="SubmitButton_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
