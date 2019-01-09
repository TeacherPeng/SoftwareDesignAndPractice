using System.ComponentModel;
using System.Text;
using System.Windows;

namespace RegexLesson03
{
    /// <summary>
    /// OpenTextFileDialog.xaml 的交互逻辑
    /// </summary>
    public partial class OpenTextFileDialog : Window, INotifyPropertyChanged
    {
        public OpenTextFileDialog()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public string FileName { get => _FileName; set { if (_FileName == value) return; _FileName = value; OnPropertyChanged(nameof(FileName)); } }
        private string _FileName;

        public Encoding CurrentEncoding { get => _CurrentEncoding; set { if (_CurrentEncoding == value) return; _CurrentEncoding = value; OnPropertyChanged(nameof(CurrentEncoding)); } }
        private Encoding _CurrentEncoding;

        public Encoding[] Encodings => _Encodings;
        private readonly static Encoding[] _Encodings = new Encoding[] { Encoding.ASCII, Encoding.BigEndianUnicode, Encoding.Default, Encoding.Unicode, Encoding.UTF32, Encoding.UTF7, Encoding.UTF8 };

        public string Preview { get => _Preview; set { if (_Preview == value) return; _Preview = value; OnPropertyChanged(nameof(Preview)); } }
        private string _Preview;

        private void OnPropertyChanged(string aPropertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(aPropertyName));
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
