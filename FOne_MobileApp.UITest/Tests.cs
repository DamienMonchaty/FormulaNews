using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace FOne_MobileApp.UITest
{
    [TestFixture(Platform.Android)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
            app.Repl();
        }

        [Test]
        public void BlogIsDisplayed()
        {
            app.ScrollDown();
            app.WaitForElement(c => c.Marked("frame_blogDetails"));
            app.Tap(c => c.Marked("frame_blogDetails"));
            app.Screenshot("On " + this.GetType().Name);
        }

        [Test]
        public void BlogIsDisplayedFromHomeView()
        {
            app.WaitForElement(c => c.Marked("frame_blogDetails"));
            app.Tap(c => c.Marked("frame_blogDetails"));
            app.Screenshot("On " + this.GetType().Name);
        }

        [Test]
        public void ResultIsDisplayed()
        {
            app.WaitForElement(c => c.Marked("btn_Result"));
            app.Tap(c => c.Marked("btn_Result"));
            app.Tap(c => c.Marked("lbl_Year"));
            app.Tap(c => c.Marked("lbl_Item"));
            app.Tap(c => c.Marked("frame_Card"));
            app.Screenshot("On " + this.GetType().Name);
        }
    }
}
