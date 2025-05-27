// See https://aka.ms/new-console-template for more information
namespace Spotify_CLI
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<User> allusers = new List<User>();
            Person? activeUser = null;
            string[] names = {"levi", "stijn" };
            Admin admin = new Admin("admin");
            for (int i = 0; i < names.Length; i++)
            {
                User user = new User(names[i]);
                allusers.Add(user);
            }
            void menu()
            {
                string option = "";
                Console.WriteLine("Ben je een admin of normale gebruiker");
                option = Console.ReadLine();
                switch (option)
                {
                    case "admin":
                        setActiveUser(admin);
                        Console.WriteLine("welkom admin");
                        Console.WriteLine("Wat wil je doen:");
                        Console.WriteLine("1. Artiest aanmaken");
                        Console.WriteLine("2. Nummer aanmaken");
                        Console.WriteLine("3. Album aanmaken");
                        string adminInput = Console.ReadLine();
                        switch (adminInput)
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
                        string username = "";
                        while (!allusers.Any(u => u.name == username))
                        {
                            Console.WriteLine("Wat is je gebruikersnaam");
                            username = Console.ReadLine();
                        }
                        Person person = allusers.Find(u => u.name == username);
                        setActiveUser(person);
                        Console.WriteLine($"Welkom {getActiveUser().ToString()}");
                        Console.WriteLine("Wat wil je doen:");
                        Console.WriteLine("1. Toon alle nummers");
                        Console.WriteLine("2. Toon alle albums");
                        string userInput = Console.ReadLine();
                        switch (userInput)
                        {
                            case "1":
                                break;
                            case "2":
                                break;
                        }
                        break;
                    default:
                        Console.WriteLine("verkeerde input");
                        break;
                }
            }
            void setActiveUser(Person person)
            {
                activeUser = person;
            }
            Person getActiveUser()
            {
                return activeUser;
            }
            menu();
        }
    }
}