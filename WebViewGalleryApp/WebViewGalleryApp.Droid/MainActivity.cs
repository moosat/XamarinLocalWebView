using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using XLabs.Forms;

namespace WebViewGalleryApp.Droid
{
    [Activity(Label = "WebViewGalleryApp", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : XFormsApplicationDroid
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

			App.ScreenWidth = (int)Resources.DisplayMetrics.WidthPixels; // real pixels
			App.ScreenHeight = (int)Resources.DisplayMetrics.HeightPixels; // real pixels


            LoadApplication(new App());

        }
    }
}

