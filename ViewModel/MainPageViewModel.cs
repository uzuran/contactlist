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
        public string UsernameFromLogInInput
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

        static bool IsPasswordValid(string username, string password)
        {
            var db = new UserDataContext();
            
            var user = db.Users.FirstOrDefault(u => u.Username == username);

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
            bool checkPasswordValidation = IsPasswordValid(UsernameFromLogInInput, PasswordFromLogInInput);

            if (checkPasswordValidation)
            {
                await Application.Current.MainPage.Navigation.PushModalAsync(new ContactListPage());
            }
        }

    }
}
