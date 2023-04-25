using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FOne_MobileApp.Models
{
    public class Blog
    {
        //[PrimaryKey, AutoIncrement]
        public string BlogId { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Text1 { get; set; }
        public string Text2 { get; set; }
        public string Text3 { get; set; }
        public string AuthorName { get; set; }
        public string DateCreated { get; set; }
        public string Image { get; set; }
    }
}
