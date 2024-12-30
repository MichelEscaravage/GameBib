using GameBib.Data.Classes;
using GameBib.Utility;
using Microsoft.EntityFrameworkCore;
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
using static GameBib.MainWindow;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace GameBib
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EditGenrePage : Page
    {
        private Genre _currentGenre;
        private readonly AppDbContext _context = new AppDbContext();
        private GameSavedCallback RefreshGameList;
        private GameSavedCallback _MoveListBack;

        public EditGenrePage()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var parameters = e.Parameter as EditGameParameters;
            RefreshGameList = parameters.RefreshGameList;
            _MoveListBack = parameters._MoveListBack;

            if (parameters?.Genre != null)
            {
                _currentGenre = await _context.Genre
                    .FirstOrDefaultAsync(genre => genre.Id == parameters.Genre.Id);

                GenreNameTextBox.Text = parameters.Genre.Name;
            }
        }

        private bool IsGenreNameValid(string genreName)
        {
            var regex = new System.Text.RegularExpressions.Regex("^[a-zA-Z0-9 ]+$");

            return regex.IsMatch(genreName);
        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {

            if (!IsGenreNameValid(GenreNameTextBox.Text))
            {
                var invalidNameDialog = new ContentDialog
                {
                    Title = "Invalid Genre Name",
                    Content = "The genre name can only contain letters and numbers",
                    CloseButtonText = "OK",
                    XamlRoot = this.XamlRoot
                };

                await invalidNameDialog.ShowAsync();
                return;
            }

            bool hasEmptyFields = false;

            if (GenreNameTextBox.Text == null || GenreNameTextBox.Text.Length == 0)
            {
                GenreNameTextBox.PlaceholderText = "Required!";
                GenreNameTextBox.PlaceholderForeground = new SolidColorBrush(Colors.Red);

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

            // Assume _currentGenre is the genre you want to edit, retrieved when you navigated to this page
            if (_currentGenre != null)
            {
                // Update the genre's properties with the new values from the UI
                _currentGenre.Name = GenreNameTextBox.Text;

                // Save the changes to the database
                _context.Genre.Update(_currentGenre);
                await _context.SaveChangesAsync();

                // Notify user of success
                var contentDialog = new ContentDialog
                {
                    Title = "Genre Updated",
                    Content = "The genre has been successfully updated.",
                    CloseButtonText = "OK",
                    XamlRoot = this.XamlRoot // Use the appropriate element for XamlRoot
                };

                await contentDialog.ShowAsync();

                RefreshGameList.Invoke();
                _MoveListBack.Invoke();
            }
        }

    }
}
