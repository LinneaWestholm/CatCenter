
namespace CatCenter.Views;


public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

    private async void OnClickedLoggedIn(object sender, EventArgs e)
    {
        string username = UsernameEntry.Text;
        string password = PasswordEntry.Text;

        if (username == "admin" && password == "admin123")
        {
            
            await Navigation.PushAsync(new AdminPage());
        }
        else if (username == "user" && password == "user123")
        {
            await Navigation.PopAsync();
        }
        else
        {
            await DisplayAlert("Inloggning misslyckades", "Ogiltligt användarnamn eller lösenord", "OK");
        }
    }
}