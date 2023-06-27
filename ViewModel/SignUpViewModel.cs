using CommunityToolkit.Mvvm.ComponentModel;
using ContactList.Models;
using ContactList.View;
using MvvmHelpers.Commands;
using System.Windows.Input;


namespace ContactList.ViewModels
{
    public class SignUpViewModel : ObservableObject
    {   // Set bool variable for check if method is in active mode for activity indicator.
        private bool isBusy;

        public bool IsBusy
        {
            get => isBusy;
            set => SetProperty(ref isBusy, value);
        }
        // Set, get user name from input field.
        private string usernameFromInput;
        public string UsernameFromInput
        {
            get => usernameFromInput;
            set
            {
                SetProperty(ref usernameFromInput, value);
                CheckUsername();
            }

        }
        // Color for correct format 
        private Color checkIfUsernameIsValidColor;
        public Color CheckIfUsernameIsValidColor
        {
            get { return checkIfUsernameIsValidColor; }
            set { SetProperty(ref checkIfUsernameIsValidColor, value); }
        }

        // Set variable for check if user name is valid.
        private string checkIfUsernameIsValid;

        public string CheckIfUsernameIsValid
        {
            get { return checkIfUsernameIsValid; }
            set { SetProperty(ref checkIfUsernameIsValid, value); }
        }

        //Check validation of username.
        private void CheckUsername()
        {
            bool containsSpace = UsernameFromInput?.Contains(' ') ?? false;

            if (containsSpace)
            {
                CheckIfUsernameIsValid = "Username is in incorrect format.";
                CheckIfUsernameIsValidColor = Color.FromRgb(255, 0, 0);
            }
            else
            {
                CheckIfUsernameIsValid = "Username is in correct format.";
                CheckIfUsernameIsValidColor = Color.FromRgb(34, 139, 34);
            }
        }
        // Set, get for password from input field.
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

        // Module for registration users to database.
        private async Task RegisterAsync()
        {
            IsBusy = true; // Start the activity indicator

            bool usernameExists = CheckIfUsernameExists(UsernameFromInput);
            bool containsSpace = UsernameFromInput?.Contains(' ') ?? false;

            if (usernameExists)
            {
                await Task.Delay(1500); // Delay of 1,5 seconds
                // Aler page for existing user.
                await Application.Current.MainPage.Navigation.PushModalAsync(new UserExistAlertPage());
                IsBusy = false; // Stop the activity indicator
            }

            else if (containsSpace)
            {
                await Task.Delay(1500); // Delay of 1,5 seconds
                //Contain spaces warning.
                await Application.Current.MainPage.DisplayAlert("Alert", $"Your name {usernameFromInput} contain spaces.", "Ok");
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
