namespace CatCenter.Views;

public partial class AboutPage : ContentPage
{
	public AboutPage()
	{
		InitializeComponent();
	}

    private async void OnClickedOurCats(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new OurCatsPage());
    }
}