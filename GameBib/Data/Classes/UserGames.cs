using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBib.Data.Classes
{
    internal class UserGames
    {
        public int UserId { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }
        public User User { get; set; }

        public UserGames(int userId, int gameId)
        {
            UserId = userId;
            GameId = gameId;
        }
    }


}
