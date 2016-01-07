using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using XLabs.Ioc;
using XLabs.Platform.Device;
using XLabs.Platform.Services;

namespace WebViewGalleryApp
{
    public class App : Application
    {
		public static int ScreenWidth;
		public static int ScreenHeight;

        public App()
        {
            //var container = new SimpleContainer();
         

			//container.Register<IDevice>(t => AppleDevice.CurrentDevice);
            //container.Register<IDisplay>(t => t.Resolve<IDevice>().Display);
            //container.Register<INetwork>(t => t.Resolve<IDevice>().Network);

            //Resolver.SetResolver(container.GetResolver());
            // The root page of your application
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
