using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebViewGalleryApp.Controls;
using Xamarin.Forms;

namespace WebViewGalleryApp
{
    public class BaseUrlWebView : WebView
    {
        public static readonly BindableProperty SourceHtmlStringProperty =
            BindableProperty.Create<BaseUrlWebView, string>(p => p.SourceHtmlString, "<html><h1>Blank</h1></html>", BindingMode.TwoWay, propertyChanged: OnSourceHtmlStringPropertyChanged);

        private static void OnSourceHtmlStringPropertyChanged(BindableObject bindable, string oldvalue, string newvalue)
        {
            BaseUrlWebView webView = bindable as BaseUrlWebView;
            if (webView == null)
                return;

            if (newvalue.StartsWith("http"))
            {
                webView.Source = new UrlWebViewSource() {Url = newvalue};
            }
            else
            {
                var htmlSource = new HtmlWebViewSource();
                // do not set the BaseUrl on iOS because of the bug
                if (Device.OS != TargetPlatform.iOS)
                {
                    // the BaseUrlWebViewRenderer does this for iOS, until bug is fixed
                    htmlSource.BaseUrl = DependencyService.Get<IBaseUrl>().Get();
                }
                htmlSource.Html = newvalue;
                webView.Source = htmlSource;
            }
        }

        public string SourceHtmlString
        {
            get { return (string) GetValue(SourceHtmlStringProperty); }
            set { SetValue(SourceHtmlStringProperty, value); }
        }

    }
}
