using System.ComponentModel;

namespace Trpz2.ViewModels.Base
{
    public interface IViewModelsResolver
    {
        INotifyPropertyChanged GetViewModelInstance(string alias, object param = default(object));
    }
}
