using GameBib.Data.Classes;
using GameBib.Data.Lists;
using GameBib.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
using Windows.Services.Maps;
using Windows.Storage;

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
        private bool IsGameChecked;

        private readonly AppDbContext _context = new AppDbContext();


        public MainWindow()
        {
            this.InitializeComponent();
            ShowGames();

            RefreshGameList = ShowGames;
            _MoveListBack = MoveListBack;
            AddGenre = AddGenreButton_Click;
            AppWindow.SetPresenter(Microsoft.UI.Windowing.AppWindowPresenterKind.FullScreen);
        }

        private string _selectedFilter = "All Games";

        internal void ShowGames()
        {
            if (User.LoggedInUser.RoleId != Role.Admin)
            {
                AdminButton.Visibility = Visibility.Collapsed;
            }

            using (var db = new AppDbContext())
            {
                var games = db.Game
                    .Include(game => game.GameGenres)
                    .ThenInclude(gameGenre => gameGenre.Genre)
                    .OrderBy(game => game.Name);

                if (_selectedFilter == "My Games")
                {
                    var myGames = games
                        .Where(g => g.UserGames.Any(ug => ug.UserId == User.LoggedInUser.Id))
                        .ToList();
                    Debug.WriteLine(User.LoggedInUser.Name);

                    GameList.ItemsSource = myGames;
                    return;
                }

                GameList.ItemsSource = games.ToList();
            }
        }

        private void MenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {
            if (sender is MenuFlyoutItem selectedItem)
            {
                // Update the filter text in the TextBlock
                if (FilterGamesButton.ContentTemplateRoot is StackPanel stackPanel)
                {
                    var textBlock = stackPanel.Children.OfType<TextBlock>().FirstOrDefault();
                    if (textBlock != null)
                    {
                        textBlock.Text = selectedItem.Text;
                    }
                }
                _selectedFilter = selectedItem.Text;

                ShowGames();
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
            FilterBox.Text = "";
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
            FilterBox.Text = "";
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
            FilterBox.Text = "";
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
            FilterBox.Text = "";
        }

        private async void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            var confirmDialog = new ContentDialog()
            {
                Title = $"Logging out",
                Content = $"Are you sure you want to log out?",
                PrimaryButtonText = "Logout",
                CloseButtonText = "Cancel",
                DefaultButton = ContentDialogButton.Close,
                XamlRoot = this.mainGrid.XamlRoot
            };

            var result = await confirmDialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                StorageFolder storageFolder = ApplicationData.Current.LocalFolder;

                var cookieFile = await storageFolder.GetFileAsync("remember_token.txt");
                await cookieFile.DeleteAsync();

                User.LoggedInUser.RememberToken = null;

                LoginWindow loginWindow = new LoginWindow();

                loginWindow.Activate();
                this.Close();
            }
            return;
        }
        private async void FavButton_Click(object sender, RoutedEventArgs e)
        {
            FilterBox.Text = "";
            Button button = sender as Button;
            Game selectedItem = button?.CommandParameter as Game;
            User selectedUser = User.LoggedInUser;
            string selectedList = FilterGamesButton.Content?.ToString();
            {
                if (selectedItem != null)
                {
                    using (var db = new AppDbContext())
                    {
                        // Check if the game is already in the favorites list
                        var userGame = db.UserGames
                            .FirstOrDefault(ug => ug.UserId == selectedUser.Id && ug.GameId == selectedItem.Id);

                        if (userGame == null)
                        {
                            // If not, add it to the favorites
                            db.UserGames.Add(new UserGames(selectedUser.Id, selectedItem.Id));
                            await db.SaveChangesAsync();

                            FilterGamesButton.Content = "My Games";
                            ShowGames();
                        }
                        if (selectedList == "My Games")
                        {
                            var userGameToRemove = db.UserGames
                                .FirstOrDefault(ug => ug.UserId == selectedUser.Id && ug.GameId == selectedItem.Id);

                            if (userGameToRemove != null)
                            {
                                db.UserGames.Remove(userGameToRemove);
                                IsGameChecked = false;
                                await db.SaveChangesAsync();
                                ShowGames();
                            }
                        }


                    }
                }
            }
        }

        private void FavButton_Loaded(object sender, RoutedEventArgs e)
        {
            Button favButton = sender as Button;
            if (favButton != null)
            {
                string selectedList = FilterGamesButton.Content?.ToString();
                {
                    if (selectedList == "My Games")
                    {
                        favButton.Content = "Un-Favourite";
                    }
                }
            }
        }

        private void AdminFlyoutItem_Click(object sender, RoutedEventArgs e)
        {
            if (sender is MenuFlyoutItem selectedItem)
            {
                AdminButton.Content = selectedItem.Text;

                if (selectedItem.Text == "Users")
                {
                    using (var db = new AppDbContext())
                    {
                        var users = db.User
                               .Include(user => user.UserGames)
                               .ThenInclude(UserGames => UserGames.Game)
                               .OrderBy(User => User.Name);

                        UsersListView.ItemsSource = users;

                        GameList.Visibility = Visibility.Collapsed;
                        UsersListView.Visibility = Visibility.Visible;
                    }
                }
                else if (selectedItem.Text == "Games")
                {
                    GameList.Visibility = Visibility.Visible;
                    UsersListView.Visibility = Visibility.Collapsed;
                }
            };


        }

        private async void closeWindowButton_Click(object sender, RoutedEventArgs e)
        {
            var confirmDialog = new ContentDialog()
            {
                Title = $"Closing down the application",
                Content = $"Are you sure you want to close the application?",
                PrimaryButtonText = "Close",
                CloseButtonText = "Cancel",
                DefaultButton = ContentDialogButton.Close,
                XamlRoot = this.mainGrid.XamlRoot
            };

            var result = await confirmDialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                this.Close();
            }
            return;

        }
    }
}

