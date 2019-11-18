using System.Windows;
using Trpz2.Navigator;
using Trpz2.ViewModels;
using Trpz2.ViewModels.Resolvers;

namespace Trpz2.Views
{
    public partial class StartupWindow : Window
    {
        public StartupWindow()
        {

            InitializeComponent();

            Loaded += Window_Loaded;
        }

        

        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Navigation.Service = MainFrame.NavigationService;

            DataContext = new StartupWindowViewModel(new ViewModelsResolver());
        }
    }
}
