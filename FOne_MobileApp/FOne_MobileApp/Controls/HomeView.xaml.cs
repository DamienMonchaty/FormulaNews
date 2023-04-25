using FOne_MobileApp.Persistence;
using FOne_MobileApp.Services.SQLite;
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
    public partial class HomeView : ContentView
    {
        public HomeView()
        {
            InitializeComponent();
            var blogDao = new BlogDao(DependencyService.Get<ISQLiteDb>());
            BindingContext = new HomeViewModel(blogDao);
        }
    }
}