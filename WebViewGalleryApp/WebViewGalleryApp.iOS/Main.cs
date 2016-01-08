using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace WebViewGalleryApp.iOS
{
    public class Application
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.

			App.ScreenWidth = (int)UIScreen.MainScreen.Bounds.Width;
			App.ScreenHeight = (int)UIScreen.MainScreen.Bounds.Height;

            UIApplication.Main(args, null, "AppDelegate");
        }
    }
}
