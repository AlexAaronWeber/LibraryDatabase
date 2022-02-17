using System;
namespace GroupProjectLibrary
{
	public class Library
	{
		public List<Book> books = new List<Book>() 
		{

            new Book ("The Prophet", "Kahlil Gibran", true, DateOnly.Parse("01/03/22")),
			new Book ("The Midnight Library", "Matt Haig", false),
			new Book ("Black Cake", "Charmaine Wilkerson", false),
			new Book ("The Maid", "Nita Prose", true, DateOnly.Parse("12/31/22")),
			new Book ("The Lincoln Highway", "Amor Towles", true, DateOnly.Parse("4/5/22")),
			new Book ("The Christie Affair", "Nina De Gramont", true, DateOnly.Parse("12/31/22")),
			new Book ("The Last Thing He Told Me", "Laura Dave", false),
			new Book ("The Judge's List", "John Grisham", false),
			new Book ("Harry Potter and the Chamber of Secrets", "J.K Rowling", true, DateOnly.Parse("6/21/22")),
			new Book ("The Hobbit", "J.R. Tolkein", true, DateOnly.Parse("5/5/22")),
			new Book ("It", "Stephen King", false),
			new Book ("To the Lighthouse", "Virginia Wolfe", false),
			new Book ("The Lovely Bones", "Alice Sebold", true, DateOnly.Parse("12/31/22")),
		};


        public void DisplayAllBooks()
        {
            foreach (Book b in books)
            {
                Console.WriteLine(b);
            }
        }

		//      public void showTitle(List<Book> books)
		//{
		//	foreach (Book b in books)
		//	{
		//		Console.WriteLine(b.Title);
		//	}
		//}

		//-------------------------------
		//git reset --hard
		//used to remove chanes oyu made on your project, so oyu can copy whats on the repo


		public string GetUserSearch()
		{
					Console.WriteLine("Search by author or title keyword");

					string input = Console.ReadLine().ToLower().Trim();

					foreach (Book book in books)
                    {
						if (book.Author.ToLower().Contains(input) || book.Title.ToLower().Contains(input))
						{
							return input;
						}
					}
				return "";
		}
		public void CheckOut (List<Book> Books )
        {
			Console.WriteLine($"Please pick the number of the book you'd like to check out 1-{Books.Count} ");
			int entry = int.Parse(Console.ReadLine());

			if (Books[entry].Status == false )
            {
				Books[entry].Status = true;
				Books[entry].DueDate = DateOnly.FromDateTime(DateTime.Now).AddDays(14);

            }
        }
	

	}
}






