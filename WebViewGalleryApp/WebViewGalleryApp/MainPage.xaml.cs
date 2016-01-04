using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebViewGalleryApp.Controls;
using Xamarin.Forms;

namespace WebViewGalleryApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            var htmlSource = new HtmlWebViewSource();
            // do not set the BaseUrl on iOS because of the bug
            if (Device.OS != TargetPlatform.iOS)
            {
                // the BaseUrlWebViewRenderer does this for iOS, until bug is fixed
                htmlSource.BaseUrl = DependencyService.Get<IBaseUrl>().Get();
            }

            htmlSource.Html = @"<html>
                                <head>
                                    <link rel=""stylesheet"" href=""stylesheet.css"">
                                </head>
                                <body>
                                    <h1>Welcome to Gallery, Mo</h1>
                                    <p>The CSS and image are loaded from local files!</p>
                                    <img src='WebFiles/Images/kodakit.png'/>
                                    <p><a href=""local.html"">next page</a></p>
                                </body>
                                </html>";
            Browser.Source = htmlSource;
        }
    }
}
