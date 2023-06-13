using ContactList.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactList.Pages;

public partial class SignUpPage : ContentPage
{   
    public SignUpPage()
	{
		InitializeComponent();
    }
    private void OnRegisterClicked(object sender, EventArgs e)
    {
        string userName = UsernameEntry.Text;
        string userPassword = PasswordEntry.Text;

        UserModel user = new UserModel
        {
            Username = userName,
            Password = userPassword
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

            DisplayAlert(title: "Error", message: errorMessage, cancel: "Exit");

            // Handle or log the error details
        }

        // Display a success message or navigate to another page
        // after successful registration
    }

}