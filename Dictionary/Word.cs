using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    public class Word : INotifyPropertyChanged
    {
        public String Name { get; set; }
        public String Category { get; set; }
        public String Description { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Word && (obj as Word).Name == Name;
        }
        public override string ToString()
        {
            return Name;
        }
        public Word(String name,String category, String description)
        {
            Name = name;
            Category = category;
            Description = description;
        }
        public Word (Word w)
        {
            Name = w.Name;
            Category = w.Category;
            Description = w.Description;
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
