using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameBib.Data.Classes;
using static GameBib.MainWindow;

namespace GameBib.Utility
{
    internal class EditGameParameters
    {
        public Game Game { get; set; }
        public Genre Genre { get; set; }
        public GameSavedCallback RefreshGameList { get; set; }
        public GameSavedCallback _MoveListBack { get; set; }
        public GameSavedCallbackButton AddGenre { get; set; }
        public GameSavedCallback DeleteGenre { get; set; }
        public GameSavedCallback EditGenre { get; set; }

    }
}
