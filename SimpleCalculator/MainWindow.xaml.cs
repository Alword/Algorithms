using System;
using System.Windows;
using System.Windows.Controls;

namespace SimpleCalculator
{
    public partial class MainWindow : Window
    {
        private double lastNumber, result;
        private SelectedOperator selectedOperator;

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
            if (!double.TryParse(ResultLabel.Content.ToString(), out double tempNumber)) return;

            switch (selectedOperator)
            {
                case SelectedOperator.Multiplication:
                    result = SimpleMath.Multiplication(lastNumber, tempNumber);
                    break;
                case SelectedOperator.Subtraction:
                    result = SimpleMath.Subtraction(lastNumber, tempNumber);
                    break;
                case SelectedOperator.Addition:
                    result = SimpleMath.Addition(lastNumber, tempNumber);
                    break;
                case SelectedOperator.Division:
                    result = SimpleMath.Division(lastNumber, tempNumber);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            ResultLabel.Content = result;
        }

        private void PercentButton_Click(object sender, RoutedEventArgs e)
        {
            if (!double.TryParse(ResultLabel.Content.ToString(), out double tempNumber)) return;

            if (!lastNumber.Equals(0)) tempNumber = tempNumber / 100 * lastNumber;
            ResultLabel.Content = tempNumber;
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
            result = 0;
            lastNumber = 0;
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            if (!double.TryParse(ResultLabel.Content.ToString(), out lastNumber)) return;

            if (sender.Equals(MultiplyButton)) selectedOperator = SelectedOperator.Multiplication;
            if (sender.Equals(DivideButton)) selectedOperator = SelectedOperator.Division;
            if (sender.Equals(PlusButton)) selectedOperator = SelectedOperator.Addition;
            if (sender.Equals(MinusButton)) selectedOperator = SelectedOperator.Subtraction;

            ResultLabel.Content = "0";
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            string content = (sender as Button)?.Content.ToString();
            if (content == null) return;
            int selectedValue = int.Parse(content);
            ;

            if (ResultLabel.Content.ToString().Equals("0"))
                ResultLabel.Content = $"{selectedValue}";
            else
                ResultLabel.Content += $"{selectedValue}";
        }

        private void DotButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (!ResultLabel.Content.ToString().Contains(".")) ResultLabel.Content = $"{ResultLabel.Content}.";
        }
    }
}