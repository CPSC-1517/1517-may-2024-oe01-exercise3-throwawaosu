using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace BookSystem
{
    public class Book
    {

        private Author _Author;
        private GenreType _Genre;
        private string _ISBN;
        private string _Title;
        private int _PublishYear;
        private List<Review> _Reviews;

        #region properties


        public Author Author
        {
            get { return _Author; }
            set
            {
                try
                {
                    _Author = value;
                    if (value == null)
                    {
                        throw new ArgumentNullException();
                    }
                }
                catch
                {
                    if (value == null)
                    {
                        throw new ArgumentNullException("Author is required");
                    }
                    else
                    {
                        throw new ArgumentException("Bad author data");
                    }

                }


            }
        }
        public GenreType Genre
        {
            get; set;
        }

        public string Title
        {
            get { return _Title; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Title *is required*");
                }

                _Title = value.Trim();

            }
        }



        public string ISBN
        {
            get { return _ISBN; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("ISBN *is required*");
                }


                _ISBN = value.Trim();

            }
        }

        public int PublishYear
        {
            get { return _PublishYear; }
            set
            {

                string pattern = @"^\d{4}$";
                // stole this straight from stack overflow
                // https://stackoverflow.com/questions/42674717/regex-match-exactly-4-digits
                Regex regex = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);



                if (regex.IsMatch(value.ToString()))
                {
                    if (value > 0)
                    {
                        _PublishYear = value;
                    }
                    else
                    {
                        throw new FormatException("This is not an *acceptable year* (#### format, above 0)");
                    }
                }
                else
                {
                    throw new FormatException("This is not an *acceptable year pattern* (#### format, above 0)");
                }


            }
        }
        public List<Review> Reviews
        {
            get; set;
        }
        public int TotalReviews
        {
            get
            {
                return _Reviews.Count;
            }
        }



        #endregion
        #region constructor
        public Book(Author author, GenreType genre, string isbn, string title, int publishyear, List<Review> reviews = null)
        {
            if (reviews == null)
            {
                reviews = new List<Review>();
            }

            Author = author;
            Genre = genre;
            Title = title;
            ISBN = isbn;
            PublishYear = publishyear;
            Reviews = reviews;

        }


        #endregion
        #region methods
        public void AddReview(string isbn, Review review) //idk why we need the lowercase 'isbn' nooooooot gna lie
        {
            if (isbn == null)
            {
                throw new ArgumentNullException("ISBN required");
            }
            else
            {

                if (review == null)
                {
                    throw new ArgumentNullException("Review required");
                }
                else
                {
                    if (review.ISBN != ISBN)
                    {
                        throw new ArgumentException($"ISBN mismatch. *{review.ISBN}*");
                    }
                }
            }

            Reviewer reviewer = review.Reviewer;

            for (int i = 0; i < Reviews.Count; i++)
            {
                if (reviewer == Reviews[i].Reviewer)
                {
                    throw new ArgumentException($"Review already exists for user *{review.Reviewer.ReviewerName}*");
                }
            }

            Reviews.Add(review);

        }
        #endregion 
    }
}