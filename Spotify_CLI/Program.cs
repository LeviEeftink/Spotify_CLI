using Spotify_CLI;
using static Playlist;

namespace Spotify_CLI
{
    internal class Program
    {
        private static List<User> allusers = new List<User>();
        private static List<Artist> allArtists = new List<Artist>();
        private static List<Song> allSongs = new List<Song>();
        private static List<Album> allAlbums = new List<Album>();
        private static List<Playlist> allPlaylists = new List<Playlist>();
        private static Person? activeUser = null;
        private static Admin admin = new Admin("admin");

        private static void Main(string[] args)
        {
            string[] names = { "levi", "stijn" };

            foreach (var name in names)
            {
                allusers.Add(new User(name));
            }

            while (true)
            {
                ShowMainMenu();
                Console.WriteLine();
            }
        }

        private static void ShowMainMenu()
        {
            Console.WriteLine("Ben je een admin of gebruiker? (of typ 'exit')");
            string option = Console.ReadLine()?.ToLower();

            if (option == "exit")
                Environment.Exit(0);

            switch (option)
            {
                case "admin":
                    setActiveUser(admin);
                    ShowAdminMainMenu();
                    break;

                case "gebruiker":
                    ShowUserLogin();
                    break;

                default:
                    Console.WriteLine("Verkeerde input.");
                    break;
            }
        }

        private static void ShowAdminMainMenu()
        {
            Console.WriteLine("Admin Menu:");
            Console.WriteLine("1. Artiest aanmaken");
            Console.WriteLine("2. Nummer aanmaken");
            Console.WriteLine("3. Album aanmaken");
            Console.WriteLine("4. Alle artiesten tonen");
            Console.WriteLine("5. Alle nummers tonen");
            Console.WriteLine("6. Alle albums tonen");
            Console.WriteLine("7. Playlist menu");
            Console.WriteLine("8. Terug naar hoofdmenu");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Artist newArtist = Artist.CreateArtist();
                    allArtists.Add(newArtist);
                    Console.WriteLine($"Artiest '{newArtist.Name}' is aangemaakt.");
                    break;
                case "2":
                    Song newSong = Song.CreateSong(allArtists);
                    if (newSong != null)
                    {
                        allSongs.Add(newSong);
                        Console.WriteLine($"Nummer '{newSong.Title}' is aangemaakt.");
                    }
                    break;
                case "3":
                    Album newAlbum = Album.CreateAlbum(allArtists, allSongs);
                    if (newAlbum != null)
                    {
                        allAlbums.Add(newAlbum);
                        Console.WriteLine($"Album '{newAlbum.Title}' is aangemaakt.");
                    }
                    break;
                case "4":
                    ShowArtists();
                    break;
                case "5":
                    Song.ToonSongs(allSongs);
                    break;
                case "6":
                    Album.ToonAlbums(allAlbums);
                    break;
                case "7":
                    ShowAdminPlaylistMenu();
                    break;
                case "8":
                    return;
                default:
                    Console.WriteLine("Ongeldige keuze.");
                    break;
            }
        }

