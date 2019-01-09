using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace RegexToolkit
{
    class RegexModel : INotifyPropertyChanged
    {
        public void DoMatch()
        {
            Regex aRegex = new Regex(Pattern);
            MatchCollection aMatches = aRegex.Matches(SourceText);
            StringBuilder aStringBuilder = new StringBuilder();
            foreach(Match aMatch in aMatches)
            {
                aStringBuilder.AppendLine($"Match: {aMatch.Value}");
                int i = 0;
                foreach (Group aGroup in aMatch.Groups)
                {
                    aStringBuilder.AppendLine($"    Group[{i}]: {aGroup.Value}");
                    i++;
                }
                aStringBuilder.AppendLine();
            }
            Result = aStringBuilder.ToString();
        }
        public bool CanMatch => !string.IsNullOrEmpty(Pattern) && !string.IsNullOrEmpty(SourceText);

        public void DoSelect()
        {
            Regex aRegex = new Regex(Pattern);
            MatchCollection aMatches = aRegex.Matches(SourceText);
            StringBuilder aStringBuilder = new StringBuilder();
            foreach (Match aMatch in aMatches)
            {
                if (aMatch.Groups.Count == 1)
                {
                    aStringBuilder.AppendLine(aMatch.Value);
                }
                else
                {
                    for (int i = 1; i < aMatch.Groups.Count; i++)
                    {
                        aStringBuilder.AppendLine(aMatch.Groups[i].Value);
                    }
                }
            }
            Result = aStringBuilder.ToString();
        }
        public bool CanSelect => CanMatch;

        public void DoReplace()
        {
            Regex aRegex = new Regex(Pattern);
            Result = aRegex.Replace(SourceText, ReplacePattern);
        }
        public bool CanReplace => CanMatch && !string.IsNullOrEmpty(ReplacePattern);

        public void SaveResult(string aFileName)
        {
            File.WriteAllText(aFileName, Result);
        }

        public ObservableCollection<string> Patterns { get; } = new ObservableCollection<string>();

        public void UpdatePatterns()
        {
            if (string.IsNullOrEmpty(Pattern)) return;
            if (Patterns.Contains(Pattern)) return;
            Patterns.Add(Pattern);
        }

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

        public string ReplacePattern { get => _ReplacePattern; set { if (_ReplacePattern == value) return; _ReplacePattern = value; OnPropertyChanged(nameof(ReplacePattern)); } }
        private string _ReplacePattern;

        public string SourceText { get => _SourceText; set { if (_SourceText == value) return; _SourceText = value; OnPropertyChanged(nameof(SourceText)); } }
        private string _SourceText;

        public string Result
        {
            get { return _Result; }
            set
            {
                if (_Result == value) return;
                _Result = value;
                OnPropertyChanged(nameof(Result));
                UpdatePatterns();
            }
        }
        private string _Result;

        public void LoadTextFile(string aFileName, Encoding aEncoding)
        {
            SourceText = File.ReadAllText(aFileName, aEncoding);
        }

        private void OnPropertyChanged(string aPropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(aPropertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
