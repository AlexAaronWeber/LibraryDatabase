using System;
namespace GroupProjectLibrary
{
	public class Book
	{
		public string Title { get; set; }
		public string Author { get; set; }
		public bool Status { get; set; }
		public DateOnly? DueDate { get; set; } //'?' is for making many Data types nullable

		//checked out
		public Book(string _title, string _author, bool _status, DateOnly _duedate)
		{
			Title = _title;
			Author = _author;
			Status = _status;
			DueDate = _duedate;
		}

        //on shelf
        public Book(string _title, string _author, bool _status)
        {
            Title = _title;
            Author = _author;
            Status = _status;
            DueDate = null;
        }

        //methods

        public override string ToString()
        {
            if (Status == true)
            {
                //return $"Title: {Title}, Author: {Author}, Status: Checked out, Due Date: {DueDate}";
                return string.Format("{0, -45} {1, -25} {2,-5} {3,20} ", Title, Author, "Checked Out", $"Due: {DueDate}");

            }
            else
            {
                //return $"Title: {Title}, Author: {Author}, Status: On shelf";
                return string.Format("{0, -45} {1, -25} {2,-5}", Title, Author, "On Shelf");

            }
        }
    }
}

