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

namespace Kalkulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // varibles for numbers
        string stringA = null;

        // varible for operation name
        string operation = null;

        double doubleA = 0;

        // varible bool for first or second number
        bool number = false;

        // varible for one comma in number
        bool Comma = false;
        
        public MainWindow()
        {
            InitializeComponent();
            LabelForOperation.Content = stringA;
            TB.AppendText("0");
        }

        // function for check first or second number
        public bool FirstOrSecondNumber()
        {
            if (number == false)
                return false;
            else
                return true;
        }

        // function for check comma
        public bool CheckComma()
        {
            if (Comma == false)
                return false;
            else
                return true;
        }
        // Parse String To Double
        public double ParseStringToDouble(string textFromLabelForOperation)
        {
            double number;
            if (Double.TryParse(textFromLabelForOperation, out number))
                return number;
            else
                MessageBox.Show("Blad parsowania liczby");
            return Double.Parse(textFromLabelForOperation);
        }

        //to key
        public void key(object sender, KeyEventArgs e)
        {
            MessageBox.Show("key");
        }

        // function for numbers
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(TB.Text == "0" || number == true)
            {
                TB.Clear();
            }
            Button button = (Button)sender;
            TB.Text = TB.Text + button.Content;
            doubleA = ParseStringToDouble(button.Content.ToString());
        }

        // funktion for operation
        private void Button_Opieration(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            //TB.Text = TB.Text + button.Content;
            operation = button.Content.ToString();
            LabelForOperation.Content = doubleA + operation;
            number = true;
        }

        // button plus minus
        private void Button_Click_plus_minus(object sender, RoutedEventArgs e)
        {
            if (LabelForOperation.Content.ToString().Contains("-") == false)
            {
                // add minus
                LabelForOperation.Content = "-" + LabelForOperation.Content.ToString();
            }
            else
            {
                // remove minus
                LabelForOperation.Content = LabelForOperation.Content.ToString().Remove(0, 1);
            }
        }
        
        //Button_Click_comma
        private void Button_Click_comma(object sender, RoutedEventArgs e)
        {
            if (Comma == false)
            {
                LabelForOperation.Content = LabelForOperation.Content + ",";
                Comma = true;
            }
        }

        //button to clear enter
        private void Button_Click_CE(object sender, RoutedEventArgs e)
        {
            stringA = null;
            doubleA = 0;
            operation = null;
            number = true;
            Comma = false;
            LabelForOperation.Content = null;
        }

        //button to clear last number
        private void Button_Click_C(object sender, RoutedEventArgs e)
        {
            number = true;
            Comma = false;
            LabelForOperation.Content = null;
        }

        //Button_Click_division
        private void Button_Click_division(object sender, RoutedEventArgs e)
        {
            if (number == false)
            {
                CheckOperation();
                operation = "division";
            }
        }

        // check if the operation has been selected
        public void CheckOperation()
        {
            if (LabelForOperation.Content == null)
            {
                MessageBox.Show("operacja juz zostala wybrana");
            }
            else
            {
                doubleA = ParseStringToDouble(LabelForOperation.Content.ToString());
                number = true;
                Comma = false;
                LabelForOperation.Content = null;
            }
        }

        ////Button_Click_multipication
        //private void Button_Click_multipication(object sender, RoutedEventArgs e)
        //{
        //    CheckOperation();
        //    operation = "multipication";
        //}

        ////Button_Click_minus
        //private void Button_Click_minus(object sender, RoutedEventArgs e)
        //{
        //    CheckOperation();
        //    operation = "minus";
        //}

        ////Button_Click_plus
        //private void Button_Click_plus(object sender, RoutedEventArgs e)
        //{
        //    CheckOperation();
        //    operation = "plus";
        //}


        //Button_Click_score
        private void Button_Click_score(object sender, RoutedEventArgs e)
        {
            double score = 0;
            switch (operation)
            {
                case null:
                    MessageBox.Show("wybierz operacje i wprowadz druga liczbe");
                    break;
                case "/":
                    if (ParseStringToDouble(TB.Text) == 0)
                    {
                        MessageBox.Show("nie dzielimy przez 0");
                    }
                    else
                    {
                        score = doubleA / ParseStringToDouble(TB.Text);
                        TB.Text = score.ToString();
                    }
                    break;
                case "*":
                    double scoreMultiplication = doubleA * ParseStringToDouble(TB.Text);
                    TB.Text = scoreMultiplication.ToString();
                    break;
                case "-":
                    score = doubleA - ParseStringToDouble(TB.Text);
                    TB.Text = score.ToString();
                    break;
                case "+":
                    score = doubleA + ParseStringToDouble(TB.Text);
                    TB.Text = score.ToString();
                    break;
                default:
                    LabelForOperation.Content = "Blad dzialania programu";
                    break;
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
