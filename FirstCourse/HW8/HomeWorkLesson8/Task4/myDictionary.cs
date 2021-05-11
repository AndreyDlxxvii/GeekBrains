using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Task4
{
    [Serializable]
    public class myDictionary
    {
        private string _engWord;
        private string _rusWord;

        public string EngWord
        {
            get => _engWord;
            set => _engWord = value;
        }

        public string RusWord
        {
            get => _rusWord;
            set => _rusWord = value;
        }

        public myDictionary()
        {
        }

        public myDictionary(string engWord, string rusWord)
        {
            _engWord = engWord;
            _rusWord = rusWord;
        }
    }

    class EnglishRusDict
    {
        private List<myDictionary> list;
        string _fileName;

        public string FileName
        {
            set => _fileName = value;
        }

        public EnglishRusDict(string fileName)
        {
            _fileName = fileName;
            list = new List<myDictionary>();
        }

        public void Add(string engWord, string rusWord)
        {
            list.Add(new myDictionary(engWord,rusWord));
        }

        public void Remove(int index)
        {
            if (list != null && index < list.Count && index >= 0)
            {
                list.RemoveAt(index);
            }
        }
        public void Save()
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<myDictionary>));
            Stream fStream = new FileStream(_fileName, FileMode.Create, FileAccess.Write);
            xmlFormat.Serialize(fStream, list);
            fStream.Close();
        }
        public void Load()
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<myDictionary>));
            Stream fStream = new FileStream(_fileName, FileMode.Open, FileAccess.Read);
            list = (List<myDictionary>)xmlFormat.Deserialize(fStream);
            fStream.Close();
        }
        public int Count => list.Count;

        public myDictionary this[int i] => list[i];
    }
}