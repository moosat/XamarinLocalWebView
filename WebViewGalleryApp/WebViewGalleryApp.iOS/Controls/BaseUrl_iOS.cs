using Foundation;
using WebViewGalleryApp.Controls;
using WebViewGalleryApp.iOS.Controls;
using Xamarin.Forms;

[assembly: Dependency(typeof(BaseUrl_iOS))]
namespace WebViewGalleryApp.iOS.Controls
{
    public class BaseUrl_iOS : IBaseUrl
    {
        public string Get()
        {
            return NSBundle.MainBundle.BundlePath;
        }
    }
}
