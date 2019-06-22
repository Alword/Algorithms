using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using DesktopContactsApp.Classes;

namespace DesktopContactsApp.Controls
{
    public partial class ContactControl : UserControl
    {
        public Contact Contact
        {
            get => (Contact)GetValue(ContactProperty);
            set => SetValue(ContactProperty, value);
        }

        public static readonly DependencyProperty ContactProperty =
            DependencyProperty.Register(nameof(Contact), typeof(Contact), typeof(ContactControl), new PropertyMetadata(null, SetText));

        private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!(d is ContactControl contactControl)) throw new NotImplementedException();

            contactControl.nameTextBlock.Text = (e.NewValue as Contact)?.Name;
            contactControl.emailTextBlock.Text = (e.NewValue as Contact)?.Email;
            contactControl.phoneTextBlock.Text = (e.NewValue as Contact)?.Phone;
        }

        public ContactControl()
        {
            InitializeComponent();
        }
    }
}