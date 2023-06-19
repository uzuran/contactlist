using CommunityToolkit.Mvvm.ComponentModel;
using ContactList.Models;
using MvvmHelpers.Commands;
using System.Windows.Input;


namespace ContactList.ViewModels
{
    public class SignUpViewModel : ObservableObject
    {
        private bool isBusy;

        public bool IsBusy
        {
            get => isBusy;
            set => SetProperty(ref isBusy, value);
        }

        private string username;
        public string Username
        {
            get => username;
            set => SetProperty(ref username, value);
        }

        private string password;
        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }

        public ICommand RegisterCommand { get; }

        public SignUpViewModel()
        {
            RegisterCommand = new AsyncCommand(RegisterAsync);
        }

        private async Task RegisterAsync()
        {
            IsBusy = true; // Start the activity indicator

            try
            {
                // Create model for username, password.
                var user = new UserModel
                {
                    Username = Username,
                    Password = Password
                };
                
                // Simulate a delay using Task.Delay before showing the alert
                await Task.Delay(1500); // Delay of 1,5 seconds
                // Use userDataContext to add username, password to the database.
                using (var db = new UserDataContext())
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                }
                IsBusy = false; // Stop the activity indicator


                // Registration success alert.
                await Application.Current.MainPage.DisplayAlert("Alert", $"Your registration is successful, {username}!", "OK");
            }
            catch (Exception ex)
            {
                // Handle the exception here (e.g., display an error message)
                await Application.Current.MainPage.DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }

        }
    }
}
