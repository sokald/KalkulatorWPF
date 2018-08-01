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
        string stringA, stringB = null;

        // varible for operation name
        string operation = null;

        double doubleA, doubleB = 0;

        // varible bool for first or second number
        bool number = false;

        // varible for one comma in number
        bool Comma = false;

        public MainWindow()
        {
            InitializeComponent();
            Label.Content = stringA;
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

        public double ParseStringToDouble(string textFromLabel)
        {
            double number;
            if (Double.TryParse(textFromLabel, out number))
                return number;
            else
                MessageBox.Show("Blad parsowania liczby");
            return Double.Parse(textFromLabel);
        }

        //7
        private void Button_Click_7(object sender, RoutedEventArgs e)
        {

            Label.Content = Label.Content+"7";
        }

        //8
        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            Label.Content = Label.Content + "8";
        }

        //9
        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            Label.Content = Label.Content + "9";
        }

        //4
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Label.Content = Label.Content + "4";
        }

        //5
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Label.Content = Label.Content + "5";
        }

        //6
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Label.Content = Label.Content + "6";
        }

        //1
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Label.Content = Label.Content + "1";
        }

        //2
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Label.Content = Label.Content + "2";
        }

        //3
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Label.Content = Label.Content + "3";
        }

        // button plus minus
        private void Button_Click_plus_minus(object sender, RoutedEventArgs e)
        {
            if(Label.Content.ToString().Contains("-") == false)
            {
                // add minus
                Label.Content = "-" + Label.Content.ToString();
            }
            else
            {
                // remove minus
                Label.Content = Label.Content.ToString().Remove(0,1);
            }
        }

        //Button_Click_0
        private void Button_Click_0(object sender, RoutedEventArgs e)
        {
            Label.Content = Label.Content + "0";
        }

        //Button_Click_comma
        private void Button_Click_comma(object sender, RoutedEventArgs e)
        {
            Label.Content = Label.Content + ".";
        }

        //Button_Click_division
        private void Button_Click_division(object sender, RoutedEventArgs e)
        {
            if (number == false)
            {
                doubleA = ParseStringToDouble(Label.Content.ToString());
                number = true;
                operation = "division";
                Comma = false;
                Label.Content = null;
            }

        }

        //button to clear enter
        private void Button_Click_CE(object sender, RoutedEventArgs e)
        {
            stringA = stringB = null;
            doubleA = doubleB = 0;
            operation = null;
            number = true;
            Comma = false;
            Label.Content = null;
        }

        //button to clear last number
        private void Button_Click_C(object sender, RoutedEventArgs e)
        {
            number = true;
            Comma = false;
            Label.Content = null;
        }

        //Button_Click_multipication
        private void Button_Click_multipication(object sender, RoutedEventArgs e)
        {
            doubleA = ParseStringToDouble(Label.Content.ToString());
            operation = "multipication";
            number = true;
            Comma = false;
            Label.Content = null;
        }

        //Button_Click_minus
        private void Button_Click_minus(object sender, RoutedEventArgs e)
        {
            doubleA = ParseStringToDouble(Label.Content.ToString());
            operation = "minus";
            number = true;
            Comma = false;
            Label.Content = null;
        }

        //Button_Click_plus
        private void Button_Click_plus(object sender, RoutedEventArgs e)
        {
            doubleA = ParseStringToDouble(Label.Content.ToString());
            operation = "plus";
            number = true;
            Comma = false;
            Label.Content = null;
        }

        //Button_Click_score
        private void Button_Click_score(object sender, RoutedEventArgs e)
        {
            double score;
            switch (operation)
            {
                case null:
                    MessageBox.Show("wybierz operacje i wprowadz druga liczbe");
                    break;
                case "division":
                    score = doubleA / ParseStringToDouble(Label.Content.ToString());
                    Label.Content = "wynik dzielenia to: " + score.ToString();
                    break;
                case "multipication":
                    Label.Content = "wynik mnozenia to: " + doubleA * ParseStringToDouble(Label.Content.ToString());
                    break;
                case "minus":
                    score = doubleA - ParseStringToDouble(Label.Content.ToString());
                    Label.Content = "wynik odejmowania to: " + score.ToString();
                    break;
                case "plus":
                    score = doubleA + ParseStringToDouble(Label.Content.ToString());
                    Label.Content = "wynik dodoawania to: " + score.ToString();
                    break;
                default:
                    MessageBox.Show("blad dzialania programu");
                    break;
            }
        }
    }
}
