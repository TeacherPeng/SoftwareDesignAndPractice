using System.ComponentModel;
using System.Data.Linq;

namespace LinqToSqlLesson02
{
    class MainModel : INotifyPropertyChanged
    {
        public const string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=linqlesson01;Integrated Security=True;";
        public MainModel()
        {
            DataContext = new ContactDataContext(ConnectionString);
        }

        public void Submit()
        {
            DataContext.SubmitChanges();
        }
        public Table<Contact> Contacts
        {
            get { return DataContext.Contact; }
        }
        public ContactDataContext DataContext { get; }
        private void OnPropertyChanged(string aPropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(aPropertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
