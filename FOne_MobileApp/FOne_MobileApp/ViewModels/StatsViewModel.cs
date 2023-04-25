using FOne_MobileApp.Controls;
using FOne_MobileApp.Helpers;
using FOne_MobileApp.Models;
using FOne_MobileApp.Services;
using FOne_MobileApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FOne_MobileApp.ViewModels
{
    public class StatsViewModel : BaseViewModel
    {
        private TabViewModel tvmDrivers;
        private TabViewModel tvmRaces;
        private TabViewModel tvmTeams;
        private TabViewModel tvmDriverResults;
        private TabViewModel tvmConstructorResults;

        private IPageService _pageService;

        private static string year = "";
        public ObservableCollection<Event> Events { get; set; }
        public ObservableCollection<Season> Seasons { get; set; }
        //public ObservableCollection<Driver> Drivers { get; set; }
        public ObservableCollection<Race> Races { get; set; }

        private ObservableCollection<Driver> _drivers;
        public ObservableCollection<Driver> Drivers
        {
            get { return _drivers; }
            set
            {
                _drivers = value;
                OnPropertyChanged(nameof(Drivers));
            }
        }

        private Season _selectedSeason;
        public Season SelectedSeason
        {
            get => _selectedSeason;
            set
            {
                if (_selectedSeason != null)
                    _selectedSeason.Selected = false;
                _selectedSeason = value;
                OnPropertyChanged(nameof(SelectedSeason));
                if (_selectedSeason != null)
                    _selectedSeason.Selected = true;
            }
        }

        private bool _isRefreshing = false;
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }

        private TabViewModel _currentTabVm;

        public ObservableCollection<TabViewModel> TabVms { get; set; }

        public TabViewModel CurrentTabVm
        {
            get => _currentTabVm;
            set
            {
                SetValue(ref _currentTabVm, value);
                OnPropertyChanged(nameof(CurrentTabVm));
                SetSelection();
            }
        }

        private void SetSelection()
        {
            this.TabVms.ToList().ForEach(vm => vm.IsSelected = false);
            this.CurrentTabVm.IsSelected = true;
        }

        public ICommand GetDriversCommand { get; set; }
        public ICommand GetRacesCommand { get; set; }

        public StatsViewModel(IPageService pageService)
        {
            _pageService = pageService;

            TabVms = new ObservableCollection<TabViewModel>();
            tvmDrivers = new TabViewModel("PILOTES");
            Task.Run(() => {
                Device.BeginInvokeOnMainThread(() => IsBusy = true);

                var result = ApiHelper.GetDriversBySeasonYearAsync("2023").GetAwaiter().GetResult();
                result.data.DriverTable.Drivers.ForEach(x =>
                {
                    tvmDrivers.Content.Add(new TabModel() { 
                        Name = x.GivenName + " " + x.FamilyName, 
                        OtherName = x.Nationality, 
                        Desc = x.PermanentNumber,
                        Image = ImageSource.FromFile(Regex.Replace(x.GivenName, @"\s+", "") + ".png"),
                        Year = "2023"
                    });
                });

                Device.BeginInvokeOnMainThread(() => IsBusy = false);

            });
            TabVms.Add(tvmDrivers);

            tvmRaces = new TabViewModel("COURSES");
            Task.Run(() => {
                var result = ApiHelper.GetRacesBySeasonYearAsync("2023").GetAwaiter().GetResult();
                result.data.RaceTable.Races.ForEach(x =>
                {
                    if(DateTime.Parse(x.Date) < DateTime.Today)
                    {
                        tvmRaces.Content.Add(
                            new TabModel() { 
                                Name = x.RaceName, 
                                OtherName = x.Circuit.Location.Locality,
                                Image = ImageSource.FromFile("racescircuit.png"),
                                Round = x.Round,
                                Year = "2023"
                            });
                    }
                });
            });
            TabVms.Add(tvmRaces);

            tvmTeams = new TabViewModel("CONSTRUCTEURS");
            Task.Run(() => {
                var r5 = ApiHelper.GetConstructorsBySeasonYearAsync("2023").GetAwaiter().GetResult();
                r5.data.ConstructorTable.Constructors.ForEach(x =>
                {
                    tvmTeams.Content.Add(new TabModel() { Name = x.Name, OtherName = x.Nationality, Image = ImageSource.FromFile(Regex.Replace(x.Name, @"\s+", "") + ".png")});
                });
            });
            TabVms.Add(tvmTeams);

            tvmDriverResults = new TabViewModel("CLASSEMENT PILOTES");
            Task.Run(() => {
                var r5 = ApiHelper.GetDriverStandingsBySeasonYearAsync("2023").GetAwaiter().GetResult();
                r5.data.StandingsTable.StandingsLists.ForEach(x => x.DriverStandings.ForEach(r => {
                    tvmDriverResults.Content.Add(new TabModel()
                    {
                        Name = r.Driver.GivenName + " " + r.Driver.FamilyName,
                        OtherName = r.Driver.Nationality,
                        Desc = r.position,
                        OtherDesc = r.points,
                        Image = ImageSource.FromFile(Regex.Replace(r.Driver.GivenName, @"\s+", "") + ".png"),
                    });
                }));
            });
            TabVms.Add(tvmDriverResults);

            tvmConstructorResults = new TabViewModel("CLASSEMENT CONSTRUCTEURS");
            Task.Run(() => {
                var r5 = ApiHelper.GetConstructorStandingsBySeasonYearAsync("2023").GetAwaiter().GetResult();
                r5.data.StandingsTable.StandingsLists.ForEach(x => x.ConstructorStandings.ForEach(r => {
                    tvmConstructorResults.Content.Add(new TabModel() { Name = r.Constructor.Name, OtherName = r.Constructor.Nationality, Desc = r.position, OtherDesc = r.points, Image = ImageSource.FromFile(Regex.Replace(r.Constructor.Name, @"\s+", "") + ".png") });
                }));
            });
            TabVms.Add(tvmConstructorResults);

            this.CurrentTabVm = this.TabVms.FirstOrDefault();

            var s = new Season() { Year = "2023" };

            SelectedSeason = s;

            Seasons = new ObservableCollection<Season>
            {
                s,
                new Season { Year="2022"},
                new Season { Year="2021"},
                new Season { Year="2020"},
                new Season { Year="2019"},
                new Season { Year="2018"},
                new Season { Year="2017"},
                new Season { Year="2016"},
                new Season { Year="2015"}
            };

            MessagingCenter.Subscribe<StatsViewModel>(this, "Update listview", (sender) =>
            {
                RefreshData();
            });
        }
        private bool _selected;

        public bool Selected { get => _selected; set => SetValue(ref _selected, value); }

        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                SetValue(ref _isBusy, value);
                OnPropertyChanged(nameof(IsBusy));
            }
        }

        public Command SelectedSeasonChangedCommand
        {
            get
            {
                return new Command((sender) =>
                {
                    Season season = sender as Season;
                    Console.WriteLine("SelectedSeason CollectionView" + SelectedSeason.Year);
                    year = SelectedSeason.Year;
                    SelectedSeason = season;
                    Console.WriteLine("Select item in Colletionview " + season.Year);
                    Console.WriteLine("Select item SelectedSeason " + SelectedSeason.Year);
                    tvmDrivers.Content.Clear();
                    tvmRaces.Content.Clear();
                    tvmTeams.Content.Clear();
                    tvmDriverResults.Content.Clear();
                    tvmConstructorResults.Content.Clear();

                    MessagingCenter.Send(this, "Update listview");
                });
            }
        }


        public void RefreshData()
        {
            tvmDrivers.Content.Clear();
            tvmRaces.Content.Clear();
            tvmTeams.Content.Clear();
            tvmDriverResults.Content.Clear();
            tvmConstructorResults.Content.Clear();
            Task.Run(() => {
                try {

                    Device.BeginInvokeOnMainThread(() => IsBusy = true);

                    var r5 = ApiHelper.GetDriversBySeasonYearAsync(year).GetAwaiter().GetResult();
                    r5.data.DriverTable.Drivers.ForEach(x =>
                    {
                        //IDictionary<string, string> map = new Dictionary<string, string>() {
                        //    { @"\s+", "" },
                        //    { @"é", "e" },
                        //    { @"ü", "u" },
                        //};
                        //var regex = new Regex(String.Join("|", map.Keys));

                        tvmDrivers.Content.Add(new TabModel() {
                            Name = x.GivenName + " " + x.FamilyName,
                            OtherName = x.Nationality,
                            Desc = x.PermanentNumber,
                            Image = ImageSource.FromFile(x.GivenName + ".png"),
                            Year = year
                        });
                    });

                    var r6 = ApiHelper.GetRacesBySeasonYearAsync(year).GetAwaiter().GetResult();
                    r6.data.RaceTable.Races.ForEach(x =>
                    {
                        tvmRaces.Content.Add(
                            new TabModel() { 
                                Name = x.RaceName, 
                                OtherName = x.Circuit.Location.Locality, 
                                Image = ImageSource.FromFile(Regex.Replace(x.Circuit.Location.Locality, @"\s+", "") + ".png"),
                                Round = x.Round,
                                Year = year
                            });
                    });

                    var r7 = ApiHelper.GetConstructorsBySeasonYearAsync(year).GetAwaiter().GetResult();
                    r7.data.ConstructorTable.Constructors.ForEach(x =>
                    {
                        tvmTeams.Content.Add(new TabModel() { Name = x.Name, OtherName = x.Nationality, Image = ImageSource.FromFile(Regex.Replace(x.Name, @"\s+", "") + ".png") });
                    });

                    var r8 = ApiHelper.GetDriverStandingsBySeasonYearAsync(year).GetAwaiter().GetResult();
                    r8.data.StandingsTable.StandingsLists.ForEach(x => x.DriverStandings.ForEach(r => {
                        tvmDriverResults.Content.Add(new TabModel()
                        {
                            Name = r.Driver.GivenName + " " + r.Driver.FamilyName,
                            OtherName = r.Driver.Nationality,
                            Desc = r.position,
                            OtherDesc = r.points,
                            Image = ImageSource.FromFile(Regex.Replace(r.Driver.GivenName, @"\s+", "") + ".png"),
                            Year = year
                        });
                    }));

                    var r9 = ApiHelper.GetConstructorStandingsBySeasonYearAsync(year).GetAwaiter().GetResult();
                    r9.data.StandingsTable.StandingsLists.ForEach(x => x.ConstructorStandings.ForEach(r => {
                        tvmConstructorResults.Content.Add(new TabModel() { Name = r.Constructor.Name, OtherName = r.Constructor.Nationality, Desc = r.position, OtherDesc = r.points, Image = ImageSource.FromFile(Regex.Replace(r.Constructor.Name, @"\s+", "") + ".png") });
                    }));

                }
                catch (Exception ex)
                {

                   
                }
                finally
                {
                    Device.BeginInvokeOnMainThread(() => IsBusy = false);
                }           
            });
        }
    }
}