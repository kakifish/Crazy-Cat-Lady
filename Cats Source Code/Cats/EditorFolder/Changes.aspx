<%@ Page Title="" Language="C#" MasterPageFile="~/EditorFolder/Editor.Master" AutoEventWireup="true" CodeBehind="Changes.aspx.cs" Inherits="Cats.EditorFolder.Changes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeaderText" runat="server">
    Changes From Users
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <br/>
    <br/>
    <div>
        <asp:GridView ID="AllBreedGrid" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Height="100%" Width="100%" OnRowCommand="AllBreedGrid_OnRowCommand">
            <Columns>
                <asp:BoundField HeaderText="Breed" DataField="Breed" />
                <asp:BoundField HeaderText="Country" DataField="Country" />
                <asp:BoundField HeaderText="Origin" DataField="Origin" />
                <asp:BoundField HeaderText="Body Type" DataField="Body Type" />
                <asp:BoundField HeaderText="Coat" DataField="Coat" />
                <asp:BoundField HeaderText="Pattern" DataField="Pattern" />
                <asp:BoundField HeaderText="Information" DataField="Information" />
                <asp:ImageField HeaderText="Image" DataImageUrlField="Image">
                </asp:ImageField>
                <asp:BoundField HeaderText="Change" DataField="Change" />
                <asp:ButtonField ButtonType="Button" Text="Confirm" CommandName="ConfirmButton">
                <ControlStyle BackColor="#CCFFFF" Font-Size="Large" ForeColor="#0000CC" />
                </asp:ButtonField>
                <asp:ButtonField ButtonType="Button" Text="Discard" CommandName="DiscardButton">
                <ControlStyle BackColor="Black" Font-Size="Large" ForeColor="Red" />
                </asp:ButtonField>
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#000066" CssClass=""/>
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" Font-Names="Segoe Print" Font-Size="Large" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>
    </div>
</asp:Content>
