using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spotify_CLI;

namespace Spotify_CLI
{
    class Artist
    {
        public string Name { get; set; }

        public Artist(string name)
        {
            Name = name;
        }

        public override string ToString() => Name;
    }
}
