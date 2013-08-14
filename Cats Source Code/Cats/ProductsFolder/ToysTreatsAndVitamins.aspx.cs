using System;
using System.Data;
using System.Linq;

namespace Cats.ProductsFolder
{
    public partial class Toys : System.Web.UI.Page
    {
        private string _category;
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
            _category = Request.QueryString["category"];

            CategoryLabel.Text = _category;

            var productBL = new ProductBL();
            var productList = productBL.GetCategoryList(_category);

            var dt = new DataTable();
            var dcImage = new DataColumn("Image", typeof(string));
            var dcProductName = new DataColumn("Product Name", typeof(string));
            var dcDescription = new DataColumn("Description", typeof(string));
            var dcPrice = new DataColumn("Price", typeof(string));

            dt.Columns.AddRange(new[] { dcImage, dcProductName, dcDescription, dcPrice });

            for (var i = 0; i < productList.Count; i++)
            {
                dt.Rows.Add(new object[]
                    {
                        productList.ElementAt(i).GetImage().Trim(), productList.ElementAt(i).GetProductName().Trim(),
                        productList.ElementAt(i).GetDescription().Trim(), productList.ElementAt(i).GetPrice().Trim()
                    });
            }

            ToysTreatsAndVitaminsGrid.DataSource = dt;
            ToysTreatsAndVitaminsGrid.DataBind();
        }
    }
}