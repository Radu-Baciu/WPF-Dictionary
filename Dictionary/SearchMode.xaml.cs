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
    /// Interaction logic for SearchMode.xaml
    /// </summary>
    public partial class SearchMode : UserControl
    {
        public SearchMode()
        {
            InitializeComponent();
            foreach (var item in (DataContext as WordSet).Words)
            {
                AutoCompleteBox.Items.Add(item);
            }
        }

        private void WordSearch(object sender, RoutedEventArgs e)
        {
            bool search = false;

            foreach (var item in (DataContext as WordSet).Words)
            {
                if (item.ToString().ToUpper().Equals(SearchBox.Text.ToUpper()))
                {
                    WordResultBox.Text = item.Name;
                    CategoryResultBox.Text = item.Category;
                    DescriptionResultBox.Text = item.Description;
                    search = true;
                }
            }
            if (search == false)
            {
                MessageBox.Show("No word found!");
            }
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            AutoCompleteBox.Items.Clear();
            foreach (var item in (DataContext as WordSet).Words)
            {
                if (item.Name.ToUpper().StartsWith(SearchBox.Text.ToUpper()))
                {
                    AutoCompleteBox.Items.Add(item);
                }
            }
        }

        private void AutoCompleteBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AutoCompleteBox.SelectedItem is Word)
            {
                WordResultBox.Text = (AutoCompleteBox.SelectedItem as Word).Name;
                CategoryResultBox.Text = (AutoCompleteBox.SelectedItem as Word).Category;
                DescriptionResultBox.Text = (AutoCompleteBox.SelectedItem as Word).Description;
                SearchBox.Text = (AutoCompleteBox.SelectedItem as Word).Name;
            }
        }
    }
}
