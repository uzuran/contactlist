namespace ContactList.View;

public partial class RegistrationSuccessAlertPage : ContentPage
{
    public RegistrationSuccessAlertPage()
    {
        InitializeComponent();
    }

    // Method for dismiss alert after registration success and move to the main page.
    private async void GoToMainPage(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("////MainPage");

    }
}