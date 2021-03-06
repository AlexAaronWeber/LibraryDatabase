using System;
namespace GroupProjectLibrary
{
	public class Library
	{
		string filepath = "../../../file1.txt";

		//list of books
		public List<Book> books = new List<Book>()
		{
			
        };

		//-----------------------------Methods-----------------------------

		//display a list of all books
		public void DisplayAllBooks()
		{
			for (int i = 0; i < books.Count; i++)
			if(i<=8)
			{
				Console.WriteLine($"{ i + 1}  { books[i].ToString()}");
			}
			else
			{
				Console.WriteLine($"{ i + 1} { books[i].ToString()}");
			}

			if (books.Count == 0)
            {
                Console.WriteLine("You have burned down the library of Alexandria and have set human civilization back a few hundred years");
            }
		}

		//get the user's search
		public void  GetUserSearch()
		{

			Console.WriteLine("Search by author or title keyword");

			string input = Console.ReadLine().ToLower().Trim();

			List<Book> searchResult = books.Where(b => b.Title.ToLower().Contains(input) || b.Author.ToLower().Contains(input)).ToList();

			foreach (Book book in searchResult)
			{
				if (book.Author.ToLower().Contains(input) || book.Title.ToLower().Contains(input))
				{
					Console.WriteLine($"We have the book {book.Title} by {book.Author}.");
				}
			}

			if (searchResult.Count == 0)
			{
				Console.WriteLine("Try again");
			}


		}

		//check out a book
		public void CheckOut()
		{
			Console.WriteLine($"Please pick the number of the book you'd like to check out 1-{books.Count} ");
			int entry = int.Parse(Console.ReadLine()) - 1;


			if (books[entry].Status == false)
			{
				books[entry].Status = true;
				books[entry].DueDate = DateOnly.FromDateTime(DateTime.Now).AddDays(14);
				Console.WriteLine($"You have checked out {books[entry].Title} it will be due on {books[entry].DueDate}!");

			}
			else if (books[entry].Status == true)
			{
				Console.WriteLine($"Unfortunetly, {books[entry].Title} is already checked out. It should be returned on {books[entry].DueDate}");
			}
		}

		//return a book
		public void ReturnBook(List<Book> ReturnBooks)
		{
			Console.WriteLine("Please enter the number for the book you would like to return");
			int entry = int.Parse(Console.ReadLine()) - 1;

			if (ReturnBooks[entry].Status == true)
			{
				ReturnBooks[entry].Status = false;
				ReturnBooks[entry].DueDate = null;
				Console.WriteLine($"Thank you for returning {ReturnBooks[entry].Title}!");
			}
			else if (ReturnBooks[entry].Status == false)
			{
				Console.WriteLine($"{ReturnBooks[entry].Title} is not checked out.");
			}
		}

		public void ifNeedsReturn()
        {
			List<Book> checkedOut = books.Where(b => b.Status == true).ToList();
			if (checkedOut.Count > 0)
			{
				DisplayCheckedOut(checkedOut);
				ReturnBook(checkedOut);
				//library.ReturnBook(library.books);
			}
			else
			{
				Console.WriteLine("No books to return!");
			}

		}

		//displays checked out books
		public void DisplayCheckedOut(List<Book> list)
		{
			for (int i = 0; i < list.Count; i++)
				if (i <= 8)
				{
					Console.WriteLine($"{ i + 1}  { list[i].ToString()}");
				}
				else
				{
					Console.WriteLine($"{ i + 1} { list[i].ToString()}");
				}
		}

		//gets the File if it already exists and creates one with starting values if it does not exist
		public void getFile()
		{
			if (File.Exists(filepath) == false)
            {
				List<Book> tempBooks = new List<Book>()
				{
					new Book ("The Prophet", "Kahlil Gibran", true, DateOnly.FromDateTime(DateTime.Now)),
					new Book ("The Midnight Library", "Matt Haig", false),
					new Book ("Black Cake", "Charmaine Wilkerson", false),
					new Book ("The Maid", "Nita Prose", true,  DateOnly.FromDateTime(DateTime.Now)),
					new Book ("The Lincoln Highway", "Amor Towles", true,  DateOnly.FromDateTime(DateTime.Now)),
					new Book ("The Christie Affair", "Nina De Gramont", true,  DateOnly.FromDateTime(DateTime.Now)),
					new Book ("The Last Thing He Told Me", "Laura Dave", false),
					new Book ("The Judge's List", "John Grisham", false),
					new Book ("Harry Potter and the Chamber of Secrets", "J.K Rowling", true,  DateOnly.FromDateTime(DateTime.Now)),
					new Book ("The Hobbit", "J.R. Tolkein", true,  DateOnly.FromDateTime(DateTime.Now)),
					new Book ("It", "Stephen King", false),
					new Book ("To the Lighthouse", "Virginia Wolfe", false),
					new Book ("The Lovely Bones", "Alice Sebold", true,  DateOnly.FromDateTime(DateTime.Now)),
				};
				StreamWriter writer = new StreamWriter(filepath);
				foreach (Book b in tempBooks)
				{
					if(b.DueDate != null)
                    {
						writer.WriteLine($"{b.Title}_{b.Author}_{b.Status}_{b.DueDate}");
					}
                    else
                    {
						writer.WriteLine($"{b.Title}_{b.Author}_{b.Status}");
					}
				}
				//Save file
				writer.Close();
			}
			//Grab all students and save them

			StreamReader ClassReader = new StreamReader(filepath);

			while (true)
			{
				string Line = ClassReader.ReadLine();
				if (Line == null)
				{
					break;
				}
				else
				{
					//Console.WriteLine(Line);
					string[] values = Line.Split("_");
					string Title = values[0];
					string Author = values[1];
					bool Status = bool.Parse(values[2]);
                    if(values.Length == 4)
                    {
						DateOnly DueDate = DateOnly.Parse(values[3]);
						Book newBook = new Book(Title, Author, Status, DueDate);
						books.Add(newBook);
					}
                    else
                    {
						Book newBook = new Book(Title, Author, Status);
						books.Add(newBook);
					}
				}
			}
			ClassReader.Close();
		}

		//save changes
		public void SaveChanges()
        {
			StreamWriter BooksWriter = new StreamWriter(filepath);
			foreach (Book book in books)
            {
				if (book.DueDate != null)
                {
					BooksWriter.WriteLine($"{book.Title}_{book.Author}_{book.Status}_{book.DueDate}");
				}
				else
                {
					BooksWriter.WriteLine($"{book.Title}_{book.Author}_{book.Status}");

				}
            }
			BooksWriter.Close();
        }


	}
	
}



//-------------------------------
//git reset --hard
//used to remove chanes oyu made on your project, so oyu can copy whats on the repo




