namespace ContactList.View;

public partial class UserExistAlertPage : ContentPage
{
	public UserExistAlertPage()
	{
		InitializeComponent();
	}

    private async void GoToSignUpPage(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(Pages.SignUpPage));

    }
}