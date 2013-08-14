using System;
using System.Collections.Generic;
using System.Linq;

namespace Cats.ProductsFolder
{
    public class ProductBL
    {
        private readonly ProductDAL _productDal = new ProductDAL();

        public Product GetProduct(string productName)
        {
            return _productDal.GetProduct(productName);
        }

        public Boolean IsProductExist(string productName)
        {
            return _productDal.GetProduct(productName) != null;
        }

        //We can add an existing product too
        public void AddProduct(Product product)
        {
            _productDal.AddProduct(product);
        }

        public LinkedList<Product> GetCategoryList(string category)
        {
            return _productDal.GetCategoryList(category);
        }

        public LinkedList<string> GetListOfSpecification(string specification)
        {
            return _productDal.GetListOfSpecification(specification);
        }

        public string GetCategorySpecification(string category, string specification)
        {
            return _productDal.GetCategorySpecification(category, specification);
        }

        public void AddSpecificationToProduct(string productName, string specification, string specificationValue)
        {
            _productDal.AddSpecificationToProduct(productName, specification, specificationValue);
        }

        public void AddSpecificationsToProduct(string productName, string[] specificationArray, string[] specificationValueArray)
        {
            for (var i = 0; i < specificationArray.Length; i++)
            {
                AddSpecificationToProduct(productName, specificationArray[i], specificationValueArray[i]);
            }
        }

        public string FindCatImage(string breed)
        {
            var imageList = GetListOfSpecification("Image");
            return imageList.Where(image => image.Split('.')[0].Trim().Equals("~/CatPictures/" + breed)).Select(image => image.Trim()).FirstOrDefault();
        }
    }
}