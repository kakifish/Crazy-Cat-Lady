<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Cats.EditorFolder.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeaderText" runat="server">
    Editor Registration 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:Label ID="ThankYouLabel" runat="server" Text="Thank you for the registration, please wait for authorization (you will get email with our response). Meanwhile you can anjoy our website without the editor features" Font-Bold="True" Font-Italic="True" Font-Size="XX-Large"></asp:Label>
        <table id="RegisterTable" runat="server">
            <tr>
                <td>
                    <asp:Label ID="RegisterLabel" runat="server" Text="Register" BorderStyle="None" Font-Bold="True" Font-Italic="True" Font-Overline="False" Font-Size="X-Large" Font-Strikeout="False" Font-Underline="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="FirstNameLabel" runat="server" Text="First Name" Font-Size="Large"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="FirstNameTextBox" runat="server"></asp:TextBox>        
                </td>
                <td>
                    <asp:Label ID="FirstName_Validator" runat="server" Text="you have to enter a name" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>                
                    <asp:Label ID="LastNameLabel" runat="server" Text="Last Name" Font-Size="Large"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="LastNameTextBox" runat="server"></asp:TextBox>        
                </td>
                <td>
                    <asp:Label ID="LastName_Validator" runat="server" Text="you have to enter last name" ForeColor="Red"></asp:Label>                    
                </td>
            </tr>
            <tr>
                <td>                
                    <asp:Label ID="UserNameLabel" runat="server" Text="Username" Font-Size="Large"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="UserNameTextBox" runat="server"></asp:TextBox>        
                </td>
                <td>
                    <asp:Label ID="UserName_Validator" runat="server" Text="you have to enter username" ForeColor="Red"></asp:Label>                    
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
                    <asp:Label ID="Password_Validator" runat="server" Text="you have to enter password" ForeColor="Red"></asp:Label>                    
                </td>
            </tr>
            <tr>
                <td>                
                    <asp:Label ID="EmailLabel" runat="server" Text="E-Mail" Font-Size="Large"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="EmailTextBox" runat="server"></asp:TextBox>        
                </td>
                <td>
                    <asp:Label ID="Email_Validator" runat="server" Text="you have to enter email" ForeColor="Red"></asp:Label>                    
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="RegisterButton" runat="server" Text="Register" OnClick="RegisterButton_Click" Font-Bold="True" Font-Size="Large" />
                </td>
            </tr>
        </table>        
    </div>
</asp:Content>
