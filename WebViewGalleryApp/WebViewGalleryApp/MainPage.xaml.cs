using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WebViewGalleryApp.Controls;
using Xamarin.Forms;
using XLabs.Ioc;
using XLabs.Platform.Device;

namespace WebViewGalleryApp
{
    public partial class MainPage : ContentPage
    {
        private List<string> _coludinaryIds = new List<string>()
        {
            "MoSamples/pic_30.jpg",
            "MoSamples/pic_31.jpg",
            "MoSamples/pic_32.jpg",
            "MoSamples/pic_33.jpg",
            "MoSamples/pic_34.jpg",
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

            string displayMatrix = GetDisplayMatrix();
            htmlSource.Html = $@"<html>
                                <head>
                                    <link rel=""stylesheet"" href=""stylesheet.css"">
                                </head>
                                <body>
                                    <h1>Welcome to Gallery, Mo</h1>
                                    <h2>{displayMatrix}</h2>
                                    <p>The CSS and image are loaded from local files!</p>
                                    <img src='WebFiles/Images/kodakit.png'/>
                                    <p><a href=""local.html"">next page</a></p>
                                </body>
                                </html>";
            htmlSource.Html = GetVlboxHtmlSource();
            //htmlSource.Html = GetPhotoSwipeHtml();
            Browser.Source = htmlSource;
        }

        private string GetDisplayMatrix()
        {
            var device = Resolver.Resolve<IDevice>(); //DependencyService.Get<IDevice>();
            
            string matrix = $"{device.Display.Height}x{device.Display.Width}";
            return matrix;
        }
        private string GetPhotoSwipeHtml()
        {
            const string replaceClause = "####IMAGES_LINES_GOWSHERE###";

            string template = GetHtmlTemplate("SwipeHtmlTemplate.html");

            string lines = BuildPhotoSwipeImagesLines(_coludinaryIds);

            string sourceHtml = template.Replace(replaceClause, lines);

            return sourceHtml;
        }


        //<a class="vlightbox1" href="http://res.cloudinary.com/kodakbluesky/image/upload/v1451847955/da960d4e-0284-4e6c-89c3-69ba49a9db1e/da960d4e-0284-4e6c-89c3-69ba49a9db1e/1421656088-1_-_Copy.jpg" title=""><img src = "http://res.cloudinary.com/kodakbluesky/image/upload/t_Scale120/v1451847955/da960d4e-0284-4e6c-89c3-69ba49a9db1e/da960d4e-0284-4e6c-89c3-69ba49a9db1e/1421656088-1_-_Copy.jpg" /></ a >

        private string GetVlboxHtmlSource()
        {
            const string replaceClause = "####IMAGES_LINES_GOWSHERE###";
            string template = GetHtmlTemplate("HtmlTemplate.html");
            string lines = BuildVlboxImagesLines(_coludinaryIds);
            string sourceHtml = template.Replace(replaceClause, lines);
            return sourceHtml;
        }

        private string GetHtmlTemplate(string resourceFile)
        {
            var assembly = typeof(MainPage).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream($"WebViewGalleryApp.Resources.{resourceFile}");
            string text = "";
            using (var reader = new System.IO.StreamReader(stream))
            {
                text = reader.ReadToEnd();
            }
            return text;
        }

        private string GetThumnbailTransformation()
        {
            var device = Resolver.Resolve<IDevice>(); 
            int thumnW = (device.Display.Width/5);
            int thumnH = (int) (thumnW*0.5622);
            //string trans = $"c_thumb,h_{thumnH},w_{thumnW}/";
            string trans = $"c_thumb,w_{thumnW}/";
            return trans;
        }

        private string GetScaledImageUrl(string cloudinaryId)
        {
            string cloudinaryScaleImage = GetFullSizeTransformation();
            string scaledImageUrl = $"{CloudinaryBaseUrl}{cloudinaryScaleImage}{cloudinaryId}";
            return scaledImageUrl;
        }
        private string GetScaledThunmbailImageUrl(string cloudinaryId)
        {
            string cloudinaryScaleImage = GetThumnbailTransformation();
            string scaledImageUrl = $"{CloudinaryBaseUrl}{cloudinaryScaleImage}{cloudinaryId}";
            return scaledImageUrl;
        }

        private string GetFullSizeTransformation()
        {
            //1366x768 fill
            //return "t_Landscape/";
            return "c_scale,w_500/";
        }
        const string CloudinaryBaseUrl = "https://res.cloudinary.com/kodakbluesky/image/upload/";
        private string BuildPhotoSwipeImagesLines(List<string> cloudinaryIds)
        {            
            StringBuilder sb = new StringBuilder();
            foreach (var cloudinaryId in cloudinaryIds)
            {
                string scaledImageUrl = GetScaledImageUrl(cloudinaryId);
                string scaledThumbnailUrl = GetScaledThunmbailImageUrl(cloudinaryId);

                string lineTemplate = $@"<figure itemprop='associatedMedia' itemscope itemtype='http://schema.org/ImageObject'>
                                         <a href='{scaledImageUrl}' itemprop='contentUrl' data-size='1366x768'>
                                         <img src='{scaledThumbnailUrl}' itemprop='thumbnail' alt='Image description'/>
                                         </a>
                                         </figure>";
                sb.Append(lineTemplate);
            }
            return sb.ToString();
        }


        private string BuildVlboxImagesLines(List<string> cloudinaryIds)
        {            
            StringBuilder sb = new StringBuilder();
            foreach (var cloudinaryId in cloudinaryIds)
            {
                string scaledImageUrl = GetScaledImageUrl(cloudinaryId);
                string scaledThunmbailImageUrl = GetScaledThunmbailImageUrl(cloudinaryId);
                string lineTemplate = $@"<a class='vlightbox1' href='{scaledImageUrl}' title=''><img src='{scaledThunmbailImageUrl}' /></a>";
                sb.Append(lineTemplate);
            }
            return sb.ToString();
        }
    }
}
