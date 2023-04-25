using ContactList.Pages;


namespace ContactList;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(SignUpPage), typeof(SignUpPage));
    }
}
