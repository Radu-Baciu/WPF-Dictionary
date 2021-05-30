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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Dictionary
{
    /// <summary>
    /// Interaction logic for SwitcherMenu.xaml
    /// </summary>
    public partial class SwitcherMenu : UserControl
    {
        public SwitcherMenu()
        {
            InitializeComponent();
        }

        private void funMode(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new FunMode());
        }
        private void searchMode(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new SearchMode());
        }

        private void adminMode(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new AdminMode());
        }
    }
}
