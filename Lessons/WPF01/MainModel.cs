using System;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace WPF01
{
    class MainModel : INotifyPropertyChanged
    {
        private readonly Regex _EmailPattern = new Regex(@"(\w+)@(\w+)(\.\w+){1,3}");
        public string Email { get => _Email; set { if (_Email == value) return; _Email = value; OnPropertyChanged(nameof(Email)); } }
        private string _Email;
        public bool IsValidEmail => !string.IsNullOrWhiteSpace(Email) && _EmailPattern.IsMatch(Email);

        public string EmailContent { get => _EmailContent; set { if (_EmailContent == value) return; _EmailContent = value; OnPropertyChanged(nameof(EmailContent)); } }
        private string _EmailContent;

        public string PictureFileName { get => _PictureFileName; set { if (_PictureFileName == value) return; _PictureFileName = value; OnPropertyChanged(nameof(PictureFileName)); } }
        private string _PictureFileName;

        public bool IsValid => IsValidEmail && !string.IsNullOrWhiteSpace(EmailContent) && File.Exists(PictureFileName);

        public void LoadEmailContent(string aFileName, Encoding aEncoding)
        {
            EmailContent = File.ReadAllText(aFileName, aEncoding);
        }

        private void OnPropertyChanged(string aPropertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(aPropertyName));
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
