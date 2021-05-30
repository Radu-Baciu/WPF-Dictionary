using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Dictionary
{
    public static class XMLReader
    {
        public static void WriteWords(ObservableCollection<Word> words)
        {
            var filename = @"Resources\Words.xml";
            var currentDirectory = Directory.GetCurrentDirectory();
            currentDirectory = Directory.GetParent(currentDirectory).FullName;
            currentDirectory = Directory.GetParent(currentDirectory).FullName;

            var wordsFilePath = Path.Combine(currentDirectory, filename);

            XmlTextWriter writer = new XmlTextWriter(wordsFilePath, null);
            writer.Formatting = Formatting.Indented;

            writer.WriteStartElement("words");

            foreach (var word in words)
            {
                writer.WriteStartElement("word");

                writer.WriteStartAttribute("Name");
                writer.WriteString(word.Name);
                writer.WriteEndAttribute();

                writer.WriteStartAttribute("Description");
                writer.WriteString(word.Description);
                writer.WriteEndAttribute();

                writer.WriteStartAttribute("Category");
                writer.WriteString(word.Category);
                writer.WriteEndAttribute();

                writer.WriteEndElement();
            }

            writer.WriteEndElement();

            writer.Flush();
            writer.Close();
        }
        public static ObservableCollection<Word> ReadWords()
        {
            ObservableCollection<Word> Words = new ObservableCollection<Word>();
            var filename = @"Resources\Words.xml";
            var currentDirectory = Directory.GetCurrentDirectory();
            currentDirectory = Directory.GetParent(currentDirectory).FullName;
            currentDirectory = Directory.GetParent(currentDirectory).FullName;

            var wordsFilePath = Path.Combine(currentDirectory, filename);

            XmlReader reader = XmlReader.Create(wordsFilePath);

            if (reader.ReadToFollowing("word"))
            do
            {

                reader.MoveToAttribute("Name");
                string name = reader.ReadContentAsString();

                reader.MoveToAttribute("Description");
                string description = reader.ReadContentAsString();

                reader.MoveToAttribute("Category");
                string category = reader.ReadContentAsString();

                Words.Add(new Word(name,category,description));

            } while (reader.ReadToFollowing("word"));

            reader.Close();

            return Words;
        }
    }
}
