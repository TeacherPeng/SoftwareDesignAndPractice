using System;
using System.ComponentModel;

namespace WPF00
{
    class MyModel : INotifyPropertyChanged
    {
        public string Data
        {
            get => _Data; 
            set
            {
                if (value == _Data) return;
                _Data = value;
                OnPropertyChanged(nameof(Data));
            }
        }
        private string _Data = "My Data!";

        public void ClearData() => Data = "";

        private void OnPropertyChanged(string aPropertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(aPropertyName));
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
