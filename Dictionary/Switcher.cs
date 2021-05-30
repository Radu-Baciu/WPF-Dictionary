using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Dictionary
{
    public static class Switcher
    {
        public static MainWindow pageSwitcher;

        public static void Switch(UserControl nextPage)
        {
            pageSwitcher.Navigate(nextPage);
        }
    }
}
