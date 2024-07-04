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
        public static Author[] baseAuthors()
        {
            List<Author> authors = new List<Author>();


            Author author1 = new Author("Karen Miller");
            Author author2 = new Author("Adrian Tchaikovsky");
            Author author3 = new Author("Cixin Liu");

            authors.Add(author1);
            authors.Add(author2);
            authors.Add(author3);
            return authors.ToArray();
            /// I havea  feeling this is probably where i would need the base classes too bad i can't find them and i cannot be bothered to look 
        }


        #endregion 
    }
}