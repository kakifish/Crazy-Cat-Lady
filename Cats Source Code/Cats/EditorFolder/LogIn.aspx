<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="Cats.EditorFolder.LogIn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeaderText" runat="server">
    Log In As Editor
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:Label ID="SorryLabel" runat="server" Text="We are sorry, you have not been authorization yet. Meanwhile you can anjoy our website without the editor features" Font-Bold="True" Font-Italic="True" Font-Size="XX-Large"></asp:Label>
        <asp:HyperLink ID="RegisterLink" runat="server" NavigateUrl="~/EditorFolder/Register.aspx" ForeColor="#6600FF"><h1>Click Here To Register</h1></asp:HyperLink>
    </div>
    <br/>
    <div>
        <table id="LoginTable" runat="server">
            <tr>
                <td>
                    <asp:Label ID="LoginLabel" runat="server" Text="Login" BorderStyle="None" Font-Bold="True" Font-Italic="True" Font-Overline="False" Font-Size="X-Large" Font-Strikeout="False" Font-Underline="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="UsernameLabel" runat="server" Text="Username" Font-Size="Large"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="UsernameTextBox" runat="server"></asp:TextBox>        
                </td>
                <td>
                    <asp:Label ID="Username_Validator" runat="server" Text="invalid username, please try again" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>                
                    <asp:Label ID="PasswordLabel" runat="server" Text="Password" Font-Size="Large"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="PasswordTextBox" runat="server"></asp:TextBox>        
                </td>
                <td>
                    <asp:Label ID="Password_Validator" runat="server" Text="invalid password, please try again" ForeColor="Red"></asp:Label>                    
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="ErrorLabel" runat="server" Text="Password or username are incorrect" Font-Size="Medium" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="LoginButton" runat="server" Text="Login" Font-Bold="True" Font-Size="Large" OnClick="LoginButton_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
