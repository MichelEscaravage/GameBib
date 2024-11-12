using GameBib.Data.Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Gaming.XboxLive.Storage;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace GameBib
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public delegate void GameSavedCallback();
        public delegate void GameSavedCallbackButton(object sender, RoutedEventArgs e);

        public GameSavedCallback RefreshGameList;
        public GameSavedCallback _MoveListBack;
        public GameSavedCallbackButton AddGenre;
        public GameSavedCallback DeleteGenre;
        public GameSavedCallback EditGenre;

        private readonly AppDbContext _context = new AppDbContext();


        public MainWindow()
        {
            this.InitializeComponent();
            ShowGames();

            RefreshGameList = ShowGames;
            _MoveListBack = MoveListBack;
            AddGenre = AddGenreButton_Click;
        }

        internal void ShowGames()
        {
            using (var db = new AppDbContext())
            {
                var games = db.Game
                    .Include(game => game.GameGenres)
                    .ThenInclude(gameGenre => gameGenre.Genre)
                    .OrderBy(game => game.Name)
                    .ToList();

                GameList.ItemsSource = games;
            }
        }
        private void GameList_ItemClick(object sender, ItemClickEventArgs e)
        {
            Grid.SetColumn(GameList, 0);
            Game selectedItem = e.ClickedItem as Game;
            SideContentFrame.Navigate(typeof(ShowGameDetailsPage), selectedItem);
            SideContentFrame.Visibility = Visibility.Visible;
            closeGameButton.Visibility = Visibility.Visible;
        }


        private void GenresListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            Grid.SetColumn(GameList, 0);
            GameGenre selectedItem = e.ClickedItem as GameGenre;    
            SideContentFrame.Navigate(typeof(ShowGamesOfGenrePage), selectedItem);
            SideContentFrame.Visibility = Visibility.Visible;
            closeGameButton.Visibility = Visibility.Visible;
        }

        private void ShowGenreList_Click(object sender, RoutedEventArgs e)
        {
            Grid.SetColumn(GameList, 0);
            var parameters = new EditGameParameters()
            {
                RefreshGameList = RefreshGameList,
                _MoveListBack = _MoveListBack,
                AddGenre = AddGenre

            };
            SideContentFrame.Navigate(typeof(ShowAllGenresPage), parameters);
            SideContentFrame.Visibility = Visibility.Visible;
            closeGameButton.Visibility = Visibility.Visible;
        }

        private void NewGameButton_Click(object sender, RoutedEventArgs e)
        {
            Grid.SetColumn(GameList, 0);
            var parameters = new EditGameParameters
            {
                RefreshGameList = RefreshGameList,
                _MoveListBack = _MoveListBack
            };
            SideContentFrame.Navigate(typeof(CreateGame), parameters);
            SideContentFrame.Visibility = Visibility.Visible;
            closeGameButton.Visibility = Visibility.Visible;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Grid.SetColumn(GameList, 0);
            Game selectedItem = (sender as Button).CommandParameter as Game;
            var parameters = new EditGameParameters
            {
                Game = selectedItem,
                RefreshGameList = RefreshGameList,
                _MoveListBack = _MoveListBack
            };
            SideContentFrame.Navigate(typeof(EditGame), parameters);

            SideContentFrame.Visibility = Visibility.Visible;
            closeGameButton.Visibility = Visibility.Visible;
        }

        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            
            Game selectedItem = (sender as Button).CommandParameter as Game;

            var confirmDialog = new ContentDialog()
            {
                Title = $"Delete {selectedItem.Name}",
                Content = $"Are you sure you want to delete {selectedItem.Name}",
                PrimaryButtonText = "Delete",
                CloseButtonText = "Cancel",
                DefaultButton = ContentDialogButton.Close,
                XamlRoot = this.mainGrid.XamlRoot
            };

            var result = await confirmDialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                var gameToDelete = await _context.Game.FindAsync(selectedItem.Id);

                _context.Game.Remove(gameToDelete);
                await _context.SaveChangesAsync();
                ShowGames();
            }
        }

        public void MoveListBack()
        {
            SideContentFrame.Visibility = Visibility.Collapsed;
            Grid.SetColumn(GameList, 1);
            closeGameButton.Visibility = Visibility.Collapsed;
        }

        private void closeGameButton_Click(object sender, RoutedEventArgs e)
        {
            SideContentFrame.Content = null;
            closeGameButton.Visibility = Visibility.Collapsed;
            Grid.SetColumn(GameList, 1);
        }

        private void FilterBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filter = FilterBox.Text;

            FilterGames(filter);
        }

        private void FilterGames(string filter)
        {
            using (var db = new AppDbContext())
            {
                string lowerFilter = filter.ToLower();

                var games = db.Game 
                    .Include(game => game.GameGenres)
                        .ThenInclude(gameGenre => gameGenre.Genre)
                    .ToList();

                var filteredGames = games
                    .Where(game =>
                        game.Name.ToLower().Contains(lowerFilter) ||
                        game.GameGenres.Any(gg => gg.Genre.Name.ToLower().Contains(lowerFilter)) ||
                        game.Rating.ToString().Contains(lowerFilter) ||
                        game.ReleaseDate.ToString("dd/MM/yyyy").Contains(lowerFilter)
                    )
                    .OrderBy(game => game.Name)
                    .ToList();

                GameList.ItemsSource = filteredGames;
            }
        }

        private void AddGenreButton_Click(object sender, RoutedEventArgs e)
        {
            Grid.SetColumn(GameList, 0);
            var parameters = new EditGameParameters
            {
                RefreshGameList = RefreshGameList,
                _MoveListBack = _MoveListBack
            };
            SideContentFrame.Navigate(typeof(CreateGenrePage), parameters);
            SideContentFrame.Visibility = Visibility.Visible;
            closeGameButton.Visibility = Visibility.Visible;
        }
    }
}
