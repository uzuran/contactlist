using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ContactList.Models;
using Microsoft.EntityFrameworkCore;
using System.Windows.Input;

namespace ContactList.ViewModels
{
    public class SignUpViewModel : ObservableObject
    {
        private string username;
        public string Username
        {
            get { return username; }
            set { SetProperty(ref username, value); }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set { SetProperty(ref password, value); }
        }

        public ICommand RegisterCommand { get; }

        public SignUpViewModel()
        {
            RegisterCommand = new RelayCommand(Register);
        }

        private void Register()
        {
            UserModel user = new UserModel
            {
                Username = Username,
                Password = Password
            };

            try
            {
                using (var db = new UserDataContext())
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                }
            }
            catch (DbUpdateException ex)
            {
                Exception innerException = ex.InnerException;

                // Extract details from the inner exception
                string errorMessage = innerException.Message;
                string stackTrace = innerException.StackTrace;


            }
        }
    }
}
