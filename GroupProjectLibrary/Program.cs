using GroupProjectLibrary;

Console.WriteLine("Welcome to the Library");
Console.WriteLine();
Console.WriteLine("Here's a list of our books: ");




Library library = new Library();

library.DisplayAllBooks();

bool runProgram = true;
while (runProgram)
{

    //Console.WriteLine("Would you like to search by author? ");
    //    string authorEntry = Console.ReadLine();  

    //List<Book> result = library.Where(b => b.Author == authorEntry).ToList();

    ////List<Book> result = library.Where(b => b.Author == authorEntry.ToLower().ToList();

    //    foreach (Book b in result)
    //    {
    //        Console.WriteLine(b.Title);
    //    }

    //    if(result.Count == 0)
    //    {
    //        Console.WriteLine("No Authors match");
    //    }

    //get user search testing--------------------------------------

    string search = library.GetUserSearch();

    List<Book> searchResult = library.books.Where(b => b.Title.ToLower().Contains(search) || b.Author.ToLower().Contains(search)).ToList();


    foreach(Book b in searchResult)
    {
        Console.WriteLine(b.Title);
    }
    

}