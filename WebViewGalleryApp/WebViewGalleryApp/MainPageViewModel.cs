using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WebViewGalleryApp.Annotations;

namespace WebViewGalleryApp
{
    public class MainPageViewModel :INotifyPropertyChanged
    {
        public MainPageViewModel()
        {
            BindSource = "Click Default";
        }
        private string _bindSource;

        public string BindSource
        {
            get { return _bindSource; }
            set
            {
                if (value != _bindSource)
                {
                    _bindSource = value;
                    OnPropertyChanged();
                }
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
