<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchBreed.aspx.cs" Inherits="Cats.SearchBreed" %>
<asp:Content ID="head" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="header" ContentPlaceHolderID="HeaderText" runat="server">
    Search For Breed
</asp:Content>
<asp:Content ID="main" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <div>
        <asp:GridView ID="SearchCatGrid" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Height="150px" Width="100%">
            <Columns>
                <asp:TemplateField HeaderText="Breed"></asp:TemplateField>
                <asp:TemplateField HeaderText="Country"></asp:TemplateField>
                <asp:TemplateField HeaderText="Origin"></asp:TemplateField>
                <asp:TemplateField HeaderText="Body Type"></asp:TemplateField>
                <asp:TemplateField HeaderText="Coat"></asp:TemplateField>
                <asp:TemplateField HeaderText="Pattern"></asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>
    </div>
    <div>
        <br />        
        <br />
        <table class="searchCatButtonTable">
            <tr>
                <td>
                    <asp:Button id="SearchForBreedName" runat="server" type="button" Text="Search For Breed Name" onclick="SearchForBreedName_Click"></asp:Button>

                </td>
                <td>
                    <asp:Button id="SearchInformation" runat="server" type="button" Text="Search Information About Breed" onclick="SearchInformation_Click"/>
                </td>
            </tr>
        </table>
        <br />
    </div>
    <div>
        <br />
        <asp:Label ID="CatBreedName" runat="server" Visible="False" Font-Size="XX-Large" Font-Underline="True" ForeColor="#3333CC"></asp:Label>
        <br />
        <asp:Image ID="CatImage" runat="server" ImageAlign="Middle" Visible="False"/>
        <br />
        <textarea class="textarea" id="CatText" runat="server" Visible="False" spellcheck="True" rows="1" style="width: 99.5%" ></textarea>
    </div>
    <div>
        <br />
        <br />
        <table class="searchCatButtonTable">
            <tr>
                <td>
                    <asp:Button ID="EditTextButton" runat="server" Text="Edit Text" OnClick="EditTextButton_Click" Visible="False" />
                </td>
                <td>
                    <asp:Button ID="SubmitTextChangesButton" runat="server" Text="Submit Changes" Visible="False" OnClick="SubmitTextChangesButton_Click"/>   
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
