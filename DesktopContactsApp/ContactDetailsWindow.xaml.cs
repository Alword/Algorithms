using System;
using System.Windows;
using DesktopContactsApp.Classes;
using SQLite;


namespace DesktopContactsApp
{

    public partial class ContactDetailsWindow : Window
    {
        private readonly Contact contact;
        public ContactDetailsWindow(Contact contact)
        {
            this.contact = contact;
            InitializeComponent();
        }

        private void UpdateButton_OnClick(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteButton_OnClick(object sender, RoutedEventArgs e)
        {
            using (var connection = new SQLiteConnection(App.DatabasePath))
            {
                connection.CreateTable<Contact>();
                connection.Delete(contact);
            }
            Close();
        }
    }
}
