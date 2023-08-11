using CommunityToolkit.Mvvm.ComponentModel;
using ContactList.Models;
using ContactList.View;
using MvvmHelpers.Commands;
using System.Windows.Input;

namespace ContactList.ViewModel
{
    public class MainPageViewModel : ObservableObject
    {
        private bool isBusy;

        public bool IsBusy
        {
            get => isBusy;
            set => SetProperty(ref isBusy, value);
        }

        // Set, get user name from input field.
        private string usernameFromLogInInput;
        public string UserNameFromLogInInput
        {
            get => usernameFromLogInInput;
            set
            {
                SetProperty(ref usernameFromLogInInput, value);
            }

        }

        // Set, get for password from input field.
        private string passwordFromLogInInput;
        public string PasswordFromLogInInput
        {
            get => passwordFromLogInInput;
            set
            {
                SetProperty(ref passwordFromLogInInput, value);
            }

        }

        private readonly UserDataContext userDataContext;

        public MainPageViewModel(UserDataContext userDataContext)
        {
            this.userDataContext = userDataContext;
        }

        bool IsPasswordValid(string username, string password)
        {
            

            var user = userDataContext.Users.FirstOrDefault(u => u.Username == username);

            if (user != null)
            {
                return user.Password == password;
            }

            return false;
        }

        public ICommand LogInCommand { get; }

        public MainPageViewModel()
        {
            LogInCommand = new AsyncCommand(LogInAsync);
        }


        private async Task LogInAsync()
        {

            IsBusy = true; // Start the activity indicator

            bool checkPasswordValidation = IsPasswordValid(UserNameFromLogInInput.ToLower(), PasswordFromLogInInput);

            if (checkPasswordValidation)
            {
                await Task.Delay(1500); // Delay of 1,5 seconds
                await Application.Current.MainPage.Navigation.PushModalAsync(new ContactListPage());
                isBusy = false; // Stop the activity indicator
            }

            else
            {
                await Task.Delay(1500); // Delay of 1,5 seconds
                //Contain spaces warning.
                await Application.Current.MainPage.DisplayAlert("Alert", $"User or password is incorrect!", "Ok");
                IsBusy = false; // Stop the activity indicator
            }

        }

    }
}
