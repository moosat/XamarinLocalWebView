using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using WebViewGalleryApp.Controls;
using WebViewGalleryApp.Droid.Controls;
using Xamarin.Forms;

[assembly: Dependency(typeof(BaseUrl_Android))]
namespace WebViewGalleryApp.Droid.Controls
{
    public class BaseUrl_Android : IBaseUrl
    {
        public string Get()
        {
            return "file:///android_asset/";           
        }
    }
}