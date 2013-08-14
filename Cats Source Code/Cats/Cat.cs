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
        private string _image;
        private string _info;
        private string _change;

        public Cat(string breed, string image)
        {
            _breed = breed;
            _image = image;
        }

        public Cat(string breed, string country, string origin, string bodyType, string coat, string pattern, string image, string info)
        {
            _breed = breed;
            _country = country;
            _origin = origin;
            _bodyType = bodyType;
            _coat = coat;
            _pattern = pattern;
            _image = image;
            _info = info;
        }

        public Cat(string breed, string country, string origin, string bodyType, string coat, string pattern, string image, string info, string change)
        {
            _breed = breed;
            _country = country;
            _origin = origin;
            _bodyType = bodyType;
            _coat = coat;
            _pattern = pattern;
            _image = image;
            _info = info;
            _change = change;
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

        public string GetChange()
        {
            return _change;
        }
    }
}