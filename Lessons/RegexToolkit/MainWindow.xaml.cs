using Microsoft.Win32;
using System.Windows;
using TextDialogHelper;

namespace RegexToolkit
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            _Model = new RegexModel();
            this.DataContext = _Model;
        }

        private RegexModel _Model;

        private void OnLoad_Click(object sender, RoutedEventArgs e)
        {
            OpenTextFileDialog aDlg = new OpenTextFileDialog();
            if (aDlg.ShowDialog() != true) return;
            try
            {
                _Model.LoadTextFile(aDlg.FileName, aDlg.CurrentEncoding);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnMatch_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            try
            {
                _Model.DoMatch();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnMatch_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _Model != null && _Model.CanMatch;
        }

        private void OnSelect_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            try
            {
                _Model.DoSelect();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnSelect_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _Model != null && _Model.CanSelect;
        }

        private void OnReplace_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            try
            {
                _Model.DoReplace();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnReplace_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _Model != null && _Model.CanReplace;
        }

        private void OnSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog aDlg = new SaveFileDialog();
            if (aDlg.ShowDialog() != true) return;
            try
            {
                _Model.SaveResult(aDlg.FileName);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
