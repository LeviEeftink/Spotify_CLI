using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify_CLI
{
    class User : Person
    {
        List<User> friends = new List<User>();
        public User(string name) : base(name)
        {

        }
        public List<User> getFriends()
        {
            return friends;
        }
        public void playSong(Song song, int durationCount)
        {
            for (int i = durationCount; i < song.Duration; i++)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true); 
                    if (key.Key == ConsoleKey.P)
                    {
                        this.pauseSong(song, i);
                        return; 
                    }
                }

                durationCount++;
                Console.WriteLine($"{song.Title}, {song.Artist}: {durationCount}/{song.Duration}");
                Thread.Sleep(1000); 
            }
            Console.WriteLine("Song finished");
        }

        public void pauseSong(Song song, int durationCount)
        {
            Console.WriteLine("Song paused");
            Console.WriteLine("1. Continue song");
            Console.WriteLine("2. Stop song");
            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    playSong(song, durationCount);
                    break;
                    case "2":
                    Console.WriteLine("Song stopped");
                    break;
                    default:
                    Console.WriteLine("Verkeerde input");
                    break;
            }
        }
        public void playAlbum (Album album)
        {
            foreach (Song song in album.ShowSongs())
            {
                playSong(song, 0);
            }
            Console.WriteLine("Album is fully played");
        }
        public void playPlaylist (Playlist playlist)
        {
            foreach (Song song in playlist.ShowSongs())
            {
                playSong(song, 0);
            }
            Console.WriteLine("Playlist is fully played");
        }
        public void shufflePlaylist (Playlist playlist)
        {
            List <Song> songs = playlist.ShowSongs();
            songs = songs.OrderBy(x => Random.Shared.Next()).ToList();
            foreach (Song song in songs)
            {
                playSong(song, 0);
            }
            Console.WriteLine("Playlist is fully shuffled");
        }
        public void shuffleAlbum(Album album)
        {
            List<Song> songs = album.ShowSongs();
            songs = songs.OrderBy(x => Random.Shared.Next()).ToList();
            foreach (Song song in songs)
            {
                playSong(song, 0);
            }
            Console.WriteLine("Album is fully shuffled");
        }
    }
}