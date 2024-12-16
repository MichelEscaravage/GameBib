using GameBib.Data.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBib.Data.Lists
{
    internal class GamesGenresLists
    {
        public List<GameGenre> GameGenres = new List<GameGenre>
        {
            new GameGenre(1, 1), 
            new GameGenre(1, 2), 
            new GameGenre(2, 1), 
            new GameGenre(2, 3), 
            new GameGenre(3, 1), 
            new GameGenre(3, 4), 
            new GameGenre(4, 2), 
            new GameGenre(4, 3), 
            new GameGenre(5, 7), 
            new GameGenre(5, 8), 
            new GameGenre(6, 2), 
            new GameGenre(6, 8), 
            new GameGenre(7, 1), 
            new GameGenre(8, 1), 
            new GameGenre(9, 6), 
            new GameGenre(10, 4),
            new GameGenre(11, 4),
            new GameGenre(12, 6),
            new GameGenre(13, 5),
            new GameGenre(14, 1),
            new GameGenre(15, 3),
            new GameGenre(16, 1),
            new GameGenre(17, 1),
            new GameGenre(17, 4),
            new GameGenre(29, 3),
            new GameGenre(18, 4),
            new GameGenre(27, 2),
            new GameGenre(21, 1),
            new GameGenre(22, 6),
            new GameGenre(25, 7),
            new GameGenre(19, 5),
            new GameGenre(20, 8),
            new GameGenre(26, 3),
            new GameGenre(24, 7),
            new GameGenre(28, 8),
            new GameGenre(30, 4),
            new GameGenre(23, 1),

        };

        public List<GameGenre> GetGameGenres()
        {
            return GameGenres;
        }
    }
}
