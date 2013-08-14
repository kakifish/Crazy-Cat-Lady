using System;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;

namespace Cats.EditorFolder
{
    public partial class Changes : System.Web.UI.Page
    {
        private bool _admin;
        private CatBL _catBL;
        private CatBL _userCatBL;

        protected void Page_PreInit(Object sender, EventArgs e)
        {
            _admin = Convert.ToBoolean(Request.QueryString["admin"]);
            if (_admin)
            {
                MasterPageFile = "~/EditorFolder/Editor.Master";
            }
        }

        protected void Page_Init(Object sender, EventArgs e)
        {
            _catBL = new CatBL(true);
            _userCatBL = new CatBL(false);    
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var catsList = _catBL.GetAllCatsWithChanges();

            var dt = new DataTable();
            var dcBreed = new DataColumn("Breed", typeof(string));
            var dcCountry = new DataColumn("Country", typeof(string));
            var dcOrigin = new DataColumn("Origin", typeof(string));
            var dcBodyType = new DataColumn("Body Type", typeof(string));
            var dcCoat = new DataColumn("Coat", typeof(string));
            var dcPattern = new DataColumn("Pattern", typeof(string));
            var dcInformation = new DataColumn("Information", typeof(string));
            var dcImage = new DataColumn("Image", typeof(string));
            var dcChange = new DataColumn("Change", typeof(string));

            dt.Columns.AddRange(new[] { dcBreed, dcCountry, dcOrigin, dcBodyType, dcCoat, dcPattern, dcInformation, dcImage, dcChange });

            for (var i = 0; i < catsList.Count; i++)
            {
                dt.Rows.Add(new object[]
                    {
                        catsList.ElementAt(i).GetBreed().Trim(), catsList.ElementAt(i).GetCountry().Trim(),
                        catsList.ElementAt(i).GetOrigin().Trim(), catsList.ElementAt(i).GetBodyType().Trim(),
                        catsList.ElementAt(i).GetCoat().Trim(), catsList.ElementAt(i).GetPattern().Trim(),
                        catsList.ElementAt(i).GetInfo(), ResolveUrl(catsList.ElementAt(i).GetImage().Trim()), 
                        catsList.ElementAt(i).GetChange()
                    });
            }

            AllBreedGrid.DataSource = dt;
            AllBreedGrid.DataBind();
        }

        protected void AllBreedGrid_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            var index = Convert.ToInt32(e.CommandArgument);
            var breed = AllBreedGrid.Rows[index].Cells[0].Text.Trim();
            var change = AllBreedGrid.Rows[index].Cells[8].Text.Trim();

            if (change.Equals("deleted cat"))
            {
                if (e.CommandName == "ConfirmButton")
                {
                    _catBL.DeleteCat(breed);
                    var src = "<script>alert('You have permenantly deleted the breed: " + breed + "');</script>";
                    Response.Write(src);
                }
                else
                {
                    var cat = _catBL.GetCat(breed);
                    _userCatBL.AddCat(cat, "");
                    _catBL.DeleteCat(breed);
                    var src = "<script>alert('You have restored the breed: " + breed + "');</script>";
                    Response.Write(src);
                }
            }
            else if (change.Equals("information"))
            {
                var information = AllBreedGrid.Rows[index].Cells[6].Text.Trim();
                if (e.CommandName == "ConfirmButton")
                {
                    _userCatBL.AddSpecificationToBreed(breed, "Information", information);
                }
                _catBL.DeleteRow(index);
            }
            else if (change.Equals("new cat"))
            {
                var country = AllBreedGrid.Rows[index].Cells[1].Text.Trim();
                var origin = AllBreedGrid.Rows[index].Cells[2].Text.Trim();
                var bodyType = AllBreedGrid.Rows[index].Cells[3].Text.Trim();
                var coat = AllBreedGrid.Rows[index].Cells[4].Text.Trim();
                var pattern = AllBreedGrid.Rows[index].Cells[5].Text.Trim();
                var image = AllBreedGrid.Rows[index].Cells[7].Text.Trim();
                var information = AllBreedGrid.Rows[index].Cells[6].Text.Trim();

                var cat = new Cat(breed, country, origin, bodyType, coat, pattern, image, information);

                if (e.CommandName == "ConfirmButton")
                {
                    string src;
                    if (_userCatBL.AddCat(cat, ""))
                    {
                        src = "<script>alert('You have added the breed: " + breed + "');</script>";                        
                    }
                    else
                    {
                        src = "<script>alert('Breed: " + breed + " is already exists');</script>";                        
                    }
                    Response.Write(src);
                }
                _catBL.DeleteRow(index);
            }
            else if (change.Equals("specifications"))
            {
                var country = AllBreedGrid.Rows[index].Cells[1].Text.Trim();
                var origin = AllBreedGrid.Rows[index].Cells[2].Text.Trim();
                var bodyType = AllBreedGrid.Rows[index].Cells[3].Text.Trim();
                var coat = AllBreedGrid.Rows[index].Cells[4].Text.Trim();
                var pattern = AllBreedGrid.Rows[index].Cells[5].Text.Trim();
                var image = AllBreedGrid.Rows[index].Cells[7].Text.Trim();

                var specifications = new string[6];
                specifications[0] = "Country";
                specifications[1] = "Origin";
                specifications[2] = "Body Type";
                specifications[3] = "Coat";
                specifications[4] = "Pattern";
                specifications[5] = "Image";
                var specificationsValues = new string[6];
                specificationsValues[0] = country;
                specificationsValues[1] = origin;
                specificationsValues[2] = bodyType;
                specificationsValues[3] = coat;
                specificationsValues[4] = pattern;
                specificationsValues[5] = image;
                if (e.CommandName == "ConfirmButton")
                {
                    _userCatBL.AddSpecificationsToBreed(breed, specifications, specificationsValues);                    
                }
                _catBL.DeleteRow(index);
            }

            Page_Load(sender, e);
        }
    }
}
