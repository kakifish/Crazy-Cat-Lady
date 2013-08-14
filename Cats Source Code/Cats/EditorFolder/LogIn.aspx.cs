using System;

namespace Cats.EditorFolder
{
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Username_Validator.Visible = false;
            Password_Validator.Visible = false;
            ErrorLabel.Visible = false;
            SorryLabel.Visible = false;
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            var userName = UsernameTextBox.Text.Trim();
            var password = PasswordTextBox.Text.Trim();
            var validateEmpty = userName.Equals("") || password.Equals("");
            if (validateEmpty)
            {
                if (userName.Equals(""))
                {
                    Username_Validator.Visible = true;
                }
                if (password.Equals(""))
                {
                    Password_Validator.Visible = true;
                }
            }
            else
            {
                var editorBL = new EditorBL();
                var editor = editorBL.GetEditor(userName);
                if (editor != null)
                {
                    if (editor.GetAuthorized() == 1)
                    {
                        Response.Redirect("~/EditorFolder/EditorsDefault.aspx");                        
                    }
                    else
                    {
                        RegisterLink.Visible = false;
                        LoginTable.Visible = false;
                        SorryLabel.Visible = true;
                    }
                }
                else
                {
                    ErrorLabel.Visible = true;
                }
            }
        }
    }
}