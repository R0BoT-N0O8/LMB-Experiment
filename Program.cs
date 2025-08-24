using System.Diagnostics;
using System.Media;

namespace T1._9;

class Program
{
    static void Main(string[] args)
    {
        SoundPlayer bootup = new SoundPlayer("bootup.wav");
        SoundPlayer menuyes = new SoundPlayer("menuyes.wav");
        SoundPlayer menuno = new SoundPlayer("menuerror.wav");
        SoundPlayer fire = new SoundPlayer("fire.wav");
        SoundPlayer removebook = new SoundPlayer("removebook.wav");
        SoundPlayer addbook = new SoundPlayer("addbook.wav");
        SoundPlayer search = new SoundPlayer("search.wav");
        SoundPlayer Nuh_Uh = new SoundPlayer("nuhuh.wav");

        List<Book> books = new List<Book>();

        string asciilogo =
        @"
┌───────────────────────────────────────────────────┐
│  .---.            ,---.    ,---.        _______   │
│  | ,_|            |    \  /    |       \  ____  \ │
│,-./  )            |  ,  \/  ,  |       | |    \ | │
│\  '_ '`)          |  |\_   /|  |       | |____/ / │
│ > (_)  )          |  _( )_/ |  |       |   _ _ '. │
│(  .  .-'          | (_ o _) |  |       |  ( ' )  \│
│ `-'`-'|___        |  (_,_)  |  |       | (_{;}_) |│
│  |        \       |  |      |  |       |  (_,_)  /│
│  `--------`       '--'      '--'       /_______.' │
└───────────────────────────────────────────────────┘
        ";

        int fee = 298071;

        bool secret1 = false;
        bool secret2 = false;
        bool secret3 = false;
        bool secret4 = false;
        bool secret5 = false;

        Console.Clear();
        Console.WriteLine("\x1b[3J");

