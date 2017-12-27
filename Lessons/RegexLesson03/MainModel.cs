using System.Collections.Generic;
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

        public List<MatchView> Matches { get { return _Matches; } private set { if (_Matches == value) return; _Matches = value; OnPropertyChanged(nameof(Matches)); } }
        private List<MatchView> _Matches;

        public string CollectedText { get { return _CollectedText; } private set { if (_CollectedText == value) return; _CollectedText = value; OnPropertyChanged(nameof(CollectedText)); } }
        private string _CollectedText;

        public string ReplaceResult { get { return _ReplaceResult; } private set { if (_ReplaceResult == value) return; _ReplaceResult = value; OnPropertyChanged(nameof(ReplaceResult)); } }
        private string _ReplaceResult;

        private static Encoding[] _Encodings = new Encoding[] { Encoding.Default, Encoding.ASCII, Encoding.UTF8, Encoding.Unicode, Encoding.UTF7, Encoding.UTF32, Encoding.BigEndianUnicode };
        public Encoding[] Encodings { get { return _Encodings; } }

        public Encoding CurrentEncoding { get { return _CurrentEncoding; } set { if (_CurrentEncoding == value) return; _CurrentEncoding = value; OnPropertyChanged(nameof(CurrentEncoding)); } }
        private Encoding _CurrentEncoding = Encoding.Default;

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
            TargetText = File.ReadAllText(aFileName, CurrentEncoding);
        }

        public class GroupView
        {
            public int Index { get; set; }
            public string Value { get; set; }
        }
        public class MatchView
        {
            public int Index { get; set; }
            public string Value { get; set; }
            public List<GroupView> Groups { get; set; }
        }
        public void GetMatches()
        {
            Regex aRegex = new Regex(Pattern);
            MatchCollection aMatches = aRegex.Matches(TargetText);
            List<MatchView> aMatchViews = new List<MatchView>();
            for (int i = 0; i < aMatches.Count; i++)
            {
                List<GroupView> aGroupViews = new List<GroupView>();
                for (int j = 0; j < aMatches[i].Groups.Count; j++)
                {
                    aGroupViews.Add(new GroupView { Index = j, Value = aMatches[i].Groups[j].Value });
                }
                aMatchViews.Add(new MatchView { Index = i, Value = aMatches[i].Value, Groups = aGroupViews });
            }
            Matches = aMatchViews;

            StringBuilder aStringBuilder = new StringBuilder();
            foreach (Match aMatch in aMatches)
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
