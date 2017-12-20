using System.ComponentModel;

namespace RegexLesson02
{
    class MainModel : INotifyPropertyChanged
    {
        public string[] SourceTexts { get { return _SourceTexts; } set { if (_SourceTexts == value) return; _SourceTexts = value; OnPropertyChanged(nameof(SourceTexts)); } }
        private string[] _SourceTexts;

        public string[] FilterdTexts { get { return _FilterdTexts; } set { if (_FilterdTexts == value) return; _FilterdTexts = value; OnPropertyChanged(nameof(FilterdTexts)); } }
        private string[] _FilterdTexts;

        public string Pattern { get { return _Pattern; } set { if (_Pattern == value) return; _Pattern = value; OnPropertyChanged(nameof(Pattern)); } }
        private string _Pattern;

        private void OnPropertyChanged(string aPropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(aPropertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
