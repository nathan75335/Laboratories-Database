// See https://aka.ms/new-console-template for more information
using BookProject;
using Microsoft.EntityFrameworkCore;

ApplicationContext db=  new ApplicationContext();

while (true)
{
    Console.WriteLine("Choose The Number you want");
    Console.WriteLine("1.Genre");
    Console.WriteLine("2.Book");
    Console.WriteLine("3.Edition House");
    Console.WriteLine("4.See All The book of a genre");
    int number = int.Parse(Console.ReadLine());

    switch (number)
    {
        case 1:

            bool next = true;

            while (next)
            {
                Console.WriteLine("1.List of Genres");
                Console.WriteLine("2.Update");
                Console.WriteLine("3.Delete");
                Console.WriteLine("4.Create");
                Console.WriteLine("5.Exit");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:

                        var listGenres = db.Genres.ToList();

                        Console.WriteLine("Id\t \tName \tAuthor");

                        foreach (var genreWrite in listGenres)
                        {
                            
                            Console.WriteLine($"{genreWrite.Id}\t{genreWrite.Name}\t{genreWrite.Description}");
                        }

                        var listGenresLooked = db.Genres.Where(i => i.Name.Contains("j") ).ToList();

                        Console.WriteLine("\n\n");
                        Console.WriteLine("Id\t \tName \tAuthor");

                        foreach (var genreWrite in listGenresLooked)
                        {

                            Console.WriteLine($"{genreWrite.Id}\t{genreWrite.Name}\t{genreWrite.Description}");
                        }

                        Console.WriteLine("\n\n");

                        var lookedCount = db.Genres.Where(i => i.Name == "Romantic").Count();

                        Console.WriteLine($"Number of Romance {lookedCount}");
                        break;
                        
                    case 2:

                        Console.WriteLine("Enter the Id of the genre You want to Update");
                        int id = int.Parse(Console.ReadLine());

                        var genre = await db.Genres.FindAsync(id);                   

                        Console.WriteLine("Enter the Name of The Genre");
                        genre.Name = Console.ReadLine();
                        Console.WriteLine("Enter the Description of The Genre");
                        genre.Description = Console.ReadLine();

                        db.Genres.Update(genre);

                        break;

                    case 3:
                        Console.WriteLine("Enter the Id of the genre You want to Delete");
                        var genreid = int.Parse(Console.ReadLine());

                        var genreLooked = await db.Books.FindAsync(genreid);
                        db.Books.Update(genreLooked);

                        break;
                    case 4:
                        var myGenre = new Genre();
                        Console.WriteLine("Enter the name of the genre");
                        myGenre.Name = Console.ReadLine();
                        Console.WriteLine("Enter the description of the genre");
                        myGenre.Description = Console.ReadLine();

                        db.Genres.Add(myGenre);
                        db.SaveChanges();
                        break;
                    case 5:
                       
                        next = false;

                        break;

                }

            }

            break;

        case 2:

            bool nextBook = true;

            while (nextBook)
            {
                Console.WriteLine("1.List of Book");
                Console.WriteLine("2.Update");
                Console.WriteLine("3.Delete");
                Console.WriteLine(("4.Create"));
                Console.WriteLine("5.Exit");

                var choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:

                        var listBooks = db.Books.Include(i => i.Genre)
                            .Include(i => i.EditionHouse)
                            .ToList();
                        Console.WriteLine("Id\t \tName \t Genre\t \tDescription");

                        foreach (var bookWrite in listBooks)
                        {
                            
                            Console.WriteLine($"{bookWrite.Id}\t {bookWrite.Genre.Name}\t{bookWrite.Author}");
                        }

                        var listBooksLooked = db.Books.Include(i => i.Genre)
                           .Include(i => i.EditionHouse).Where(i => i.Name.Contains("v"))
                           .ToList();
                        Console.WriteLine("Id\t \tName \t \tDescription");

                        foreach (var bookWrite in listBooksLooked)
                        {

                            Console.WriteLine($"{bookWrite.Id}\t\t{bookWrite.Author}");
                        }
                        break;
                    case 2:

                        Console.WriteLine("Enter the Id of the Genre You want to Update");
                        var id = int.Parse(Console.ReadLine());

                        var book = await db.Books.FindAsync(id);                     //var newGenre = new Genre();

                        Console.WriteLine("Enter the Name of The Genre");
                        book.Name = Console.ReadLine();
                        Console.WriteLine("Enter the Description of The Genre");
                        book.Author = Console.ReadLine();

                        db.Books.Update(book);

                        break;

                    case 3:
                        Console.WriteLine("Enter the Id of the Genre You want to Delete");
                        var bookid = int.Parse(Console.ReadLine());

                        var bookLooked = await db.Books.FindAsync(bookid);
                        db.Books.Update(bookLooked);

                        break;
                    case 4:
                        
                        var myBook = new Book();
                        
                        Console.WriteLine("Enter the Name of book");
                        myBook.Name = Console.ReadLine();
                        Console.WriteLine("Enter the autor");
                        myBook.Author = Console.ReadLine();
                        Console.WriteLine("Enter the edition year");
                        myBook.Year = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the id of the genre");
                        myBook.GenreId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the id of edition house");
                        myBook.EditionHouseId = Convert.ToInt32(Console.ReadLine());
                            
                        db.Books.Add(myBook);
                        db.SaveChanges();
                        
                        break;
                       
                        
                    case 5:

                        nextBook = false;

                        break;

                }

            }

            break;

        case 3:
            Console.WriteLine("Id \t Name  \t City ");
            var editionHouses = db.EditionHouses.ToList();
            foreach (var editionHouse in editionHouses)
            {
                Console.WriteLine($"{editionHouse.Id} \t {editionHouse.Name} \t {editionHouse.Adress}" );
            }
            break;
        case 4:

            Console.WriteLine("Enter the genre");
            var genreSingleLooked = Console.ReadLine();
            var list =  db.Genres.Include(i => i.Books).FirstOrDefault(i => i.Name == genreSingleLooked);

            foreach(var item in list.Books)
            {
                Console.WriteLine($"{item.Name} \t\t {item.Author}");
            }

            break;
    }
}
