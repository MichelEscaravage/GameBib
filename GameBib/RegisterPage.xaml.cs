using GameBib.Data.Classes;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI;
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
using GameBib.Utility;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace GameBib
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RegisterPage : Page
    {
        private readonly AppDbContext _context = new AppDbContext();
        private string _password;
        private string _confirmPassword;
        Window loginWindow;
        private List<string> _usernames;

        public RegisterPage()
        {
            this.InitializeComponent();
            _usernames = _context.User.Select(u => u.UserName).ToList();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter is LoginWindow window)
            {
                loginWindow = window;
            }

        }

        private void PasswordTextBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            _password = PasswordTextBox.Password;
        }

        private void confirmPasswordTextBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            _confirmPassword = confirmPasswordTextBox.Password;

            PasswordValidator.ValidatePasswords(_password, _confirmPassword, PasswordTextBox, confirmPasswordTextBox, confirmPasswordLabel);
        }

        private bool IsPasswordSafe(string Password)
        {
            return Password.Count() > 8;
        }

        private async void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            if (!IsPasswordSafe(PasswordTextBox.Password))
            {
                var invalidNameDialog = new ContentDialog
                {
                    Title = "Unsafe password!",
                    Content = "Password must contain atleast 9 characters",
                    CloseButtonText = "OK",
                    XamlRoot = this.XamlRoot
                };

                await invalidNameDialog.ShowAsync();
                return;
            }

            string name = NameTextBox.Text;
            string userName = UsernameTextBox.Text;

            _password = PasswordTextBox.Password;
            _confirmPassword = confirmPasswordTextBox.Password;

            string hashedPassword = SecureHasher.Hash(_password);

            var inputControls = new List<Control>()
            {
                NameTextBox,
                UsernameTextBox,
                PasswordTextBox,
                confirmPasswordTextBox,
            };

            bool hasEmptyFields = FormChecker.ValidateControls(inputControls);

            if (hasEmptyFields)
            {
                ContentDialog errorDialog = new ContentDialog()
                {
                    Title = "Incomplete Form",
                    Content = "Please fill in all fields",
                    CloseButtonText = "OK",
                    XamlRoot = this.XamlRoot,
                };

                await errorDialog.ShowAsync();
                return;
            }

            if (!PasswordValidator.ValidatePasswords(_password, _confirmPassword, PasswordTextBox, confirmPasswordTextBox, confirmPasswordLabel))
            {
                PasswordTextBox.Password = string.Empty;
                confirmPasswordTextBox.Password = string.Empty;

                ContentDialog MissmatchDialog = new ContentDialog()
                {
                    Title = "Passwords dont match!",
                    Content = "Password and confirmation password must match",
                    CloseButtonText = "OK",
                    XamlRoot = this.XamlRoot,
                };

                await MissmatchDialog.ShowAsync();
                return;
            }

           bool usernameAlreadyExist = _context.User.Any(u => u.UserName == UsernameTextBox.Text);

            if (usernameAlreadyExist)
            {
                ContentDialog usernameExists = new ContentDialog()
                {
                    Title = "Username in use",
                    Content = "Username is already in use!",
                    CloseButtonText = "OK",
                    XamlRoot = this.XamlRoot,
                };

                await usernameExists.ShowAsync();
                return;
            }

            User user = new User()
            {
                Name = name,
                UserName = userName,
                HashedPassword = hashedPassword,
                UserGames = new List<UserGames>(),
            };

            _context.User.Add(user);
            await _context.SaveChangesAsync();

            this.Frame.Navigate(typeof(LoginPage), loginWindow);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(LoginPage), loginWindow);
        }

        private void UsernameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {

            if (_usernames.Contains(UsernameTextBox.Text))
            {
                usernameLabel.Text = "Username already in use";
                usernameLabel.Foreground = new SolidColorBrush(Colors.Red);
            }
            else
            {
                usernameLabel.Text = "Username";
                usernameLabel.Foreground = new SolidColorBrush(ColorHelper.FromArgb(0xFF, 0x39, 0xFF, 0x14));
            }
        }
    }
}
