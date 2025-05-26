using System;
using System.Collections.Generic;

using System;
using System.Collections.Generic;

using Spotify_CLI;




class Program
{

    static void Main()
    {
        while (true)
        {
            menu();
        }
    }

    static void menu()
    {
        Console.WriteLine();
        Console.WriteLine("Ben je een admin of normale gebruiker");
        string option = Console.ReadLine();

        if (option.ToLower() == "exit")
        {
            Environment.Exit(0);
        }

        switch (option.ToLower())
        {
            case "admin":
                Console.WriteLine("welkom admin");
                Console.WriteLine("Wat wil je doen:");
                Console.WriteLine("1. Artiest aanmaken");
                Console.WriteLine("2. Nummer aanmaken");
                Console.WriteLine("3. Album aanmaken");
                Console.WriteLine("Typ 'menu' om terug te gaan");
                string adminInput = Console.ReadLine();
                if (adminInput.ToLower() == "menu") return;

                switch (adminInput)
                {
                    case "1":
                        break;
                    case "2":
                        Song.CreateSong();
                        break;
                    case "3":
                        break;
                    default:
                        Console.WriteLine("Ongeldige keuze.");
                        break;
                }
                break;

            case "gebruiker":
                Console.WriteLine("Wat is je gebruikersnaam");
                string username = Console.ReadLine();
                if (username.ToLower() == "menu") return;

                switch (username.ToLower())
                {
                    case "levi":
                    case "stijn":
                        Console.WriteLine($"Welkom {username}");
                        Console.WriteLine("Wat wil je doen:");
                        Console.WriteLine("1. Toon alle nummers");
                        Console.WriteLine("2. Toon alle albums");
                        Console.WriteLine("Typ 'menu' om terug te gaan");
                        string userInput = Console.ReadLine();
                        if (userInput.ToLower() == "menu") return;

                        switch (userInput)
                        {
                            case "1":
                                break;
                            case "2":
                                break;
                            default:
                                Console.WriteLine("Ongeldige keuze.");
                                break;
                        }
                        break;
                    default:
                        Console.WriteLine("Gebruiker niet herkend.");
                        break;
                }
                break;

            default:
                Console.WriteLine("verkeerde input");
                break;
        }
    }
 }







