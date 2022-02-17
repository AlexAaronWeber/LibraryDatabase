using GroupProjectLibrary;

Console.WriteLine("Welcome to the Library");
Console.WriteLine();
Console.WriteLine("Here's a list of our books: ");
Library library = new Library();
library.DisplayAllBooks();


Console.WriteLine(); 
bool runProgram = true;
while (runProgram)
{
    //ask user what they would like to do
    Console.WriteLine("What would you liket to do today:");
    Console.WriteLine();
    Console.WriteLine("Type 'Search' to look up a book");
    Console.WriteLine("Type 'Checkout' if you'd like to checkout a book.");
    Console.WriteLine("Type 'Return' if you have a book you'd like to return.");
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
        library.ReturnBook(library.books);
    }
    else
    {
        Console.WriteLine("Not a valid entry");
    }
    Validator.Validator.GetContinue("Would you like to go back to main menu?");
    Console.WriteLine();
}



