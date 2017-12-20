using System.Windows;
using Microsoft.Win32;

namespace RegexLesson02
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
        private MainModel _Model;

        private void OnLoad_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            OpenFileDialog aDlg = new OpenFileDialog();
            if (aDlg.ShowDialog() != true) return;
            _Model.Load(aDlg.FileName);
        }

        private void OnLoad_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void OnStartFilter_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            _Model.DoFilter();
        }

        private void OnStartFilter_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }
}
