using FOne_MobileApp.Controls;
using FOne_MobileApp.Models;
using FOne_MobileApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FOne_MobileApp.ViewModels
{
    public class TabViewModel : BaseViewModel
    {
        private string _title;
        private ObservableCollection<TabModel> _content { get; set; }
        private bool _isSelected;

        public ICommand SelectItemCommand { get; set; }
        public ICommand SelectAllowItemCommand { get; set; }

        public TabViewModel(string title)
        {
            Title = title;
            Content = new ObservableCollection<TabModel>();
            SelectItemCommand = new Command<TabModel>(async c => await SelectOne(c));
            SelectAllowItemCommand = new Command<bool>(c => AddAllowed(c));
        }

        public string Title { get => _title; set => SetValue(ref _title, value); }
        
        public ObservableCollection<TabModel> Content 
            { 
            get => _content;
            set
            {
                _content = value;                
                OnPropertyChanged(nameof(Content));
            }
        }
        public bool IsSelected { get => _isSelected; set => SetValue(ref _isSelected, value); }

        private TabModel _selectedItem;

        public TabModel SelectedItem
        {
            get { return _selectedItem; }
            set { SetValue(ref _selectedItem, value); }
        }

        private async Task SelectOne(TabModel tabModel)
        {
            if (tabModel.Year != null)
            {
                await MainPage.Navigation.PushAsync(new StatsDetailsView(tabModel));
            }
        }

        private Page MainPage
        {
            get { return Application.Current.MainPage; }
        }

        public bool AddAllowed(object obj) => !string.IsNullOrEmpty(_selectedItem.Year);
    }
}
