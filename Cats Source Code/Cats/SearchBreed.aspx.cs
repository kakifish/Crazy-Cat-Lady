using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cats
{
    public partial class SearchBreed : Page
    {
        private readonly CatBL _catBL = new CatBL();

        protected void Page_Init(object sender, EventArgs e)
        {
            var dt = new DataTable();

            dt.Rows.Add();
            SearchCatGrid.DataSource = dt;
            SearchCatGrid.DataBind();

            var breedList = _catBL.GetListOfSpecification("Breed");
            var countryList = _catBL.GetListOfSpecification("Country");
            var originList = _catBL.GetListOfSpecification("Origin");
            var bodyTypeList = _catBL.GetListOfSpecification("Body type");
            var coatList = _catBL.GetListOfSpecification("Coat");
            var patternList = _catBL.GetListOfSpecification("Pattern");

            var breed = new DropDownList();
            var country = new DropDownList();
            var origin = new DropDownList();
            var bodyType = new DropDownList();
            var coat = new DropDownList();
            var pattern = new DropDownList();
            breed.Items.Add(new ListItem("Choose Breed"));
            country.Items.Add(new ListItem("Choose Country"));
            origin.Items.Add(new ListItem("Choose Origin"));
            bodyType.Items.Add(new ListItem("Choose Body Type"));
            coat.Items.Add(new ListItem("Choose Coat"));
            pattern.Items.Add(new ListItem("Choose Pattern"));
            
            foreach (var node in breedList)
            {
                breed.Items.Add(new ListItem(node.Trim()));
            }
            foreach (var node in countryList)
            {
                country.Items.Add(new ListItem(node.Trim()));
            }
            foreach (var node in originList)
            {
                origin.Items.Add(new ListItem(node.Trim()));
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
            SearchCatGrid.Rows[0].Cells[1].Controls.Add(country);
            SearchCatGrid.Rows[0].Cells[2].Controls.Add(origin);
            SearchCatGrid.Rows[0].Cells[3].Controls.Add(bodyType);
            SearchCatGrid.Rows[0].Cells[4].Controls.Add(coat);
            SearchCatGrid.Rows[0].Cells[5].Controls.Add(pattern);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void SearchForBreedName_Click(object sender, EventArgs e)
        {

        }

        protected void SearchInformation_Click(object sender, EventArgs e)
        {
            var selectedBreedName = ((DropDownList) (SearchCatGrid.Rows[0].Cells[0].Controls[0])).SelectedItem.Text.Trim();
            if (!selectedBreedName.Equals("Choose Breed"))
            {
                var imageUrl = _catBL.FindCatImage(selectedBreedName);
                CatImage.ImageUrl = ResolveUrl(imageUrl ?? "~/CatPictures/catNotFound.jpg");
                CatImage.Visible = true;
                var catInformation = _catBL.GetBreedSpecification(selectedBreedName, "Information");
                CatText.InnerText = catInformation ?? "Soory, No Information Avalible For This Breed";
                if (catInformation != null)
                {
                    CatText.Rows = SetRowsToTextArea(catInformation);
                }
                CatText.Disabled = true;
                CatText.Visible = true;
                EditTextButton.Visible = true;
                SubmitTextChangesButton.Visible = true;
                CatBreedName.Text = selectedBreedName;
                CatBreedName.Visible = true;
            }
            else
            {
                //      message - breed was not chossen 
                for (var i = 0; i < 10; i++)
                {
                    Console.WriteLine("a");
                }
            }
        }

        private static int SetRowsToTextArea(string text)
        {
            return text.Length/100;
        }

        protected void EditTextButton_Click(object sender, EventArgs e)
        {
            CatText.Disabled = false;
        }

        protected void SubmitTextChangesButton_Click(object sender, EventArgs e)
        {
            if (!CatText.InnerText.Trim().Equals("") && !CatText.InnerText.Trim().Equals("Soory, No Information Avalible For This Breed"))
                _catBL.AddSpecificationToBreed(CatBreedName.Text, "Information", CatText.InnerText.Trim());
        }
    }
}