namespace Spotify_CLI
{
    public class Artist
    {
        public string Name { get; set; }

        public Artist(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }

        public static Artist CreateArtist()
        {
            Console.Write("Voer de naam van de artiest in: ");
            string name = Console.ReadLine();
            return new Artist(name);
        }
    }
}
