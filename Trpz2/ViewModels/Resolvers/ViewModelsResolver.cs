using System;
using System.Collections.Generic;
using System.ComponentModel;
using Trpz2.ViewModels.Base;

namespace Trpz2.ViewModels.Resolvers
{
    public class ViewModelsResolver : IViewModelsResolver
    {

        private readonly Dictionary<string, Func<INotifyPropertyChanged>> _vmResolvers = new Dictionary<string, Func<INotifyPropertyChanged>>();

        public ViewModelsResolver()
        {
            _vmResolvers.Add(StartupWindowViewModel.InfoPageViewModelAlias, () => new InfoPageViewModel());
            _vmResolvers.Add(StartupWindowViewModel.ItemsPageViewModelAlias, () => new ItemsPageViewModel());
            _vmResolvers.Add(StartupWindowViewModel.ShoppingCartPageViewModelAlias, () => new ShoppingCartPageViewModel());
        }

        public INotifyPropertyChanged GetViewModelInstance(string alias)
        {
            if (_vmResolvers.ContainsKey(alias))
            {
                return _vmResolvers[alias]();
            }

            return default;//_vmResolvers[MainViewModel.NotFoundPageViewModelAlias]();
        }
    }
}
