using System;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cats
{
    public partial class SearchBreed : Page
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
            _catBL = new CatBL(_admin);
            _userCatBL = new CatBL(false);

            var dt = new DataTable();

            dt.Rows.Add();
            SearchCatGrid.DataSource = dt;
            SearchCatGrid.DataBind();

            var breedList = _userCatBL.GetListOfSpecification("Breed");
            var bodyTypeList = _userCatBL.GetListOfSpecification("Body type");
            var coatList = _userCatBL.GetListOfSpecification("Coat");
            var patternList = _userCatBL.GetListOfSpecification("Pattern");

            var breed = new DropDownList();
            var bodyType = new DropDownList();
            var coat = new DropDownList();
            var pattern = new DropDownList();
            breed.Items.Add(new ListItem("Choose Breed"));
            bodyType.Items.Add(new ListItem("Choose Body Type"));
            coat.Items.Add(new ListItem("Choose Coat"));
            pattern.Items.Add(new ListItem("Choose Pattern"));
            
            foreach (var node in breedList)
            {
                breed.Items.Add(new ListItem(node.Trim()));
            }
            foreach (var node in bodyTypeList)
            {
                bodyType.Items.Add(new ListItem(node.Trim()));
            }
            foreach (var node in coatList)
            {
                coat.Items.Add(new ListItem(node.Trim()));
            }
            foreach (var node in patternList)
            {
                pattern.Items.Add(new ListItem(node.Trim()));
            }

            SearchCatGrid.Rows[0].Cells[0].Controls.Add(breed);
            SearchCatGrid.Rows[0].Cells[1].Controls.Add(bodyType);
            SearchCatGrid.Rows[0].Cells[2].Controls.Add(coat);
            SearchCatGrid.Rows[0].Cells[3].Controls.Add(pattern);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            NoBreedNameLabel.Visible = false;
            NoBodyTypeLabel.Visible = false;
            NoCoatLabel.Visible = false;
            NoPatternLabel.Visible = false;
            WantedBreedGrid.Visible = false;
            EditTextButton.Visible = false;
            CatBreedName.Visible = false;
            CatImage.Visible = false;
            SubmitButton.Visible = false;
            textDiv.Visible = false;
            EditTextBox.Visible = false;
            LabelsTable.Visible = false;
            tempDiv.Visible = false;
        }

        protected void SearchForBreedName_Click(object sender, EventArgs e)
        {
            var bodyType = ((DropDownList)(SearchCatGrid.Rows[0].Cells[1].Controls[0])).SelectedItem.Text.Trim();
            var coat = ((DropDownList)(SearchCatGrid.Rows[0].Cells[2].Controls[0])).SelectedItem.Text.Trim();
            var pattern = ((DropDownList)(SearchCatGrid.Rows[0].Cells[3].Controls[0])).SelectedItem.Text.Trim();

            var specifications = new string[3];
            specifications[0] = bodyType;
            specifications[1] = coat;
            specifications[2] = pattern;
            var catsList = _userCatBL.FindBreedBySpecifications(specifications);

            if (catsList.Count != 0)
            {
                var dt = new DataTable();
                var dcBreed = new DataColumn("Breed", typeof(string));
                var dcImage = new DataColumn("Image", typeof(string));

                dt.Columns.AddRange(new[] { dcBreed, dcImage });

                for (var i = 0; i < catsList.Count; i++)
                {
                    var imageUrl = catsList.ElementAt(i).GetImage().Trim();
                    if (imageUrl.Trim().Equals(""))
                    {
                        imageUrl = "~/CatPictures/catNotFoundSmall.jpg";
                    }
                    dt.Rows.Add(new object[]
                        {
                            catsList.ElementAt(i).GetBreed().Trim(), 
                            ResolveUrl(imageUrl)
                        });
                }

                WantedBreedGrid.DataSource = dt;
                WantedBreedGrid.DataBind();
                WantedBreedGrid.Visible = true;
            }
            else
            {
                NoBodyTypeLabel.Visible = true;
                NoCoatLabel.Visible = true;
                NoPatternLabel.Visible = true;
            }
        }

        protected void SearchInformation_Click(object sender, EventArgs e)
        {
            var selectedBreedName = ((DropDownList) (SearchCatGrid.Rows[0].Cells[0].Controls[0])).SelectedItem.Text.Trim();
            if (!selectedBreedName.Equals("Choose Breed"))
            {
                var cat = _userCatBL.GetCat(selectedBreedName);
                var imageUrl = cat.GetImage();
                CatImage.ImageUrl = ResolveUrl(imageUrl ?? "~/CatPictures/catNotFound.jpg");
                CatImage.Visible = true;
                var catInformation = cat.GetInfo();
                if (catInformation.Trim().Equals("") || catInformation.Trim().Equals("NULL"))
                {
                    catInformation = "##h1**Sorry, No Information Avalible For This Breed##/h1**";
                }
                textDiv.Visible = true;
                var replace = catInformation;
                replace = replace.Replace("##", "<");
                replace = replace.Replace("**", ">");
                textDiv.InnerHtml = replace;
                EditTextButton.Visible = true;
                CatBreedName.Text = selectedBreedName;
                CatBreedName.Visible = true;
                CountryLabel.Text = "Country: " + cat.GetCountry();
                OriginLabel.Text = "Origin: " + cat.GetOrigin();
                BodyTypeLabel.Text = "Body Type: " + cat.GetBodyType();
                CoatLabel.Text = "Coat: " + cat.GetCoat();
                PatternLabel.Text = "Pattern: " + cat.GetPattern();
                LabelsTable.Visible = true;
            }
            else
            {
                NoBreedNameLabel.Visible = true;
            }
        }

        protected void EditTextButton_Click(object sender, EventArgs e)
        {
            CatImage.Visible = true;
            CatBreedName.Visible = true;
            SubmitButton.Visible = true;
            var replace = textDiv.InnerHtml.Trim();
            replace = replace.Replace("<", "##");
            replace = replace.Replace(">", "**");
            EditTextBox.Text = replace;
            EditTextBox.Visible = true;
            tempDiv.Visible = true;
            EditTextBox.Focus();
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            var replace = EditTextBox.Text.Trim();
            replace = replace.Replace("##", "<");
            replace = replace.Replace("**", ">");
            textDiv.InnerHtml = replace;
            CatImage.Visible = true;
            CatBreedName.Visible = true;
            EditTextButton.Visible = true;
            var cat = _userCatBL.GetCat(CatBreedName.Text.Trim());
            _catBL = new CatBL(!_admin);
            if (_admin == false)
            {
                _catBL.AddCat(new Cat(cat.GetBreed(), cat.GetCountry(), cat.GetOrigin(), cat.GetBodyType(), cat.GetCoat(), cat.GetPattern(), cat.GetImage(), EditTextBox.Text.Trim()), "information");
            }
            else
            {
                _userCatBL.AddSpecificationToBreed(CatBreedName.Text, "Information", EditTextBox.Text.Trim());                
            }
            textDiv.Visible = true;
            Response.Write(_admin
                ? "<script>alert('You successfully edited the information of the breed');</script>"
                : "<script>alert('You successfully edited the information of the breed, the changes are waiting for the approval of the administrator');</script>");
        }

        //protected void TextStyle(object sender, EventArgs e)
        //{
        //    var btn = (Button) sender;
        //    var btnText = btn.Text;
        //    var style = "";
        //    if (btnText.Equals("B"))
        //    {
        //        style = "b";
        //    }
        //    else if (btnText.Equals("/"))
        //    {
        //        style = "i";
        //    }
        //    else if (btnText.Equals("_"))
        //    {
        //        style = "";
        //    }
        //    else if (btnText.Equals("h1"))
        //    {
        //        style = "h1";
        //    }
        //    else if (btnText.Equals("h2"))
        //    {
        //        style = "h2";
        //    }
        //    else if (btnText.Equals("h3"))
        //    {
        //        style = "h3";
        //    }

        //    EditTextBox.Focus();
        //    //EditTextBox.Text = EditTextBox.Text.Insert(EditTextBox., "''" + style + "** Insert Text Here ''/" + style + "**");
            
        //    CatImage.Visible = true;
        //    CatBreedName.Visible = true;
        //    SubmitButton.Visible = true;
        //    ChangeFontTable.Visible = true;
        //    EditTextBox.Visible = true;
        //    //textDiv.Attributes["contenteditable"] = "true";
        //}
    }
}