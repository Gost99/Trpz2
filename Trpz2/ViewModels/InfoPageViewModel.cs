using System.ComponentModel;

namespace Trpz2.ViewModels
{
    public class InfoPageViewModel: Base.BaseViewModel, INotifyPropertyChanged
    {
        public string Page1Text
        {
            get { return "Info about app..."; }
        }
    }
}
