using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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

        ////to key
        //public void key(object sender, KeyEventArgs e)
        //{
        //    MessageBox.Show("key");
        //}

        // function for numbers
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (TB.Text == "0")
            {
                TB.Clear();
            }
            Button button = (Button)sender;
            TB.Text = TB.Text + button.Content.ToString();
            //string a = button.Content.ToString();
            //doubleA = ParseStringToDouble(button.Content.ToString());
        }

        // funktion for operation
        private void Button_Opieration(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            //TB.Text = TB.Text + button.Content;

            doubleA = ParseStringToDouble(TB.Text);
            operation = button.Content.ToString();
            LabelForOperation.Content = doubleA + operation;
            TB.Clear();
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
            TB.Text = null;
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

        //handling keybord
        private void GridKey(object sender, KeyEventArgs e)
        {
            //clear textBox if is 0 or null
            if (TB.Text == "0" || number == true)
            {
                TB.Clear();
            }

            //insert number from keybord
            switch (e.Key)
            {
                case Key.NumPad7:
                    TB.Text = TB.Text + "7";
                    break;
                case Key.NumPad8:
                    TB.Text = TB.Text + "8";
                    break;
                case Key.NumPad9:
                    TB.Text = TB.Text + "9";
                    break;

                case Key.NumPad4:
                    TB.Text = TB.Text + "4";
                    break;
                case Key.NumPad5:
                    TB.Text = TB.Text + "5";
                    break;
                case Key.NumPad6:
                    TB.Text = TB.Text + "6";
                    break;

                case Key.NumPad1:
                    TB.Text = TB.Text + "1";
                    break;
                case Key.NumPad2:
                    TB.Text = TB.Text + "2";
                    break;
                case Key.NumPad3:
                    TB.Text = TB.Text + "3";
                    break;

                    //button for division
                case Key.Divide:
                    //MessageBox.Show("bedziemy dzielic");
                    //Button_Click_division(null, null);
                    Button sender2;
                    sender2 = new Button() { Content = "/" };
                    Button_Opieration(sender2, null);
                    break;

                //button for score
                case Key.Enter:
                    Button_Click_score(null, null);
                    break;
                // button for plus
                case Key.OemPlus:
                    sender2 = new Button() { Content = "+" };
                    Button_Opieration(sender2, null);
                    break;

                // button for minus
                case Key.OemMinus:
                    sender2 = new Button() { Content = "-" };
                    Button_Opieration(sender2, null);
                    break;

                // button for multiplication
                case Key.Multiply:
                    sender2 = new Button() { Content = "*" };
                    Button_Opieration(sender2, null);
                    break;

                default:
                    break;
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
