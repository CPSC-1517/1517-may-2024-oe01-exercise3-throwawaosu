using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace BookSystem
{
    public class Author
    {
        private string _ContactUrl;
        private string _FirstName;
        private string _LastName;
        private string _ResidentCity;
        private string _ResidentCountry;

        #region properties
        public string AuthorName
        {
            get { return $"{_LastName}, {_FirstName}"; }
        }
        public string FirstName
        {
            get { return _FirstName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("First name *is required*");
                }
               
                _FirstName = value.Trim();

            }
        }
        public string LastName
        {
            get { return _LastName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Last name *is required*");
                }
 
                 _LastName = value.Trim();
                
            }
        }
        public string ContactUrl
        {
            get { return _ContactUrl; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("URL is *is required*");
                }
                
                string pattern = @"^(?:http(s)?:\/\/)?[\w.-]+(?:\.[\w\.-]+)+[\w\-\._~:/?#[\]@!\$&'\(\)\*\+,;=.]+$";
                // stole this straight from stack overflow, the simple regular expression in the readmedid not work
                // https://stackoverflow.com/a/56128519
                Regex regex = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
                
                if (regex.IsMatch(value))
                {
                    _ContactUrl = value.Trim();
                }
                else
                {
                    throw new ArgumentException("This is not an *acceptable url pattern*");
                }

                
            }
        }
        public string ResidentCity
        {
            get { return _ResidentCity; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("City *is required*");
                }
                _ResidentCity = value.Trim();
            }
        }
        public string ResidentCountry
        {
            get { return _ResidentCountry; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Country *is required*");
                }
                _ResidentCountry = value.Trim();
            }
        }


        #endregion
#region constructor
        public Author(string firstname, string lastname, string contacturl, string city, string country)
        {
                FirstName = firstname;
                LastName = lastname;
                ContactUrl = contacturl;
                ResidentCity = city;
                ResidentCountry = country;
            
            

        }

        #endregion
        #region methods
        public override string ToString()
        {
            return $"{FirstName},{LastName},{ContactUrl},{ResidentCity},{ResidentCountry}";
        }
        #endregion 
    }
}