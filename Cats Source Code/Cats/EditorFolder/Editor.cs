namespace Cats.EditorFolder
{
    public class Editor
    {
        private string _firstName;
        private string _lastName;
        private string _userName;
        private string _password;
        private string _email;
        private int _authorized;

        /*
         * constructor for food
         */
        public Editor(string firstName, string lastName, string userName, string password, string email, int authorized)
        {
            _firstName = firstName;
            _lastName = lastName;
            _userName = userName;
            _password = password;
            _email = email;
            _authorized = authorized;
        }

        public string GetFirstName()
        {
            return _firstName;
        }

        public void SetFirstName(string firstName)
        {
            _firstName = firstName;
        }

        public string GetLastName()
        {
            return _lastName;
        }

        public void SetLastName(string lastName)
        {
            _lastName = lastName;
        }

        public string GetUserName()
        {
            return _userName;
        }

        public void SetUserName(string userName)
        {
            _userName = userName;
        }
        public string GetPassword()
        {
            return _password;
        }

        public void SetPassword(string password)
        {
            _password = password;
        }

        public string GetEmail()
        {
            return _email;
        }

        public void SetEmail(string email)
        {
            _email = email;
        }

        public int GetAuthorized()
        {
            return _authorized;
        }

        public void SetAuthorized(int authorized)
        {
            _authorized = authorized;
        }
    }
}