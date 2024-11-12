using GameBib.Data.Classes;
using GameBib.Data.Lists;
using Microsoft.EntityFrameworkCore;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using static GameBib.MainWindow;


// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace GameBib
{
    public sealed partial class EditGame : Page
    {
        private Game _currentGame;
        private readonly AppDbContext _context = new AppDbContext();
        private GameSavedCallback RefreshGameList;
        private GameSavedCallback _MoveListBack;
        public EditGame()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
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

            if (parameters?.Game != null)
            {
                _currentGame = await _context.Game
               .Include(g => g.GameGenres)
               .ThenInclude(gg => gg.Genre)
               .FirstOrDefaultAsync(g => g.Id == parameters.Game.Id);

                GameNameTextBox.Text = parameters.Game.Name;
                GameDescriptionTextBox.Text = parameters.Game.Description;
                RatingSlider.Value = parameters.Game.Rating;    
                GameReleaseDateTextBox.SelectedDate = parameters.Game.ReleaseDate;

                // Set the selected genres for the game
                foreach (var gameGenre in _currentGame.GameGenres)
                {
                    var matchingGenre = GameGenresBox.Items
                        .OfType<Genre>()
                        .FirstOrDefault(genre => genre.Id == gameGenre.GenreId);

                    if (matchingGenre != null)
                    {
                        GameGenresBox.SelectedItems.Add(matchingGenre);
                    }
                }

                RefreshGameList = parameters.RefreshGameList;
                _MoveListBack = parameters._MoveListBack;
            }
        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // List of controls to validate
            var inputControls = new List<Control>
            {
                GameNameTextBox,
                GameDescriptionTextBox,
                GameReleaseDateTextBox,
                RatingSlider
            };

            // Track if any field is empty
            bool hasEmptyFields = false;

            // Reset any previous styling
            foreach (var control in inputControls)
            {
                control.BorderBrush = new SolidColorBrush(Colors.Transparent);
            }
            GameGenresBox.BorderBrush = new SolidColorBrush(Colors.Transparent);

            // Check each control for input
            foreach (var control in inputControls)
            {
                if (control is TextBox textBox && string.IsNullOrWhiteSpace(textBox.Text))
                {
                    // Add red placeholder text for empty TextBox
                    textBox.PlaceholderText = "Required";
                    textBox.PlaceholderForeground = new SolidColorBrush(Colors.Red);
                    hasEmptyFields = true;
                }
                else if (control is DatePicker datePicker && datePicker.SelectedDate == null)
                {
                    // Add red outline to empty DatePicker
                    datePicker.BorderBrush = new SolidColorBrush(Colors.Red);
                    datePicker.BorderThickness = new Thickness(2);
                    hasEmptyFields = true;
                }
                else if (control is Slider slider && slider.Value == 0) // or some invalid default
                {
                    // Add red outline to the Slider if not set
                    slider.BorderBrush = new SolidColorBrush(Colors.Red);
                    slider.BorderThickness = new Thickness(2);
                    hasEmptyFields = true;
                }
            }

            // Check if at least one genre is selected
            if (GameGenresBox.SelectedItems.Count == 0)
            {
                GameGenresBox.BorderBrush = new SolidColorBrush(Colors.Red);
                GameGenresBox.BorderThickness = new Thickness(2);
                hasEmptyFields = true;
            }

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


            _currentGame.Name = GameNameTextBox.Text;
            _currentGame.Description = GameDescriptionTextBox.Text;
            _currentGame.Rating = (float)RatingSlider.Value;
            _currentGame.ReleaseDate = DateTime.Parse(GameReleaseDateTextBox.SelectedDate.ToString());

            _currentGame.GameGenres.Clear();
            foreach (var selectedGenre in GameGenresBox.SelectedItems.OfType<Genre>())
            {
                _currentGame.GameGenres.Add(new GameGenre(_currentGame.Id, selectedGenre.Id));
            }
                
            await _context.SaveChangesAsync();

            if (RefreshGameList != null)
            {
                RefreshGameList.Invoke();
                _MoveListBack.Invoke();

                var contentDialog = new ContentDialog
                {
                    Title = $"{_currentGame.Name} has been edited!",
                    Content = "Changes have been saved!",
                    CloseButtonText = "OK"
                };

                contentDialog.XamlRoot = this.XamlRoot;

                await contentDialog.ShowAsync();
            }
        }
    }
}
