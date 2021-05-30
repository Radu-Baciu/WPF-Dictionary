using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    public class WordSet
    {
        public ObservableCollection<Word> Words { get; set; }

        public WordSet()
        {
            Words = new ObservableCollection<Word>();
            Words = XMLReader.ReadWords();
        }  
    }
}
