using System;

namespace Cats
{
    public partial class AddSpecifications : System.Web.UI.Page
    {
        private CatBL _catBL;
        private CatBL _userCatBL;
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
            _catBL = new CatBL(!_admin);
            _userCatBL = new CatBL(false);

            var catsList = _userCatBL.GetAllCats();
            ChooseBreedDownList.Items.Add("Choose Breed");
            foreach (var cat in catsList)
            {
                ChooseBreedDownList.Items.Add(cat.GetBreed());
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            CountryTextBox.Visible = false;
            OriginTextBox.Visible = false;
            BodyTypeTextBox.Visible = false;
            CoatTextBox.Visible = false;
            PatternTextBox.Visible = false;
            CatImage.Visible = false;
            //upload image
            ErrorLabel.Visible = false;
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            var breed = ChooseBreedDownList.SelectedItem.Text.Trim();
            var country = CountryTextBox.Text.Trim();
            var origin = OriginTextBox.Text.Trim();
            var bodyType = BodyTypeTextBox.Text.Trim();
            var coat = CoatTextBox.Text.Trim();
            var pattern = PatternTextBox.Text.Trim();
            var image = "";

            var specifications = new string[6];
            specifications[0] = "Country";
            specifications[1] = "Origin";
            specifications[2] = "Body Type";
            specifications[3] = "Coat";
            specifications[4] = "Pattern";
            specifications[5] = "Image";
            var specificationsValues = new string[7];
            specificationsValues[0] = country;
            specificationsValues[1] = origin;
            specificationsValues[2] = bodyType;
            specificationsValues[3] = coat;
            specificationsValues[4] = pattern;
            specificationsValues[5] = image;

            if (_admin == false)
            {
                var cat = _userCatBL.GetCat(breed);
                var newCat = new Cat(breed, country, origin, bodyType, coat, pattern, cat.GetInfo(), image);
                _catBL.AddCat(newCat, "specifications");
            }
            else
            {
                _catBL.AddSpecificationsToBreed(breed, specifications, specificationsValues);
            }
            Response.Write(_admin
                ? "<script>alert('You successfully added specifications');</script>"
                : "<script>alert('You successfully added specifications, the changes are waiting for the approval of the administrator');</script>");
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            if (!ChooseBreedDownList.SelectedItem.Text.Equals("Choose Breed"))
            {
                CountryTextBox.Visible = true;
                OriginTextBox.Visible = true;
                BodyTypeTextBox.Visible = true;
                CoatTextBox.Visible = true;
                PatternTextBox.Visible = true;
                CatImage.Visible = false;
                //upload image
                var cat = _userCatBL.GetCat(ChooseBreedDownList.SelectedItem.Text);
                var imageUrl = cat.GetImage();
                CatImage.ImageUrl = ResolveUrl(imageUrl ?? "~/CatPictures/catNotFound.jpg");
                CatImage.Visible = true;
                CountryTextBox.Text = cat.GetCountry();
                OriginTextBox.Text = cat.GetOrigin();
                BodyTypeTextBox.Text = cat.GetBodyType();
                CoatTextBox.Text = cat.GetCoat();
                PatternTextBox.Text = cat.GetPattern();
            }
            else
            {
                CountryTextBox.Visible = false;
                OriginTextBox.Visible = false;
                BodyTypeTextBox.Visible = false;
                CoatTextBox.Visible = false;
                CatImage.Visible = false;
                //upload image
                ErrorLabel.Visible = true;
            }
        }
    }
}