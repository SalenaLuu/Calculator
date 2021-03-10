using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CalculatorApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double lastNumber, result;
        SelectedOperator selectedOperator;

        public MainWindow()
        {
            InitializeComponent();
        }
        // ===== Resetting of all variables =====
        #region AC
        private void AcButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = "0";
            result = 0;
            lastNumber = 0;
        }
        #endregion
        // ===== Negate Number =====
        #region Negate
        private void NegateButton_Click(object sender, RoutedEventArgs e)
        {
            if(double.TryParse(resultLabel.Content.ToString(),out lastNumber))
            {
                lastNumber = lastNumber * -1;
                resultLabel.Content = lastNumber.ToString();
            }
        }
        #endregion
        // ===== Percent Methode =====
        #region Percent
        private void PercentButton_Click(object sender, RoutedEventArgs e)
        {
            double tempNum;
            if (double.TryParse(resultLabel.Content.ToString(), out tempNum))
            {
                tempNum = (tempNum / 100);
                if (lastNumber != 0)
                    tempNum *= lastNumber;
                resultLabel.Content = tempNum.ToString();
            }  
        }
        #endregion
        // ===== Decimal Methode =====
        #region Decimal
        private void DecimalButton_Click(object sender, RoutedEventArgs e)
        {
            if (resultLabel.Content.ToString().Contains(","))
            {
                //do nothing
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content},";
            }
        }
        #endregion
        // ===== Result Methode =====
        #region Result
        private void EqualButton_Click(object sender, RoutedEventArgs e)
        {
            double newNumber;
            if (double.TryParse(resultLabel.Content.ToString(), out newNumber))
            {
                switch (selectedOperator)
                {
                    case SelectedOperator.Addition:
                        result = SimpleMath.Add(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Division:
                        result = SimpleMath.Div(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Multiplication:
                        result = SimpleMath.Mul(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Substraction:
                        result = SimpleMath.Sub(lastNumber, newNumber);
                        break;
                }
                resultLabel.Content = result.ToString();
            }
        }
        #endregion
        // ===== Operator choosing Methode =====
        #region Operator
        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                resultLabel.Content = "0";
            }

            if (sender == multiplyButton)
                selectedOperator = SelectedOperator.Multiplication;
            if (sender == divitionButton)
                selectedOperator = SelectedOperator.Division;
            if (sender == addButton)
                selectedOperator = SelectedOperator.Addition;
            if (sender == subtractButton)
                selectedOperator = SelectedOperator.Substraction;
        }
        #endregion
        // ===== Number Buttons =====
        #region Numbers
        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            int selectedValue = 0;

            if (sender == zeroButton)
                selectedValue = 0;
            if (sender == oneButton)
                selectedValue = 1;
            if (sender == twoButton)
                selectedValue = 2;
            if (sender == threeButton)
                selectedValue = 3;
            if (sender == fourButton)
                selectedValue = 4;
            if (sender == fiveButton)
                selectedValue = 5;
            if (sender == sixButton)
                selectedValue = 6;
            if (sender == sevenButton)
                selectedValue = 7;
            if (sender == eightButton)
                selectedValue = 8;
            if (sender == nineButton)
                selectedValue = 9;

            if (resultLabel.Content.ToString() == "0")
            {
                resultLabel.Content = $"{selectedValue}";
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}{selectedValue}";
            }
        }
    }
    #endregion
    // ===== Enum  Operator =====
    #region Enum Operators
    public enum SelectedOperator
    {
        Addition,
        Substraction,
        Multiplication,
        Division
    }
    #endregion
    // ===== Simple Math Class =====
    #region Simple Math
    public class SimpleMath
    {
        public static double Add (double n1, double n2)
        {
            return n1 + n2;
        }
        public static double Sub(double n1, double n2)
        {
            return n1 - n2;
        }
        public static double Mul(double n1, double n2)
        {
            return n1 * n2;
        }
        public static double Div(double n1, double n2)
        {
            if(n2 == 0)
            {
                MessageBox.Show("Division by 0 is not supported", "Wrong operation", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }
            return n1 / n2;
        }
    }
    #endregion
}
