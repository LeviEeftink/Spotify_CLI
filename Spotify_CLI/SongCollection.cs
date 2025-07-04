﻿using Spotify_CLI;

public class SongCollection
{
    public string Title { get; set; }
    protected List<Song> Songs { get; set; }

    public SongCollection(string title)
    {
        Title = title;
        Songs = new List<Song>();
    }

    public List<Song> ShowSongs()
    {
        return Songs;
    }
    public void compareCollectionToNewPlaylist(SongCollection collectie2, string username)
    {
        SongCollection[] collections = { this, collectie2 };
        string[] genreCollection = Enum.GetNames(typeof(Genre));
        int[] genreCount = new int[genreCollection.Length];
        for (int i = 0; i < genreCollection.Length; i++)
        {
            genreCount[i] = 0;
        }
        foreach (SongCollection collectie in collections)
        {
            foreach (Song song in collectie.Songs)
            {
                Genre genre = song.Genre;
                int genreIndex = (int)genre;
                genreCount[genreIndex]++;
            }
        }
        int maxCount = 0;
        int maxGenreIndex = 0;
        for (int i = 0; i < genreCount.Length; i++)
        {
            if (genreCount[i] > maxCount)
            {
                maxCount = genreCount[i];
                maxGenreIndex = i;
            }
        }
        Genre mostCommonGenre = (Genre)maxGenreIndex;
        Playlist generatedPlaylist = new Playlist($"compared playlist {this.Title} and {collectie2.Title}", username);
        foreach (SongCollection collectie in collections)
        {
            foreach (Song song in collectie.Songs)
            {
                if (song.Genre == mostCommonGenre)
                {
                    generatedPlaylist.Songs.Add(song);
                }
            }
        }
    }
}
public class Playlist : SongCollection
{
    public string Owner { get; set; }

    public Playlist(string title, string owner) : base(title)
    {
        Owner = owner;
    }
    internal static Playlist CreatePlaylist(List<Song> allSongs)
    {
        if (allSongs.Count == 0)
        {
            Console.WriteLine("Geen nummers beschikbaar. Maak eerst een nummer aan.");
            return null;
        }

        Console.Write("Voer de naam van de playlist in: ");
        string playlistTitle = Console.ReadLine();

        Console.Write("Voer de naam van de eigenaar in: ");
        string owner = Console.ReadLine();

        Playlist playlist = new Playlist(playlistTitle, owner);

        while (true)
        {
            Console.WriteLine("Voeg nummers toe. Typ 0 om te stoppen.");
            for (int i = 0; i < allSongs.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {allSongs[i].Title} (Artiest: {allSongs[i].Artist.Name})");
            }

            string choice = Console.ReadLine();
            if (choice == "0")
            {
                break;
            }

            if (int.TryParse(choice, out int songIndex) && songIndex >= 1 && songIndex <= allSongs.Count)
            {
                Song selectedSong = allSongs[songIndex - 1];
                if (!playlist.Songs.Contains(selectedSong))
                {
                    playlist.Songs.Add(selectedSong);
                    Console.WriteLine($"Nummer '{selectedSong.Title}' toegevoegd.");
                }
                else
                {
                    Console.WriteLine("Nummer is al toegevoegd aan de playlist.");
                }
            }
            else
            {
                Console.WriteLine("Ongeldige keuze, probeer opnieuw.");
            }
        }

        if (playlist.Songs.Count == 0)
        {
            Console.WriteLine("Er zijn geen nummers toegevoegd. Playlist wordt niet aangemaakt.");
            return null;
        }

        return playlist;
    }

