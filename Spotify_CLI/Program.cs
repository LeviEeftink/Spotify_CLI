// See https://aka.ms/new-console-template for more information

void menu()
{
    Console.WriteLine("Ben je een admin of normale gebruiker");
    string option = Console.ReadLine();
     switch(option)
    {
        case "admin":
            Console.WriteLine("welkom admin");
            break;
        case "gebruiker":
            Console.WriteLine("Wat is je gebruikersnaam");
            string username = Console.ReadLine();
            switch(username)
            {
                case "levi":
                    Console.WriteLine($"Welkom {username}");
                    break;
                case "stijn":
                    Console.WriteLine($"welkom {username}");
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