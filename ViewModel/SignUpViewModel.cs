using CommunityToolkit.Mvvm.ComponentModel;
using ContactList.Models;
using ContactList.View;
using MvvmHelpers.Commands;
using System.Windows.Input;
using System.Text.RegularExpressions;
using System.Drawing.Text;

namespace ContactList.ViewModels
{
    public class SignUpViewModel : ObservableObject
    {
        public SignUpViewModel()
        {
            // Initialize properties and perform any necessary setup
        }


        // Set bool variable for check if method is in active mode for activity indicator.
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
        // Color for correct format.
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
        {   // If UsernameFromInput contain whitespace true else false.
            bool containsSpace = UsernameFromInput?.Contains(' ') ?? false;

            // If  UsernameFromInput contain only one char false. 
            bool containsOnlyOneChar = UsernameFromInput?.Length == 1;

            // Check if username contain special char.
            string pattern = @"[^a-zA-Z0-9]";
            bool regexCeck = Regex.IsMatch(UsernameFromInput, pattern);

            if (containsSpace || regexCeck)
            {
                CheckIfUsernameIsValid = "Username is not in incorrect format.";
                CheckIfUsernameIsValidColor = Color.FromRgb(255, 0, 0);
            }

            else if (containsOnlyOneChar)
            {
                CheckIfUsernameIsValid = "Username is not in incorrect format.";
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
            set
            {

                SetProperty(ref passwordFromInput, value);
                CheckPasswordValidation();
            }

        }

        private Color checkIfPasswordIsValidColor;
        public Color CheckIfPasswordIsValidColor
        {
            get { return checkIfPasswordIsValidColor; }
            set { SetProperty(ref checkIfPasswordIsValidColor, value); }
        }

        // Set variable for check if user name is valid.
        private string checkIfPasswordIsValid;

        public string CheckIfPasswordIsValid
        {
            get { return checkIfPasswordIsValid; }
            set { SetProperty(ref checkIfPasswordIsValid, value); }
        }

        private void CheckPasswordValidation()
        {
            // If  UsernameFromInput contain only one char false. 
            bool checkLengthOfPassword = !string.IsNullOrEmpty(PasswordFromInput) && PasswordFromInput.Length <= 5;

            bool passContainsSpace = PasswordFromInput?.Contains(' ') ?? false;

            if (checkLengthOfPassword)
            {
                CheckIfPasswordIsValid = "Password must be 6 characters or longer.";
                CheckIfPasswordIsValidColor = Color.FromRgb(255, 0, 0);
            }

            else if (passContainsSpace)
            {
                CheckIfPasswordIsValid = "Password can not contain spaces.";
                CheckIfPasswordIsValidColor = Color.FromRgb(255, 0, 0);
            }

            else
            {
                CheckIfPasswordIsValid = "Password is in correct format.";
                CheckIfPasswordIsValidColor = Color.FromRgb(34, 139, 34);
            }
        }


        public ICommand RegisterCommand { get; }
        private readonly UserDataContext _userDataContext;
        public SignUpViewModel(UserDataContext userDataContext)
        {
            RegisterCommand = new AsyncCommand(RegisterAsync);
            _userDataContext = userDataContext;
        }

        // Module for registration users to database.
        private async Task RegisterAsync()
        {
            IsBusy = true; // Start the activity indicator


            // Check if user name exist in database.
            bool usernameExists = CheckIfUsernameExists(UsernameFromInput);
            // Check if user name input contain spaces.
            bool containsSpace = UsernameFromInput?.Contains(' ') ?? false;

            // Check password if pass contain spaces.
            bool passContainsSpace = PasswordFromInput?.Contains(' ') ?? false;

            // If  UsernameFromInput contain only one char false. 
            bool containsOnlyOneChar = UsernameFromInput?.Length == 1;

            // Check if user name contain special char.
            string pattern = @"[^a-zA-Z0-9]";
            bool regexCeck = Regex.IsMatch(UsernameFromInput, pattern);

            //Check for length of password. 
            bool checkLengthOfPassword = !string.IsNullOrEmpty(PasswordFromInput) && PasswordFromInput.Length <= 5;



            //Random numbers for generate random name if name exist.
            var random = new Random();
            int randomNumber = random.Next(100);
            int randomNumber2 = random.Next(100);

            if (usernameExists)
            {
                await Task.Delay(1500); // Delay of 1,5 seconds
                //Contain spaces warning.
                await Application.Current.MainPage.DisplayAlert("Alert", $"The user name {usernameFromInput} is exist. Please choose a different user name {usernameFromInput + randomNumber}, {usernameFromInput + randomNumber2}.", "Ok");
                IsBusy = false; // Stop the activity indicator
            }

            else if (containsSpace)
            {
                await Task.Delay(1500); // Delay of 1,5 seconds
                //Contain spaces warning.
                await Application.Current.MainPage.DisplayAlert("Alert", $"Your name {usernameFromInput} contain spaces.", "Ok");
                IsBusy = false; // Stop the activity indicator
            }

            else if (regexCeck)
            {
                await Task.Delay(1500); // Delay of 1,5 seconds
                //Contain spaces warning.
                await Application.Current.MainPage.DisplayAlert("Alert", $"Your name {usernameFromInput} contain special char.", "Ok");
                IsBusy = false; // Stop the activity indicator
            }


            else if (containsOnlyOneChar)
            {
                await Task.Delay(1500); // Delay of 1,5 seconds
                //Contain spaces warning.
                await Application.Current.MainPage.DisplayAlert("Alert", $"Your name {usernameFromInput} contain only one char min count of char name is 2.", "Ok");
                IsBusy = false; // Stop the activity indicator
            }


            else if (checkLengthOfPassword)
            {
                await Task.Delay(1500); // Delay of 1,5 seconds
                //Contain spaces warning.
                await Application.Current.MainPage.DisplayAlert("Alert", $"Password must be 6 characters or longer!", "Ok");
                IsBusy = false; // Stop the activity indicator
            }

            else if (passContainsSpace)
            {
                await Task.Delay(1500); // Delay of 1,5 seconds
                //Contain spaces warning.
                await Application.Current.MainPage.DisplayAlert("Alert", $"Password can not contain spaces!", "Ok");
                IsBusy = false; // Stop the activity indicator
            }

            else
            {
                // Create model for user name, password.
                var user = new UserModel
                {
                    Username = UsernameFromInput.ToLower(),
                    Password = PasswordFromInput
                };

                // Simulate a delay using Task.Delay before showing the alert
                await Task.Delay(1500); // Delay of 1,5 seconds

                // Use userDataContext to add user name, password to the database.
                _userDataContext.Users.Add(user);
                _userDataContext.SaveChanges();

                IsBusy = false; // Stop the activity indicator


                // Registration success alert.
                await Application.Current.MainPage.Navigation.PushModalAsync(new RegistrationSuccessAlertPage());
            }

        }

        // Method for check if username exists in database.
        private bool CheckIfUsernameExists(string username)
        {


            // Check if a user with the given username exists in the database
            return _userDataContext.Users.Any(user => user.Username == username);
        }



    }
}
