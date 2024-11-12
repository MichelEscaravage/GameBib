using GameBib.Data.Classes;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using static GameBib.MainWindow;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace GameBib
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ShowAllGenresPage : Page
    {
        private GameSavedCallbackButton AddGenre;
        private readonly AppDbContext _context = new AppDbContext();
        private GameSavedCallback RefreshGameList;
        private GameSavedCallback _MoveListBack;

        public ShowAllGenresPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            LoadAllGenres();
            var parameters = e.Parameter as EditGameParameters;
            AddGenre = parameters.AddGenre;
            RefreshGameList = parameters.RefreshGameList;
            _MoveListBack = parameters._MoveListBack;
        }

        private void LoadAllGenres()
        {
            using (var db = new AppDbContext())
            {
                var allGenres = db.Genre
                    .OrderBy(genre => genre.Name).ToList();

                GenreList.ItemsSource = allGenres;
            }
        }

        private void AddGenreButton_Click(object sender, RoutedEventArgs e)
        {
            if (AddGenre != null)
            {
                AddGenre.Invoke(sender, e);

            }
        }

        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Genre selectedItem = (sender as Button).CommandParameter as Genre;

            var confirmDialog = new ContentDialog()
            {
                Title = $"Delete {selectedItem.Name}",
                Content = $"Are you sure you want to delete {selectedItem.Name}",
                PrimaryButtonText = "Delete",
                CloseButtonText = "Cancel",
                DefaultButton = ContentDialogButton.Close,
            };

            confirmDialog.XamlRoot = this.XamlRoot;


            var result = await confirmDialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                var GenreToDelete = await _context.Genre.FindAsync(selectedItem.Id);

                _context.Genre.Remove(GenreToDelete);
                await _context.SaveChangesAsync();
                LoadAllGenres();
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Genre selectedItem = (sender as Button).CommandParameter as Genre;
            var parameters = new EditGameParameters
            {
                Genre = selectedItem,
                RefreshGameList = RefreshGameList,
                _MoveListBack = _MoveListBack
            };
            Frame.Navigate(typeof(EditGenrePage), parameters);
        }
    }
}
