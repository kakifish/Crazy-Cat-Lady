using System;
using System.Collections.Generic;
using System.Linq;

namespace Cats
{
    public class CatBL
    {
        private readonly CatsDAL _catDal = new CatsDAL();

        public Cat GetCat(string breed)
        {
            return _catDal.GetCat(breed);
        }

        public Boolean IsCatExist(string breed)
        {
            return _catDal.GetCat(breed) != null;
        }

        public Boolean AddCat(Cat cat)
        {
            var catBl = new CatBL();
            if (!catBl.IsCatExist(cat.GetBreed().Trim()))
            {
                _catDal.AddCat(cat);
                return true;
            }
            return false;
        }

        public LinkedList<Cat> GetAllCats()
        {
            return _catDal.GetAllCats();
        }

        public LinkedList<string> GetListOfSpecification(string specification)
        {
            return _catDal.GetListOfSpecification(specification);
        }

        public string GetBreedSpecification(string breed, string specification)
        {
            return _catDal.GetBreedSpecification(breed, specification);
        }

        public void AddSpecificationToBreed(string breed, string specification, string specificationValue)
        {
            _catDal.AddSpecificationToBreed(breed, specification, specificationValue);
        }

        public void AddSpecificationsToBreed(string breed, string[] specificationArray, string[] specificationValueArray)
        {
            for (var i = 0; i < specificationArray.Length; i++)
            {
                AddSpecificationToBreed(breed, specificationArray[i], specificationValueArray[i]);
            }
        }

        public string FindCatImage(string breed)
        {
            var imageList = GetListOfSpecification("Image");
            return imageList.Where(image => image.Split('.')[0].Trim().Equals("~/CatPictures/" + breed)).Select(image => image.Trim()).FirstOrDefault();
        }
    }
}