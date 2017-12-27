using System.ComponentModel;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace RegexLesson03
{
    class MainModel : INotifyPropertyChanged
    {
        public string Pattern
        {
            get { return _Pattern; }
            set
            {
                if (_Pattern == value) return; _Pattern = value; OnPropertyChanged(nameof(Pattern));
            }
        }
        private string _Pattern;

        public string ReplacePattern { get { return _ReplacePattern; } set { if (_ReplacePattern == value) return; _ReplacePattern = value; OnPropertyChanged(nameof(ReplacePattern)); } }
        private string _ReplacePattern;

        public string TargetText { get { return _TargetText; } set { if (_TargetText == value) return; _TargetText = value; OnPropertyChanged(nameof(TargetText)); } }
        private string _TargetText;

        public MatchCollection Matches { get { return _Matches; } private set { if (_Matches == value) return; _Matches = value; OnPropertyChanged(nameof(Matches)); } }
        private MatchCollection _Matches;

        public string CollectedText { get { return _CollectedText; } private set { if (_CollectedText == value) return; _CollectedText = value; OnPropertyChanged(nameof(CollectedText)); } }
        private string _CollectedText;

        public string ReplaceResult { get { return _ReplaceResult; } private set { if (_ReplaceResult == value) return; _ReplaceResult = value; OnPropertyChanged(nameof(ReplaceResult)); } }
        private string _ReplaceResult;

        public bool CanStartMatch
        {
            get
            {
                return !string.IsNullOrWhiteSpace(Pattern) && !string.IsNullOrWhiteSpace(TargetText);
            }
        }

        public bool CanStartReplace
        {
            get
            {
                return !string.IsNullOrWhiteSpace(Pattern) && !string.IsNullOrWhiteSpace(ReplacePattern) && !string.IsNullOrWhiteSpace(TargetText);
            }
        }

        public void LoadTargetTextFrom(string aFileName)
        {
            TargetText = File.ReadAllText(aFileName);
        }

        public void GetMatches()
        {
            Regex aRegex = new Regex(Pattern);
            Matches = aRegex.Matches(TargetText);
            StringBuilder aStringBuilder = new StringBuilder();
            foreach (Match aMatch in Matches)
            {
                aStringBuilder.AppendLine(aMatch.Value);
            }
            CollectedText = aStringBuilder.ToString();
        }

        public void Replace()
        {
            Regex aRegex = new Regex(Pattern);
            ReplaceResult = aRegex.Replace(TargetText, ReplacePattern);
        }

        private void OnPropertyChanged(string aPropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(aPropertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
