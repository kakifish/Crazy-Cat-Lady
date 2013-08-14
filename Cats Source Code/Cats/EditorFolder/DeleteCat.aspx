<%@ Page Title="" Language="C#" MasterPageFile="~/EditorFolder/Editor.Master" AutoEventWireup="true" CodeBehind="DeleteCat.aspx.cs" Inherits="Cats.EditorFolder.DeleteCat" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeaderText" runat="server">
    Delete Breed
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <br/>
    <div>
        <asp:Label ID="ChooseBreedLabel" runat="server" Text="Choose Breed To Delete" Font-Size="Large"></asp:Label>
        <asp:DropDownList ID="ChooseBreedDropDownList" runat="server"></asp:DropDownList>
        <asp:Button ID="DeleteButton" runat="server" Text="Delete" BackColor="Black" Font-Size="Medium" ForeColor="Red" OnClick="DeleteButton_Click" />
        <asp:Label ID="ChooseBreed_Validator" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red" Text="Please choose a breed to delete"></asp:Label>
    </div>
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
