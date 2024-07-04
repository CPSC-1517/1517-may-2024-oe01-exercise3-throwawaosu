using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace BookSystem
{
    public class Author
    {
        private string _Name;
        

        #region properties

        public string Name
        {
            get { return _Name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Name *is required*");
                }

                _Name = value.Trim();

            }
        }
        public string Value
        {
            get { return _Name.Replace(" ", string.Empty); }
        }

      


        #endregion
#region constructor
        public Author(string name)
        {
                Name = name;
        }

        #endregion
        #region methods

        #endregion 
    }
}