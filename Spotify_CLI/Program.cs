// See https://aka.ms/new-console-template for more information

void menu()
{
    Console.WriteLine("Ben je een admin of normale gebruiker");
    string option = Console.ReadLine();
     switch(option)
    {
        case "admin":
            Console.WriteLine("welkom admin");
            Console.WriteLine("Wat wil je doen:");
            Console.WriteLine("1. Artiest aanmaken");
            Console.WriteLine("2. Nummer aanmaken");
            Console.WriteLine("3. Album aanmaken");
            string adminInput = Console.ReadLine();
            switch(adminInput)
            {
                case "1": 
                    break;
                case "2":
                    break;
                case "3":
                    break;
                    default:
                    break;

            }
            break;
        case "gebruiker":
            Console.WriteLine("Wat is je gebruikersnaam");
            string username = Console.ReadLine();
            switch(username)
            {
                case "levi":
                    Console.WriteLine($"Welkom {username}");
                    Console.WriteLine("Wat wil je doen:");
                    Console.WriteLine("1. Toon alle nummers");
                    Console.WriteLine("2. Toon alle albums");
                    string userInput = Console.ReadLine();
                    switch(userInput)
                    {
                        case "1":
                            break;
                        case "2":
                            break;
                    }
                    break;
                case "stijn":
                    Console.WriteLine($"Welkom {username}");
                    Console.WriteLine("Wat wil je doen:");
                    Console.WriteLine("1. Toon alle nummers");
                    Console.WriteLine("2. Toon alle albums");
                    string user2Input = Console.ReadLine();
                    switch (user2Input)
                    {
                        case "1":
                            break;
                        case "2":
                            break;
                    }
                    break;
                default:
                    break;
            }
            break;
        default:
            Console.WriteLine("verkeerde input");
            break;
    }
}

menu();