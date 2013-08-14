namespace Cats.ProductsFolder
{
    public class Product
    {
        private string _category;
        private string _productName;
        private string _image;
        private string _description;
        private string _price;
        private string _brand;
        private string _weight;
        //////////////////unused??///////////////////
        private string _storeName;
        private string _storeAddress;
        private string _storePhone;
        //////////////////unused??///////////////////

        /*
         * constructor for food
         */
        public Product(string category, string productName, string brand, string description, string price, string weight, string image)
        {
            _category = category;
            _productName = productName;
            _brand = brand;
            _description = description;
            _price = price;
            _weight = weight;
            _image = image;
        }

        /*
         * constructor for toys
         */
        public Product(string category, string productName, string description, string price, string image)
        {
            _category = category;
            _productName = productName;
            _description = description;
            _price = price;
            _image = image;
        }

        public Product(string category, string productName, string description, string image, string price, string brand, string weight, string storeName, string storeAddress, string storePhone)
        {
            _category = category;
            _productName = productName;
            _description = description;
            _image = image;
            _price = price;
            _brand = brand;
            _weight = weight;
            _storeName = storeName;
            _storeAddress = storeAddress;
            _storePhone = storePhone;
        }

        public string GetCategory()
        {
            return _category;
        }
        public void SetCategory(string category)
        {
            _category = category;
        }

        public string GetProductName()
        {
            return _productName;
        }
        public void SetProductName(string productName)
        {
            _productName = productName;
        }

        public string GetDescription()
        {
            return _description;
        }
        public void SetDescription(string description)
        {
            _description = description;
        }

        public string GetImage()
        {
            return _image;
        }
        public void SetImage(string image)
        {
            _image = image;
        }

        public string GetBrand()
        {
            return _brand;
        }
        public void SetBrand(string brand)
        {
            _brand = brand;
        }

        public string GetWeight()
        {
            return _weight;
        }
        public void SetWeight(string weight)
        {
            _weight = weight;
        }

        public string GetPrice()
        {
            return _price;
        }
        public void SetPrice(string price)
        {
            _price = price;
        }

        public string GetStoreName()
        {
            return _storeName;
        }
        public void SetStoreName(string storeName)
        {
            _storeName = storeName;
        }

        public string GetStoreAddress()
        {
            return _storeAddress;
        }
        public void SetStoreAddress(string storeAddress)
        {
            _storeAddress = storeAddress;
        }

        public string GetStorePhone()
        {
            return _storePhone;
        }
        public void SetStorePhone(string storePhone)
        {
            _storePhone = storePhone;
        }
    }
}