using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for FunMode.xaml
    /// </summary>
    public partial class FunMode : UserControl
    {
        private int points = 0;
        private ObservableCollection<Word> riddles = new ObservableCollection<Word>();
        private void generateRiddles()
        {
            Random random = new Random();
            for (int i = 0; i < 5; i++)
            {
                int input = random.Next((DataContext as WordSet).Words.Count);
                if (riddles != null)
                    riddles.Add((DataContext as WordSet).Words[input]);
            }
            RiddleBox.Text = riddles[0].Description;
        }

        public FunMode()
        {
            InitializeComponent();
            generateRiddles();
            points = 0;
        }

        private void AnswerButton_Click(object sender, RoutedEventArgs e)
        {
            if (riddles.Count > 0)
            {
                if (GuessBox.Text.ToUpper().Equals(riddles[0].Name.ToUpper()))
                     points++;
                riddles.Remove(riddles[0]);
                if (riddles.Count != 0)
                    RiddleBox.Text = riddles[0].Description;
                else
                    MessageBox.Show("You earned " + points.ToString() + " points!");
            }
        }
    }
}
