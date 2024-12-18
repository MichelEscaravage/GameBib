﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBib.Data.Classes
{
    internal class GameGenre
    {
        public int GameId { get; set; }
        public int GenreId { get; set; }
        public Game Game { get; set; }
        public Genre Genre { get; set; }

        public GameGenre(int gameId, int genreId)
        {
            GameId = gameId;
            GenreId = genreId;
        }
    }
}
