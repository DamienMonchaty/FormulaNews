using FOne_MobileApp.Models;
using FOne_MobileApp.Services;
using FOne_MobileApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FOne_MobileApp.Controls.HomeControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SeasonListCarouselView : ContentView
    {
        public ObservableCollection<Season> ItemsSource { get; set; }

        public SeasonListCarouselView()
        {
            InitializeComponent();
            var pageService = new PageService();
            BindingContext = new StatsViewModel(pageService);
        }
    }
}