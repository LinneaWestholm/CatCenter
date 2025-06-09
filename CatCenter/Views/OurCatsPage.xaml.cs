namespace CatCenter.Views;

public partial class OurCatsPage : ContentPage
{
	public OurCatsPage()
	{
		InitializeComponent();
        BindingContext = new ViewModels.OurCatsViewModel();
    }

    private async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var cat = ((ListView)sender).SelectedItem as Models.Cat;
        if (cat != null)
        {
            var page = new CatInfoPage();
            page.BindingContext = cat;
            await Navigation.PushAsync(page);
        }
    }
}