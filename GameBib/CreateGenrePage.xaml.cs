using GameBib.Data.Classes;
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
    public sealed partial class CreateGenrePage : Page
    {
        private Game _currentGame;
        private readonly AppDbContext _context = new AppDbContext();
        private GameSavedCallback RefreshGameList;
        private GameSavedCallback _MoveListBack;
        public CreateGenrePage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var parameters = e.Parameter as EditGameParameters;

            RefreshGameList = parameters.RefreshGameList;
            _MoveListBack = parameters._MoveListBack;
        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
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

            Genre newGenre = new Genre()
            {
                Name = GenreNameTextBox.Text,
            };

            _context.Genre.Add(newGenre);
            await _context.SaveChangesAsync();


            if (RefreshGameList != null)
            {

                RefreshGameList.Invoke();
                _MoveListBack.Invoke();

                var contentDialog = new ContentDialog
                {
                    Title = "Genre Saved!",
                    Content = "Your game has been saved successfully.",
                    CloseButtonText = "OK"
                };

                contentDialog.XamlRoot = this.XamlRoot;

                await contentDialog.ShowAsync();
            }
        }
    }
}
