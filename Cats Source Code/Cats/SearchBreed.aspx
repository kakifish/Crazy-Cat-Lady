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
        <table style="width: 100%">
            <tr>
                <td style="width: 31%">
                    <asp:Label ID="NoBreedNameLabel" runat="server" Text="Choose Breed" Visible="False" ForeColor="Red" Font-Bold="True" Font-Size="Large"  Width="100%"></asp:Label>
                </td>
                <td style="width: 20%">
                    <asp:Label ID="NoBodyTypeLabel" runat="server" Text="Choose Body Type" Visible="False" ForeColor="Red" Font-Bold="True" Font-Size="Large" Width="100%"></asp:Label>
                </td>
                <td style="width: 21%">
                    <asp:Label ID="NoCoatLabel" runat="server" Text="Choose Coat" Visible="False" ForeColor="Red" Font-Bold="True" Font-Size="Large" Width="100%"></asp:Label>
                </td>
                <td style="width: 28%">
                    <asp:Label ID="NoPatternLabel" runat="server" Text="Choose Pattern" Visible="False" ForeColor="Red" Font-Bold="True" Font-Size="Large" Width="100%"></asp:Label>
                </td>
            </tr>
        </table>        
    </div>
    <div>
        <br />        
      <br />
        <table class="searchCatButtonTable">
            <tr>
                <td>
                    <asp:Button id="SearchInformation" runat="server" type="button" Text="Search Information About Breed" onclick="SearchInformation_Click"/>
                </td>
                <td>
                    <asp:Button id="SearchForBreedName" runat="server" type="button" Text="Search For Breed Name" onclick="SearchForBreedName_Click"></asp:Button>
                </td>
            </tr>
        </table>
        <br />
    </div>

    <div>
        <asp:GridView ID="WantedBreedGrid" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Height="100%" Width="100%">
            <Columns>
                <asp:BoundField HeaderText="Breed" DataField="Breed" />
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

    <div>
        <br />
        <asp:Label ID="CatBreedName" runat="server" Visible="False" Font-Size="XX-Large" Font-Underline="True" ForeColor="#3333CC" style="margin-left: 40%"></asp:Label>
        <br />
        <asp:Image ID="CatImage" runat="server" ImageAlign="Middle" Visible="False" style="margin-left: 42%"/>
        <br />
        <table id="LabelsTable" runat="server" class="specificationsLabelsTable">
            <tr>
                <td>
                    <asp:Label ID="SpecificationsLable" runat="server" Text="Specifications: " Font-Size="Large" Font-Bold="True" Font-Underline="True"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="CountryLabel" runat="server" Text="Country: " Font-Size="Large" Font-Bold="True" Font-Underline="True"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="OriginLabel" runat="server" Text="Origin: " Font-Size="Large" Font-Bold="True" Font-Underline="True"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="BodyTypeLabel" runat="server" Text="Body Type: " Font-Size="Large" Font-Bold="True" Font-Underline="True"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="CoatLabel" runat="server" Text="Coat: " Font-Size="Large" Font-Bold="True" Font-Underline="True"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="PatternLabel" runat="server" Text="Pattern: " Font-Size="Large" Font-Bold="True" Font-Underline="True"></asp:Label>
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
    <div id="textDiv" runat="server" style="font-size: large">
    </div>
    <asp:TextBox ID="EditTextBox" runat="server" Width="100%" TextMode="MultiLine"></asp:TextBox>
    <div>
        <br />
        <br />
        <table class="searchCatButtonTable">
            <tr>
                <td>
                    <asp:Button ID="EditTextButton" runat="server" Text="Edit Text" OnClick="EditTextButton_Click" Visible="False" />
                </td>
            </tr>
        </table>
        <table class="searchCatButtonTable">
            <tr>
                <td>
                    <asp:Button ID="SubmitButton" runat="server" Text="Submit Changes" Visible="False" OnClick="SubmitButton_Click" />
                </td>
            </tr>
        </table>
    </div>
 </asp:Content>
