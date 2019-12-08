using System.Windows;
using Trpz2.EntityFramework;
using Trpz2.EntityFramework.Models;
using Trpz2.Models;
using Trpz2.Navigator;
using Trpz2.ViewModels;
using Trpz2.ViewModels.Resolvers;

namespace Trpz2.Views
{
    public partial class StartupWindow : Window
    {
        //private static StartupWindow _current;

        public readonly PermissionClass CurrentPermission;

        public StartupWindow()
            : this(PermissionClass.User)
        { }

        public StartupWindow(PermissionClass permissionToSet)
        {
            //if(_current != null)
            //{
            //    this.Close();
            //    _current = null;
            //    StartupWindow signIn = new StartupWindow(permissionToSet);
            //    signIn.Show();
            //}

  

            CurrentPermission = permissionToSet;

            InitializeComponent();

            Loaded += Window_Loaded;

            //Closing += new System.ComponentModel.CancelEventHandler(OnWindowClosing);
        }

        //void OnWindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        //{
        //    StartupWindow win = new StartupWindow(CurrentPermission);
        //    win.Show();
        //}

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Navigation.Service = MainFrame.NavigationService;

            DataContext = new StartupWindowViewModel(new ViewModelsResolver(CurrentPermission), CurrentPermission);
        }
    }
}
