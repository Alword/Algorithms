using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DesktopContactsApp
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const string DATABASE_NAME = "Contact.db";
        private static readonly string DatabaseFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public static readonly string DatabasePath = System.IO.Path.Combine(DatabaseFolder, DATABASE_NAME);

    }
}
