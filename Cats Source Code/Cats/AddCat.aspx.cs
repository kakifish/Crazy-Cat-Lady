using System;

namespace Cats
{
    public partial class AddCat : System.Web.UI.Page
    {
        private CatBL _catBL;
        private bool _admin;

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
            _admin = Convert.ToBoolean(Request.QueryString["admin"]);
            _catBL = new CatBL(!_admin);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        //protected void TextStyle(object sender, EventArgs e)
        //{
        //    var btn = (Button)sender;
        //    var btnText = btn.Text;
        //    if (btnText.Equals("b"))
        //    {

        //    }
        //    else if (btnText.Equals("/"))
        //    {

        //    }
        //    else if (btnText.Equals("_"))
        //    {

        //    }
        //    else if (btnText.Equals("h1"))
        //    {

        //    }
        //    else if (btnText.Equals("h2"))
        //    {

        //    }
        //    else if (btnText.Equals("h3"))
        //    {
        //        textDiv.InnerHtml += "catInformation";
        //    }
        //}

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            //ADD IMAGE!!!!!!!!!!!!
            var breed = CatBreedNameTextBox.Text.Trim();
            var country = CountryTextBox.Text.Trim();
            var origin = OriginTextBox.Text.Trim();
            var bodyType = BodyTypeTextBox.Text.Trim();
            var coat = CoatTextBox.Text.Trim();
            var pattern = PatternTextBox.Text.Trim();
            var image = "";
            var information = EditTextBox.Text.Trim();

            var cat = new Cat(breed, country, origin, bodyType, coat, pattern, image, information);

            if (_admin == false)
            {
                _catBL.AddCat(cat, "new cat");
                Response.Write("<script>alert('You successfully added a breed, the changes are waiting for the approval of the administrator');</script>");
            }
            else
            {
                if (_catBL.AddCat(cat, ""))
                {
                    Response.Write("<script>alert('You successfully added a breed');</script>");
                    return;
                }
                Response.Write("<script>alert('Breed is already exists, try the add specifications page');</script>");
            }
            Page_Load(sender, e);
        }
    }
}