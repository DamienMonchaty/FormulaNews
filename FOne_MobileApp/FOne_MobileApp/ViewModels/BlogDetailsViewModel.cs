using FOne_MobileApp.Models;
using FOne_MobileApp.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace FOne_MobileApp.ViewModels
{
    public class BlogDetailsViewModel : BaseViewModel
    {
        public Blog Blog { get; private set; }

        public BlogDetailsViewModel(Blog blog)
        {
            if (blog == null)
                throw new ArgumentNullException(nameof(blog));

            Blog = new Blog
            {
                Title = blog.Title,
                SubTitle = blog.SubTitle,
                Text1 = blog.Text1,
                Text2 = blog.Text2,
                Text3 = blog.Text3,
                AuthorName = blog.AuthorName,
                DateCreated = blog.DateCreated,
                Image = blog.Image,
            };
        }
    }
}
