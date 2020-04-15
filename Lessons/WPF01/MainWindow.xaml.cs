using Microsoft.Win32;
using System.Windows;
using System.Windows.Input;
using UIHelper;

namespace WPF01
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            _Model = new MainModel();
            this.DataContext = _Model;
        }

        private readonly MainModel _Model;

        private void OnOk_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }

        private void OnOk_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _Model != null && _Model.IsValid;
        }

        private void OnBrowseEmailContent_Click(object sender, RoutedEventArgs e)
        {
            OpenTextFileDialog aDlg = new OpenTextFileDialog();
            if (aDlg.ShowDialog() != true) return;
            try
            {
                _Model.LoadEmailContent(aDlg.FileName, aDlg.CurrentEncoding);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnBrowsePicture_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog aDlg = new OpenFileDialog
            {
                Title = "选择图片"
            };
            if (aDlg.ShowDialog() != true) return;
            _Model.PictureFileName = aDlg.FileName;
        }
    }
}
