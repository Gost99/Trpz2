using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Trpz2.Helpers;
using Trpz2.ViewModels.Base;
using Trpz2.Navigator;

namespace Trpz2.ViewModels
{
    public class StartupWindowViewModel : Base.BaseViewModel
    {
        #region Consts

        public static readonly string InfoPageViewModelAlias = "InfoPageVM";
        public static readonly string ItemsPageViewModelAlias = "ItemsPageVM";
        public static readonly string ShoppingCartPageViewModelAlias = "ShoppingCartPageVM";

        #endregion

        #region Ctors

        public StartupWindowViewModel(IViewModelsResolver resolver)
        {
            _resolver = resolver;

            _p1ViewModel = _resolver.GetViewModelInstance(InfoPageViewModelAlias);
            _p2ViewModel = _resolver.GetViewModelInstance(ItemsPageViewModelAlias);
            _p3ViewModel = _resolver.GetViewModelInstance(ShoppingCartPageViewModelAlias);

            InitializeCommands();
        }

        #endregion

        #region Fields  

        private readonly IViewModelsResolver _resolver;

        private ICommand _goToInfoPageCommand;

        private ICommand _goToIemsPageCommand;

        private ICommand _goToShoppingCartPageCommand;

        private readonly INotifyPropertyChanged _p1ViewModel;
        private readonly INotifyPropertyChanged _p2ViewModel;
        private readonly INotifyPropertyChanged _p3ViewModel;

        #endregion

        #region Commands

        public ICommand GoToInfoPageCommand
        {
            get { return _goToInfoPageCommand; }
            set
            {
                SetProperty(ref _goToInfoPageCommand, value, "GoToInfoPageCommand");
            }
        }

        public ICommand GoToIemsPageCommand
        {
            get
            {
                return _goToIemsPageCommand;
            }
            set
            {
                SetProperty(ref _goToIemsPageCommand, value, "GoToItemsPageCommand");
            }
        }

        public ICommand GoToShoppingCartPageCommand
        {
            get { return _goToShoppingCartPageCommand; }
            set
            {
                SetProperty(ref _goToShoppingCartPageCommand, value, "GoToShoppingCartPageCommand");
            }
        }

        public INotifyPropertyChanged Page1ViewModel
        {
            get { return _p1ViewModel; }
        }

        public INotifyPropertyChanged Page2ViewModel
        {
            get { return _p2ViewModel; }
        }

        public INotifyPropertyChanged Page3ViewModel
        {
            get { return _p3ViewModel; }
        }

        #endregion

        private void InitializeCommands()
        {

            GoToInfoPageCommand = new RelayCommand<INotifyPropertyChanged>(GoToPage1CommandExecute);

            GoToIemsPageCommand = new RelayCommand<INotifyPropertyChanged>(GoToPage2CommandExecute);

            GoToShoppingCartPageCommand = new RelayCommand<INotifyPropertyChanged>(GoToPage3CommandExecute);

        }

        private void GoToPage1CommandExecute(INotifyPropertyChanged viewModel)
        {
            Navigation.Navigate(Navigation.Page1Alias, Page1ViewModel);
        }

        private void GoToPage2CommandExecute(INotifyPropertyChanged viewModel)
        {
            Navigation.Navigate(Navigation.Page2Alias, Page2ViewModel);
        }

        private void GoToPage3CommandExecute(INotifyPropertyChanged viewModel)
        {
            Navigation.Navigate(Navigation.Page3Alias, Page3ViewModel);
        }
    }
}
