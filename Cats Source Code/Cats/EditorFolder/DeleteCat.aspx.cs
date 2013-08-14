using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using MailMessage = System.Net.Mail.MailMessage;
using NetworkCredential = System.Net.NetworkCredential;

namespace Cats.EditorFolder
{
    public partial class DeleteCat : System.Web.UI.Page
    {
        private bool _admin;
        private LinkedList<Cat> _catsList;
        private CatBL _userCatBL;
        private CatBL _adminCatBL;

        protected void Page_PreInit(Object sender, EventArgs e)
        {
            _admin = Convert.ToBoolean(Request.QueryString["admin"]);
            if (_admin)
            {
                MasterPageFile = "~/EditorFolder/Editor.Master";
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            _userCatBL = new CatBL(false);
            _adminCatBL = new CatBL(true);
            ChooseBreed_Validator.Visible = false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            _catsList = _userCatBL.GetAllCats();

            var dt = new DataTable();
            var dcBreed = new DataColumn("Breed", typeof(string));
            var dcCountry = new DataColumn("Country", typeof(string));
            var dcOrigin = new DataColumn("Origin", typeof(string));
            var dcBodyType = new DataColumn("Body Type", typeof(string));
            var dcCoat = new DataColumn("Coat", typeof(string));
            var dcPattern = new DataColumn("Pattern", typeof(string));
            var dcImage = new DataColumn("Image", typeof(string));

            dt.Columns.AddRange(new[] { dcBreed, dcCountry, dcOrigin, dcBodyType, dcCoat, dcPattern, dcImage });

            ChooseBreedDropDownList.Items.Add("Choose Breed");

            for (var i = 0; i < _catsList.Count; i++)
            {
                ChooseBreedDropDownList.Items.Add(_catsList.ElementAt(i).GetBreed().Trim());

                dt.Rows.Add(new object[]
                    {
                        _catsList.ElementAt(i).GetBreed().Trim(), _catsList.ElementAt(i).GetCountry().Trim(),
                        _catsList.ElementAt(i).GetOrigin().Trim(), _catsList.ElementAt(i).GetBodyType().Trim(),
                        _catsList.ElementAt(i).GetCoat().Trim(), _catsList.ElementAt(i).GetPattern().Trim(),
                        ResolveUrl(_catsList.ElementAt(i).GetImage().Trim())
                    });
            }

            AllBreedGrid.DataSource = dt;
            AllBreedGrid.DataBind();
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            var breed = ChooseBreedDropDownList.SelectedItem.Text;
            if (breed.Equals("Choose Breed"))
            {
                ChooseBreed_Validator.Visible = true;
                return;
            }
            ChooseBreed_Validator.Visible = false;
            var cat = _userCatBL.GetCat(breed);
            _adminCatBL.AddCat(cat, "deleted cat");
            _userCatBL.DeleteCat(breed);

            SendMail(cat);

            Response.Write("<script>alert('You successfully deleted a breed, email has been sent to the administrator');</script>");

            ChooseBreedDropDownList.Items.Clear();

            Page_Load(sender, e);
        }

        private static void SendMail(Cat cat)
        {
            try
            {
                var loginInfo = new NetworkCredential("kakifish1@gmail.com", "V746025625VLADIMIRNO");
                var msg = new MailMessage { From = new MailAddress("kakifish1@gmail.com") };
                msg.To.Add(new MailAddress("kakifish1@gmail.com"));
                msg.Subject = "Cats!!";
                msg.Body = "<p>Cat deleted:</p><p><b>breed:</b></p><p>" + cat.GetBreed() + "</p>country" + cat.GetCountry() + "</p><p><b>origin:</b> " + cat.GetOrigin() + "</p><p><b>body type:</b> " + cat.GetBodyType() + "</p><p><b>coat:</b> " + cat.GetCoat() + "</p><p><b>pattern:</b> " + cat.GetPattern() + "</p><p><b>image:</b> " + cat.GetImage() + "</p><p><b>information:</b> " + cat.GetInfo() + "</p>";
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