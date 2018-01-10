using System;
using System.Windows;

namespace LinqToSqlLesson02
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

        private void OnSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _Model.Submit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
