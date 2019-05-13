using System.Windows;

namespace SimpleCalculator
{
    public class SimpleMath
    {
        public static double Addition(double a, double b)
        {
            return a + b;
        }

        public static double Subtraction(double a, double b)
        {
            return a - b;
        }

        public static double Multiplication(double a, double b)
        {
            return a * b;
        }

        public static double Division(double a, double b)
        {
            if (!b.Equals(0)) return a / b;
            MessageBox.Show("Division by zero", "Wrong operation", MessageBoxButton.OK, MessageBoxImage.Error);
            return 0;
        }
    }
}