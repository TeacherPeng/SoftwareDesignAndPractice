using System;
using System.ComponentModel;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Media;
using Microsoft.Win32;

namespace MyUiHelper
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

        public string FileName
        {
            get => _FileName;
            set
            {
                if (_FileName == value) return;
                _FileName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FileName)));
                PreviewWithReload();
            }
        }
        private string _FileName;

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
                PreviewWithoutReload();
            }
        }
        private Encoding _CurrentEncoding = Encoding.Default;

        public string PreviewText
        {
            get => _PreviewText;
            private set
            {
                if (_PreviewText == value) return;
                _PreviewText = value;
                OnPropertyChanged(nameof(PreviewText));
            }
        }
        private string _PreviewText;

        byte[] _PreviewBytes = new byte[2048];
        private void Preview(bool aReload)
        {
            try
            {
                if (aReload)
                {
                    FileStream aStream = File.OpenRead(FileName);
                    aStream.Read(_PreviewBytes, 0, _PreviewBytes.Length);
                    aStream.Close();
                }

                PreviewText = CurrentEncoding.GetString(_PreviewBytes);
                txtPreview.Foreground = new SolidColorBrush(Colors.Black);
            }
            catch (Exception ex)
            {
                PreviewText = ex.Message;
                txtPreview.Foreground = new SolidColorBrush(Colors.Red);
            }
        }
        private void PreviewWithReload() => Preview(true);
        private void PreviewWithoutReload() => Preview(false);

        private void OnPropertyChanged(string aPropertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(aPropertyName));
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog aDlg = new OpenFileDialog();
            if (aDlg.ShowDialog() == false) return;
            FileName = aDlg.FileName;
        }
    }
}
