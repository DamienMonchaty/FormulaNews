using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace FOne_MobileApp.UITest
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp.Android.InstalledApp("com.companyname.fone_mobileapp").EnableLocalScreenshots().StartApp();
            }
            return ConfigureApp.iOS.StartApp();
        }
    }
}