using GroupProjectLibrary;

Console.WriteLine("Welcome to the Library");
Console.WriteLine();
Console.WriteLine("Here's a list of our books: ");




Library library = new Library();

library.DisplayAllBooks();

bool runProgram = true;
while (runProgram)
{

    //get user search testing--------------------------------------

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
            Console.WriteLine(b.Title);
        }

    } 
    
    Console.WriteLine("Would you like to check out? (y/n)");
    string entry = Console.ReadLine().ToLower().Trim();


    if (entry == "y")
    {
        b.status = true;
    }


}