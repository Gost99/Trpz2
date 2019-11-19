using System;
using System.Collections.Generic;
using System.ComponentModel;
using Trpz2.Models;
using Trpz2.ViewModels.Base;

namespace Trpz2.ViewModels.Resolvers
{
    public class ViewModelsResolver : IViewModelsResolver
    {

        private readonly Dictionary<string, Func<INotifyPropertyChanged>> _vmResolvers = new Dictionary<string, Func<INotifyPropertyChanged>>();

        public ViewModelsResolver(PermissionClass currentPermission)
        {
            _vmResolvers.Add(StartupWindowViewModel.InfoPageViewModelAlias, () => new InfoPageViewModel());
            _vmResolvers.Add(StartupWindowViewModel.ItemsPageViewModelAlias, () => new ItemsPageViewModel(currentPermission));
            _vmResolvers.Add(StartupWindowViewModel.ShoppingCartPageViewModelAlias, () => new ShoppingCartPageViewModel());
        }

        public INotifyPropertyChanged GetViewModelInstance(string alias, object param = null)
        {
            if (_vmResolvers.ContainsKey(alias))
            {
                return _vmResolvers[alias]();
            }

            return default;
        }
    }
}