        Console.WriteLine("Salutations!");
        menuyes.Play();
        System.Threading.Thread.Sleep(2000);
        Console.WriteLine("Welcome to the Library Management Beta (LMB).");
        Console.WriteLine(asciilogo);
        bootup.Play();
        System.Threading.Thread.Sleep(2000);
        Console.WriteLine(" ");
        Console.WriteLine("Type 'help' for a list of commands.");
        menuyes.Play();
        while (true)
        {
            Console.WriteLine(" ");
            Console.Write("> ");
            string? command = Console.ReadLine();
            Console.Clear();

            if (command?.ToLower() == ("help"))
            {
                menuyes.Play();
                Console.WriteLine(" ");
                Console.WriteLine("----------------=[ V.1 Commands ]=----------------");
                Console.WriteLine(" ");
                Console.WriteLine("add - Add a new book");
                Console.WriteLine("remove - Remove a book");
                Console.WriteLine("list - List all books");
                Console.WriteLine("genre - List all books, by Genre");
                Console.WriteLine("fire - Burns all books");
                Console.WriteLine("search - Search for a book by author or title");
                Console.WriteLine(" ");
                Console.WriteLine("special_function - Passcode required");
                Console.WriteLine(" ");
                Console.WriteLine("help - Show this help message");
                Console.WriteLine("exit - Exit the program");
                Console.WriteLine(" ");
                Console.WriteLine("----------------=[ V.1 Commands ]=----------------");
                Console.WriteLine(" ");
                Console.WriteLine(" ");
                Console.WriteLine("There are some additional secret commands.");
                Console.WriteLine("Find them all for an additional secret function.");
                Console.WriteLine(" ");
                Console.WriteLine("..Actually, ran out of time to make this. sorry.. :<");
            }
            else if (command?.ToLower() == ("add"))
            {
                menuyes.Play();
                Console.WriteLine(" ");
                Console.Write("Enter book title: ");
                string title = Console.ReadLine();
                Console.Write("Enter author: ");
                string author = Console.ReadLine();
                Console.Write("Enter year: ");
                int year = int.Parse(Console.ReadLine());
                Console.Write("Enter genre: ");
                string genre = Console.ReadLine();
                books.Add(new Book { Title = title, Author = author, Year = year, Genre = genre });
                addbook.Play();
                Console.Clear();
                Console.WriteLine("Book added.");
            }
            else if (command?.ToLower() == ("remove"))
            {
                menuyes.Play();
                Console.WriteLine(" ");
                Console.Write("Enter title of book to remove: ");
                string titleToRemove = Console.ReadLine();
                Book? bookToRemove = books.FirstOrDefault(b => b.Title.ToLower() == titleToRemove.ToLower());
                if (bookToRemove != null)
                {
                    books.Remove(bookToRemove);
                    removebook.Play();
                    Console.WriteLine("Book removed.");
                }
                else
                {
                    menuno.Play();
                    Console.WriteLine("Book not found.");
                }
            }
            else if (command?.ToLower() == ("list"))
            {
                menuyes.Play();
                Console.WriteLine(" ");
                if (books.Count == 0)
                {
                    Console.WriteLine("..Huh. The library is empty.");
                    Console.WriteLine("What kind of library has no books?!");
                }
                else
                {
                    foreach (Book b in books)
                    {
                        Console.WriteLine($"{b.Title} - {b.Author} - {b.Year} - {b.Genre}");
                    }
                }
            }
            else if (command?.ToLower() == ("search"))
            {
                menuyes.Play();
                Console.WriteLine(" ");
                Console.Write("Enter search query (title or author): ");
                string query = Console.ReadLine().ToLower();
                var results = books.Where(b => b.Title.ToLower().Contains(query) || b.Author.ToLower().Contains(query));
                foreach (var b in results)
                {
                    Console.WriteLine($"{b.Title} - {b.Author} - {b.Year} - {b.Genre}");
                }
            }
            else if (command?.ToLower() == "genre")
            {
                menuyes.Play();
                Console.WriteLine(" ");
                Console.Write("Enter genre to filter: ");
                string genreSearch = Console.ReadLine();
                var filtered = books.Where(b => b.Genre.ToLower() == genreSearch.ToLower());
                menuyes.Play();
                Console.WriteLine(" ");
                foreach (var b in filtered)
                {
                    Console.WriteLine($"{b.Title} - {b.Author} - {b.Year} - {b.Genre}");
                }
            }
            else if (command?.ToLower() == ("fire"))
            {
                menuyes.PlaySync();
                fire.Play();
                Console.WriteLine(" ");
                Console.WriteLine("A fire has been mysteriously lit!");
                System.Threading.Thread.Sleep(500);
                Console.WriteLine("The library is now burning down!");
                System.Threading.Thread.Sleep(2000);
                books.Clear();
                Console.WriteLine("All stored books have now been lost.");
                System.Threading.Thread.Sleep(2000);
                Console.WriteLine($"You now owe the library {fee}€ in damages.");
                fee += 29807041; // The more you burn, the more you owe.
            }
            else if (command?.ToLower() == ("exit"))
            {
                menuyes.PlaySync();
                System.Threading.Thread.Sleep(1000);
                menuno.PlaySync();
                System.Threading.Thread.Sleep(350);
                menuno.PlaySync();
                System.Threading.Thread.Sleep(350);
                menuno.PlaySync();
                System.Threading.Thread.Sleep(350);
                Console.WriteLine(" ");
                Console.WriteLine("Goodbyeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee");
                break;
            }
            else if (command?.ToLower() == ("special_function"))
            {
                menuyes.Play();
                Console.WriteLine(" ");
                Console.WriteLine("Please enter passcode.");
                Console.WriteLine("type 'exit' to cancel.");
                while (true)
                {
                    Console.WriteLine(" ");
                    Console.Write("> ");
                    string? passcodeentry = Console.ReadLine();
                    Console.Clear();
                    if (passcodeentry == "passcode") // no, not unfinished, the passcode is literally passcode XD
                    {
                        menuyes.Play();
                        System.Diagnostics.Process.Start(new ProcessStartInfo("https://www.youtube.com/watch?v=uHgt8giw1LY") { UseShellExecute = true });
                        secret1 = true;
                        break;
                    }
                    else if (passcodeentry == "exit")
                    {
                        menuyes.Play();
                        Console.Clear();
                        break;
                    }
                    else
                    {
                        menuno.Play();
                        Console.WriteLine("Incorrect.");
                    }
                }
            }
            else if (command?.ToLower() == ("hello") || command?.ToLower() == ("hey") || command?.ToLower() == ("hi"))
            {
                menuyes.Play();
                Console.WriteLine(" ");
                Console.WriteLine("...Salutations.");
                secret2 = true;
            }
            else if (command?.ToLower() == ("nuh uh") || command?.ToLower() == ("no"))
            {
                menuyes.PlaySync();
                menuyes.PlaySync();
                menuyes.PlaySync();
                menuyes.PlaySync();
                menuyes.PlaySync();
                Nuh_Uh.Play();
                Console.WriteLine(" ");
                Console.WriteLine("> Connection established.");
                Console.WriteLine(" ");
                Console.WriteLine("Luke, i am your father.");
                System.Threading.Thread.Sleep(4700);
                Console.WriteLine("The fuck you mean, 'Nuh uh'??");
                System.Threading.Thread.Sleep(3200);
                Console.WriteLine("Yuh uh! I am your dad!");
                System.Threading.Thread.Sleep(3100);
                Console.WriteLine("The fuck does that even mean, 'Nuh uh'? What the f-");
                System.Threading.Thread.Sleep(2500);
                Console.WriteLine(" ");
                Console.WriteLine("> Connection timeout.");
                secret3 = true;
            }
            else
            {
                menuno.Play();
                Console.WriteLine(" ");
                Console.WriteLine("Unknown command. Type 'help' for a list of commands.");
            }
        }
    }
}