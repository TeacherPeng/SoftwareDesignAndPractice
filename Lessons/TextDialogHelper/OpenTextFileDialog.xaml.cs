using Microsoft.Win32;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace TextDialogHelper
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
            get { return _FileName; }
            set
            {
                if (_FileName == value) return; _FileName = value; OnPropertyChanged(nameof(FileName));
                UpdatePreview(true);
            }
        }
        private string _FileName;

        public Encoding[] Encodings { get { return _Encodings; } }
        private readonly static Encoding[] _Encodings = new Encoding[]
        {
            Encoding.ASCII, Encoding.Default, Encoding.Unicode, Encoding.UTF7, Encoding.UTF8, Encoding.UTF32, Encoding.BigEndianUnicode,
        };

        public Encoding CurrentEncoding
        {
            get { return _CurrentEncoding; }
            set
            {
                if (_CurrentEncoding == value) return; _CurrentEncoding = value; OnPropertyChanged(nameof(CurrentEncoding));
                UpdatePreview(false);
            }
        }
        private Encoding _CurrentEncoding = Encoding.UTF8;


        public string Preview
        {
            get { return _Preview; }
            set
            {
                if (_Preview == value) return;
                _Preview = value;
                OnPropertyChanged(nameof(Preview));
            }
        }
        private string _Preview;
        private void OnPropertyChanged(string aPropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(aPropertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnBrowse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog aDlg = new OpenFileDialog();
            if (aDlg.ShowDialog() != true) return;
            FileName = aDlg.FileName;
        }

        private byte[] _Bytes = new byte[1024];
        private void UpdatePreview(bool aReload)
        {
            try
            {
                if (aReload)
                    using (FileStream aStream = File.OpenRead(FileName))
                    {
                        aStream.Read(_Bytes, 0, _Bytes.Length);
                        aStream.Close();
                    }
                Preview = CurrentEncoding.GetString(_Bytes);
                txtPreview.Foreground = new SolidColorBrush(Colors.Black);
            }
            catch (System.Exception ex)
            {
                Preview = ex.Message + ex.StackTrace;
                txtPreview.Foreground = new SolidColorBrush(Colors.Red);
            }
        }

        private void OnOk_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void OnOk_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = !string.IsNullOrWhiteSpace(FileName) && CurrentEncoding != null;
        }
    }
}
