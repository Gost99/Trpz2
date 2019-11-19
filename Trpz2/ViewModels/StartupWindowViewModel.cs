using System.ComponentModel;
using System.Windows.Input;
using Trpz2.Helpers;
using Trpz2.Models;
using Trpz2.Navigator;
using Trpz2.ViewModels.Base;
using Trpz2.Views;

namespace Trpz2.ViewModels
{
    public class StartupWindowViewModel : Base.BaseViewModel
    {
        private PermissionClass _currentPermission;

        public PermissionClass Permission { set { _currentPermission = value; } }

        public string CurrentRole
        {
            get
            {
                return $"Current role: {_currentPermission}";
            }
        }

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

        public StartupWindowViewModel(IViewModelsResolver resolver, PermissionClass currentPermission) : this(resolver)
        {
            this._currentPermission = currentPermission;
            _p2ViewModel = _resolver.GetViewModelInstance(ItemsPageViewModelAlias, currentPermission);
        }

        private void InitializeCommands()
        {

            GoToInfoPageCommand = new RelayCommand<INotifyPropertyChanged>((viewModel) => {
                Navigation.Navigate(Navigation.Page1Alias, InfoPageViewModel);
            });

            GoToItemsPageCommand = new RelayCommand<INotifyPropertyChanged>((viewModel) => {
                Navigation.Navigate(Navigation.Page2Alias, ItemsPageViewModel);
            });

            GoToShoppingCartPageCommand = new RelayCommand<INotifyPropertyChanged>((viewModel) => {
                Navigation.Navigate(Navigation.Page3Alias, ShoppingCartPageViewModel);
            });

        }

        #endregion

        #region Fields  

        private readonly IViewModelsResolver _resolver;

        private ICommand _goToInfoPageCommand;

        private ICommand _goToItemsPageCommand;

        private ICommand _goToShoppingCartPageCommand;

        private ICommand _openManagerLoginPageCommand;
        
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

        public ICommand GoToItemsPageCommand
        {
            get
            {
                return _goToItemsPageCommand;
            }
            set
            {
                SetProperty(ref _goToItemsPageCommand, value, "GoToItemsPageCommand");
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

        public ICommand OpenManagerLoginPageCommand => _openManagerLoginPageCommand ?? 
            (_openManagerLoginPageCommand = new SimpleCommand(() => {
                ManagerLoginWindow passwordWindow = new ManagerLoginWindow();

                passwordWindow.ShowDialog();
            }));

        #endregion

        public INotifyPropertyChanged InfoPageViewModel
        {
            get { return _p1ViewModel; }
        }

        public INotifyPropertyChanged ItemsPageViewModel
        {
            get { return _p2ViewModel; }
        }

        public INotifyPropertyChanged ShoppingCartPageViewModel
        {
            get { return _p3ViewModel; }
        }




    }
}
