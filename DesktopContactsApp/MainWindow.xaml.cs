using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
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
            List<Contact> contacts = null;
            using (var conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<Contact>();
                contacts = conn.Table<Contact>().ToList();
            }
            ContactListView.ItemsSource = contacts;
        }
    }
}
