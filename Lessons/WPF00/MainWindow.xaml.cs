using System.Windows;

namespace WPF00
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            _Model = new MyModel();
            this.DataContext = _Model;
        }
        private MyModel _Model;

        private void OnShowData_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(_Model.Data);
        }

        private void OnClear_Click(object sender, RoutedEventArgs e)
        {
            _Model.ClearData();
        }
    }
}
