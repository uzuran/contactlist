using ContactList.ViewModels;


namespace ContactList.Pages;

public partial class SignUpPage : ContentPage
{   
    public SignUpPage()
	{
        // Create an instance of SignUpViewModel and set as BindingContext
        var viewModel = new SignUpViewModel();
        BindingContext = viewModel;
        InitializeComponent();
    }
}
