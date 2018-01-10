using System;
using System.ComponentModel;
using System.Xml;
using System.Xml.Linq;

namespace XmlLesson01
{
    class MainModel : INotifyPropertyChanged
    {
        public XmlDocument CurrentXml { get { return _CurrentXml; } set { if (_CurrentXml == value) return; _CurrentXml = value; OnPropertyChanged(nameof(CurrentXml)); } }
        private XmlDocument _CurrentXml;
        private string _FileName;

        public void LoadXmlFile(string aFileName)
        {
            XmlDocument aXml = new XmlDocument();
            aXml.Load(aFileName);
            CurrentXml = aXml;
            _FileName = aFileName;
        }
        private const string ConfigFileName = "xmllesson01.cfg";
        public void SaveConfig()
        {
            XDocument aXDocument = new XDocument(
                new XElement("Config", 
                    new XElement("LastFile", _FileName)
                )
            );
            aXDocument.Save(ConfigFileName);
        }
        public void LoadConfig()
        {
            XDocument aXDocument = XDocument.Load(ConfigFileName);
            _FileName = aXDocument.Root.Element("LastFile").Value;
            LoadXmlFile(_FileName);
        }
        private void OnPropertyChanged(string aPropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(aPropertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
