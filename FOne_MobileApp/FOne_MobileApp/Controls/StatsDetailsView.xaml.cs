using FOne_MobileApp.Models;
using FOne_MobileApp.Services;
using FOne_MobileApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FOne_MobileApp.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StatsDetailsView : ContentPage
    {
        public StatsDetailsView(TabModel tabModel)
        {
            InitializeComponent();
            var pageService = new PageService();
            BindingContext = new StatsDetailsViewModel(pageService, tabModel);
        }
    }
}