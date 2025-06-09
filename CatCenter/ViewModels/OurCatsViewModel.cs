using CatCenter.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatCenter.ViewModels
{
    internal class OurCatsViewModel: INotifyPropertyChanged
    {
        private ObservableCollection<Models.Cat> _cats;

        public ObservableCollection<Models.Cat> Cats
        {
            get => _cats;
            set
            {
                _cats = value;
                OnPropertyChanged();
            }
        }

        private readonly CatApi _catApi;

        public OurCatsViewModel()
        {
            _catApi = new CatApi();
            _ = LoadCatsAsync();
        }

        private async Task LoadCatsAsync()
        {
            Cats = new ObservableCollection<Models.Cat>();

            Cats.Add(new Models.Cat
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Fluffy",
                BirthDate = "2018-03-25",
                Description = "Fluffy är en väldigt fluffig katt. Hon älskar att bli klappad och sova.",
                ImageUrl = await _catApi.GetRandomCatImageAsync()
            });

            Cats.Add(new Models.Cat
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Junior",
                BirthDate = "2025-01-03",
                Description = "Junior är en väldigt lekfull katt. Han älskar att leka med andra katter.",
                ImageUrl = await _catApi.GetRandomCatImageAsync()
            });

            Cats.Add(new Models.Cat
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Tiger",
                BirthDate = "2022-05-15",
                Description = "Tiger är en väldigt gosig katt. Han älskar att bli klappad och kommer att spinna högt när du gör det.",
                ImageUrl = await _catApi.GetRandomCatImageAsync()
            });

            Cats.Add(new Models.Cat
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Kajsa",
                BirthDate = "2025-01-03",
                Description = "Kajsa är en väldigt lugn katt. Hon älskar att sova och mysa.",
                ImageUrl = await _catApi.GetRandomCatImageAsync()
            });

            Cats.Add(new Models.Cat
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Max",
                BirthDate = "2021-07-03",
                Description = "Max är en busing kille med en stor personlighet! Han älskar att vara ute.",
                ImageUrl = await _catApi.GetRandomCatImageAsync()
            });

            Cats.Add(new Models.Cat
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Maja",
                BirthDate = "2020-11-06",
                Description = "Maja är en skygg katt. Hon kan behöva lite tid att vänja sig vid nya människor.",
                ImageUrl = await _catApi.GetRandomCatImageAsync()
            });

            await GetCatsFromDbAsync(Cats.ToList());
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged() => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Our Cats"));

        private async Task GetCatsFromDbAsync(List<Models.Cat> cats)
        {
            await Data.DB.CatCollection().InsertManyAsync(cats);
        }
    }
}
