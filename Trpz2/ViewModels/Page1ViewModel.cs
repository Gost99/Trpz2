using System.ComponentModel;

namespace Trpz2.ViewModels
{
    public class Page1ViewModel: Base.BaseViewModel, INotifyPropertyChanged
    {
        public string Page1Text
        {
            get { return "Hello, world!\nSent from my iPage 1..."; }
        }
    }
}
