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
            NameTextBox.Text = contact.Name;
            EmailTextBox.Text = contact.Email;
            PhoneNameTextBox.Text = contact.Phone;
        }

        private void UpdateButton_OnClick(object sender, RoutedEventArgs e)
        {
            contact.Name = NameTextBox.Text;
            contact.Email = EmailTextBox.Text;
            contact.Phone = PhoneNameTextBox.Text;
            using (var connection = new SQLiteConnection(App.DatabasePath))
            {
                connection.CreateTable<Contact>();
                connection.Update(contact);
            }
            Close();
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
