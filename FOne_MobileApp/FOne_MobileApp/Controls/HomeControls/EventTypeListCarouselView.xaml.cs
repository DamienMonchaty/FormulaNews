using FOne_MobileApp.Services;
using FOne_MobileApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FOne_MobileApp.Controls.HomeControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventTypeListCarouselView : ContentView
    {
        public EventTypeListCarouselView()
        {
            InitializeComponent();
            var pageService = new PageService();
            BindingContext = new StatsViewModel(pageService);
        }

        //private void FavoriteProductPage_Appearing(object sender, EventArgs e)
        //{
        //    BindingContext = new HomeViewModel();
        //}

        private void CarouselView_CurrentItemChanged(object sender, CurrentItemChangedEventArgs e)
        {
            this.CustomTabsView.ScrollTo(e.CurrentItem, null, ScrollToPosition.Center, true);
        }
    }
}