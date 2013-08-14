<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddCat.aspx.cs" Inherits="Cats.AddCat" %>
<asp:Content ID="head" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="header" ContentPlaceHolderID="HeaderText" runat="server">
</asp:Content>
<asp:Content ID="main" ContentPlaceHolderID="MainContent" runat="server">
        <div>
        <br />
        <asp:Label ID="CatBreedNameLabel" runat="server" Text="Breed Name:" Font-Size="XX-Large" Font-Underline="True" ForeColor="#3333CC" style="margin-left: 30%"></asp:Label>
            <asp:TextBox ID="CatBreedNameTextBox" runat="server"></asp:TextBox>
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
        <%--This is temporary!! --%>
        <div id="tempDiv" runat="server">
            <table>
                <tr>
                    <td style="color: blue; border-style: groove">
                        <b>Choose your style</b>
                    </td>
                    <td style="color: blue; border-style: groove">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Type text below</b>
                    </td>

                </tr>
                <tr>
                    <td style="color: #ff0000; border-style: groove">
                        <b>Bold</b>
                    </td>
                    <td style="color: #ff0000; border-style: groove">
                        &nbsp;&nbsp; ##b**<b>your text</b>##/b**
                    </td>
                </tr>
                <tr>
                    <td style="color: #ff0000; border-style: groove">
                        <i>Italic</i>
                    </td>
                    <td style="color: #ff0000; border-style: groove">
                        &nbsp;&nbsp; ##i**<b>your text</b>##/i**
                    </td>
                </tr>
                <tr>
                    <td style="color: #ff0000; border-style: groove">
                        h1
                    </td>
                    <td style="color: #ff0000; border-style: groove">
                        &nbsp; ##h1**<b>your text</b>##/h1** &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="color: #ff0000; border-style: groove">
                        h2
                    </td>
                    <td style="color: #ff0000; border-style: groove">
                        &nbsp; ##h2**<b>your text</b>##/h2** &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="color: #ff0000; border-style: groove">
                        h3
                    </td>
                    <td style="color: #ff0000; border-style: groove">
                        &nbsp; ##h3**<b>your text</b>##/h3** &nbsp;
                    </td>
                </tr>
            </table>
        </div>
<%--        <table id="ChangeFontTable" runat="server" style="border-style: solid">
            <tr>
                <td>
                    <asp:Label ID="ChooseStyleLabel" runat="server" Text="Choose your style" Font-Bold="True" Font-Underline="True" Font-Size="20px"></asp:Label>
                </td>
                <td>
                    <asp:Button ID="BoldBtn" runat="server" Text="B" Font-Bold="True" Font-Size="20px" ClientIDMode="Static" OnClick="TextStyle"/>
                </td>
                <td>
                    <asp:Button ID="ItalicBtn" runat="server" Text="/" Font-Bold="True" Font-Size="20px" OnClick="TextStyle"/>
                </td>
                <td>
                    <asp:Button ID="UnderlineBtn" runat="server" Text="_" Font-Bold="True" Font-Size="20px" OnClick="TextStyle"/>
                </td>
                <td>
                    <asp:Button ID="h1Btn" runat="server" Text="h1" Font-Size="20px" OnClick="TextStyle"/>
                </td>
                <td>
                    <asp:Button ID="h2Btn" runat="server" Text="h2" Font-Size="20px" OnClick="TextStyle"/>
                </td>
                <td>
                    <asp:Button ID="h3Btn" runat="server" Text="h3" Font-Size="20px" OnClick="TextStyle"/>
                </td>
            </tr>
        </table> --%>
    </div>
    <br />
    <asp:TextBox ID="EditTextBox" runat="server" Width="100%" TextMode="MultiLine"></asp:TextBox>
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
