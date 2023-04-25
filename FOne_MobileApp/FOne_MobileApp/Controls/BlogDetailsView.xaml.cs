using FOne_MobileApp.Models;
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
    public partial class BlogDetailsView : ContentPage
    {
        public BlogDetailsView(Blog blog)
        {
            InitializeComponent();
            BindingContext = new BlogDetailsViewModel(blog);
        }
    }
}