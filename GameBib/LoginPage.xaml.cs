using GameBib.Data.Classes;
using GameBib.Utility;
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
using Windows.Storage;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace GameBib
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {

        Window loginWindow;

        public LoginPage()
        {
            this.InitializeComponent();
            TryLoaduser();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter is Window window)
            {
                if (window != null)
                {
                    loginWindow = window;
                }
            }
            

        }

        async void TryLoaduser()
        {
            using (var db = new AppDbContext())
            {
                StorageFolder storageFolder = ApplicationData.Current.LocalFolder;

                try
                {
                    var cookieFile = await storageFolder.GetFileAsync("remember_token.txt");
                    string rememberToken = await FileIO.ReadTextAsync(cookieFile);

                    User selectedUser = db.User
                        .FirstOrDefault(u => u.RememberToken == rememberToken);

                    if (selectedUser != null)
                    {
                        User.LoggedInUser = selectedUser;

                        selectedUser.FailedLoginAttempts = 0;
                        selectedUser.LastFailedLogin = DateTime.Now;

                        MainWindow mainWindow = new MainWindow();


                        mainWindow.Activate();
                        loginWindow.Close();

        
                    }
                }
                catch (FileNotFoundException)
                {

                }
            }
        }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var inputControls = new List<Control>()
            {
                UsernameTextBox,
                PasswordTextBox
            };

            bool hasEmptyFields = FormChecker.ValidateControls(inputControls);

            if (hasEmptyFields)
            {
                // Exit if any field is empty
                if (hasEmptyFields)
                {
                    var contentDialog = new ContentDialog
                    {
                        Title = "Incomplete Form",
                        Content = "Please fill in all fields before logging in.",
                        CloseButtonText = "OK",
                        XamlRoot = this.XamlRoot
                    };

                    await contentDialog.ShowAsync();
                    return;
                }
            }          

            using (var db = new AppDbContext())
            {
                var selectedUser = db.User.
                    FirstOrDefault(u => u.UserName == UsernameTextBox.Text);

                if (selectedUser == null)
                {
                    return;
                }

                TimeSpan timeDifference = DateTime.Now - selectedUser.LastFailedLogin;

                if (selectedUser.FailedLoginAttempts >= 3 && timeDifference.TotalSeconds < 10)
                {
                    var lockoutDialog = new ContentDialog()
                    {
                        Title = "Account Locked",
                        Content = "Too many failed attempts please try again later.",
                        CloseButtonText = "OK", 
                        XamlRoot= this.XamlRoot
                    };

                    PasswordTextBox.Password = "";
                    await lockoutDialog.ShowAsync();
                    return;
                }

                if (!SecureHasher.Verify(PasswordTextBox.Password, selectedUser.HashedPassword) || selectedUser == null)
                {
                    selectedUser.FailedLoginAttempts++;
                    selectedUser.LastFailedLogin = DateTime.Now;

                    db.SaveChanges();

                    var loginDialog = new ContentDialog()
                    {
                        Title = "Credentials dont match",
                        Content = "Wrong password or username, please try again",
                        CloseButtonText = "OK",
                        XamlRoot = this.XamlRoot    
                    };

                    PasswordTextBox.Password = "";
                    await loginDialog.ShowAsync();
                    return;
                }

                selectedUser.RememberToken = User.GenerateRandomToken();
                StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
                StorageFile cookiefile = await storageFolder.CreateFileAsync(
                    "remember_token.txt",
                    CreationCollisionOption.ReplaceExisting);
                await FileIO.WriteTextAsync(cookiefile, selectedUser.RememberToken);

                Debug.WriteLine(cookiefile.Path);

                selectedUser.FailedLoginAttempts = 0;
                selectedUser.LastFailedLogin = DateTime.Now;

                db.SaveChanges();
                User.LoggedInUser = selectedUser;

                MainWindow mainWindow = new MainWindow();

                mainWindow.Activate();
                loginWindow.Close();
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(RegisterPage), loginWindow);
        }
    }
}
