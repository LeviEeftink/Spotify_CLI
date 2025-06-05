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
            private static Person? activeUser = null;
            private static Admin admin = new Admin("admin");
        private static List<Playlist> allPlaylists = new List<Playlist>();

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
                Console.WriteLine("Ben je een admin of normale gebruiker (of typ 'exit' om te stoppen)?");
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
            Console.WriteLine("1. Artiest");
            Console.WriteLine("2. Nummer / Album");
            Console.WriteLine("3. Playlists");
            Console.WriteLine("4. Terug naar hoofdmenu");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ShowAdminArtistMenu();
                    break;
                case "2":
                    ShowAdminSongAlbumMenu();
                    break;
                case "3":
                    ShowAdminPlaylistMenu();
                    break;
                case "4":
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

        private static void ShowAdminArtistMenu()
            {
                Console.WriteLine("Artiest Menu:");
                Console.WriteLine("1. Artiest aanmaken");
                Console.WriteLine("2. Alle artiesten tonen");
                Console.WriteLine("3. Terug");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Artist newArtist = Artist.CreateArtist();
                        allArtists.Add(newArtist);
                        Console.WriteLine($"Artiest '{newArtist.Name}' is aangemaakt.");
                        break;

                    case "2":
                        ShowArtists();
                        break;

                    case "3":
                        return;

                    default:
                        Console.WriteLine("Ongeldige keuze.");
                        break;
                }
            }

            private static void ShowAdminSongAlbumMenu()
            {
                Console.WriteLine("Nummer / Album Menu:");
                Console.WriteLine("1. Nummer aanmaken");
                Console.WriteLine("2. Album aanmaken");
                Console.WriteLine("3. Alle nummers tonen");
                Console.WriteLine("4. Alle albums tonen");
                Console.WriteLine("5. Terug");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Song newSong = Song.CreateSong(allArtists);
                        if (newSong != null)
                        {
                            allSongs.Add(newSong);
                            Console.WriteLine($"Nummer '{newSong.Title}' is aangemaakt.");
                        }
                        break;

                    case "2":
                    Album newAlbum = Album.CreateAlbum(allArtists, allSongs);
                        if (newAlbum != null)
                        {
                            allAlbums.Add(newAlbum);
                            Console.WriteLine($"Album '{newAlbum.Title}' is aangemaakt.");
                        }
                        break;

                    case "3":
                        Song.ToonSongs(allSongs);
                        break;

                    case "4":
                        Album.ToonAlbums(allAlbums);
                        break;

                    case "5":
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

            Person person = allusers.Find(u => u.name == username);
                setActiveUser(person);
                Console.WriteLine($"Welkom {getActiveUser()}");
                ShowUserMenu();
            }

            private static void ShowUserMenu()
            {
                Console.WriteLine("Gebruikersmenu:");
                Console.WriteLine("1. Toon alle nummers");
                Console.WriteLine("2. Toon alle albums");
                Console.WriteLine("3. Terug naar hoofdmenu");

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
