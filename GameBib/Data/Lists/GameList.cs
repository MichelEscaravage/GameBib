using GameBib.Data.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBib.Data.Lists
{
    internal class GameList
    {
        public List<Game> Games = new List<Game>
        {
            new Game { Id = 1, Name = "Sky Quest", Description = "Journey above the clouds.", Rating = 4.5f, ReleaseDate = new DateTime(2021, 5, 20) },
            new Game { Id = 2, Name = "Mystic Forest", Description = "Explore a mystical forest.", Rating = 4.3f, ReleaseDate = new DateTime(2022, 1, 15) },
            new Game { Id = 3, Name = "Galactic Adventure", Description = "Space exploration game.", Rating = 4.7f, ReleaseDate = new DateTime(2019, 11, 10) },
            new Game { Id = 4, Name = "Dungeon Crawl", Description = "Deep dive into dungeons.", Rating = 4.0f, ReleaseDate = new DateTime(2020, 8, 30) },
            new Game { Id = 5, Name = "World of Warcraft", Description = "Epic fantasy MMORPG.", Rating = 4.8f, ReleaseDate = new DateTime(2004, 11, 23) },
            new Game { Id = 6, Name = "The Elder Scrolls V: Skyrim", Description = "Fantasy RPG with dragons.", Rating = 4.9f, ReleaseDate = new DateTime(2011, 11, 11) },
            new Game { Id = 7, Name = "Zelda: Breath of the Wild", Description = "Open-world adventure.", Rating = 4.9f, ReleaseDate = new DateTime(2017, 3, 3) },
            new Game { Id = 8, Name = "Mystic Ruins", Description = "Ancient mysteries await.", Rating = 4.2f, ReleaseDate = new DateTime(2020, 6, 1) },
            new Game { Id = 9, Name = "Ocean Explorer", Description = "Underwater exploration.", Rating = 4.0f, ReleaseDate = new DateTime(2018, 5, 12) },
            new Game { Id = 10, Name = "City Builder", Description = "Build and manage a city.", Rating = 4.3f, ReleaseDate = new DateTime(2019, 7, 22) },
            new Game { Id = 11, Name = "Space Commander", Description = "Strategic space battles.", Rating = 4.1f, ReleaseDate = new DateTime(2021, 9, 15) },
            new Game { Id = 12, Name = "Farm Life", Description = "Manage your farm.", Rating = 4.4f, ReleaseDate = new DateTime(2020, 4, 9) },
            new Game { Id = 13, Name = "Puzzle Quest", Description = "Challenging puzzle game.", Rating = 4.2f, ReleaseDate = new DateTime(2021, 2, 27) },
            new Game { Id = 14, Name = "Desert Survival", Description = "Survive in the desert.", Rating = 3.8f, ReleaseDate = new DateTime(2018, 10, 14) },
            new Game { Id = 15, Name = "Castle Defender", Description = "Defend the castle.", Rating = 4.0f, ReleaseDate = new DateTime(2019, 12, 2) },
            new Game { Id = 16, Name = "Jungle Hunt", Description = "Adventure in the jungle.", Rating = 3.9f, ReleaseDate = new DateTime(2017, 8, 5) },
            new Game { Id = 17, Name = "Galaxy Rangers", Description = "Protect the galaxy.", Rating = 4.5f, ReleaseDate = new DateTime(2020, 1, 3) },
            new Game { Id = 18, Name = "Cyber City", Description = "Futuristic city RPG.", Rating = 4.1f, ReleaseDate = new DateTime(2019, 3, 11) },
            new Game { Id = 19, Name = "Mountain Climber", Description = "Conquer the peaks.", Rating = 3.8f, ReleaseDate = new DateTime(2021, 6, 23) },
            new Game { Id = 20, Name = "Pirate Seas", Description = "Sail the seas as a pirate.", Rating = 4.2f, ReleaseDate = new DateTime(2021, 4, 8) },
            new Game { Id = 21, Name = "Haunted Mansion", Description = "Explore a haunted mansion.", Rating = 3.7f, ReleaseDate = new DateTime(2020, 10, 31) },
            new Game { Id = 22, Name = "Island Escape", Description = "Survive on a deserted island.", Rating = 4.3f, ReleaseDate = new DateTime(2018, 7, 18) },
            new Game { Id = 23, Name = "Battle Arena", Description = "Intense PvP battles.", Rating = 4.2f, ReleaseDate = new DateTime(2021, 12, 10) },
            new Game { Id = 24, Name = "Space Odyssey", Description = "Journey through space.", Rating = 4.6f, ReleaseDate = new DateTime(2017, 9, 7) },
            new Game { Id = 25, Name = "Medieval Conquest", Description = "Strategy game set in medieval times.", Rating = 4.0f, ReleaseDate = new DateTime(2019, 6, 29) },
            new Game { Id = 26, Name = "Robot Revolution", Description = "Lead a robot rebellion.", Rating = 4.1f, ReleaseDate = new DateTime(2020, 3, 20) },
            new Game { Id = 27, Name = "Dragon Kingdom", Description = "Adventure with dragons.", Rating = 4.7f, ReleaseDate = new DateTime(2018, 2, 5) },
            new Game { Id = 28, Name = "Viking Quest", Description = "Embark on a Viking adventure.", Rating = 4.5f, ReleaseDate = new DateTime(2017, 11, 20) },
            new Game { Id = 29, Name = "Alien Invasion", Description = "Defend Earth from aliens.", Rating = 3.9f, ReleaseDate = new DateTime(2022, 5, 4) },
            new Game { Id = 30, Name = "War of Empires", Description = "Command your empire to victory.", Rating = 4.6f, ReleaseDate = new DateTime(2020, 12, 6) }
        };
        public List<Game> GetGameList()
        {
            return Games;
        }
    }
}

