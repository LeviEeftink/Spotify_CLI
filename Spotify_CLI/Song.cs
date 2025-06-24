namespace Spotify_CLI
{
    public enum Genre
    {
        Rap,
        Pop,
        Metal,
        Rock,
        Trance,
        Uptempo,
        Hardcore,
        Rawstyle,
        Hardstyle,
    }
    public class Song
    {
        public string Title { get; set; }
        public Artist Artist { get; set; }
        public int Duration { get; set; } // in seconden
        public Genre Genre { get; set; }

        public Song(string title, Artist artist, int duration, Genre genre)
        {
            Title = title;
            Artist = artist;
            Duration = duration;
            Genre = genre;
        }

        public override string ToString()
        {
            var minutes = Duration / 60;
            var seconds = Duration % 60;
            return $"{Title} - {Genre} - {Artist.Name} ({minutes}:{seconds:D2})";
        }

        public static Song CreateSong(List<Artist> allArtists)
        {
            if (allArtists.Count == 0)
            {
                Console.WriteLine("Geen artiesten beschikbaar. Maak eerst een artiest aan.");
                return null;
            }

            Console.Write("Voer de titel van het nummer in: ");
            string title = Console.ReadLine();

            Console.WriteLine("Kies een artiest:");
            for (int i = 0; i < allArtists.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {allArtists[i].Name}");
            }

            int artistIndex;
            while (!int.TryParse(Console.ReadLine(), out artistIndex) || artistIndex < 1 || artistIndex > allArtists.Count)
            {
                Console.WriteLine("Ongeldige keuze. Probeer opnieuw.");
            }

            Artist selectedArtist = allArtists[artistIndex - 1];

            Console.Write("Voer de duur van het nummer in (in seconden): ");
            int duration;
            while (!int.TryParse(Console.ReadLine(), out duration) || duration <= 0)
            {
                Console.WriteLine("Ongeldige invoer. Voer een positief getal in.");
            }
            Console.WriteLine("Kies een genre uit de lijst:");
            int p = 0;
            foreach (Genre genre in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine($"{p}: {genre}");
                p++;
            }
            int genreIndex = int.Parse(Console.ReadLine()); 
            Genre selectedGenre = (Genre)genreIndex;

            return new Song(title, selectedArtist, duration, selectedGenre);
        }

        public static void ToonSongs(List<Song> songs)
        {
            if (songs.Count == 0)
            {
                Console.WriteLine("Er zijn nog geen nummers.");
            }
            else
            {
                Console.WriteLine("Alle nummers:");
                foreach (var song in songs)
                {
                    Console.WriteLine($"- {song}");
                }
            }
        }
    }
}