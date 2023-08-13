using ContactList.ViewModels;


namespace ContactList.Pages;

public partial class SignUpPage : ContentPage
{   
    public SignUpPage(SignUpViewModel signUpViewModel)
	{        
        BindingContext = signUpViewModel;
        InitializeComponent();
    }
}
