using GameBib.Data.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBib.Data.Lists
{
    internal class UserGamesList
    {
        public List<UserGames> UserGames = new List<UserGames>()
        {
            new UserGames(1,1),
            new UserGames(2,2),
            new UserGames(3,3),
            new UserGames(4,4),
            new UserGames(5,5),
            new UserGames(6,6),
            new UserGames(7,7),
            new UserGames(8,8),
            new UserGames(9,9),
            new UserGames(10,10),
        };

        public List<UserGames> GetUserGames()
        {
            return UserGames;
        }
    }
}
