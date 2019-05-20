using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Windows;
using System.Windows.Controls;
using DesktopContactsApp.Classes;
using SQLite;

namespace DesktopContactsApp
{
    public partial class MainWindow : Window
    {
        private List<Contact> contacts;

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
            contacts = new List<Contact>();
        }

        public void ReadContacts()
        {
            using (var conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<Contact>();
                contacts = conn.Table<Contact>().ToList();
            }
            ContactListView.ItemsSource = contacts;
        }

        private void TextBoxBase_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (!(sender is TextBox searchTextBox)) return;

            List<Contact> filterList = contacts.Where(c => c.Name.ToLower().Contains(searchTextBox.Text.ToLower())).ToList();

            ContactListView.ItemsSource = filterList;
        }
    }
}
