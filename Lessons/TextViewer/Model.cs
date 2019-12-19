using System;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace TextViewer
{
    class Model : INotifyPropertyChanged
    {
        public void Load(string aFileName, Encoding aEncoding)
        {
            Text = File.ReadAllText(aFileName, aEncoding);
            if (!CanStartFilte)
                FiltedText = Text;
            else
                StartFilte();
        }

        public string Text
        {
            get => _Text;
            set
            {
                if (_Text == value) return;
                _Text = value;
                OnPropertyChanged(nameof(Text));
            }
        }
        private string _Text;

        public string FiltedText
        {
            get => _FiltedText;
            set
            {
                if (_FiltedText == value) return;
                _FiltedText = value;
                OnPropertyChanged(nameof(FiltedText));
            }
        }
        private string _FiltedText;

        public string Pattern
        {
            get => _Pattern;
            set
            {
                if (_Pattern == value) return;
                _Pattern = value;
                OnPropertyChanged(nameof(Pattern));
            }
        }
        private string _Pattern;

        private void OnPropertyChanged(string aPropertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(aPropertyName));
        public event PropertyChangedEventHandler PropertyChanged;

        public void StartFilte()
        {
            string[] aLines = Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder aStringBuilder = new StringBuilder();
            Regex aRegex = new Regex(Pattern);
            foreach(var aLine in aLines)
            {
                if (aRegex.IsMatch(aLine))
                {
                    aStringBuilder.AppendLine(aLine);
                }
            }
            FiltedText = aStringBuilder.ToString();
        }
        public bool CanStartFilte => 
            !string.IsNullOrWhiteSpace(Text) && 
            !string.IsNullOrWhiteSpace(Pattern);
    }
}
