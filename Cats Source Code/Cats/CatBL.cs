using System;
using System.Collections.Generic;

namespace Cats
{
    public class CatBL
    {
        private readonly CatsDAL _catDal;
        private readonly bool _admin;

        public CatBL(bool admin)
        {
            _admin = admin;
            _catDal = new CatsDAL(_admin);
        }

        public Cat GetCat(string breed)
        {
            return _catDal.GetCat(breed);
        }

        public Boolean IsCatExist(string breed)
        {
            return _catDal.GetCat(breed) != null;
        }

        public Boolean AddCat(Cat cat, string changes)
        {
            var catBl = new CatBL(_admin);
            if (!_admin && catBl.IsCatExist(cat.GetBreed().Trim()))
            {
                return false;
            }
            _catDal.AddCat(cat, changes);
            return true;
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
            return _catDal.GetBreedSpecification(breed, "Image");
        }

        public LinkedList<Cat> FindBreedBySpecifications(string[] specifications)
        {
            return _catDal.FindBreedBySpecifications(specifications);
        }

        public void DeleteCat(string breed)
        {
            _catDal.DeleteCat(breed);
        }

        public void DeleteCat(string breed, string specifications, string value)
        {
            _catDal.DeleteCat(breed, specifications, value);
        }

        public void AddChanges(string breed, string cahnges)
        {
            _catDal.AddChanges(breed, cahnges);
        }

        public void DeleteRow(int row)
        {
            _catDal.DeleteRow(row);
        }

        public LinkedList<Cat> GetAllCatsWithChanges()
        {
            return _catDal.GetAllCatsWithChanges();
        }
    }
}