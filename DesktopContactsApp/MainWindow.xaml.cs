using System.Windows;

namespace DesktopContactsApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var contactWindow = new CreateContactWindow();
            contactWindow.ShowDialog();
        }
    }
}
