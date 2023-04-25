using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using FOne_MobileApp.Droid;
using FOne_MobileApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(MainPage), typeof(MainContentPageRenderer))]
namespace FOne_MobileApp.Droid
{
    public class MainContentPageRenderer : PageRenderer
    {
        public MainContentPageRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);

            //if (Control != null)
            //{
            //    Control.SetBackgroundColor(global::Android.Graphics.Color.LightBlue);
            //}
        }
    }
}
