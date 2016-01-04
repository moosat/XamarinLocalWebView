using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WebViewGalleryApp.Controls;
using Xamarin.Forms;

namespace WebViewGalleryApp
{
    public partial class MainPage : ContentPage
    {
        private List<string> _coludinaryIds = new List<string>()
        {
            "MoSamples/pic_1.jpg",
            "MoSamples/pic_2.jpg",
            "MoSamples/pic_3.jpg",
            "MoSamples/pic_4.jpg",
            "MoSamples/pic_5.jpg",
            "MoSamples/pic_6.jpg",
            "MoSamples/pic_7.jpg",
            "MoSamples/pic_8.jpg",
            "MoSamples/pic_9.jpg",
            "MoSamples/pic_10.jpg",
            "MoSamples/pic_11.jpg",
            "MoSamples/pic_12.jpg",
            "MoSamples/pic_13.jpg",
            "MoSamples/pic_14.jpg",
            "MoSamples/pic_15.jpg",
            "MoSamples/pic_16.jpg",
            "MoSamples/pic_17.jpg",
            "MoSamples/pic_18.jpg",
            "MoSamples/pic_19.jpg",
            "MoSamples/pic_20.jpg",
            "MoSamples/pic_21.jpg",
            "MoSamples/pic_22.jpg",
            "MoSamples/pic_23.jpg",
            "MoSamples/pic_24.jpg",
            "MoSamples/pic_24.jpg"
        };

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
            htmlSource.Html = GetHtmlSource();
            Browser.Source = htmlSource;
        }


                //<a class="vlightbox1" href="http://res.cloudinary.com/kodakbluesky/image/upload/v1451847955/da960d4e-0284-4e6c-89c3-69ba49a9db1e/da960d4e-0284-4e6c-89c3-69ba49a9db1e/1421656088-1_-_Copy.jpg" title=""><img src = "http://res.cloudinary.com/kodakbluesky/image/upload/t_Scale120/v1451847955/da960d4e-0284-4e6c-89c3-69ba49a9db1e/da960d4e-0284-4e6c-89c3-69ba49a9db1e/1421656088-1_-_Copy.jpg" /></ a >

        private string GetHtmlSource()
        {
            const string replaceClause = "####IMAGES_LINES_GOWSHERE###";
            string template = GetHtmlTemplate();
            string lines = BuildImagesLines(_coludinaryIds);
            string sourceHtml = template.Replace(replaceClause, lines);
            return sourceHtml;
        }

        private string GetHtmlTemplate()
        {
            var assembly = typeof(MainPage).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("WebViewGalleryApp.Resources.HtmlTemplate.html");
            string text = "";
            using (var reader = new System.IO.StreamReader(stream))
            {
                text = reader.ReadToEnd();
            }
            return text;
        }

        private string BuildImagesLines(List<string> cloudinaryIds)
        {            
            const string cloudinaryBaseUrl = "https://res.cloudinary.com/kodakbluesky/image/upload/";
            const string cloudinaryScale = "c_scale,w_120/";
            StringBuilder sb = new StringBuilder();
            foreach (var cloudinaryId in cloudinaryIds)
            {
                string fullImageUrl = $"{cloudinaryBaseUrl}{cloudinaryId}";
                string scaledImageUrl = $"{cloudinaryBaseUrl}{cloudinaryScale}{cloudinaryId}";
                string lineTemplate = $@"<a class='vlightbox1' href='{fullImageUrl}' title=''><img src='{scaledImageUrl}' /></a>";
                sb.Append(lineTemplate);
            }
            return sb.ToString();
        }
    }
}
