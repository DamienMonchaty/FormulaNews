using FOne_MobileApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace FOne_MobileApp.Controls.Selectors
{
    public class ItemsDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate FirstItem { get; set; }
        public DataTemplate OtherItem { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item is Blog blog)
            {
                var listView = container as ListView;
                var index = listView.ItemsSource.Cast<Blog>().ToList().IndexOf(blog);
                return (index == 0) ? FirstItem : OtherItem;
            }
            return null;
        }
    }
}
