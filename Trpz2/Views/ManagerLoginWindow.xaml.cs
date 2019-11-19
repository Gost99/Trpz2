using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Trpz2.ViewModels;
using Trpz2.Views.Interfaces;

namespace Trpz2.Views
{
    /// <summary>
    /// Interaction logic for ManagerLoginWindow.xaml
    /// </summary>
    public partial class ManagerLoginWindow : Window
    {
        public ManagerLoginWindow()
        {
            InitializeComponent();

            this.DataContext = new ManagerLoginWindowViewModel();

            Loaded += (s, e) =>
            {
                if (DataContext is IClosable)
                {
                    (DataContext as IClosable).RequestClose += (_, __) => this.Close();
                }
                if (DataContext is IWarningShowable)
                {
                    (DataContext as IWarningShowable).RequestDialogBoxShow += (_, __) => MessageBox.Show("Incorrect creditinals!!!");
                }

            };
        }

    }
}
