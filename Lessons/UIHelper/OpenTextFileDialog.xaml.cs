using System;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows;
using Microsoft.Win32;

namespace UIHelper
{
    /// <summary>
    /// OpenTextFileDialog.xaml 的交互逻辑
    /// </summary>
    public partial class OpenTextFileDialog : Window
    {
        public OpenTextFileDialog()
        {
            InitializeComponent();
            _Model = new Model();
            this.DataContext = _Model;
        }
        private Model _Model;

        public string FileName => _Model.FileName;

        public Encoding CurrentEncoding => _Model.CurrentEncoding;

        private void OnOk_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void OnOk_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = !string.IsNullOrEmpty(_Model?.FileName);
        }

        private void OnBrowse_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            OpenFileDialog aDlg = new OpenFileDialog()
            {
                Title = "选择文件",
                Filter = "文本文件 (*.txt)|*.txt|Xml文件 (*.xml)|*.xml|所有文件 (*.*)|*.*",
            };
            if (aDlg.ShowDialog() != true) return;
            _Model.FileName = aDlg.FileName;
        }
    }

    class Model : INotifyPropertyChanged
    {
        public string FileName
        {
            get => _FileName;
            set { if (_FileName == value) return; _FileName = value; OnPropertyChanged(nameof(FileName)); GetPreview(); }
        }
        private string _FileName;

        public string Preview
        {
            get => _Preview;
            set { if (_Preview == value) return; _Preview = value; OnPropertyChanged(nameof(Preview)); }
        }
        private string _Preview;

        public Encoding CurrentEncoding
        {
            get => _CurrentEncoding;
            set { if (_CurrentEncoding == value) return; _CurrentEncoding = value; OnPropertyChanged(nameof(CurrentEncoding)); GetPreview(); }
        }
        private Encoding _CurrentEncoding = Encoding.Default;

        public Encoding[] Encodings => _Encodings;
        private static Encoding[] _Encodings = new Encoding[]
        {
            Encoding.Default, Encoding.UTF7, Encoding.UTF8, Encoding.UTF32, Encoding.ASCII, Encoding.BigEndianUnicode, Encoding.Unicode
        };

        private void GetPreview()
        {
            try
            {
                Preview = File.ReadAllText(FileName, CurrentEncoding);
            }
            catch (Exception ex)
            {
                Preview = ex.Message;
            }
        }

        private void OnPropertyChanged(string aPropertyName) 
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(aPropertyName));
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
