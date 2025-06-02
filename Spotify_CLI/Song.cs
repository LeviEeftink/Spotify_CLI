using Spotify_CLI;

enum SongGenre
{
    Pop, Rock, HipHop, Jazz, Klassiek, Uptempo, Anders
}


class Song
{

    public string Title { get; set; }
    public List<Artist> Artists { get; set; }
    public int Duration { get; set; }
    public DateTime ReleaseDate { get; set; }
    public SongGenre Genre { get; set; }

    public Song(string title, List<Artist> artists, int duration, DateTime releaseDate, SongGenre genre)
    {
        Title = title;
        Artists = artists;
        Duration = duration;
        ReleaseDate = releaseDate;
        Genre = genre;
    }

    public override string ToString()
    {
        string artistNames = string.Join(", ", Artists);
        return $"{Title} door {artistNames} \n {Duration} sec \n {ReleaseDate.ToShortDateString()} \n Genre: {Genre}";
    }
    static List<Song> songs = new List<Song>();
    public static void CreateSong()
    {

        Console.Write("Titel van het nummer: ");
        string title = Console.ReadLine();

        Console.Write("Naam van de artiest: ");
        string artistName = Console.ReadLine();
        var artists = new List<Artist> { new Artist(artistName) };

        Console.Write("Duur (in seconden): ");
        int duration = int.Parse(Console.ReadLine());

        Console.Write("Releasedatum (yyyy-mm-dd): ");
        DateTime releaseDate = DateTime.Parse(Console.ReadLine());

        Console.WriteLine("Genre (Pop, Rock, HipHop, Jazz, Klassiek, Uptempo, Anders): ");
        SongGenre genre = (SongGenre)Enum.Parse(typeof(SongGenre), Console.ReadLine(), true);

        Song newSong = new Song(title, artists, duration, releaseDate, genre);
        songs.Add(newSong);

        Console.WriteLine(newSong.ToString());
    }
}
