namespace CatCenter
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnClickedGoLoginPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.LoginPage());
        }

        private async void OnClickedGoAboutPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.AboutPage());
        }

        private async void OnClickedGoOurCatsPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.OurCatsPage());
        }

        private async void OnClickedGoContactsPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.ContactsPage());
        }
    }

}
