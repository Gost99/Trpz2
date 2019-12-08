using System;
using System.Windows.Controls;
using System.Windows.Input;
using Trpz2.Helpers;
using Trpz2.Models;
using Trpz2.Views;
using Trpz2.Views.Interfaces;

namespace Trpz2.ViewModels
{
    public class ManagerLoginWindowViewModel: Base.BaseViewModel, IClosable, IWarningShowable
    {
        #region Fields

        public string UserName { get; set; }

        #endregion


        #region Commands

        private ICommand _loginCommand;

        public event EventHandler RequestClose;
        public event EventHandler RequestDialogBoxShow;


        public ICommand LoginCommand => _loginCommand ??
            (_loginCommand = new RelayCommand<PasswordBox>((parameter) => {
                var passwordBox = parameter as PasswordBox;
                var password = passwordBox.Password;

                if(!string.IsNullOrEmpty(UserName) && password.Length > 0)
                {
                    AdminDto userToContinue = new AdminDto() { Username = UserName, Password = password, Permission = PermissionClass.Admin };

                    if (UserPermissionChecker.CheckPermission(userToContinue))
                    {
                        new StartupWindow(userToContinue.Permission).Show();
                        RequestClose(this, new EventArgs());
                    }
                    else
                    {
                        RequestDialogBoxShow(this, new EventArgs());
                    }
                }

            }));

        #endregion
    }
}
