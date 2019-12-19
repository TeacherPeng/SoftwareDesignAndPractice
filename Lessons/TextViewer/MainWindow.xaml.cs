using Microsoft.Win32;
using System.Windows;
using UIHelper;

namespace TextViewer
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            _Model = new Model();
            this.DataContext = _Model;
        }

        private Model _Model;

        private void OnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OnOpen_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            OpenTextFileDialog aDlg = new OpenTextFileDialog();
            if (aDlg.ShowDialog() != true) return;
            try
            {
                _Model.Load(aDlg.FileName, aDlg.CurrentEncoding);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnStartFilte_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            try
            {
                _Model.StartFilte();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnStartFilte_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _Model != null && _Model.CanStartFilte;
        }
    }
}
