using System;
using System.Windows;
using Microsoft.Win32;

namespace XmlLesson01
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                _Model = new MainModel();
                _Model.LoadConfig();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.DataContext = _Model;
        }
        private MainModel _Model;

        private void OnOpen_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            try
            {
                OpenFileDialog aDlg = new OpenFileDialog();
                aDlg.Filter = "Xml 文件 (*.xml)|*.xml|所有文件 (*.*)|*.*";
                if (aDlg.ShowDialog() != true) return;
                _Model.LoadXmlFile(aDlg.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnClosed(object sender, EventArgs e)
        {
            try
            {
                _Model.SaveConfig();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
