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

namespace Wpf_Task2._2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public double number1 = 0;
        public double number2 = 0;
        public double result = 0;
        public bool number2Entered = false;
        public bool operatorClicked = false;
        public bool equalsClicked = false;
        public char op = ' ';
        public bool EnableTyping = true;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void number0_Click(object sender, RoutedEventArgs e)
        {
            if (EnableTyping)
            {
                var btn = sender as Button;


                if (equalsClicked && !operatorClicked)
                {
                    Screen.Text = btn.Content.ToString();
                    History.Text = String.Empty;
                    equalsClicked = false;
                }
                else if (Screen.Text == "0" || operatorClicked || Screen.Text == "Zero Division Error!")
                {
                    Screen.Text = btn.Content.ToString();
                }
                else
                {
                    Screen.Text += btn.Content.ToString();
                }

                if (operatorClicked)
                {
                    number2Entered = true;
                }
            }
        }

        private void buttonC_Click(object sender, RoutedEventArgs e)
        {
            Screen.Text = "0";
            History.Text = String.Empty;
        }

        private void Screen_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Screen.Text.Length == 12)
            {
                EnableTyping = !EnableTyping;
            }
            else
            {
                EnableTyping = true;
            }

            Screen.FontSize = 55;
            if (Screen.Text.Length > 10 && Screen.Text != "Zero Division Error!")
            {
                Screen.FontSize -= Screen.Text.Length * 0.4;
            }
        }

        private void History_TextChanged(object sender, TextChangedEventArgs e)
        {
            History.FontSize = 25;
            if (History.Text.Length > 17)
            {
                History.FontSize -= History.FontSize * 0.4;
            }
            else
            {
                History.FontSize = 25;
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            History.Text = String.Empty;
            if (Screen.Text != "0")
            {
                if (Screen.Text.Length == 1)
                {
                    Screen.Text = "0";
                }
                else
                {
                    Screen.Text = Screen.Text.Remove(Screen.Text.Length - 1);
                }
            }
        }

        private void DivideBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!number2Entered)
            {
                operatorClicked = true;
                var btn = sender as Button;
                op = btn.Content.ToString().ToCharArray().ElementAt(0);
                number1 = double.Parse(Screen.Text);
                History.Text = $"{number1} {op} ";
            }
        }

        private void Dot_Click(object sender, RoutedEventArgs e)
        {
            if (!Screen.Text.Contains("."))
            {
                History.Text = String.Empty;
                Screen.Text += ".";
                operatorClicked = true;
                equalsClicked = false;
            }
        }

        private void OneDivideNumber_Click(object sender, RoutedEventArgs e)
        {
            var number = double.Parse(Screen.Text);
            Screen.Text = (1 / number).ToString();
            History.Text = $"1 / {number} = {Screen.Text}";
        }

        private void EqualsBtn_Click(object sender, RoutedEventArgs e)
        {
            if (number2Entered)
            {
                number2 = double.Parse(Screen.Text);
                if (operatorClicked)
                {
                    if (op.ToString() == "+")
                    {
                        result = number1 + number2;
                    }
                    if (op.ToString() == "–")
                    {
                        result = number1 - number2;

                    }
                    if (op.ToString() == "×")
                    {
                        result = number1 * number2;
                    }
                    if (op.ToString() == "÷")
                    {
                        if (number2 == 0)
                        {
                            History.Text = String.Empty;
                            Screen.Text = "Zero Division Error!";
                            operatorClicked = false;
                            Screen.FontSize = 35;
                            return;
                        }
                        else
                        {
                            result = number1 / number2;
                        }
                    }

                    Screen.Text = result.ToString();
                    History.Text += $"{number2} = {result}";

                    equalsClicked = true;
                    operatorClicked = false;
                    number2Entered = false;
                }
            }
        }

        private void SignChange_Click(object sender, RoutedEventArgs e)
        {
            var number = double.Parse(Screen.Text);
            if (number > 0)
                number -= number * 2;
            else
                number += Math.Abs(number) * 2;
            Screen.Text = number.ToString();

            if (!operatorClicked)
                number1 = number;
            else
                number2 = number;
        }

        private void CE_Click(object sender, RoutedEventArgs e)
        {
            Screen.Text = String.Empty;
        }
    }
}
