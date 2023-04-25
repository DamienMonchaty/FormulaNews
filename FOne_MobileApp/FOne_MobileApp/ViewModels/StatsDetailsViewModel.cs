using FOne_MobileApp.Helpers;
using FOne_MobileApp.Models;
using FOne_MobileApp.Services;
using FOne_MobileApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FOne_MobileApp.ViewModels
{
    public class StatsDetailsViewModel : BaseViewModel
    {
        private IPageService _pageService;
        public TabModel Model { get; private set; }

        public ObservableCollection<Result> Results { get; set; }

        public StatsDetailsViewModel(IPageService pageService, TabModel tabModel)
        {
            _pageService = pageService;

            if (tabModel == null)
                throw new ArgumentNullException(nameof(tabModel));

            Model = new TabModel
            {
                Name = tabModel.Name,
                OtherName = tabModel.OtherName,
                Desc = tabModel.Desc,
                OtherDesc = tabModel.OtherDesc,
                Image = tabModel.Image,
                Year = tabModel.Year,
                Round = tabModel.Round
            };

            Results = new ObservableCollection<Result>();

            // Check if round exists call method details API MOT LOADING ALL EACH TIME

            Console.WriteLine(Model.Round);
            if (Model.Round != null)
            {
                Task.Run(() =>
                {
                    var r1 = ApiHelper.GetResultsBySeasonYearAndByRoundAsync(Model.Year, Model.Round).GetAwaiter().GetResult();
                    r1.data.RaceTable.Races.ForEach(x => x.Results.ForEach(r =>
                    {
                        r.Driver.Image = ImageSource.FromFile(r.Driver.GivenName + ".png");
                        Results.Add(r);
                        Console.WriteLine("POSITION --------------" + r.Position);
                    }));
                });
            }
            else
            {
                var splitted = Model.Name.Split(' ');
                Task.Run(() =>
                {
                    var r1 = ApiHelper.GetResultsBySeasonYearAndByOneDriverAsync(Model.Year, splitted[1]).GetAwaiter().GetResult();
                    r1.data.RaceTable.Races.ForEach(x => x.Results.ForEach(r =>
                    {
                        Results.Add(r);
                    }));
                });
            }
        }

    }
}
