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
    /// Interaction logic for AdminMode.xaml
    /// </summary>
    public partial class AdminMode : UserControl
    {
        public AdminMode()
        {
            InitializeComponent();
        }

        private void AddWord(object sender, RoutedEventArgs e)
        {
            (DataContext as WordSet).Words.Add(new Word(WordBox.Text,CategoryBox.Text,DescriptionBox.Text));
            XMLReader.WriteWords((DataContext as WordSet).Words);
            Switcher.Switch(new AdminMode());
        }
        private void DeleteWord(object sender, RoutedEventArgs e)
        {
            (DataContext as WordSet).Words.Remove(WordListBox.SelectedItem as Word);
            XMLReader.WriteWords((DataContext as WordSet).Words);
            Switcher.Switch(new AdminMode());
        }
        private void ModifyWord(object sender, RoutedEventArgs e)
        {
            Word w = WordListBox.SelectedItem as Word;
            if (WordListBox.SelectedItem !=null)
                if (w.Equals(new Word(WordBox.Text, CategoryBox.Text, DescriptionBox.Text)))
                {
                    w.Name = WordBox.Text;
                    w.Category = CategoryBox.Text;
                    w.Description = DescriptionBox.Text;
                    XMLReader.WriteWords((DataContext as WordSet).Words);
                    Switcher.Switch(new AdminMode());
                }
            else
            {
                MessageBox.Show("No word with this name exists!");
            }
        }

        private void WordListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (WordListBox.SelectedItem is Word)
            {
                WordBox.Text = (WordListBox.SelectedItem as Word).Name;
                CategoryBox.Text = (WordListBox.SelectedItem as Word).Category;
                DescriptionBox.Text = (WordListBox.SelectedItem as Word).Description;
            }
        }
    }
}