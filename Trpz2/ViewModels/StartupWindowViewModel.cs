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

        public static readonly string Page1ViewModelAlias = "Page1VM";
        public static readonly string Page2ViewModelAlias = "Page2VM";

        #endregion

        #region Ctors

        public StartupWindowViewModel(IViewModelsResolver resolver)
        {
            _resolver = resolver;

            _p1ViewModel = _resolver.GetViewModelInstance(Page1ViewModelAlias);
            _p2ViewModel = _resolver.GetViewModelInstance(Page2ViewModelAlias);

            InitializeCommands();
        }

        #endregion

        #region Fields  

        private readonly IViewModelsResolver _resolver;

        private ICommand _goToPathCommand;

        private ICommand _goToPage1Command;

        private ICommand _goToPage2Command;

        private readonly INotifyPropertyChanged _p1ViewModel;
        private readonly INotifyPropertyChanged _p2ViewModel;

        #region Startup string

        private string _startupString = "Hello, world!";

        public string StartupString
        {
            get
            {
                return _startupString;
            }
            set
            {
                SetProperty<string>(ref _startupString, value, "StartupString");
            }
        }

        #endregion

        #endregion

        #region Commands

        public ICommand GoToPathCommand
        {
            get { return _goToPathCommand; }
            set
            {
                SetProperty(ref _goToPathCommand, value, "GoToPathCommand");
            }
        }

        public ICommand GoToPage1Command
        {
            get
            {
                return _goToPage1Command;
            }
            set
            {
                SetProperty(ref _goToPage1Command, value, "GoToPage1Command");
            }
        }

        public ICommand GoToPage2Command
        {
            get { return _goToPage2Command; }
            set
            {
                SetProperty(ref _goToPage2Command, value, "GoToPage2Command");
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

        #endregion

        private void InitializeCommands()
        {

            GoToPathCommand = new RelayCommand<string>(GoToPathCommandExecute);

            GoToPage1Command = new RelayCommand<INotifyPropertyChanged>(GoToPage1CommandExecute);

            GoToPage2Command = new RelayCommand<INotifyPropertyChanged>(GoToPage2CommandExecute);

        }

        private void GoToPathCommandExecute(string alias)
        {
            if (string.IsNullOrWhiteSpace(alias))
            {
                return;
            }

            Navigation.Navigate(alias);
        }

        private void GoToPage1CommandExecute(INotifyPropertyChanged viewModel)
        {
            Navigation.Navigate(Navigation.Page1Alias, Page1ViewModel);
        }

        private void GoToPage2CommandExecute(INotifyPropertyChanged viewModel)
        {
            Navigation.Navigate(Navigation.Page2Alias, Page2ViewModel);
        }
    }
}
