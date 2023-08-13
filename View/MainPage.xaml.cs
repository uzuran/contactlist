using ContactList.ViewModel;

namespace ContactList;

public partial class MainPage : ContentPage
{
    public MainPage(MainPageViewModel mainPageViewModel)
    {
        BindingContext = mainPageViewModel;
        InitializeComponent();
    }


    private async void GoToSignUpPage(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(Pages.SignUpPage));

    }

}