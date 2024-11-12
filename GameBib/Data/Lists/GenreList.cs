using GameBib.Data.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBib.Data.Lists
{
    internal class GenreList
    {
        public List<Genre> Genres = new List<Genre>
        {
            new Genre {Id = 1, Name = "Adventure" },
            new Genre {Id = 2, Name = "RPG" },
            new Genre {Id = 3, Name = "Action" },
            new Genre {Id = 4, Name = "Strategy" },
            new Genre {Id = 5, Name = "Puzzle" },
            new Genre {Id = 6, Name = "Simulation" },
            new Genre {Id = 7, Name = "MMORPG" },
            new Genre {Id = 8, Name = "Fantasy" }
        };

        public List<Genre> GetGenreList()
        {
            return Genres;
        }
    }
}
