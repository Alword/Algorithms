using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using DesktopContactsApp.Classes;

namespace DesktopContactsApp.Controls
{
    public partial class ContactControl : UserControl
    {
        private Contact contact;

        public Contact Contact
        {
            get { return contact; }
            set
            {
                contact = value;
                nameTextBlock.Text = contact.Name;
                phoneTextBlock.Text = contact.Phone;
                emailTextBlock.Text = contact.Email;
            }
        }

        public ContactControl()
        {
            InitializeComponent();
        }
    }
}
