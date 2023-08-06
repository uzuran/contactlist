using CommunityToolkit.Mvvm.ComponentModel;

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



    }
}
