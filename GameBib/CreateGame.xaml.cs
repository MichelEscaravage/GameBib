using GameBib.Data.Classes;
using GameBib.Utility;
using Microsoft.UI;
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
using Windows.Security.Cryptography.Core;
using static GameBib.MainWindow;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace GameBib
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CreateGame : Page
    {
        private Game _currentGame;
        private readonly AppDbContext _context = new AppDbContext();
        private GameSavedCallback RefreshGameList;
        private GameSavedCallback _MoveListBack;

        public CreateGame()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            using (var db = new AppDbContext())
            {
                var genres = db.Genre.ToList();

                GameGenresBox.ItemsSource = genres;
                GameGenresBox.DisplayMemberPath = "Name";
                GameGenresBox.SelectedValuePath = "Id";
            }
            var parameters = e.Parameter as EditGameParameters;

            RefreshGameList = parameters.RefreshGameList;
            _MoveListBack = parameters._MoveListBack;
        }

        private bool IsGameNameValid(string gameName, string gameDescription)
        {
            var regex = new System.Text.RegularExpressions.Regex("^[a-zA-Z0-9]+$");

            if (regex.IsMatch(gameName) && regex.IsMatch(gameDescription))
            {
                return true;
            }
            return false;

        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {

            if (!IsGameNameValid(GameNameTextBox.Text, GameDescriptionTextBox.Text))
            {
                var invalidNameDialog = new ContentDialog
                {
                    Title = "Invalid Game Name or Game Description",
                    Content = "The game name and description can only contain letters and numbers.",
                    CloseButtonText = "OK",
                    XamlRoot = this.XamlRoot
                };

                await invalidNameDialog.ShowAsync();
                return;
            }

            // List of controls to validate
            var inputControls = new List<Control>
            {
                GameNameTextBox,
                GameDescriptionTextBox,
                GameReleaseDateTextBox,
                GameGenresBox,
                RatingSlider
            };

            // Reset any previous styling
            foreach (var control in inputControls)
            {
                control.BorderBrush = new SolidColorBrush(Colors.Transparent);
            }
            GameGenresBox.BorderBrush = new SolidColorBrush(Colors.Transparent);

            bool hasEmptyFields = FormChecker.ValidateControls(inputControls); 

            // Exit if any field is empty
            if (hasEmptyFields)
            {
                var contentDialog = new ContentDialog
                {
                    Title = "Incomplete Form",
                    Content = "Please fill in all fields before saving.",
                    CloseButtonText = "OK",
                    XamlRoot = this.XamlRoot
                };

                await contentDialog.ShowAsync();
                return;
            }

            // Proceed with saving if all fields are valid
            Game Newgame = new Game
            {
                Name = GameNameTextBox.Text,
                Description = GameDescriptionTextBox.Text,
                Rating = (float)RatingSlider.Value,
                ReleaseDate = GameReleaseDateTextBox.SelectedDate?.Date ?? DateTime.MinValue,
                GameGenres = new List<GameGenre>(),
            };

            _context.Game.Add(Newgame);
            await _context.SaveChangesAsync();

            foreach (var selectedGenre in GameGenresBox.SelectedItems.OfType<Genre>())
            {
                Newgame.GameGenres.Add(new GameGenre(Newgame.Id, selectedGenre.Id));    
            }

            await _context.SaveChangesAsync();

            RefreshGameList?.Invoke();
            _MoveListBack?.Invoke();

            var successDialog = new ContentDialog
            {
                Title = $"{Newgame.Name} Saved!",
                Content = "Your game has been saved successfully.",
                CloseButtonText = "OK",
                XamlRoot = this.XamlRoot
            };

            await successDialog.ShowAsync();
        }
    }
}
