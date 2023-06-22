using CommunityToolkit.Mvvm.ComponentModel;
using ContactList.Models;
using ContactList.View;
using MvvmHelpers.Commands;
using System.Windows.Input;


namespace ContactList.ViewModels
{
    public class SignUpViewModel : ObservableObject
    {   // Set bool variable for check if method is in active mode for activity idicator.
        private bool isBusy;

        public bool IsBusy
        {
            get => isBusy;
            set => SetProperty(ref isBusy, value);
        }

        private string usernameFromInput;
        public string UsernameFromInput
        {
            get => usernameFromInput;
            set => SetProperty(ref usernameFromInput, value);
        }

        private string passwordFromInput;
        public string PasswordFromInput
        {
            get => passwordFromInput;
            set => SetProperty(ref passwordFromInput, value);
        }

        public ICommand RegisterCommand { get; }

        public SignUpViewModel()
        {
            RegisterCommand = new AsyncCommand(RegisterAsync);
        }

        private async Task RegisterAsync()
        {
            IsBusy = true; // Start the activity indicator

            bool usernameExists = CheckIfUsernameExists(UsernameFromInput);

            if (usernameExists)
            {   
                await Task.Delay(1500); // Delay of 1,5 seconds
                // Aler page for existing user.
                await Application.Current.MainPage.Navigation.PushModalAsync(new UserExistAlertPage());
                IsBusy = false; // Stop the activity indicator
            }


            else
            {
                // Create model for username, password.
                var user = new UserModel
                {
                    Username = UsernameFromInput,
                    Password = PasswordFromInput
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
                await Application.Current.MainPage.Navigation.PushModalAsync(new RegistrationSuccessAlertPage());
            }

        }

        // Method for check if username exists in database.
        private static bool CheckIfUsernameExists(string username)
        {
            var db = new UserDataContext();

            // Check if a user with the given username exists in the database
            return db.Users.Any(user => user.Username == username);
        }

    }
}
