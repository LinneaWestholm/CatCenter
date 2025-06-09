using CatCenter.Data;
using System.Threading.Tasks;

namespace CatCenter.Views;

public partial class AdminPage : ContentPage
{
    private readonly CatApi _catApi;
    public AdminPage()
	{
		InitializeComponent();
        _catApi = new CatApi();
       
    }

    private async void OnClickedSavedCat(object sender, EventArgs e)
    {
        var cat = new Models.Cat
        {
            Id = Guid.NewGuid().ToString(),
            Name = NameEntry.Text,
            BirthDate = BirthDateEntry.Text,
            Description = DescriptionEntry.Text,
            ImageUrl = await _catApi.GetRandomCatImageAsync()
        };
        await Data.DB.CatCollection().InsertOneAsync(cat);
        await DisplayAlert("Success", $"{cat.Name} har sparats!", "OK");
        await Navigation.PopAsync();
    }
}