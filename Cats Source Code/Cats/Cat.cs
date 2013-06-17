namespace Cats
{
    public class Cat
    {
        private string _breed;
        private string _country;
        private string _origin;
        private string _bodyType;
        private string _coat;
        private string _pattern;
        //////////////////unused??///////////////////
        private string _wikipediaLink;
        private string _image;
        private string _info;
        //////////////////unused??///////////////////

        public Cat(string breed)
        {
            _breed = breed;
        }

        public Cat(string breed, string country)
        {
            _breed = breed;
            _country = country;
        }

        public Cat(string breed, string country, string origin)
        {
            _breed = breed;
            _country = country;
            _origin = origin;
        }

        public Cat(string breed, string country, string origin, string bodyType)
        {
            _breed = breed;
            _country = country;
            _origin = origin;
            _bodyType = bodyType;
        }

        public Cat(string breed, string country, string origin, string bodyType, string coat)
        {
            _breed = breed;
            _country = country;
            _origin = origin;
            _bodyType = bodyType;
            _coat = coat;
        }

        public Cat(string breed, string country, string origin, string bodyType, string coat, string pattern)
        {
            _breed = breed;
            _country = country;
            _origin = origin;
            _bodyType = bodyType;
            _coat = coat;
            _pattern = pattern;
        }

        public Cat(string breed, string country, string origin, string bodyType, string coat, string pattern, string wikipediaLink)
        {
            _breed = breed;
            _country = country;
            _origin = origin;
            _bodyType = bodyType;
            _coat = coat;
            _pattern = pattern;
            _wikipediaLink = wikipediaLink;
        }

        public Cat(string breed, string country, string origin, string bodyType, string coat, string pattern, string wikipediaLink, string image)
        {
            _breed = breed;
            _country = country;
            _origin = origin;
            _bodyType = bodyType;
            _coat = coat;
            _pattern = pattern;
            _wikipediaLink = wikipediaLink;
            _image = image;
        }

        public Cat(string breed, string country, string origin, string bodyType, string coat, string pattern, string wikipediaLink, string image, string info)
        {
            _breed = breed;
            _country = country;
            _origin = origin;
            _bodyType = bodyType;
            _coat = coat;
            _pattern = pattern;
            _wikipediaLink = wikipediaLink;
            _image = image;
            _info = info;
        }

        public string GetBreed()
        {
            return _breed;
        }
        public void SetBreed(string breed)
        {
            _breed = breed;
        }

        public string GetCountry()
        {
            return _country;
        }
        public void SetCountry(string country)
        {
            _country = country;
        }

        public string GetOrigin()
        {
            return _origin;
        }
        public void SetOrigin(string origin)
        {
            _origin = origin;
        }

        public string GetBodyType()
        {
            return _bodyType;
        }
        public void SetBodyType(string bodyType)
        {
            _bodyType = bodyType;
        }

        public string GetCoat()
        {
            return _coat;
        }
        public void SetCoat(string coat)
        {
            _coat = coat;
        }

        public string GetPattern()
        {
            return _pattern;
        }
        public void SetPattern(string pattern)
        {
            _pattern = pattern;
        }

        public string GetWikipwdiaLink()
        {
            return _wikipediaLink;
        }
        public void SetWikipediaLink(string wikipediaLink)
        {
            _wikipediaLink = wikipediaLink;
        }

        public string GetImage()
        {
            return _image;
        }
        public void SetImage(string image)
        {
            _image = image;
        }

        public string GetInfo()
        {
            return _info;
        }
        public void SetInfo(string info)
        {
            _info = info;
        }
    }
}