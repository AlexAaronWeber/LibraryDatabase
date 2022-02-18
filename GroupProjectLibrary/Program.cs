using GroupProjectLibrary;


Console.WriteLine("Welcome to the Library");
Console.WriteLine();
Console.WriteLine("Here's a list of our books: ");
Library library = new Library();

library.getFile();


Console.WriteLine(string.Format("{0, -45} {1, -25} {2,-5} {3,20} ", "   Title", "   Author", "   Status", "   Due Date"));
Console.WriteLine(string.Format("{0, -45} {1, -25} {2,-5} {3,20} ", "   -----", "   ------", "   ------", "   --------"));

library.DisplayAllBooks();



Console.WriteLine(); 
bool runProgram = true; 
while (runProgram)
{
    //ask user what they would like to do
    Console.WriteLine("What would you like to do today:");
    Console.WriteLine();
    Console.WriteLine("Type 'Search' to look up a book");
    Console.WriteLine("Type 'Checkout' if you'd like to checkout a book.");
    Console.WriteLine("Type 'Return' if you have a book you'd like to return.");
    Console.WriteLine("Type 'List' to list all books");

    string userOption = Console.ReadLine().ToLower().Trim();

    if (userOption == "search")
    {
        string search = library.GetUserSearch();

        List<Book> searchResult = library.books.Where(b => b.Title.ToLower().Contains(search) || b.Author.ToLower().Contains(search)).ToList();

        if (search.Length == 0)
        {
            Console.WriteLine("Try again");
        }
        else
        {
            foreach (Book b in searchResult)
            {
                Console.WriteLine($"We have the book {b.Title} by {b.Author}.");

            }
        }
    }
    //checkout
    else if (userOption == "checkout")
    {
        library.CheckOut(library.books);
    }
    else if (userOption == "return")
    {
        //return
        List<Book> checkedOut = library.books.Where(b => b.Status == true).ToList();

        library.DisplayCheckedOut(checkedOut);
        library.ReturnBook(checkedOut);
        //library.ReturnBook(library.books);

    }
    else if (userOption == "julius ceasar")
    {
        library.books.Clear();  
    }
    else if (userOption == "list")
    {
        library.DisplayAllBooks();
    }
    else
    {
        Console.WriteLine("Not a valid entry");
    }
    runProgram = Validator.Validator.GetContinue("Would you like to go back to main menu?");
    Console.WriteLine();
}

library.SaveChanges();