        private static void ShowAdminPlaylistMenu()
        {
            Console.WriteLine("Playlist Menu:");
            Console.WriteLine("1. Playlist aanmaken");
            Console.WriteLine("2. Alle playlists tonen");
            Console.WriteLine("3. Terug");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Playlist newPlaylist = Playlist.CreatePlaylist(allSongs);
                    if (newPlaylist != null)
                    {
                        allPlaylists.Add(newPlaylist);
                        Console.WriteLine($"Playlist '{newPlaylist.Title}' is aangemaakt.");
                    }
                    break;

                case "2":
                    Playlist.ToonPlaylists(allPlaylists);
                    break;

                case "3":
                    return;

                default:
                    Console.WriteLine("Ongeldige keuze.");
                    break;
            }
        }

        private static void ShowUserLogin()
        {
            string username = "";
            do
            {
                Console.WriteLine("Wat is je gebruikersnaam?");
                username = Console.ReadLine();
            }
            while (!allusers.Any(u => u.name == username));

            User person = allusers.Find(u => u.name == username);
            setActiveUser(person);
            Console.WriteLine($"Welkom {getActiveUser().name}");
            ShowUserMenu(person);
        }

        private static void ShowUserMenu(User person)
        {
            Console.WriteLine("Gebruikersmenu:");
            Console.WriteLine("1. Toon alle nummers");
            Console.WriteLine("2. Toon alle albums");
            Console.WriteLine("3. Bekijk nummerdetails");
            Console.WriteLine("4. Maak een playlist");
            Console.WriteLine("5. Zoek naar playlists");
            Console.WriteLine("6. Speel een nummer");
            Console.WriteLine("7. Speel een album");
            Console.WriteLine("8. Speel een playlist");
            Console.WriteLine("9. Terug naar hoofdmenu");

            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    Song.ToonSongs(allSongs);
                    break;
                case "2":
                    Album.ToonAlbums(allAlbums);
                    break;
                case "3":
                    Console.WriteLine("Voer de titel van het nummer in:");
                    string titel = Console.ReadLine();
                    Song song = allSongs.Find(s => s.Title.ToLower() == titel.ToLower());
                    if (song != null)
                    {
                        Console.WriteLine($"Titel: {song.Title}");
                        Console.WriteLine($"Artiest: {song.Artist.Name}");
                    }
                    else
                    {
                        Console.WriteLine("Nummer niet gevonden.");
                    }
                    break;
                case "4":
                    Playlist userPlaylist = Playlist.CreatePlaylist(allSongs);
                    if (userPlaylist != null)
                    {
                        allPlaylists.Add(userPlaylist);
                        Console.WriteLine($"Playlist '{userPlaylist.Title}' is aangemaakt.");
                    }
                    break;
                case "5":
                    Console.WriteLine("Voer de naam van de playlist in:");
                    string search = Console.ReadLine();
                    var results = allPlaylists.Where(p => p.Title.ToLower().Contains(search.ToLower())).ToList();
                    if (results.Count > 0)
                    {
                        Console.WriteLine("Gevonden playlists:");
                        foreach (var pl in results)
                        {
                            Console.WriteLine($"- {pl.Title}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Geen overeenkomende playlists gevonden.");
                    }
                    break;
                case "6":
                    Song.ToonSongs(allSongs);
                    Console.WriteLine("Typ de naam van het nummer dat je wil afspelen:");
                    string songInput = Console.ReadLine();
                    Song songToPlay = allSongs.FirstOrDefault(s => s.Title.Equals(songInput, StringComparison.OrdinalIgnoreCase));
                    if (songToPlay != null)
                    {
                        person.playSong(songToPlay, 0);
                    }
                    else
                    {
                        Console.WriteLine("Nummer niet gevonden.");
                    }
                    break;
                case "7":
                    Album.ToonAlbums(allAlbums);
                    Console.WriteLine("Typ de naam van het album dat je wil afspelen");
                    string albumInput = Console.ReadLine();
                    Album albumToPlay = allAlbums.FirstOrDefault(s => s.Title.Equals(albumInput, StringComparison.OrdinalIgnoreCase));
                    if (albumToPlay != null)
                    {
                        Console.WriteLine("Wil je het album normaal afspelen of laten shuffelen?");
                        string option = Console.ReadLine();
                        switch (option)
                        {
                            case "1":
                                person.playAlbum(albumToPlay);
                                break;
                            case "2":
                                person.shuffleAlbum(albumToPlay);
                                break;
                            default:
                                Console.WriteLine("Verkeerde input!");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Album niet gevonden.");
                    }
                    return;
                case "8":
                    Playlist.ToonPlaylists(allPlaylists);
                    Console.WriteLine("Typ de naam van de playlist dat je wil afspelen");
                    string playlistInput = Console.ReadLine();
                    Playlist playlistToPlay = allPlaylists.FirstOrDefault(s => s.Title.Equals(playlistInput, StringComparison.OrdinalIgnoreCase));
                    if (playlistToPlay != null)
                    {
                        Console.WriteLine("Wil je de playlist normaal afspelen of laten shuffelen?");
                        string option = Console.ReadLine();
                        switch (option)
                        {
                            case "1":
                                person.playPlaylist(playlistToPlay);
                                break;
                                case "2":
                                person.shufflePlaylist(playlistToPlay);
                                break;
                                default:
                                Console.WriteLine("Verkeerde input!");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Playlist niet gevonden.");
                    }
                    return;
                default:
                    Console.WriteLine("Ongeldige keuze.");
                    break;
            }
        }

        private static void ShowArtists()
        {
            if (allArtists.Count == 0)
            {
                Console.WriteLine("Geen artiesten beschikbaar.");
            }
            else
            {
                Console.WriteLine("Alle artiesten:");
                foreach (var artist in allArtists)
                {
                    Console.WriteLine($"- {artist.Name}");
                }
            }
        }

        private static void setActiveUser(Person person) => activeUser = person;
        private static Person getActiveUser() => activeUser;
    }
}
