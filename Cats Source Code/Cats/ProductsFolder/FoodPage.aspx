<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FoodPage.aspx.cs" Inherits="Cats.ProductsFolder.FoodPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeaderText" runat="server">
    <asp:Label ID="FoodCategoryLabel" runat="server" Text="FoodCategory"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <br/>
    <br/>
    <div>
        <asp:GridView ID="FoodGrid" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Height="100%" Width="100%">
            <Columns>
                <asp:ImageField HeaderText="Image" DataImageUrlField="Image"></asp:ImageField>
                <asp:BoundField HeaderText="Product Name" DataField="Product Name" />
                <asp:BoundField HeaderText="Brand" DataField="Brand" />
                <asp:BoundField HeaderText="Description" DataField="Description" />
                <asp:BoundField HeaderText="Weight" DataField="Weight" />
                <asp:BoundField HeaderText="Price" DataField="Price" />
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
