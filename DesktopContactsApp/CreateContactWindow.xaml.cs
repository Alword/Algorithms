using System;
using System.Windows;
using System.Windows.Shapes;
using DesktopContactsApp.Classes;
using SQLite;

namespace DesktopContactsApp
{
    // ReSharper disable once RedundantExtendsListEntry
    public partial class CreateContactWindow : Window
    {
        public CreateContactWindow()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var contact = new Contact()
            {
                Name = NameTextBox.Text,
                Email = EmailTextBox.Text,
                Phone = PhoneNameTextBox.Text
            };
            var databaseName = "Contact.db";
            string databaseFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string path = System.IO.Path.Combine(databaseFolder, databaseName);

            SQLiteConnection connection = new SQLiteConnection(path);
            connection.CreateTable<Contact>();
            connection.Insert(contact);
            connection.Close();
            Close();
        }
    }
}
