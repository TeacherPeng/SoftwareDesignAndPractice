using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace RegexLesson02
{
    class MainModel : INotifyPropertyChanged
    {
        public Encoding[] Encodings
        {
            get { return _Encodings; }
        }
        private Encoding[] _Encodings = new Encoding[] 
        {
            Encoding.Default,
            Encoding.ASCII,
            Encoding.BigEndianUnicode,
            Encoding.Unicode,
            Encoding.UTF32,
            Encoding.UTF7,
            Encoding.UTF8,
        };

        public Encoding CurrentEncoding
        {
            get => _CurrentEncoding;
            set
            {
                if (_CurrentEncoding == value) return; 
                _CurrentEncoding = value; 
                OnPropertyChanged(nameof(CurrentEncoding));
            }
        }
        private Encoding _CurrentEncoding = Encoding.Default;

        public void Load(string aFileName, Encoding aEncoding)
        {
            string[] aLines = File.ReadAllLines(aFileName, aEncoding);
            SourceTexts = aLines;
        }

        public string[] SourceTexts
        {
            get { return _SourceTexts; }
            set
            {
                if (_SourceTexts == value) return;
                _SourceTexts = value;
                DoFilter();
                OnPropertyChanged(nameof(SourceTexts));
            }
        }
        private string[] _SourceTexts;

        public void DoFilter()
        {
            if (string.IsNullOrEmpty(Pattern))
            {
                FilteredTexts = new List<string>(SourceTexts);
            }
            else
            {
                Regex aRegex = new Regex(Pattern);
                List<string> aLines = new List<string>();
                foreach (string aLine in SourceTexts)
                {
                    if (aRegex.IsMatch(aLine))
                        aLines.Add(aLine);
                }
                FilteredTexts = aLines;
            }
        }

        public List<string> FilteredTexts
        {
            get { return _FilteredTexts; }
            private set
            {
                if (_FilteredTexts == value) return;
                _FilteredTexts = value;
                OnPropertyChanged(nameof(FilteredTexts));
            }
        }
        private List<string> _FilteredTexts;

        public string Pattern
        {
            get { return _Pattern; }
            set
            {
                if (_Pattern == value) return;
                _Pattern = value;
                OnPropertyChanged(nameof(Pattern));
            }
        }
        private string _Pattern;

        // 配置文件操作
        private const string ConfigFileName = "Regex.config";
        public void LoadConfig()
        {
            try{
                XDocument aXDocument = XDocument.Load(ConfigFileName);
                this.ReadFromXml(aXDocument.Root.Element("Regex"));
            }catch (System.Exception){}
        }
        public void SaveConfig()
        {
            try{
                XDocument aXDocument = new XDocument(new XElement("Config", this.CreateXElement("Regex")));
                aXDocument.Save(ConfigFileName);
            }catch (System.Exception){}
        }
        #region 序列化
        public void ReadFromXml(XElement aXElement)
        {
            if (aXElement == null) return;
            Pattern = aXElement.Element(nameof(Pattern))?.Value;
        }
        public XElement CreateXElement(string aXmlNodeName)
        {
            return new XElement(aXmlNodeName, new XElement(nameof(Pattern), Pattern));
        }
        #endregion

        private void OnPropertyChanged(string aPropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(aPropertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
