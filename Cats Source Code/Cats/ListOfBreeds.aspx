<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListOfBreeds.aspx.cs" Inherits="Cats.ListOfBreeds" %>
<asp:Content ID="head" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="header" ContentPlaceHolderID="HeaderText" runat="server">
    Cat Breeds List
</asp:Content>
<asp:Content ID="main" ContentPlaceHolderID="MainContent" runat="server">
<br/>
<br/>
<div>
    <asp:GridView ID="AllBreedGrid" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Height="100%" Width="100%">
        <Columns>
            <asp:BoundField HeaderText="Breed" DataField="Breed" />
            <asp:BoundField HeaderText="Country" DataField="Country" />
            <asp:BoundField HeaderText="Origin" DataField="Origin" />
            <asp:BoundField HeaderText="Body Type" DataField="Body Type" />
            <asp:BoundField HeaderText="Coat" DataField="Coat" />
            <asp:BoundField HeaderText="Pattern" DataField="Pattern" />
            <asp:ImageField HeaderText="Image" DataImageUrlField="Image">
            </asp:ImageField>
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
