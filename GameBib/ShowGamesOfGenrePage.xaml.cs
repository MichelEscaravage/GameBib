using GameBib.Data.Classes;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using System.Collections.Generic;
using System.Linq;

namespace GameBib
{
    public sealed partial class ShowGamesOfGenrePage : Page
    {
        private int filteredGenreId;

        public ShowGamesOfGenrePage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            // Check if parameter is a GameGenre
            if (e.Parameter is GameGenre selectedGenre)
            {
                filteredGenreId = selectedGenre.GenreId;
                LoadGamesByGenre(filteredGenreId);
            }
        }

        private void LoadGamesByGenre(int genreId)
        {
            using (var db = new AppDbContext())
            {
                var gamesOfSelectedGenre = db.Game
                    .Where(game => game.GameGenres.Any(gg => gg.GenreId == genreId))
                    .ToList();

                GamesOfGenreList.ItemsSource = gamesOfSelectedGenre;
            }
        }
    }
}
