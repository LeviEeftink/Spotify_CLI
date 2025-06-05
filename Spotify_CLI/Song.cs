namespace Spotify_CLI
{
    public class Song
    {
        public string Title { get; set; }
        public Artist Artist { get; set; }

        public Song(string title, Artist artist)
        {
            Title = title;
            Artist = artist;
        }

        public override string ToString()
        {
            return $"{Title} - {Artist.Name}";
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
            return new Song(title, selectedArtist);
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