using CatCenter.Models;
using MongoDB.Driver;

namespace CatCenter.Views;

public partial class CatInfoPage : ContentPage
{
	public CatInfoPage()
	{
		InitializeComponent();
	}

    private async void OnClickedAdoptCat(object sender, EventArgs e)
    {
        if (BindingContext is Cat cat)
        {
            cat.isAdopted = true;
            var filter = Builders<Cat>.Filter.Eq(c => c.Id, cat.Id);
            await Data.DB.CatCollection().ReplaceOneAsync(filter, cat);
            await DisplayAlert("Adoption", $"Grattis! Du har adopterat {cat.Name}!", "OK");
            await Navigation.PopAsync();
        }
        else
        {
            await DisplayAlert("Error", "Katten blev inte adopterad", "OK");
            await Navigation.PopAsync();
        }
    }
}