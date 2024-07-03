using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace BookSystem
{
    public class Reviewer
    {

        private string _FirstName;
        private string _LastName;
        private string _Email;
        private string _Organization;

        #region properties
        public string ReviewerName
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
                    throw new ArgumentException("First name *is required*");
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
                    throw new ArgumentException("Last name *is required*");
                }

                _LastName = value.Trim();

            }
        }
        public string Email
        {
            get { return _Email; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("URL is *is required*");
                }

                string pattern = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                    @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                        @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

                //https://stackoverflow.com/a/16168117

                Regex regex = new Regex(pattern);

                if (regex.IsMatch(value))
                {
                    _Email = value.Trim();
                }
                else
                {
                    throw new ArgumentException("This is not an *acceptable email address pattern*");
                }


            }
        }

        public string Organization
        {
            get { return _Organization; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    _Organization = "";
                }

                _Organization = value;
            }
        }


        #endregion
        #region constructor
        public Reviewer(string firstname, string lastname, string email, string organization = "")
        {

                FirstName = firstname;
                LastName = lastname;
                Email = email;
                Organization = organization;
            


        }

        #endregion
        #region methods
        public override string ToString()
        {
            return $"{FirstName},{LastName},{Email},{Organization}";
        }
        #endregion 
    }
}