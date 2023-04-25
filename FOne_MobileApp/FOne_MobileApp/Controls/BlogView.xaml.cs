using FOne_MobileApp.Models;
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
    public partial class BlogView : ContentView
    {
        public BlogView()
        {
            InitializeComponent();
            var blogDao = new BlogDao(DependencyService.Get<ISQLiteDb>());
            BindingContext = new BlogViewModel(blogDao);

            //MyListView.PropertyChanged += (object sender, System.ComponentModel.PropertyChangedEventArgs e) =>
            //{
            //    if (e.PropertyName == "ItemsSource")
            //    {
            //        try
            //        {
            //            if (MyListView.ItemsSource != null)
            //            {
            //                var tmp = (IList<Blog>)MyListView.ItemsSource;
            //                MyListView.HeightRequest = tmp.Count * MyListView.RowHeight;
            //            }
            //        }
            //        catch (Exception ex)
            //        {
            //            Console.WriteLine(ex);
            //        }
            //    }
            //};
        }
    }
}