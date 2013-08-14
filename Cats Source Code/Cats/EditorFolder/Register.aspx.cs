using System;
using System.Linq;
using System.Net.Mail;
using System.Web.UI;
using System.Web.UI.WebControls;
using MailMessage = System.Net.Mail.MailMessage;
using NetworkCredential = System.Net.NetworkCredential;

namespace Cats.EditorFolder
{
    public partial class Register : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FirstName_Validator.Visible = false;
            LastName_Validator.Visible = false;
            UserName_Validator.Visible = false;
            Password_Validator.Visible = false;
            Email_Validator.Visible = false;
            ThankYouLabel.Visible = false;
        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            var textboxes = Controls.FindAll().OfType<TextBox>(); 
            var validator = textboxes.Any(t => t.Text.Trim().Equals(""));

            var firstName = FirstNameTextBox.Text.Trim();
            var lastName = LastNameTextBox.Text.Trim();
            var userName = UserNameTextBox.Text.Trim();
            var password = PasswordTextBox.Text.Trim();
            var email = EmailTextBox.Text.Trim();

            if (validator)
            {
                if (firstName.Equals(""))
                {
                    FirstName_Validator.Visible = true;
                }
                if (lastName.Equals(""))
                {
                    LastName_Validator.Visible = true;
                }
                if (userName.Equals(""))
                {
                    UserName_Validator.Text = "you have to enter username";
                    UserName_Validator.Visible = true;
                }
                if (password.Equals(""))
                {
                    Password_Validator.Visible = true;
                }
                if (email.Equals(""))
                {
                    Email_Validator.Visible = true;
                }
            }
            else
            {
                var editor = new Editor(firstName, lastName, userName, password, email, 0);
                var editorBL = new EditorBL();
                if (editorBL.AddEditor(editor))
                {
                    SendMail(firstName, lastName, userName, email);
                    RegisterTable.Visible = false;
                    ThankYouLabel.Visible = true;
                }
                else
                {
                    UserName_Validator.Text = "Username already exist";
                    UserName_Validator.Visible = true;
                }
            }
        }

        private static void SendMail(string firstName, string lastName, string userName, string email)
        {
            try
            {
                var loginInfo = new NetworkCredential("kakifish1@gmail.com", "V746025625VLADIMIRNO");
                var msg = new MailMessage {From = new MailAddress("kakifish1@gmail.com")};
                msg.To.Add(new MailAddress("kakifish1@gmail.com"));
                msg.Subject = "Cats!!";
                msg.Body = "<p>Please check this editor:</p><p><b>name:</b></p><p>" + firstName + " " + lastName + "</p><p><b>username:</b> " + userName + "</p><p><b>email:</b> " + email + "</p>";
                msg.IsBodyHtml = true;
                var client = new SmtpClient("smtp.gmail.com")
                {
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    Credentials = loginInfo
                };
                client.Send(msg);
            }
            catch (Exception ex)
            {
                var msg = "Failed to send message: ";
                msg += ex.Message;
                throw new Exception(msg);
            }   
        }
    }
}