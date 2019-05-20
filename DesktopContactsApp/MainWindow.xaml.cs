using System.Collections.Generic;
using System.Windows;
using DesktopContactsApp.Classes;
using SQLite;

namespace DesktopContactsApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ReadContacts();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var contactWindow = new CreateContactWindow();
            contactWindow.ShowDialog();
            ReadContacts();
        }

        public void ReadContacts()
        {
            using (var conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<Contact>();
                List<Contact> contacts = conn.Table<Contact>().ToList();
            }
        }
    }
}
