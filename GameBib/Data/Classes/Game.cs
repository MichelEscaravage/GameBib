using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBib.Data.Classes
{
    internal class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
        public float Rating { get; set; }
        public DateTime ReleaseDate { get ; set; }
        public string ReleaseDateToString => ReleaseDate.ToString("dd/MM/yyyy");

        public ICollection<GameGenre> GameGenres { get; set; }
    }
}
