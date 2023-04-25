using FOne_MobileApp.Controls;
using FOne_MobileApp.Helpers;
using FOne_MobileApp.Models;
using FOne_MobileApp.Services.SQLite;
using FOne_MobileApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FOne_MobileApp.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private IDao<Blog> _blogDao;

        public Blog _blog;

        public Blog Blog
        {
            get { return _blog; }
            set { SetValue(ref _blog, value); }
        }

        public ICommand SelectItemCommand { get; set; }

        public Race _race;

        public Race Race
        {
            get { return _race; }
            set
            {
                _race = value;
                OnPropertyChanged(nameof(_race));
            }
        }

        public ObservableCollection<Result> _results;

        public ObservableCollection<Result> Results
        {
            get { return _results; }
            set
            {
                _results = value;
                OnPropertyChanged(nameof(_results));
            }
        }


        private Circuit _circuit;

        public Circuit Circuit
        {
            get => _circuit;
            set
            {
                SetValue(ref _circuit, value);
                OnPropertyChanged(nameof(Circuit));
            }
        }

        public ImageSource ImageCircuit { get; set; }

        public HomeViewModel(IDao<Blog> blogDao)
        {
            _blogDao = blogDao;
            SelectItemCommand = new Command<Blog>(async c => await SelectOne(c));

            ImageCircuit = ImageSource.FromFile("racescircuit.png");
            // Circuits = new ObservableCollection<Circuit>();
            Task.Run(() => {
                var r1 = ApiHelper.GetNextCircuitAsync().GetAwaiter().GetResult();
                Circuit = new Circuit
                {
                    CircuitId = r1.data.CircuitTable.Circuits[0].CircuitId,
                    CircuitName = r1.data.CircuitTable.Circuits[0].CircuitName,
                    Location = r1.data.CircuitTable.Circuits[0].Location
                };
                Debug.WriteLine("CIRCUIT 2 " + Circuit);
            });

            Task.Run(async () => await GetOne());

            Race = new Race();
            Results = new ObservableCollection<Result>();
            Task.Run(() => {
                var result = ApiHelper.GetResultOfMostRecentRaceAsync().GetAwaiter().GetResult();
                Race.RaceName = result.data.RaceTable.Races[0].RaceName;
                result.data.RaceTable.Races.ForEach(x =>
                {
                    x.Results.ForEach(y => {
                        Results.Add(y);
                    });
                });
            });
        }

        private async Task GetOne()
        {
            Blog = await _blogDao.GetFirst();
        }

        private async Task SelectOne(Blog blog)
        {
            await MainPage.Navigation.PushAsync(new BlogDetailsView(blog));
        }

        private Page MainPage
        {
            get { return Application.Current.MainPage; }
        }
    }  
}