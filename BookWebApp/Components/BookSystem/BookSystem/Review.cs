using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSystem
{
    public class Review
    {
        private string _Comment;
        private string _ISBN;
        private Reviewer _Reviewer;
        private string _Title;
        private RatingType _Rating;
        //idk why this is not included in the diagram :D 

        #region properties
        public string Comment
        {
            get { return _Comment; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Comment *is required*");
                }
                _Comment = value.Trim();
            }
        }

        public string ISBN
        {
            get { return _ISBN; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("ISBN number *is required*");
                }
                _ISBN = value;
            }
        }

        public RatingType Rating
        {
            get { return _Rating;  }
            set { _Rating = value; }
        }

        public string Title
        {
            get { return _Title; }
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Title *is required*");
                }
                _Title = value;
            }
        }

        public Reviewer Reviewer
        {
            get { return _Reviewer; }
            set 
            {
                try
                {

                    if (value == null)
                    {
                        throw new ArgumentException();
                    }
                    _Reviewer = value;
                    
                }
                catch
                {
                    throw new ArgumentException("Reviewer *is required*"); 
                }
                    
            }
        }
        #endregion
        #region constructor
        public Review(string isbn, string title, Reviewer reviewer, RatingType rating, string comment)
        {

                
                ISBN = isbn;
                Title = title;
                Comment = comment;
                Reviewer = reviewer;
                Rating = rating;
            

        }
        #endregion 
        #region methods
        public override string ToString()
        {
            return $"{ISBN},{Reviewer},{Rating},{Comment}";
        }
        #endregion

        public string Parse(string text)
        {

        }

    }
}