    internal static void ToonPlaylists(List<Playlist> playlists)
    {
        if (playlists.Count == 0)
        {
            Console.WriteLine("Geen playlists beschikbaar.");
            return;
        }

        Console.WriteLine("Playlists:");
        foreach (var playlist in playlists)
        {
            Console.WriteLine($"Playlist: {playlist.Title} - Eigenaar: {playlist.Owner}");
            Console.WriteLine("Nummers:");
            foreach (var song in playlist.ShowSongs())
            {
                Console.WriteLine($"  - {song.Title} (Artiest: {song.Artist.Name})");
            }
        }
    }
}
public class Album : SongCollection
{
    public List<Artist> Artists { get; set; }

    public Album(string title, List<Artist> artists) : base(title)
    {
        Artists = artists;
    }

    public List<Artist> ShowArtists()
    {
        return Artists;
    }

    public static Album CreateAlbum(List<Artist> allArtists, List<Song> allSongs)
    {
        if (allArtists.Count == 0)
        {
            Console.WriteLine("Geen artiesten beschikbaar. Maak eerst een artiest aan.");
            return null;
        }

        if (allSongs.Count == 0)
        {
            Console.WriteLine("Geen nummers beschikbaar. Maak eerst een nummer aan.");
            return null;
        }

        Console.Write("Voer de naam van het album in: ");
        string albumTitle = Console.ReadLine();

        Console.WriteLine("Kies artiesten (typ nummers gescheiden door komma):");
        for (int i = 0; i < allArtists.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {allArtists[i].Name}");
        }

        List<Artist> selectedArtists = new List<Artist>();
        while (selectedArtists.Count == 0)
        {
            Console.Write("Voer de nummers van de artiesten in: ");
            string input = Console.ReadLine();
            var indexes = input.Split(',');

            foreach (var indexStr in indexes)
            {
                if (int.TryParse(indexStr.Trim(), out int artistIndex) &&
                    artistIndex >= 1 && artistIndex <= allArtists.Count)
                {
                    var artist = allArtists[artistIndex - 1];
                    if (!selectedArtists.Contains(artist))
                    {
                        selectedArtists.Add(artist);
                    }
                }
            }

            if (selectedArtists.Count == 0)
            {
                Console.WriteLine("Ongeldige keuze, probeer opnieuw.");
            }
        }

        Album album = new Album(albumTitle, selectedArtists);

        while (true)
        {
            Console.WriteLine("Voeg nummers toe. Typ 0 om te stoppen.");
            for (int i = 0; i < allSongs.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {allSongs[i].Title} (Artiest: {allSongs[i].Artist.Name})");
            }

            string choice = Console.ReadLine();
            if (choice == "0")
            {
                break;
            }

            if (int.TryParse(choice, out int songIndex) && songIndex >= 1 && songIndex <= allSongs.Count)
            {
                Song selectedSong = allSongs[songIndex - 1];
                if (!album.Songs.Contains(selectedSong))
                {
                    album.Songs.Add(selectedSong);
                    Console.WriteLine($"Nummer '{selectedSong.Title}' toegevoegd.");
                }
                else
                {
                    Console.WriteLine("Nummer is al toegevoegd aan het album.");
                }
            }
            else
            {
                Console.WriteLine("Ongeldige keuze, probeer opnieuw.");
            }
        }

        if (album.Songs.Count == 0)
        {
            Console.WriteLine("Er zijn geen nummers toegevoegd. Album wordt niet aangemaakt.");
            return null;
        }

        return album;
    }
    public static void ToonAlbums(List<Album> albums)
    {
        if (albums.Count == 0)
        {
            Console.WriteLine("Geen albums beschikbaar.");
            return;
        }

        Console.WriteLine("Albums:");
        foreach (var album in albums)
        {
            Console.WriteLine($"Album: {album.Title}");
            Console.WriteLine("Artiesten:");
            foreach (var artist in album.ShowArtists())
            {
                Console.WriteLine($"  - {artist.Name}");
            }
            Console.WriteLine("Nummers:");
            foreach (var song in album.ShowSongs())
            {
                Console.WriteLine($"  - {song.Title} (Artiest: {song.Artist.Name})");
            }
            Console.WriteLine();
        }
    }
}