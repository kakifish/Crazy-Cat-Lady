using System;
using System.Data;
using System.Linq;
using System.Web.UI;

namespace Cats
{
    public partial class ListOfBreeds : Page
    {
        private bool _admin;

        protected void Page_PreInit(Object sender, EventArgs e)
        {
            _admin = Convert.ToBoolean(Request.QueryString["admin"]);
            if (_admin)
            {
                MasterPageFile = "~/EditorFolder/Editor.Master";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var catBL = new CatBL(false);
            var catsList = catBL.GetAllCats();
            
            var dt = new DataTable();
            var dcBreed = new DataColumn("Breed", typeof(string));
            var dcCountry = new DataColumn("Country", typeof(string));
            var dcOrigin = new DataColumn("Origin", typeof(string));
            var dcBodyType = new DataColumn("Body Type", typeof(string));
            var dcCoat = new DataColumn("Coat", typeof(string));
            var dcPattern = new DataColumn("Pattern", typeof(string));
            var dcImage = new DataColumn("Image", typeof(string));
            
            dt.Columns.AddRange(new[] { dcBreed, dcCountry, dcOrigin, dcBodyType, dcCoat, dcPattern, dcImage });

            for (var i = 0; i < catsList.Count; i++)
            {
                dt.Rows.Add(new object[]
                    {
                        catsList.ElementAt(i).GetBreed().Trim(), catsList.ElementAt(i).GetCountry().Trim(),
                        catsList.ElementAt(i).GetOrigin().Trim(), catsList.ElementAt(i).GetBodyType().Trim(),
                        catsList.ElementAt(i).GetCoat().Trim(), catsList.ElementAt(i).GetPattern().Trim(),
                        ResolveUrl(catsList.ElementAt(i).GetImage().Trim())
                    });
            }

            AllBreedGrid.DataSource = dt;
            AllBreedGrid.DataBind();
        }
    }
}