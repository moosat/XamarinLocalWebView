using System;
using System.Collections.Generic;
using System.Text;
using Foundation;
using WebViewGalleryApp;
using WebViewGalleryApp.iOS.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(BaseUrlWebView), typeof(BaseUrlWebViewRenderer))]
namespace WebViewGalleryApp.iOS.Controls
{
    public class BaseUrlWebViewRenderer : WebViewRenderer
    {
        public override void LoadHtmlString(string s, NSUrl baseUrl)
        {
            baseUrl = new NSUrl(NSBundle.MainBundle.BundlePath, true);
            base.LoadHtmlString(s, baseUrl);
        }
    }
}
