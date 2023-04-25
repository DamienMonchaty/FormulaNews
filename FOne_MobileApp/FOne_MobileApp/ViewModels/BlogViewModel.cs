using FOne_MobileApp.Controls;
using FOne_MobileApp.Models;
using FOne_MobileApp.Services.SQLite;
using FOne_MobileApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FOne_MobileApp.ViewModels
{
    public class BlogViewModel : BaseViewModel
    {
        private IDao<Blog> _blogDao;

        public ObservableCollection<Blog> Blogs { get; set; }

        public ICommand SelectItemCommand { get; set; }

        public BlogViewModel(IDao<Blog> blogDao)
        {
            _blogDao = blogDao;
            SelectItemCommand = new Command<Blog>(async c => await SelectOne(c));

            Blogs = new ObservableCollection<Blog>();

            Task.Run(async () => await LoadBlogs());

        }

        private Blog _selectedItem;

        public Blog SelectedItem
        {
            get { return _selectedItem; }
            set { SetValue(ref _selectedItem, value); }
        }

        private async Task SelectOne(Blog blog)
        {
            if (blog == null)
                return;
            SelectedItem = null;
            await MainPage.Navigation.PushAsync(new BlogDetailsView(blog));
        }

        private async Task LoadBlogs()
        {
            var blogs = await _blogDao.GetListAsync();
            foreach (var b in blogs)
                Blogs.Add(b
                );
        }

        private Page MainPage
        {
            get { return Application.Current.MainPage; }
        }

    }
}
