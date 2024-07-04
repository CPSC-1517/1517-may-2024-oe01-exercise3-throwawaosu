using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BookSystem
{
    public class Review
    {
        private string _Author;
        private string _Comment;
        private string _ISBN;
        private string _Reviewer;
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

        public string Reviewer
        {
            get { return _Reviewer; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("reviewer *is required*");
                }
                _Reviewer = value;
            }
        }


        public string Author
        {
            get { return _Author; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Author *is required*");
                }
                _Author = value;
            }
        }


        #endregion
        #region constructor
        public Review(string isbn, string title, string author, string reviewer, RatingType rating, string comment)
        {

                
                ISBN = isbn;
                Title = title;
                Comment = comment;
                Reviewer = reviewer;
                Rating = rating;
                Author = author;

        }
        #endregion 
        #region methods
        public override string ToString()
        {
            return $"{ISBN},{Title},{Author},{Reviewer},{Rating},{Comment}";
        }
        #endregion

        public static Review Parse(string text)
        {

            
                string[] data = text.Split(',');

                string isbn = data[0];
                string title = data[1];
                string author = data[2];
                string reviewername = data[3];
                RatingType rating = (RatingType)Enum.Parse(typeof(RatingType), data[4]);
                string comment = data[5];
            
            //i don't think theres any other ways to screw up formatting that isn't already handled by the classes
            if (data.Length > 6)
            {
                throw new FormatException($"invalid format (too many commas) {text}");
            }

            for(int i = 0; i<6; i++)
            {
                if (data[i] ==""){
                    throw new FormatException($"invalid format (a data field is blank) {text}");
                }
            }

            Review a = new Review(isbn, title, author, reviewername, rating, comment);
            
            return a;
        }

    }
}
