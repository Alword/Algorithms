using System;
using System.Collections.Generic;
using System.Windows;

namespace SimpleCalculator
{
    public partial class MainWindow : Window
    {
        private double lastNumber, result;

        public MainWindow()
        {
            InitializeComponent();

            ResultLabel.Content = "12345";
            AcButton.Click += AcButton_Click;
            ChangeButton.Click += ChangeButton_Click;
            PercentButton.Click += PercentButton_Click;
            EqualsButton.Click += EqualsButton_Click;
        }

        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PercentButton_Click(object sender, RoutedEventArgs e)
        {
            if (!double.TryParse(ResultLabel.Content.ToString(), out lastNumber)) return;

            lastNumber /= 100;
            ResultLabel.Content = lastNumber;
        }

        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {
            if (!double.TryParse(ResultLabel.Content.ToString(), out lastNumber)) return;

            lastNumber *= -1;
            ResultLabel.Content = lastNumber;
        }

        private void AcButton_Click(object sender, RoutedEventArgs e)
        {
            ResultLabel.Content = "0";
        }

        private void SevenButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (ResultLabel.Content.Equals("0"))
            {
                ResultLabel.Content = "7";
            }
            else
            {
                ResultLabel.Content += "7";
            }
        }
    }
}
